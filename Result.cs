using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhein
{
    public readonly struct Result
    {
        public readonly int value;
        public readonly bool ok;

        public static implicit operator int(Result res) => res.value;
        public static implicit operator bool(Result res) => res.value == 0;
        public static implicit operator Result(int code) => new Result(code);
        public static implicit operator Result (bool ok) => new Result(ok ? 0 : -1);

        public Result(int code)
        {
            value = code;
            ok = code == 0;
        }

        public static readonly Result Unknown = -1;
        public static readonly Result Ok = 0;
        public static readonly Result LowMemory = 1;
    }
}
