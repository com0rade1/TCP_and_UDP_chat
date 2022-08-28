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
    public partial class UDP_ShutDownWord : Form
    {
        public UDP_ShutDownWord()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                UDP_Client _UDP_Client = new UDP_Client(textBox1.Text,textBox2.Text,textBox3.Text);
                this.Visible = false;
                _UDP_Client.ShowDialog();
                this.Visible = true;
            }
            else MessageBox.Show("Задайте ключевое слово для завершения общения с клиентом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
