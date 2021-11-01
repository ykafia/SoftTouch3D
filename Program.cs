using System;
using Silk.NET.DXGI;
using Silk.NET.Direct3D11;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
IDXGIFactory factory = new();
unsafe 
{
    IDXGIFactory* f = &factory;
    DXGIOverloads.CreateDXGIFactory(DXGI.GetApi(),new Span<Guid>(new Guid[]{IDXGIFactory.Guid}),(void**)&f);
    factory = *f;
}
unsafe 
{
    IDXGIAdapter a = new();
    IDXGIAdapter* p = &a;
    int r = factory.EnumAdapters(0,&p);
    Console.WriteLine("Result value : " + r.ToString("X"));
}

