using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Encodings.Web;
using AI_LAB03;

namespace AI_LAB02
{
    public partial class Form1 : Form
    {
        Perceptron perceptron;
        ArrayToStates const_inputs;
        bool[] states;
        string alphabet = "������Ū���ɲ��������������������"; //����� ��� ��������� �� ������� ����������� �������
        public Form1()
        {
            InitializeComponent();
            
            perceptron = new Perceptron(33, 25); //�������� ���������� � 33-�� ��������� �� 25-�� ���������� �������

            const_inputs = new ArrayToStates(); //��'��� ��� ��������� ������� ������� �������

            states = new bool[25]; //����� ��� ����������� ��������� ������� ������� �������
            for (int i = 0; i < 25; i++)
                states[i] = false;
        }
        private void ReadStates(bool[] _states) //������� ����� �������� � �����
        {
            _states[0] = tileControl1.GetState();
            _states[1] = tileControl2.GetState();
            _states[2] = tileControl3.GetState();
            _states[3] = tileControl4.GetState();
            _states[4] = tileControl5.GetState();
            _states[5] = tileControl6.GetState();
            _states[6] = tileControl7.GetState();
            _states[7] = tileControl8.GetState();
            _states[8] = tileControl9.GetState();
            _states[9] = tileControl10.GetState();
            _states[10] = tileControl11.GetState();
            _states[11] = tileControl12.GetState();
            _states[12] = tileControl13.GetState();
            _states[13] = tileControl14.GetState();
            _states[14] = tileControl15.GetState();
            _states[15] = tileControl16.GetState();
            _states[16] = tileControl17.GetState();
            _states[17] = tileControl18.GetState();
            _states[18] = tileControl19.GetState();
            _states[19] = tileControl20.GetState();
            _states[20] = tileControl21.GetState();
            _states[21] = tileControl22.GetState();
            _states[22] = tileControl23.GetState();
            _states[23] = tileControl24.GetState();
            _states[24] = tileControl25.GetState();
        }
        private void SetStates(bool[] image) //³��������� �������� �� ����
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
            tileControl16.SetState(image[15]);
            tileControl17.SetState(image[16]);
            tileControl18.SetState(image[17]);
            tileControl19.SetState(image[18]);
            tileControl20.SetState(image[19]);
            tileControl21.SetState(image[20]);
            tileControl22.SetState(image[21]);
            tileControl23.SetState(image[22]);
            tileControl24.SetState(image[23]);
            tileControl25.SetState(image[24]);
        }
        private void button1_MouseClick(object sender, MouseEventArgs e) //��������
        {
            ReadStates(states); //�������� �������� ������� ������� � �����
            int r = 0;
            bool[] result = perceptron.Run(states); //������ �������� ������� �����������
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i]) //���� ������ (1)
                    r = i;      //�� �������� ����� �������
            }
            textBox1.Text = alphabet[r].ToString(); //�������� ������� ��������� �� �������� ������� �����������
        }
        private void button2_Click(object sender, EventArgs e) //������� ����������
        {
            int count_iter = 0;
            bool t_educated = false;
            while (!t_educated) //���������� �� ��� ��, ���� ���������� �� ��������� ���������
            {
                count_iter++;
                t_educated = true;
                for (int j = 1; j < const_inputs.count; j++) //���� �� ������� �������� ������ �����
                {
                    bool[] l_states = const_inputs.Convert(j); //������� ������ �������� �� ��������
                    bool[] l_results = perceptron.Run(l_states); //������ �������� ������� �����������

                    bool[] l_right_results = new bool[perceptron.neyronsCount];
                    for (int i = 0; i < perceptron.neyronsCount; i++) //������������ ������� ���������� �������� ����������� �� ����� ���� �����
                    {
                        if ((j == i + 1))
                            l_right_results[i] = true;
                        else
                            l_right_results[i] = false;
                    }

                    double[] l_eps = new double[perceptron.neyronsCount];
                    for (int i = 0; i < perceptron.neyronsCount; i++) //���� �� ������� ������� �����������
                    {
                        l_eps[i] = Convert.ToInt32(l_right_results[i]) - Convert.ToInt32(l_results[i]); //������������ ������� �������
                        if (l_eps[i] != 0)
                        {
                            t_educated = false;
                            perceptron.Correction(l_eps, l_states); //����������� ������� �����������
                        }
                    }
                }
            }
            textBox2.Text = count_iter.ToString(); //��������� ������� �������� ��������
        }
        private void button3_Click(object sender, EventArgs e) //����������� ����� ����������� � ���������� � ����� JSON
        {
            openFileDialog1.FileName = "perceptron_w";
            openFileDialog1.Filter = " |*.json";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                if (!File.Exists(openFileDialog1.FileName))
                {
                    MessageBox.Show("���� �� �������!", "�������");
                    return;
                }
                else
                {
                    string data = File.ReadAllText(openFileDialog1.FileName);
                    perceptron = JsonSerializer.Deserialize<Perceptron>(data);
                    MessageBox.Show("���� ������ �������!", "����");
                    return;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e) //�������� ����� ����������� ����������� � ���� JSON
        {
            saveFileDialog1.FileName = "perceptron_w";
            saveFileDialog1.Filter = " |*.json";
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                if (!true)
                {
                    MessageBox.Show("���� �� ���������!", "�������");
                    return;
                }
                else
                {
                    string perceptronJson = JsonSerializer.Serialize(perceptron, new JsonSerializerOptions()
                    {
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    });
                    File.WriteAllText(saveFileDialog1.FileName, perceptronJson);
                    MessageBox.Show("���� ������ ���������!", "����");
                    return;
                }
            }
        }
        private void button5_Click(object sender, EventArgs e) //���������� ����� �������� �� �����
        {
            SetStates(const_inputs.Convert((int)numericUpDown1.Value));
        }
        private void button6_Click(object sender, EventArgs e) //���������(�����) ������� ����� � �����
        {
            int k = (int)numericUpDown1.Value;
            ReadStates(states);
            const_inputs.Set(k, states);
        }
        private void button7_Click(object sender, EventArgs e) //����������� ������� ������� � ����� JSON
        {
            openFileDialog1.FileName = "input_states";
            openFileDialog1.Filter = " |*.json";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                if (!File.Exists(openFileDialog1.FileName))
                {
                    MessageBox.Show("���� �� �������!", "�������");
                    return;
                }
                else
                {
                    string data = File.ReadAllText(openFileDialog1.FileName);
                    const_inputs = JsonSerializer.Deserialize<ArrayToStates>(data);
                    MessageBox.Show("���� ������ �������!", "����");
                    return;
                }
            }
        }
        private void button8_Click(object sender, EventArgs e) //�������� ����� �������� � ���� JSON
        {
            saveFileDialog1.FileName = "input_states";
            saveFileDialog1.Filter = " |*.json";
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                if (!true)
                {
                    MessageBox.Show("���� �� ���������!", "�������");
                    return;
                }
                else
                {
                    string inputJson = JsonSerializer.Serialize(const_inputs, new JsonSerializerOptions()
                    {
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    });
                    File.WriteAllText(saveFileDialog1.FileName, inputJson);
                    MessageBox.Show("���� ������ ���������!", "����");
                    return;
                }
            }

        }
    }

}