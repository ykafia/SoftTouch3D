using System;
using Silk.NET.Direct3D11;
using Silk.NET.DXGI;
using Silk.NET.Core;
using Silk.NET.Maths;
using Silk.NET.Core.Native;
using System.Drawing;
using System.Linq;

namespace SoftTouch
{
    public class D3DGraphics
    {
        ComPtr<ID3D11Device> device;
        ComPtr<IDXGISwapChain> swap;
        ComPtr<ID3D11DeviceContext> context;
        ComPtr<ID3D11RenderTargetView> target;

        ComPtr<ID3D11VertexShader> vShader;

        ComPtr<IDXGIAdapter> adapter;
        public D3DGraphics(IntPtr hwnd)
        {
            var sd = new SwapChainDesc
            {
                BufferCount = 2,
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

        public void DrawTriangle()
        {
            unsafe
            {
                ID3D11Buffer*[]? buffs = null;
                BufferDesc triDesc = new BufferDesc{
                    Usage = Usage.UsageDefault,
                    BindFlags = (uint)BindFlag.BindVertexBuffer,
                    ByteWidth = 8
                };
                
                var tri = new Vector2D<float>[3]{ 
                    new(0,0.5f), 
                    new(0.5f,0.5f),
                    new(0.5f,0)
                };
                SubresourceData d;
                fixed(Vector2D<float>* t = tri)
                    d = new SubresourceData{PSysMem = t};
                
                fixed(ID3D11Buffer** b = buffs)
                {
                    SilkMarshal.ThrowHResult(device.Get().CreateBuffer(&triDesc, &d,b));
                    context.Get().IASetVertexBuffers(0, 1, b, null, null);
                }
                context.Get().Draw(3,0);
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
        public void ClearColor(float r, float g, float b)
        {
            unsafe 
            {
                float[] color = new float[3]{r,g,b};
                fixed(float* c = color)
                    context.Get().ClearRenderTargetView(target,c);
            }
        }
        public void EndFrame()
        {
            unsafe {SilkMarshal.ThrowHResult(swap.Handle->Present(1, 0));}
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