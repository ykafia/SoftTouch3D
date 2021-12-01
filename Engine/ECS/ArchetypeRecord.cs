using System.Collections.Generic;

namespace WonkECS
{
    public struct ArchetypeRecord
    {
        public Archetype Archetype;
        public long Row;

        public override string ToString()
        {
            return Archetype.ToString();
        }
    }
}