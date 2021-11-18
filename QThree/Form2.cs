using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QThree
{
    public partial class Form2 : Form
    {
        static string fname;
        public Form2()
        {
            
            InitializeComponent();
        }
        OpenFileDialog ofd = new OpenFileDialog();
        private void button2_Click(object sender, EventArgs e)
        {
            fname = textBox3.Text;
            Collection read = new Collection();
          //  byte[] bytes = read.Fileread(fname);
            textBox1.Text = read.Fileread(fname);
            textBox2.Text = textBox1.Text;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Collection upload = new Collection();

            byte[] bytes = upload.ConvertHexStringToByte(textBox2.Text);
            // string str = Encoding.UTF8.GetBytes(textBox2.Text);
            upload.FileUpload(bytes);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Collection upload = new Collection();
            BinaryWriter bw = new BinaryWriter(File.OpenWrite(ofd.FileName));
           // byte[] bytes = Encoding.UTF8.GetBytes(textBox2.Text);
            byte[] bytes = upload.ConvertHexStringToByte(textBox2.Text);
            bw.Write(bytes);
            bw.Close();
        }
    }
}
