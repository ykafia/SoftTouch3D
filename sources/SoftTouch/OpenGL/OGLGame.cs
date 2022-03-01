using Silk.NET.Core;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using Silk.NET.Core.Native;
using System;
using System.Collections.Generic;

namespace SoftTouch
{
    public class OGLGame : IGame
    {
        readonly IWindow window;

        public uint Width { get; set; } = 800;
        public uint Height { get; set; } = 600;

        private static GL Gl;

        private List<ModelRender> Renderers = new();


        public OGLGame()
        {
            var options = WindowOptions.Default;
            options.Size = new Vector2D<int>((int)Width, (int)Height);
            options.Title = "OGL with Silk.NET";

            window = Window.Create(options);

            //Assign events.
            window.Load += OnLoad;
            window.Update += OnUpdate;
            window.Render += OnRender;


        }
        public void Run() => window.Run();

        private void OnLoad()
        {
            unsafe
            {


                Gl = GL.GetApi(window);

                IInputContext input = window.CreateInput();
                for (int i = 0; i < input.Keyboards.Count; i++)
                {
                    input.Keyboards[i].KeyDown += KeyDown;
                }

                //Getting the opengl api for drawing to the screen.
                Gl = GL.GetApi(window);
                Renderers.Add(new ModelRender(Gl,Model.Quad));
                Renderers.ForEach(x => x.Load());
            }

        }

        private void OnRender(double time)
        {
            unsafe
            {
                //Clear the color channel.
                Gl.Clear((uint)ClearBufferMask.ColorBufferBit);

                Renderers.ForEach(x => x.Draw(window.Time));
            }
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
            var a = window.API;
        }
    }
}