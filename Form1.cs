using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            UDP_ShutDownWord _UDP = new UDP_ShutDownWord();
            this.Visible = false;
            _UDP.ShowDialog();
            this.Visible = true;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TCP _TCP = new TCP();
            this.Visible = false;
            _TCP.ShowDialog();
            this.Visible = true;
        }
    }
}
