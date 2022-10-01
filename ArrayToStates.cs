using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AI_LAB02
{
    public class ArrayToStates
    {
        [JsonInclude]
        public int count;
        [JsonInclude]
        public List<bool[]> n_to_st/* = {
            new bool[]{
                false,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false
            },
            new bool[]{
                false,false,true,false,false,
                false,true,false,true,false,
                false,true,false,true,false,
                false,true,true,true,false,
                false,true,false,true,false
            },
            new bool[]{
                false,true,true,true,false,
                false,true,false,false,false,
                false,true,true,true,false,
                false,true,false,true,false,
                false,true,true,true,false
            },
            new bool[]{
                false,true,true,false,false,
                false,true,false,true,false,
                false,true,true,false,false,
                false,true,false,true,false,
                false,true,true,false,false
},
            new bool[]{
                false,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false
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
        }*/;
        public ArrayToStates()
        {
            count = 1;
            n_to_st = new List<bool[]>();
            n_to_st.Add(new bool[] {true,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false });

        }
        public void Set(int k, bool[] states)
        {
            if (states != null)
            {
                bool[] new_states = new bool[states.Length];
                for (int i = 0; i < states.Length; i++)
                    new_states[i] = states[i];
                if (k < count)
                    n_to_st[k] = new_states;
                else
                {
                    n_to_st.Add(new_states);
                    count++;
                }
            }
        }
        public bool[] Convert(int k)
        {
            if (k > 0 && k < count)
                return n_to_st[k];
            else
                return n_to_st[0];
        }
    }
}
