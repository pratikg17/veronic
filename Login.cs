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

namespace Ver
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtuser.Text = "";
            txtpass.Text = "";


        }

        private void lblexit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((txtuser.Text == "123") && (txtpass.Text == "123"))
            {
                StreamWriter sw = new StreamWriter();
                

                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
        }
    }
}
