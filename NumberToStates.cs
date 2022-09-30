using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_LAB02
{
    public static class NumberToStates
    {

        static readonly bool[][] n_to_st = {
            new bool[]{
                false,false,false,
                false,false,false,
                false,false,false,
                false,false,false,
                false,false,false
            },
            new bool[]{
                false,true,false,
                true,true,false,
                false,true,false,
                false,true,false,
                true,true,true
            },
            new bool[]{
                true,true,true,
                false,false,true,
                true,true,true,
                true,false,false,
                true,true,true
            },
            new bool[]{
                true,true,true,
                false,false,true,
                true,true,true,
                false,false,true,
                true,true,true
},
            new bool[]{
                true,false,true,
                true,false,true,
                true,true,true,
                false,false,true,
                false,false,true
},
            new bool[]{
                true,true,true,
                true,false,false,
                true,true,true,
                false,false,true,
                true,true,true
},
            new bool[]{
                true,true,true,
                true,false,false,
                true,true,true,
                true,false,true,
                true,true,true
},
            new bool[]{
                true,true,true,
                true,false,true,
                false,false,true,
                false,false,true,
                false,false,true
},
            new bool[]{
                true,true,true,
                true,false,true,
                true,true,true,
                true,false,true,
                true,true,true
},
            new bool[]{
                true,true,true,
                true,false,true,
                true,true,true,
                false,false,true,
                true,true,true
}
        };
        public static bool[] Convert(int k)
        {
            if (k > 0 && k < 10) return n_to_st[k];
            else return n_to_st[0];
        }
    }
}
