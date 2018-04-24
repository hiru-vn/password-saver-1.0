using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace password_saver
{
    public partial class Form1 : Form
    {
        private data dataP;
        private string filePath = "data.xml";
        public data DataP { get => dataP; set => dataP = value; }
        public Form1()
        {
            InitializeComponent();
            try
            {
                dataP = DeserializeFromXML(filePath) as data;
            }
            catch
            {
                SetDefault();
            }
        }

        void SetDefault()
        {
            dataP = new data();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) //checkbox : show password
        {
            if (checkBox1.Checked == true)
            {
                textBox1.PasswordChar = '\0';
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox1.PasswordChar = '*';
                textBox2.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e) //first attemp - set password 1 & 2
        {
            if (dataP.Password1 =="" && dataP.Password2 =="")
            {
                Form2 form2 = new Form2(dataP);
                form2.ShowDialog();
            }
        }


        //<serialization>
        private object DeserializeFromXML(string filePath) //get data from file XML, object:dataQA
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(data));

                object result = sr.Deserialize(fs);
                fs.Close();
                return result;
            }
            catch (Exception e)
            {
                fs.Close();
                throw new NotImplementedException();
            }
        }
        private void SerializeToXML(object data, string filePath) // save object dataQA to XML file
        {
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            XmlSerializer sr = new XmlSerializer(typeof(data));

            sr.Serialize(fs, data);

            fs.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializeToXML(dataP, filePath);
        }
        //<end serialization>


        //<button next - move to infor showing form>
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(dataP); //infor showing form
            if (textBox1.Text == dataP.Password1 && textBox2.Text == dataP.Password2) //confirm is password filled correctly
            {
                label4.Text = "";
                this.checkBox1.Checked = false;
                this.checkBox1.Enabled = true;
                form3.ShowDialog();
                this.Close();
            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                label4.ForeColor = Color.Blue;
                label4.Text = "please fill in password boxes";
            }
            else
            {
                label4.ForeColor = Color.Red;
                label4.Text = "wrong password";
            }
        }
        //<end next button>


        //<change password button>
        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(dataP);
            form5.ShowDialog();
        }
        //<end change password button>


        // <label forget your password>
        private void label3_Click(object sender, EventArgs e) //open form qa and password code confirm
        {
            Form6 form6 = new Form6(dataP);
            form6.ShowDialog();
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = SystemColors.ControlDark;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = SystemColors.Highlight;
        }
        //<end label setting>
    }
}
