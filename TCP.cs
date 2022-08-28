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
    public partial class TCP : Form
    {
        public TCP()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 _Form1 = new Form1();
            this.Visible = false;
            _Form1.ShowDialog();
            this.Visible = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TCP_Server _TCP_Server = new TCP_Server();
            this.Visible = false;
            _TCP_Server.ShowDialog();
            this.Visible = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            TCP_ShutDownWord _TCP_ShutDownWord = new TCP_ShutDownWord();
            this.Visible = false;
            _TCP_ShutDownWord.ShowDialog();
            this.Visible = true;
        }
    }
}
