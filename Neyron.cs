using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_LAB02
{
    class Neyron
    {
        public int[] w;
        public int k;
        double u;
        public Neyron()
        {
            Random random = new Random();
            k = 2;
            u = 1;
            w = new int[k];
            Rand_w();
        }
        public Neyron(int _k)
        {
            if (_k > 0)
            {
                Random random = new Random();
                k = _k + 1;
                u = 1;
                w = new int[k];
                Rand_w();
            }
            else
            {
                Random random = new Random();
                k = 2;
                u = 1;
                w = new int[k];
                Rand_w();
            }
        }
        void Rand_w()
        {
            Random random = new Random();
            for (int i = 0; i < k; i++)
            {
                w[i] = random.Next(0, 10);
            }
        }
        public bool Run(bool[] image)
        {
            int W_Sum = w[0];
            for (int i = 1; i < k; i++)
            {
                W_Sum += w[i] * Convert.ToInt32(image[i - 1]);
            }
            if (W_Sum >= 0)
            {
                return true;
            }
            return false;
        }
        public void Correction(int eps, bool[] image)
        {
            w[0] = w[0] + eps;
            for (int i = 1; i < k; i++)
            {
                w[i] = w[i] + eps * Convert.ToInt32(image[i - 1]);
            }
        }
    }
}
