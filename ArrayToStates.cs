using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AI_LAB02
{
    public class ArrayToStates
    {
        [JsonInclude]
        public int count;
        [JsonInclude]
        public List<bool[]> elements;
        public ArrayToStates()
        {
            count = 1;
            elements = new List<bool[]>();
            elements.Add(new bool[] {
                true,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false 
            });
        }
        public void Set(int k, bool[] states) // Змінити(або додати, якщо занято) набір даних
        {
            if (states != null)
            {
                bool[] new_states = new bool[states.Length];
                for (int i = 0; i < states.Length; i++)
                    new_states[i] = states[i];
                if (k < count)
                    elements[k] = new_states;
                else
                {
                    elements.Add(new_states);
                    count++;
                }
            }
        }
        public bool[] Convert(int k) // Повернути масив значень відповідно до запитуваного номера
        {
            if (k > 0 && k < count)
                return elements[k];
            else
                return elements[0];
        }
    }
}
