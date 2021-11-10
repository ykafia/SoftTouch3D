using System;
using Silk.NET.Direct3D11;
using Silk.NET.DXGI;
using Silk.NET.Core;
using Silk.NET.Core.Native;
namespace DXDebug
{
    public class Graphics
    {
        ComPtr<ID3D11Device> Device;
        ComPtr<IDXGISwapChain> Swap;
        ComPtr<ID3D11DeviceContext> Context;

        ComPtr<IDXGIAdapter> Adapter;
        public Graphics(IntPtr hwnd)
        {
            var sd = new SwapChainDesc
            {
                BufferCount = 1,
                BufferDesc =
                    {
                        Format = Format.FormatR8G8B8A8Unorm
                    },
                BufferUsage = DXGI.UsageRenderTargetOutput,
                OutputWindow = hwnd,
                SampleDesc ={
                        Count = 4
                    },
                Windowed = 1
            };
            unsafe
            {
                SilkMarshal.ThrowHResult(
                    D3D11.GetApi()
                    .CreateDeviceAndSwapChain(
                        null,
                        D3DDriverType.D3DDriverTypeHardware,
                        0,
                        0,
                        null,
                        0,
                        D3D11.SdkVersion,
                        &sd,
                        ref Swap.Handle,
                        ref Device.Handle,
                        null,
                        ref Context.Handle
                    )
                );
            }
        }
        
        
        
        
        
        
        public void Release()
        {
            SilkMarshal.ThrowHResult((int)Device.Release());
            SilkMarshal.ThrowHResult((int)Context.Release());
            SilkMarshal.ThrowHResult((int)Swap.Release());
        }

    }
}