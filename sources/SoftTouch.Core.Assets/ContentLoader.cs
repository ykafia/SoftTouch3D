using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;

namespace SoftTouch.Core.Assets;

public abstract class ContentSerializer
{
    public ContentManager Content => ContentManager.GetOrCreate();
}

public abstract class ContentSerializer<T> : ContentSerializer
{
    public abstract T Load(UPath path);
    public abstract void Save(T data);
}
