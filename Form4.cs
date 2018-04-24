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
    public partial class Form4 : Form
    {
        private data dataPU;
        public data DataPU { get => dataPU; set => dataPU = value; }
        public Form4(data dataP)
        {
            this.dataPU = dataP;
            InitializeComponent();
        }

        private void getNewPU() // set in save event - save user input to data
        {
            UP newup = new UP();
            newup.Title = this.textBox1.Text;
            newup.Username = this.textBox2.Text;
            newup.Password = this.textBox3.Text;
            newup.Website = this.textBox4.Text;
            dataPU.UPs1.Add(newup);
        }

        private void button1_Click(object sender, EventArgs e) //check if user fill texbox correctly
        {
            if (textBox1.Text == "")
            {
                this.label5.Text = " title must not be empty ";
                return;
            }
            if (textBox2.Text =="")
            {
                this.label5.Text = "username must not be empty";
                return;
            }
            if (textBox3.Text == "")
            {
                this.label5.Text = "password must not be empty";
                return;
            }

            getNewPU();
            this.Close();
        }
    }
}
