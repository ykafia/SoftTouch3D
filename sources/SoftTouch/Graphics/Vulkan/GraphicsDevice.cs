using System;
using System.Linq;
using System.Runtime.InteropServices;
using Silk.NET.Windowing;
using Silk.NET.Core;
using Silk.NET.Core.Native;

using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.EXT;
using Silk.NET.Vulkan.Extensions.KHR;
using System.Runtime.CompilerServices;

namespace SoftTouch.Graphics.Vulkan
{
    public class GraphicsDevice
    {
        Vk? api;
        Instance nativeInstance;
        Instance NativeInstance { get => nativeInstance; set { nativeInstance = value; } }

        PhysicalDevice physicalDevice;
        PhysicalDevice NativePhysicalDevice { get => physicalDevice; set { physicalDevice = value; } }

        Device nativeDevice;
        Device NativeDevice { get => nativeDevice; set { nativeDevice = value; } }

        GraphicsQueue queue;

        KhrSurface vkSurface;
        SurfaceKHR surface;

        GraphicsQueue Queue { get => queue; set { queue = value; } }



        private string[][] _validationLayerNamesPriorityList =
        {
            new [] { "VK_LAYER_KHRONOS_validation" },
            new [] { "VK_LAYER_LUNARG_standard_validation" },
            new []
            {
                "VK_LAYER_GOOGLE_threading",
                "VK_LAYER_LUNARG_parameter_validation",
                "VK_LAYER_LUNARG_object_tracker",
                "VK_LAYER_LUNARG_core_validation",
                "VK_LAYER_GOOGLE_unique_objects",
            }
        };
        private ExtDebugUtils? debugUtils;

        private bool EnableValidationLayers = false;
        string[]? validationLayers = { };

        private string[] instanceExtensions = { ExtDebugUtils.ExtensionName };
        private string[] deviceExtensions = { KhrSwapchain.ExtensionName };

        public unsafe void CreateInstance(IWindow window)
        {
            api = Vk.GetApi();
            if (EnableValidationLayers)
            {
                validationLayers = GetOptimalValidationLayers();
                if (validationLayers is null)
                {
                    throw new NotSupportedException("Validation layers requested, but not available!");
                }
            }
            var appInfo = new ApplicationInfo
            {
                SType = StructureType.ApplicationInfo,
                PApplicationName = (byte*)Marshal.StringToHGlobalAnsi("Hello Triangle"),
                ApplicationVersion = new Version32(1, 0, 0),
                PEngineName = (byte*)Marshal.StringToHGlobalAnsi("SoftTouch"),
                EngineVersion = new Version32(1, 0, 0),
                ApiVersion = Vk.Version11
            };
            var createInfo = new InstanceCreateInfo
            {
                SType = StructureType.InstanceCreateInfo,
                PApplicationInfo = &appInfo
            };
            var extensions = window.VkSurface!.GetRequiredExtensions(out var extCount);
            var newExtensions = stackalloc byte*[(int)(extCount + instanceExtensions.Length)];
            for (var i = 0; i < extCount; i++)
            {
                newExtensions[i] = extensions[i];
            }

            for (var i = 0; i < instanceExtensions.Length; i++)
            {
                newExtensions[extCount + i] = (byte*)SilkMarshal.StringToPtr(instanceExtensions[i]);
            }

            extCount += (uint)instanceExtensions.Length;
            createInfo.EnabledExtensionCount = extCount;
            createInfo.PpEnabledExtensionNames = newExtensions;

            if (EnableValidationLayers)
            {
                createInfo.EnabledLayerCount = (uint)validationLayers.Length;
                createInfo.PpEnabledLayerNames = (byte**)SilkMarshal.StringArrayToPtr(validationLayers);
            }
            else
            {
                createInfo.EnabledLayerCount = 0;
                createInfo.PNext = null;
            }
            fixed (Instance* instance = &nativeInstance)
            {
                if (api.CreateInstance(&createInfo, null, instance) != Result.Success)
                {
                    throw new Exception("Failed to create instance!");
                }
            }

            api.CurrentInstance = nativeInstance;

            if (!api.TryGetInstanceExtension(nativeInstance, out vkSurface))
            {
                throw new NotSupportedException("KHR_surface extension not found.");
            }
            surface = window.VkSurface!.Create<AllocationCallbacks>(nativeInstance.ToHandle(), null).ToSurface();

            Marshal.FreeHGlobal((nint)appInfo.PApplicationName);
            Marshal.FreeHGlobal((nint)appInfo.PEngineName);

            if (EnableValidationLayers)
            {
                SilkMarshal.Free((nint)createInfo.PpEnabledLayerNames);
            }

        }


