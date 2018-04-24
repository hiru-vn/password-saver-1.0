using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace password_saver
{
    public partial class Form6 : Form
    {
        private data dataPU;
        public data DataPU { get => dataPU; set => dataPU = value; }

        public Form6(data dataP)
        {
            this.dataPU = dataP;
            InitializeComponent();
            this.comboBox1.DataSource = data.QA;
        }

        private void button1_Click(object sender, EventArgs e) // next button, go to password reset form
        {
            if (this.comboBox1.SelectedItem.ToString() == dataPU.Question && this.textBox1.Text == dataPU.Answer && dataPU.Passwordcode == numericUpDown1.Value.ToString() + numericUpDown2.Value.ToString() + numericUpDown3.Value.ToString() + numericUpDown4.Value.ToString())
            {
                Form7 form7 = new Form7(dataPU);
                form7.ShowDialog();
                this.Close();
            }
            else if (this.comboBox1.SelectedItem.ToString() != dataPU.Question || this.textBox1.Text != dataPU.Answer)
            {
                this.label3.Text = "wrong question or answer";
            }
            else
            {
                this.label3.Text = "wrong password code";
            }
        }

        private void button3_Click(object sender, EventArgs e) //cancel button
        {
            this.Close();
        }
    }
}
