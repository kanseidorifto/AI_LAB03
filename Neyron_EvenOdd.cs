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
        int theta;
        public Neyron_EvenOdd(int _k)
        {
            if (_k > 0)
            {
                Random random = new Random();
                k = _k;
                w = new int[k];
                Rand_w();
                theta = random.Next(0, 10);
            }
        }
        public Neyron_EvenOdd(string path = "neyron_w.txt")
        {
            string fileText = File.ReadAllText(path);
            if (fileText != null)
            {
                string[] items = fileText.Split(' ');
                theta = Convert.ToInt32(items[0]);
                k = items.Length - 2;
                w = new int[k];
                for (int i = 0; i < k; i++)
                {
                    w[i] = Convert.ToInt32(items[i + 1]);
                }

            }
        }
        public bool Save_W(string path)
        {
            string t = Convert.ToInt32(theta).ToString() + " ";
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
                theta = Convert.ToInt32(items[0]);
                k = items.Length - 2;
                if (k > 14) 
                    return false;
                w = new int[k];
                for (int i = 0; i < k; i++)
                {
                    w[i] = Convert.ToInt32(items[i + 1]);
                }
                return true;
            }
            return false;
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
            if (W_Sum >= theta)
            {
                return true;
            }
            return false;
        }
        public bool Learn(bool[] image, bool right_result)
        {
            bool result = Run(image);
            if (result != right_result)
            {
                if (result == false)
                {
                    for (int i = 0; i < k; i++)
                    {
                        if (image[i] == true)
                        {
                            w[i] += Convert.ToInt32(image[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < k; i++)
                    {
                        if (image[i] == true)
                        {
                            w[i] -= Convert.ToInt32(image[i]);
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}
