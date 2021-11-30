using System;
using System.Collections.Generic;

namespace DXDebug.Engine
{
    public interface IQueryEntity
    {
        HashSet<Type> GetQueryType();
    }
    
    public class QueryEntity<T1> : IQueryEntity
    {
        public static readonly HashSet<Type> QueryType = new HashSet<Type>{typeof(T1)};

        public HashSet<Type> GetQueryType() => QueryType;
    }
    public class QueryEntity<T1,T2> : IQueryEntity
    {
        public static readonly HashSet<Type> QueryType = new HashSet<Type>{typeof(T1), typeof(T2)};
        public HashSet<Type> GetQueryType() => QueryType;

    }
    public class QueryEntity<T1,T2,T3> : IQueryEntity
    {
        public static readonly HashSet<Type> QueryType = new HashSet<Type>{typeof(T1), typeof(T2), typeof(T3)};
        public HashSet<Type> GetQueryType() => QueryType;

    }
    public class QueryEntity<T1,T2,T3,T4> : IQueryEntity
    {
        public static readonly HashSet<Type> QueryType = new HashSet<Type>{typeof(T1), typeof(T2), typeof(T3), typeof(T4)};
        public HashSet<Type> GetQueryType() => QueryType;

    }
    public class QueryEntity<T1,T2,T3,T4,T5> : IQueryEntity
    {
        public static readonly HashSet<Type> QueryType = new HashSet<Type>{typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5)};
        public HashSet<Type> GetQueryType() => QueryType;

    }
    public class QueryEntity<T1,T2,T3,T4,T5,T6> : IQueryEntity
    {
        public static readonly HashSet<Type> QueryType = new HashSet<Type>{typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6)};
        public HashSet<Type> GetQueryType() => QueryType;

    }
    public class QueryEntity<T1,T2,T3,T4,T5,T6,T7> : IQueryEntity
    {
        public static readonly HashSet<Type> QueryType = new HashSet<Type>{typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7)};
        public HashSet<Type> GetQueryType() => QueryType;

    }
    public class QueryEntity<T1,T2,T3,T4,T5,T6,T7,T8> : IQueryEntity
    {
        public static readonly HashSet<Type> QueryType = new HashSet<Type>{typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8)};
        public HashSet<Type> GetQueryType() => QueryType;

    }
}