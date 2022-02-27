using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project151
{
    public partial class Form3 : BaseForm151
    {
        public Form3()
        {
            InitializeComponent();
            SetFont();
            if (userFont != null)
            {
                radioButton1.Font = new System.Drawing.Font(userFont.FontFamily, radioButton1.Font.Size);
                radioButton3.Font = new System.Drawing.Font(userFont.FontFamily, radioButton3.Font.Size);
            }
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UserChanges.UserName = textBox1.Text;

            if (textBox1.Text.Length > 20)
            {
                MessageBox.Show("Name is to large.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked==false && radioButton3.Checked==false)
            {
                MessageBox.Show("you must choose difficulty level to continue!", 
                    "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Hide();
                Form1 fr1 = new Form1();
                fr1.Show();
            }
            
        }

        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "-More time";
            label3.Text = "-Slower word movement";
            label4.Text = "-Less penalty";
            label5.Text = "-Lower points";
            UserChanges.UserDiff = 1;
        }


        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "-Less time";
            label3.Text = "-Faster word movement";
            label4.Text = "-More penalty";
            label5.Text = "-Higher points";
            UserChanges.UserDiff = 2;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
        }

        private void n(object sender, EventArgs e)
        {

        }
    }
}
