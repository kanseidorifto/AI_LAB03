using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_LAB02
{
    class Neyron_EvenOdd
    {
        private int[] w;
        int k;
        double u;
        public Neyron_EvenOdd(int _k)
        {
            if (_k > 0)
            {
                Random random = new Random();
                k = _k;
                u = 1;
                w = new int[k + 1];
                w[0] = random.Next(0, 10);
                Rand_w();
            }
        }
        public Neyron_EvenOdd(string path = "neyron_w.txt")
        {
            string fileText = File.ReadAllText(path);
            if (fileText != null)
            {
                string[] items = fileText.Split(' ');
                k = items.Length - 1;
                w = new int[k];
                u = 1; //
                for (int i = 0; i < k; i++)
                {
                    w[i] = Convert.ToInt32(items[i]);
                }

            }
        }
        public bool Save_W(string path)
        {
            string t = "";
            for (int i = 0; i < k; i++)
            {
                t += w[i].ToString() + " ";
            }
            File.WriteAllText(path, t);
            return true;
        }
        public bool Load_W(string path)
        {
            string fileText = File.ReadAllText(path);
            if (fileText != null)
            {
                string[] items = fileText.Split(' ');
                k = items.Length - 1;
                if (k > 25)
                    return false;
                w = new int[k];
                for (int i = 0; i < k; i++)
                {
                    w[i] = Convert.ToInt32(items[i]);
                }
                return true;
            }
            return false;
        }
        public void Set_W(int[] _w)
        {
            w = _w;
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
            int W_Sum = 0;
            for (int i = 0; i < k; i++)
            {
                W_Sum += w[i] * Convert.ToInt32(image[i]);
            }
            if (W_Sum >= 0)
            {
                return true;
            }
            return false;
        }
        public bool Learn(bool[] image, int right_result)
        {
            int result = Convert.ToInt32(Run(image));
            if (result != right_result)
            {
                int eps = result - right_result;
                w[0] = w[0] + (int)u * eps;
                for (int i = 1; i < k; i++)
                {
                    w[i] = w[i] + (int)u * eps * Convert.ToInt32(image[i]);
                }
                return true;
            }
            return false;
        }
    }
}
