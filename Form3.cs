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
    public partial class Form3 : Form
    {
        private int indexer;
        private data dataPU;
        private List<Label> listlb;

        public data DataPU { get => dataPU; set => dataPU = value; }
        public List<Label> Listlb { get => listlb; set => listlb = value; }

        public Form3(data dataP)
        {
            this.dataPU = dataP;
            InitializeComponent();
            showUPbyLabel();
        }

        //<show title by label>
        private void showUPbyLabel()
        {
            panel1.Controls.Clear();
            listlb = new List<Label>();
            for (int i = 0; i < dataPU.UPs1.Count(); i++)
            {
                Label newlb = new Label();
                newlb.Text = " " + (i + 1).ToString() + ". " + dataPU.UPs1[i].Title;
                newlb.Height = constant.lbheight;
                newlb.Width = constant.lbwidth;
                newlb.Location = new Point(5, i * constant.lbheight + 8);
                newlb.TextAlign = ContentAlignment.MiddleLeft;
                newlb.MaximumSize = new System.Drawing.Size(1000, constant.lbheight - 1);
                newlb.Click += label_click;
                newlb.MouseHover += label_mouse_hover;
                newlb.MouseLeave += label_mouse_leave;

                listlb.Add(newlb);
                panel1.Controls.Add(newlb);
            }
        }

        void label_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((sender as Label).Text))
                return;
            int index = listlb.IndexOf(sender as Label);
            this.indexer = index;
            this.textBox1.Text = dataPU.UPs1[index].Username;
            this.textBox2.Text = dataPU.UPs1[index].Password;
            this.textBox3.Text = dataPU.UPs1[index].Website;
            this.textBox4.Text = dataPU.UPs1[index].Title;
        }
        void label_mouse_hover(object sender, EventArgs e)
        {
            (sender as Label).BackColor = SystemColors.ActiveCaption;
        }
        void label_mouse_leave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.Transparent;
        }
        //<endl show title>


        
        private void button1_Click(object sender, EventArgs e) //add new PU
        {
            int temp = dataPU.UPs1.Count();
            Form4 form4 = new Form4(dataPU);
            form4.ShowDialog();
            if (temp != dataPU.UPs1.Count())
                showUPbyLabel();
        }

        private void button2_Click(object sender, EventArgs e) //fix and save PU
        {
            if (this.button2.Text == "fix")
            {
                this.button2.Text = "save";
                this.textBox4.ReadOnly = false;
                this.textBox2.ReadOnly = false;
                this.textBox3.ReadOnly = false;
                this.textBox2.BackColor = SystemColors.Control;
                this.textBox3.BackColor = SystemColors.Control;
                this.textBox4.BackColor = SystemColors.Control;
            }
            else
            {
                this.button2.Text = "fix";
                this.textBox4.ReadOnly = true;
                this.textBox2.ReadOnly = true;
                this.textBox3.ReadOnly = true;
                this.textBox2.BackColor = SystemColors.ControlDark;
                this.textBox3.BackColor = SystemColors.ControlDark;
                this.textBox4.BackColor = SystemColors.ControlDark;
                DataPU.UPs1[indexer].Title = this.textBox4.Text;
                DataPU.UPs1[indexer].Password = this.textBox2.Text;
                DataPU.UPs1[indexer].Website = this.textBox3.Text;
                showUPbyLabel();
            }
        }

        private void button3_Click(object sender, EventArgs e) //delete PU
        {
            DialogResult yesOrno = MessageBox.Show("are you sure want to delete?", "delete", MessageBoxButtons.YesNo);
            if (yesOrno == System.Windows.Forms.DialogResult.Yes)
            {
                DataPU.UPs1.RemoveAt(indexer);
                showUPbyLabel();
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
            }
        }

        //<label need healp>
        private void label5_Click(object sender, EventArgs e) //need help label
        {
            MessageBox.Show("if you having problems in using, or find any unexpected bugs, or need sourse code, please contact me by email quanghuy1998kh@gmail.com or by facebook if you know mine", "support", MessageBoxButtons.OK);
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = SystemColors.ControlDarkDark;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = SystemColors.Highlight;
        }
        //<end label need healp>
    }
}
