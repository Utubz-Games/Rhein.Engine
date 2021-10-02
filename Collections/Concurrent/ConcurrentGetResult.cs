using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhein.Collections
{
    public readonly struct ConcurrentGetResult<T>
    {
        public readonly T value;
        public readonly bool success;
        
        public static implicit operator T(ConcurrentGetResult<T> res) => res.value;
        public static implicit operator bool(ConcurrentGetResult<T> res) => res.success;
        
        internal ConcurrentGetResult(T t, bool s)
        {
            value = t;
            success = s;
        }
    }
}
