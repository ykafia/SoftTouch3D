using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYaml.Serialization;

namespace SoftTouch.Core.Serialization;

public interface IYamlAssetFormatter
{
}

public interface IYamlSFTFormatter<T> : IYamlFormatter<T>, IYamlAssetFormatter
{

}

public interface IYamlNumericsFormatter<T> : IYamlSFTFormatter<T>, INumericsFormatter
{
}