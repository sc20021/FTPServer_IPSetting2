using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QThree
{
    public partial class Form1 : Form
    {
        static public string id;
        static public string pw;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Collection check = new Collection();
            id = textBox1.Text;
            pw = textBox2.Text;
            if(check.FTPCheck("Whowho") != 1)
            {
                textBox1.Text = "";
                textBox1.Text = "";
                textBox1.Focus();
                MessageBox.Show("ID 또는 Password가 올바르지 않습니다.");
                return;
            }
            Form2 mainform = new Form2();
            mainform.Show();
            this.Hide();
        }
    }
}
