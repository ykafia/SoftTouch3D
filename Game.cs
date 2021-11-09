using System;
using Silk.NET.DXGI;
using Silk.NET.Direct3D11;
using Silk.NET.Core.Native;
using Silk.NET.Windowing;
using Silk.NET.Maths;
using Silk.NET.Input;

namespace DXDebug
{
    public class Game
    {
        private readonly IWindow window;
        private ComPtr<ID3D11Device> device;
        private ComPtr<IDXGISwapChain> swap;
        private ComPtr<ID3D11DeviceContext> context;

        private ComPtr<IDXGIAdapter> adapter;

        public uint Width {get;set;} = 800;
        public uint Height {get;set;} = 600;

        public Game()
        {
            var options = WindowOptions.Default;
            options.Size = new Vector2D<int>((int)Width, (int)Height);
            options.Title = "D3D11 with Silk.NET";

            window = Window.Create(options);

            //Assign events.
            window.Load += OnLoad;
            window.Update += OnUpdate;
            window.Render += OnRender;

            unsafe 
            {
                var sd = new SwapChainDesc
                {
                    BufferCount = 1,
                    BufferDesc =
                    {
                        Format = Format.FormatR8G8B8A8Unorm
                    },
                    BufferUsage = DXGI.UsageRenderTargetOutput,
                    OutputWindow = window.Handle,
                    SampleDesc ={
                        Count = 4
                    },
                    Windowed = 1
                };

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
                        ref swap.Handle,
                        ref device.Handle,
                        null,
                        ref context.Handle
                    )
                );
            }
        }

        public void Run() => window.Run();

        private void OnLoad()
        {
            //Set-up input context.
            IInputContext input = window.CreateInput();
            for (int i = 0; i < input.Keyboards.Count; i++)
            {
                input.Keyboards[i].KeyDown += KeyDown;
            }
        }

        private static void OnRender(double obj)
        {
            //Here all rendering should be done.
        }

        private static void OnUpdate(double obj)
        {
            //Here all updates to the program should be done.
        }

        private void KeyDown(IKeyboard arg1, Key arg2, int arg3)
        {
            //Check to close the window on escape.
            if (arg2 == Key.Escape)
            {
                Release();
                window.Close();
            }
        }
        private void Release()
        {
            device.Get().Release();
            swap.Get().Release();
            context.Get().Release();
            
        }
    }
}