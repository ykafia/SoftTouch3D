using System;
using System.Numerics;
namespace DXDebug
{
    public class Model
    {
        public static Model Quad = new Model{
            VertexBuffer = new float[]{
            //X    Y      Z
                0.5f,  0.5f, 0.0f,
                0.5f, -0.5f, 0.0f,
                -0.5f, -0.5f, 0.0f,
                -0.5f,  0.5f, 0.5f
            },
            Indices = new uint[]{
                0, 1, 3,
                1, 2, 3
            }
        };


        public float[]? VertexBuffer;
        public uint[]? Indices;
    }
}