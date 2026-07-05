using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGR
{
    public partial class Initialize : Form
    {
        public Initialize()
        {
            InitializeComponent();
            textBox1.Text = "localhost";
            textBox2.Text = "5432";
            textBox3.Text = "admin";
            textBox4.Text = "1234";
            textBox5.Text = "RGR_Shop";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        public string getIp()
        {
            return textBox1.Text;
        }
        public string getPort()
        {
            return textBox2.Text;
        }
        public string getLogin()
        {
            return textBox3.Text;
        }
        public string getPassword()
        {
            return textBox4.Text;
        }
        public string getNameDB()
        {
            return textBox5.Text;
        }
    }
}
