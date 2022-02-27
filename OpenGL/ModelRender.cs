using System;
using System.Numerics;
using Silk.NET.OpenGL;

namespace DXDebug
{
    public class ModelRender
    {
        readonly GL Gl;
        private uint Vbo;
        private uint Ebo;
        private uint Vao;
        private uint Shader;

        private readonly Model obj;

        private string vShader = System.IO.File.ReadAllText("./Shaders/GLSL/quad.vert");
        private string fShader = System.IO.File.ReadAllText("./Shaders/GLSL/quad.frag");

        public ModelRender(GL glCtx, Model model)
        {
            Gl = glCtx;
            obj = model;
        }

        public void Load()
        {
            unsafe
            {
                Vao = Gl.GenVertexArray();
                Gl.BindVertexArray(Vao);

                //Initializing a vertex buffer that holds the vertex data.
                Vbo = Gl.GenBuffer(); //Creating the buffer.
                Gl.BindBuffer(BufferTargetARB.ArrayBuffer, Vbo); //Binding the buffer.
                fixed (void* v = &obj.VertexBuffer[0])
                {
                    Gl.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(obj.VertexBuffer.Length * sizeof(uint)), v, BufferUsageARB.StaticDraw); //Setting buffer data.
                }

                //Initializing a element buffer that holds the index data.
                Ebo = Gl.GenBuffer(); //Creating the buffer.
                Gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, Ebo); //Binding the buffer.
                fixed (void* i = &obj.Indices[0])
                {
                    Gl.BufferData(BufferTargetARB.ElementArrayBuffer, (nuint)(obj.Indices.Length * sizeof(uint)), i, BufferUsageARB.StaticDraw); //Setting buffer data.
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

        public void Draw(double time)
        {
            Gl.BindVertexArray(Vao);
            Gl.UseProgram(Shader);
            int myUniformLocation = Gl.GetUniformLocation(Shader, "time");
            Gl.Uniform1(myUniformLocation,(float)time);
            

            //Draw the geometry.
            unsafe
            {
                Gl.DrawElements(PrimitiveType.Triangles, (uint)obj.Indices.Length, DrawElementsType.UnsignedInt, null);
            }
        }
    }
}