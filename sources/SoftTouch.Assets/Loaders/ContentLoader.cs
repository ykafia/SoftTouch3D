using SoftTouch.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;
using SoftTouch.Assets;
using SoftTouch.Graphics;

namespace SoftTouch.Assets;

public partial class ContentManager
{
    
    public abstract class ContentLoader
    {
        public abstract Type AssetType { get; }
        internal ContentLoader() { }
        public abstract void Load(UPath path);
        public abstract void Unload(UPath path);
    }
    public abstract class ContentLoader<T> : ContentLoader
    {
        //public ContentLoader()
        //{
        //    if (!GetInstance().Loaders.TryAdd(typeof(T), this))
        //        throw new Exception($"Type {typeof(T).Name} already has a loader");
        //}

        public override Type AssetType => typeof(T);
        protected ContentManager Content => GetInstance();
        protected TrivaxyGraphicsState Gfx;
        //void Unload(T asset);
    }
}
