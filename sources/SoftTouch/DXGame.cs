using System;
using Silk.NET.DXGI;
using Silk.NET.Direct3D11;
using Silk.NET.Core.Native;
using Silk.NET.Windowing;
using Silk.NET.Maths;
using Silk.NET.Input;
using System.Drawing;

namespace SoftTouch
{
    public class DXGame : IGame
    {
        private readonly IWindow window;
        
        private Graphics? graphics;

        public uint Width {get;set;} = 800;
        public uint Height {get;set;} = 600;

        public DXGame()
        {
            var options = WindowOptions.Default;
            options.Size = new Vector2D<int>((int)Width, (int)Height);
            options.Title = "D3D11 with Silk.NET";
            options.API = GraphicsAPI.None;

            window = Window.Create(options);

            //Assign events.
            window.Load += OnLoad;
            window.Update += OnUpdate;
            window.Render += OnRender;

            
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

            graphics = new Graphics(window.Native.Win32.Value.Hwnd);
        }

        private void OnRender(double obj)
        {
            //Here all rendering should be done.
            // graphics.ClearColor(0,0,1);
            graphics.DrawTriangle();
            graphics.EndFrame();
        }

        private void OnUpdate(double obj)
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
            graphics.Release();
        }
    }
}