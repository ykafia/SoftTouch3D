using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MemoryPack;
using Silk.NET.Core.Native;
using SoftTouch.Assets.Serialization.JSON;
using SoftTouch.Graphics;
using Utf8Json;
using VYaml.Annotations;
using Zio;

namespace SoftTouch.Assets;

//[YamlObject]
//[YamlObjectUnion("!model",typeof(ModelAsset))]
//[YamlObjectUnion("!image", typeof(ImageAsset))]
//[YamlObjectUnion("!material", typeof(MaterialAsset))]
//[YamlObjectUnion("!shader", typeof(ShaderAsset))]
public partial interface IAssetItem
{
    public abstract string Extension { get; set; }

    public Guid ID { get; set; }

    //[YamlIgnore]
    //private Guid GuidValue = Guid.NewGuid();

    //[YamlIgnore]
    //public string FormattedGuid => 
    //    Convert.ToBase64String(GuidValue.ToByteArray())
    //    .Replace("/", "_")
    //    .Replace("+", "-")
    //    .Replace("=", "");

    public string AssetPath { get; set; }

    public string Path { get; set; }
    public string? Name { get; }
    
}