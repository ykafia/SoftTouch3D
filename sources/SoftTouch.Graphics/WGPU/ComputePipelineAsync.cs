//using Silk.NET.WebGPU;

//namespace SoftTouch.Graphics;

//public sealed class ComputePipelineAsync : GraphicsBaseObject
//{
//    unsafe Silk.NET.WebGPU.ComputePipeline* computePipeline;


//    internal unsafe ComputePipelineAsync(Silk.NET.WebGPU.ComputePipeline* ptr)
//    {
//        computePipeline = ptr;
//    }

//    public override void Dispose()
//    {
//        unsafe
//        {
//            Graphics.Disposal.Dispose(computePipeline);
//        }
//    }
//}