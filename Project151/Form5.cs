using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project151
{
    public partial class Form5 : BaseForm151
    {
        public Form5()
        {
            InitializeComponent();
            SetFont();
            HallOfFameReader();
        }

        private void HallOfFameReader()
        {
            FileStream fs = new FileStream("halloffame.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            textBox1.Text = (sr.ReadToEnd());

            sr.Close();
            fs.Close();

            //FileStream fs = new FileStream("halloffame.txt", FileMode.Create, FileAccess.Write);
            //fs.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fr2 = new Form2();
            fr2.Show();
        }
    }
}