        public struct QueueFamilyIndices
        {
            public uint? GraphicsFamily { get; set; }
            public uint? PresentFamily { get; set; }

            public bool IsComplete()
            {
                return this.GraphicsFamily.HasValue && PresentFamily.HasValue;
            }
        }
        

        public unsafe void GetPhysicalDevice()
        {
            var devices = api.GetPhysicalDevices(nativeInstance);
            
            if (devices.Count() <= 0) throw new Exception("No graphics card");
            physicalDevice = 
                devices.First( x => {
                    var indices = FindQueueFamilies(x);
                    return IsDeviceSuitable(x);
                });
        }
        public unsafe QueueFamilyIndices FindQueueFamilies(PhysicalDevice device)
        {
            uint count;
            api.GetPhysicalDeviceQueueFamilyProperties(device, &count, null);

            
            var queueFamilies = 
                sizeof(QueueFamilyProperties) * count > 512?
                    new QueueFamilyProperties[count] :
                    stackalloc QueueFamilyProperties[(int)count];

            api.GetPhysicalDeviceQueueFamilyProperties(device, &count, queueFamilies);
            if(count<=0) throw new("No family queue");
            uint i = 0;
            QueueFamilyIndices indices = new();
            foreach (var p in queueFamilies)
            {
                if ((p.QueueFlags & QueueFlags.QueueGraphicsBit) != 0)
                {
                    indices.GraphicsFamily = i;
                }

                vkSurface.GetPhysicalDeviceSurfaceSupport(device, i, surface, out var presentSupport);

                if (presentSupport == Vk.True)
                {
                    indices.PresentFamily = i;
                }
                if(indices.IsComplete()) break;
                i++;
            }
            return indices;
        }
        unsafe bool IsDeviceSuitable(PhysicalDevice device)
        {
            QueueFamilyIndices indices = FindQueueFamilies(device);
            return indices.IsComplete();
            // PhysicalDeviceProperties properties;
            // api.GetPhysicalDeviceProperties(device, &properties);
            // return
            //     properties.DeviceType == PhysicalDeviceType.DiscreteGpu ||
            //     properties.DeviceType == PhysicalDeviceType.IntegratedGpu;

        }
        private unsafe string[]? GetOptimalValidationLayers()
        {
            var layerCount = 0u;
            api?.EnumerateInstanceLayerProperties(&layerCount, null);

            var availableLayers = new LayerProperties[layerCount];
            fixed (LayerProperties* availableLayersPtr = availableLayers)
            {
                api?.EnumerateInstanceLayerProperties(&layerCount, availableLayersPtr);
            }

            var availableLayerNames = availableLayers.Select(availableLayer => Marshal.PtrToStringAnsi((nint)availableLayer.LayerName)).ToArray();
            foreach (var validationLayerNameSet in _validationLayerNamesPriorityList)
            {
                if (validationLayerNameSet.All(validationLayerName => availableLayerNames.Contains(validationLayerName)))
                {
                    return validationLayerNameSet;
                }
            }

            return null;
        }

        public unsafe void CreateLogicalDevice()
        {
            var familyIndices = FindQueueFamilies(physicalDevice);
            float priority = 1;
            DeviceQueueCreateInfo queueCreateInfo = new DeviceQueueCreateInfo
            {
                SType = StructureType.DeviceQueueCreateInfo,
                QueueFamilyIndex = familyIndices.GraphicsFamily.Value,
                QueueCount = 1,
                PQueuePriorities = &priority
            };

            PhysicalDeviceFeatures deviceFeatures = new();

            DeviceCreateInfo createDevice = new DeviceCreateInfo
            {
                SType = StructureType.DeviceCreateInfo,
                PQueueCreateInfos = &queueCreateInfo,
                PEnabledFeatures = &deviceFeatures,
                EnabledExtensionCount = 0,
                EnabledLayerCount = 0
            };
            fixed(Device* device = &nativeDevice)
            {
                if(api.CreateDevice(physicalDevice, &createDevice, null, device) != Result.Success)
                    throw new("Could not create Logical Device");
            }

        }

    }
}