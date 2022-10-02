using AI_LAB02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AI_LAB03
{
    internal class Perceptron
    {
        [JsonInclude]
        public Neyron[] neyron_arr;
        [JsonInclude]
        public int neyronsCount;
        [JsonInclude]
        public int inputsCount;
        double u;
        public Perceptron()
        {
            this.u = 1;
            this.neyronsCount = 1;
            this.inputsCount = 1;
            neyron_arr = new Neyron[neyronsCount];
            for (int i = 0; i < neyronsCount; i++)
            {
                neyron_arr[i] = new Neyron(inputsCount);
            }
        
    }
        public Perceptron(int neyronsCount, int inputsCount, double u = 1)
        {
            this.u = u;
            this.neyronsCount = neyronsCount;
            this.inputsCount = inputsCount;
            neyron_arr = new Neyron[neyronsCount];
            for (int i = 0; i < neyronsCount; i++)
            {
                neyron_arr[i] = new Neyron(inputsCount);
            }
        }
        public bool[] Run(bool[] image)
        {
            bool[] result = new bool[neyronsCount];
            for (int i = 0; i < neyronsCount; i++)
            {
                result[i] = neyron_arr[i].Run(image);
            }
            return result;
        }
        public void Correction(double[] eps, bool[] input)
        {
            for (int i = 0; i < neyronsCount; i++)
                for (int j = 0; j < inputsCount; j++)
                    neyron_arr[i].Correction((int)(u * eps[i]), input);
        }
    }
}
