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
    public partial class Form7 : Form
    {
        data dataPU;
        public data DataPU { get => dataPU; set => dataPU = value; }

        public Form7(data dataP)
        {
            this.dataPU = dataP;
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) // show password checkbox
        {
            if (this.checkBox1.Checked == true)
            {
                textBox3.PasswordChar = '\0';
                textBox4.PasswordChar = '\0';
                textBox5.PasswordChar = '\0';
                textBox6.PasswordChar = '\0';
            }
            else
            {
                textBox3.PasswordChar = '*';
                textBox4.PasswordChar = '*';
                textBox5.PasswordChar = '*';
                textBox6.PasswordChar = '*';
            }
        }
        private void button2_Click(object sender, EventArgs e) // check, done
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                label1.Text = "please fill in all textbox";
            }
            else if (textBox3.Text == textBox4.Text)
            {
                label1.Text = "password1, password2 must not be the same";
            }
            else if (textBox3.Text != textBox5.Text || textBox4.Text != textBox6.Text)
            {
                label1.Text = "confirm password wrong";
            }
            else
            {
                dataPU.Password1 = textBox3.Text;
                dataPU.Password2 = textBox4.Text;
                this.Close();
            }
        }
    }
}
