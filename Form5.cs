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
    public partial class Form5 : Form
    {
        private data dataPU;
        public data DataPU { get => dataPU; set => dataPU = value; }
        public Form5(data dataP)
        {
            this.dataPU = dataP;
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //show password
        {
            if (this.checkBox1.Checked == true)
            {
                textBox1.PasswordChar = '\0';
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
                textBox4.PasswordChar = '\0';
                textBox5.PasswordChar = '\0';
                textBox6.PasswordChar = '\0';
            }
            else
            {
                textBox1.PasswordChar = '*';
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
                textBox4.PasswordChar = '*';
                textBox5.PasswordChar = '*';
                textBox6.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e) //done button, check user input is correct
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                label7.Text = "please fill in all the textbox";
            }
            else if (textBox1.Text != dataPU.Password1)
            {
                label7.Text = "wrong password 1";
            }
            else if (textBox2.Text != dataPU.Password2)
            {
                label7.Text = "wrong password 2";
            }
            else if (textBox3.Text == textBox4.Text)
            {
                label7.Text = "password1,password2 must not be the same";
            }
            else if (textBox3.Text != textBox5.Text)
            {
                label7.Text = "password 1 confirm wrong";
            }
            else if (textBox4.Text != textBox6.Text)
            {
                label7.Text = "password 2 confirm wrong";
            }
            else
            {
                this.dataPU.Password1 = textBox3.Text;
                this.dataPU.Password2 = textBox4.Text;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e) //go back
        {
            this.Close();
        }
    }
}
