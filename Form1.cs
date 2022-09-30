using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AI_LAB02
{
    public partial class Form1 : Form
    {
        Neyron_EvenOdd ai;
        bool[] states;
        
        public Form1()
        {
            InitializeComponent();
            ai = new Neyron_EvenOdd(15);
            states = new bool[15];
            for (int i = 0; i < 15; i++)
                states[i] = false;
            
            
        }
        private void ReadStates(bool[] states )
        {
            states[0] = tileControl1.GetState();
            states[1] = tileControl2.GetState();
            states[2] = tileControl3.GetState();
            states[3] = tileControl4.GetState();
            states[4] = tileControl5.GetState();
            states[5] = tileControl6.GetState();
            states[6] = tileControl7.GetState();
            states[7] = tileControl8.GetState();
            states[8] = tileControl9.GetState();
            states[9] = tileControl10.GetState();
            states[10] = tileControl11.GetState();
            states[11] = tileControl12.GetState();
            states[12] = tileControl13.GetState();
            states[13] = tileControl14.GetState();
            states[14] = tileControl15.GetState();
        }
        private void SetStates(bool[] image)
        {
            tileControl1.SetState(image[0]);
            tileControl2.SetState(image[1]);
            tileControl3.SetState(image[2]);
            tileControl4.SetState(image[3]);
            tileControl5.SetState(image[4]);
            tileControl6.SetState(image[5]);
            tileControl7.SetState(image[6]);
            tileControl8.SetState(image[7]);
            tileControl9.SetState(image[8]);
            tileControl10.SetState(image[9]);
            tileControl11.SetState(image[10]);
            tileControl12.SetState(image[11]);
            tileControl13.SetState(image[12]);
            tileControl14.SetState(image[13]);
            tileControl15.SetState(image[14]);
        }
        private void button1_MouseClick(object sender, MouseEventArgs e) //Виконати
        {
            ReadStates(states);
            bool result = ai.Run(states);
            if (result)
            {
                textBox1.Text = "Цифра непарна (1)";
            }
            else { 
                textBox1.Text = "Цифра парна (0)";
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count_iter = 0;
            bool t_educated = false;
            while (!t_educated)
            {
                t_educated = true;
                count_iter++;
                for (int j = 1; j < 10; j++)
                {
                    bool right_result = Convert.ToBoolean(j % 2);
                    if (ai.Learn(NumberToStates.Convert(j), right_result))
                        t_educated = false;
                }
            }
            textBox2.Text = count_iter.ToString();
        }

        private void button3_Click(object sender, EventArgs e)//Load
        {
            openFileDialog1.FileName = "neyron_w";
            openFileDialog1.Filter = " |*.txt";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                if (!ai.Load_W(openFileDialog1.FileName))
                {
                    MessageBox.Show("Файл не відкрито!", "Помилка");
                    return;
                }
                else
                {
                    MessageBox.Show("Файл успішно відкрито!", "Успіх");
                    return;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)//Save
        {
            saveFileDialog1.FileName = "neyron_w";
            saveFileDialog1.Filter = " |*.txt";
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                if (!ai.Save_W(saveFileDialog1.FileName))
                {
                    MessageBox.Show("Файл не збережено!", "Помилка");
                    return;
                }
                else
                {
                    MessageBox.Show("Файл успішно збережено!", "Успіх");
                    return;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetStates(NumberToStates.Convert((int)numericUpDown1.Value));
        }
    }
    
}