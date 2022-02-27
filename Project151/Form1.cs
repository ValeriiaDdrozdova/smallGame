using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Project151
{
    public partial class Form1 : BaseForm151
    {

        string inputtext = "";


        public Form1()
        {
            InitializeComponent();
            SetFont();
        }

        public void doPenalty(int amt)
        {
            progressBar1.Increment(amt* UserChanges.UserDiff);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            label3.Text = UserChanges.UserName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.progressBar1.Increment(1 + UserChanges.UserDiff);

            if (this.progressBar1.Value == progressBar1.Maximum)
            {
                DialogResult d;
                stop();
                d = MessageBox.Show("TIME IS OUT!");
                HallOfFameWriter();

                if (d == DialogResult.OK)
                {
                    this.Hide();
                    Form5 f5 = new Form5();
                    f5.Show();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.timer1.Start();
            this.timerWordChangeHigh.Start();
            this.timerWordChangeMedium.Start();
            this.timerWordChangeEasy.Start();

            textBox1.Enabled = true;
            timer2.Enabled = true;

            label9.Text = getRndWord(1);
            label10.Text = getRndWord(1);
            label11.Text = getRndWord(1);
            label12.Text = getRndWord(1);
            label13.Text = getRndWord(1);

            label14.Text = getRndWord(2);
            label15.Text = getRndWord(2);
            label16.Text = getRndWord(2);
            label17.Text = getRndWord(2);
            label18.Text = getRndWord(2);

            label19.Text = getRndWord(3);
            label20.Text = getRndWord(3);
            label21.Text = getRndWord(3);
            label22.Text = getRndWord(3);
            label23.Text = getRndWord(3);
        }

        public int k = 0;
        int pointCount = 0;

        private void checkInput(List<Label> labelDifList, string txt, int points)
        {
            foreach (var label in labelDifList)
            {
                if (label.Text == txt)
                {
                    wordsInputedIncrease();
                    label.Text = "";
                    pointCount += points*(1*UserChanges.UserDiff);
                    label4.Text = pointCount.ToString();
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            List<Label> labelsEasy = new List<Label> { label9, label10, label11, label12, label13 };
            List<Label> labelsMedium = new List<Label> { label14, label15, label16, label17, label18 };
            List<Label> labelsHard = new List<Label> { label19, label20, label21, label22, label23 };

            move(labelsEasy, 368, 2);
            move(labelsMedium, 190, 5);
            move(labelsHard, 10, 10);

            if (inputtext != "")
            {
                checkInput(labelsEasy, inputtext, 10);
                checkInput(labelsMedium, inputtext, 20);
                checkInput(labelsHard, inputtext, 30);

                inputtext = "";
            }
        }

        private void wordsInputedIncrease()
        {
            label8.Text = (++k).ToString();
        }

        private void move(List<Label> labels, int bound, int step)
        {
            foreach (var label in labels)
            {
                if (label.Location.X < bound - step* UserChanges.UserDiff)
                {
                    label.Location = new Point(label.Location.X + 150, label.Location.Y);
                }

                label.Location = new Point(label.Location.X - step, label.Location.Y);
            }
        }

        private void handleListOfWords(Label label, int complexity)
        {
            label.Text = getRndWord(complexity);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stop();
        }

        void stop()
        {
            this.timer1.Stop();
            this.timer2.Stop();
            this.timerWordChangeHigh.Stop();
            this.timerWordChangeMedium.Stop();
            this.timerWordChangeEasy.Stop();
            textBox1.Enabled = false;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text != "")
                {
                    inputtext = textBox1.Text.ToLower();
                    inputtext = inputtext.Substring(0, inputtext.Length - 2);
                    textBox1.Text = "";
                }
            }
        }

        public int m = 0;
        private void wordsMissedIncrease()
        {
            label7.Text = (++m).ToString();
        }

        private void timerWordChangeHigh_Tick(object sender, EventArgs e)
        {
            var labelsHard = new List<Label> { label19, label20, label21, label22, label23 };
            foreach (var label in labelsHard)
            {
                if (label.Text != "")
                {
                    wordsMissedIncrease();
                    doPenalty(30);
                }
                handleListOfWords(label, 3);
            }
        }

        private void timerWordChangeEasy_Tick(object sender, EventArgs e)
        {
            List<Label> labelsEasy = new List<Label> { label9, label10, label11, label12, label13 };
            foreach (var label in labelsEasy)
            {
                if (label.Text != "")
                {
                    wordsMissedIncrease();
                    doPenalty(10);
                }
                handleListOfWords(label, 1);
            }
        }

        private void timerWordChangeMedium_Tick(object sender, EventArgs e)
        {
            List<Label> labelsMedium = new List<Label> { label14, label15, label16, label17, label18 };
            foreach (var label in labelsMedium)
            {
                if (label.Text != "")
                {
                    wordsMissedIncrease();
                    doPenalty(20);
                }
                handleListOfWords(label, 2);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string input = textBox1.Text;
                string enter = "\r\n";
                bool endwth = input.EndsWith(enter);

                if (endwth != true)
                {
                    if (input.All(Char.IsLetter) == false)
                    {
                        MessageBox.Show("Please write letters only");
                        textBox1.Clear();
                    }
                }
            }
        }

        private void HallOfFameWriter()
        {
            FileStream fs = new FileStream("halloffame.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Name: " + UserChanges.UserName);
            sw.WriteLine("Ponts: " + label4.Text);
            sw.WriteLine("Missed Words: " + label7.Text);
            sw.WriteLine("Inputed Words: " + label8.Text);
            sw.WriteLine("-------------------------");

            sw.Close();
            fs.Close();
            
        }
    }
}
