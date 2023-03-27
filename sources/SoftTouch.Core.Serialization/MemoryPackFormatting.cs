using MemoryPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Core.Serialization;

public abstract class NumericsBinaryFormatter<T> : MemoryPackFormatter<T>, IBinaryFormatter, INumericsFormatter
{
}

public abstract class BinaryFormatter<T> : MemoryPackFormatter<T>, IBinaryFormatter
{
}