using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DXDebug.Engine.Components;

namespace DXDebug.Engine
{
    public interface IEntity{}

    public class Entity
    {
        public long Index{get;set;}
        public EntityManager? Manager {get;set;}
    }
    
}