using System;

namespace Rhodos.Toolkit
{
    [Serializable] public struct MinMaxPair<T>
    {
        public T min, max;
    }    
    [Serializable] public struct InOutPair<T>
    {
        public T _in, _out;
    }
}