using Silk.NET.Core;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using Silk.NET.Core.Native;

namespace DXDebug
{
    public class OGLGame : IGame
    {

        IWindow window;

        public uint Width { get; set; } = 800;
        public uint Height { get; set; } = 600;

        public GL Gl;
        

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
            Gl = GL.GetApi(window);

            //Set-up input context.
            IInputContext input = window.CreateInput();
            for (int i = 0; i < input.Keyboards.Count; i++)
            {
                input.Keyboards[i].KeyDown += KeyDown;
            }


        }

        private void OnRender(double obj)
        {
            //Here all rendering should be done.
            Gl.Clear(ClearBufferMask.ColorBufferBit);
            Gl.ClearColor(System.Drawing.Color.AntiqueWhite);
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

        }
    }
}