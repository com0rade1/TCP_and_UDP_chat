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
    public partial class TCP_ShutDownWord : Form
    {
        public TCP_ShutDownWord()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                TCP_Client _TCP_Client = new TCP_Client(textBox1.Text);
                this.Visible = false;
                _TCP_Client.ShowDialog();
                this.Visible = true;
            }
            else MessageBox.Show("Задайте ключевое слово для завершения общения с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
