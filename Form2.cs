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
    public partial class Form2 : Form
    {
        data dataUP;
        public Form2(data dataP)
        {
            InitializeComponent();
            this.dataUP = dataP;
            this.comboBox1.DataSource = data.QA;
        }

        private void button1_Click(object sender, EventArgs e) //done! check if user fill correctly
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox1.Text != textBox2.Text && textBox3.Text == textBox1.Text && textBox4.Text == textBox2.Text && comboBox1.SelectedIndex != -1 && textBox5.Text != "")
            {
                this.Close(); // call for closing event
            }
            else if (textBox1.Text == textBox2.Text)
            {
                this.label13.Text = "password1 and password2 must not be the same";
                this.label13.Location = new Point(180, this.label13.Location.Y);
            }
            else if (textBox3.Text != textBox1.Text || textBox4.Text != textBox2.Text)
            {
                this.label13.Text = "password authentication is not correct";
                this.label13.Location = new Point(200, this.label13.Location.Y);
            }
            else
            {
                this.label13.Text = "please fill all the textbox";
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e) //get infor form user input
        {
            this.dataUP.Password1 = textBox1.Text;
            this.dataUP.Password2 = textBox2.Text;
            this.dataUP.Question = comboBox1.SelectedItem.ToString();
            this.dataUP.Answer = textBox5.Text;
            this.dataUP.Passwordcode = numericUpDown1.Value.ToString() + numericUpDown2.Value.ToString() + numericUpDown3.Value.ToString() + numericUpDown4.Value.ToString();
        }

    }
}
