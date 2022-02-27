using Silk.NET.Core;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using Silk.NET.Core.Native;
using System;

namespace DXDebug
{
    public class OGLGame : IGame
    {
        readonly IWindow window;

        public uint Width { get; set; } = 800;
        public uint Height { get; set; } = 600;

        private static GL Gl;

        private static uint Vbo;
        private static uint Ebo;
        private static uint Vao;
        private static uint Shader;

        //Vertex data, uploaded to the VBO.
        private static readonly float[] Vertices =
        {
            //X    Y      Z
             0.5f,  0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
            -0.5f, -0.5f, 0.0f,
            -0.5f,  0.5f, 0.5f
        };

        //Index data, uploaded to the EBO.
        private static readonly uint[] Indices =
        {
            0, 1, 3,
            1, 2, 3
        };



        public string vShader = System.IO.File.ReadAllText("./Shaders/GLSL/quad.vert");
        public string fShader = System.IO.File.ReadAllText("./Shaders/GLSL/quad.frag");

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

                //Creating a vertex array.
                Vao = Gl.GenVertexArray();
                Gl.BindVertexArray(Vao);

                //Initializing a vertex buffer that holds the vertex data.
                Vbo = Gl.GenBuffer(); //Creating the buffer.
                Gl.BindBuffer(BufferTargetARB.ArrayBuffer, Vbo); //Binding the buffer.
                fixed (void* v = &Vertices[0])
                {
                    Gl.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(Vertices.Length * sizeof(uint)), v, BufferUsageARB.StaticDraw); //Setting buffer data.
                }

                //Initializing a element buffer that holds the index data.
                Ebo = Gl.GenBuffer(); //Creating the buffer.
                Gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, Ebo); //Binding the buffer.
                fixed (void* i = &Indices[0])
                {
                    Gl.BufferData(BufferTargetARB.ElementArrayBuffer, (nuint)(Indices.Length * sizeof(uint)), i, BufferUsageARB.StaticDraw); //Setting buffer data.
                }

                //Creating a vertex shader.
                uint vertexShader = Gl.CreateShader(ShaderType.VertexShader);
                Gl.ShaderSource(vertexShader, vShader);
                Gl.CompileShader(vertexShader);

                //Checking the shader for compilation errors.
                string infoLog = Gl.GetShaderInfoLog(vertexShader);
                if (!string.IsNullOrWhiteSpace(infoLog))
                {
                    Console.WriteLine($"Error compiling vertex shader {infoLog}");
                }

                //Creating a fragment shader.
                uint fragmentShader = Gl.CreateShader(ShaderType.FragmentShader);
                Gl.ShaderSource(fragmentShader, fShader);
                Gl.CompileShader(fragmentShader);

                //Checking the shader for compilation errors.
                infoLog = Gl.GetShaderInfoLog(fragmentShader);
                if (!string.IsNullOrWhiteSpace(infoLog))
                {
                    Console.WriteLine($"Error compiling fragment shader {infoLog}");
                }

                //Combining the shaders under one shader program.
                Shader = Gl.CreateProgram();
                Gl.AttachShader(Shader, vertexShader);
                Gl.AttachShader(Shader, fragmentShader);
                Gl.LinkProgram(Shader);

                //Checking the linking for errors.
                Gl.GetProgram(Shader, GLEnum.LinkStatus, out var status);
                if (status == 0)
                {
                    Console.WriteLine($"Error linking shader {Gl.GetProgramInfoLog(Shader)}");
                }

                //Delete the no longer useful individual shaders;
                Gl.DetachShader(Shader, vertexShader);
                Gl.DetachShader(Shader, fragmentShader);
                Gl.DeleteShader(vertexShader);
                Gl.DeleteShader(fragmentShader);

                //Tell opengl how to give the data to the shaders.
                Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), null);
                Gl.EnableVertexAttribArray(0);
            }

        }

        private void OnRender(double obj)
        {
            unsafe
            {
                //Clear the color channel.
                Gl.Clear((uint)ClearBufferMask.ColorBufferBit);

                //Bind the geometry and shader.
                Gl.BindVertexArray(Vao);
                Gl.UseProgram(Shader);

                //Draw the geometry.
                Gl.DrawElements(PrimitiveType.Triangles, (uint)Indices.Length, DrawElementsType.UnsignedInt, null);
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