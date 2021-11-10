using System;
using Silk.NET.Direct3D11;
using Silk.NET.DXGI;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using System.Drawing;

namespace DXDebug
{
    public class Graphics
    {
        ComPtr<ID3D11Device> device;
        ComPtr<IDXGISwapChain> swap;
        ComPtr<ID3D11DeviceContext> context;
        ComPtr<ID3D11RenderTargetView> target;

        ComPtr<IDXGIAdapter> adapter;
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
                        ref swap.Handle,
                        ref device.Handle,
                        null,
                        ref context.Handle
                    )
                );
                ID3D11Resource* pRes = null;
                SilkMarshal.ThrowHResult(swap.Get().GetBuffer(0, SilkMarshal.GuidPtrOf<ID3D11Resource>(),(void**)&pRes));
                SilkMarshal.ThrowHResult(device.Get().CreateRenderTargetView(pRes,null,ref target.Handle));
                pRes->Release();
            }
        }
        
        
        public void ClearColor(Color col)
        {
            unsafe 
            {
                float[] color = new float[4]{col.R,col.G,col.B,1};
                fixed(float* c = color)
                    context.Get().ClearRenderTargetView(target,c);
            }
        }
        public void EndFrame()
        {
            SilkMarshal.ThrowHResult(swap.Get().Present(1, 0));
        }
        
        
        public void Release()
        {
            SilkMarshal.ThrowHResult((int)device.Release());
            SilkMarshal.ThrowHResult((int)context.Release());
            SilkMarshal.ThrowHResult((int)swap.Release());
            SilkMarshal.ThrowHResult((int)target.Release());
        }

    }
}