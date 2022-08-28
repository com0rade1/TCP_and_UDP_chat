using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class TCP_Client : Form
    {
        static int port = 8005; // порт сервера
        static string address = "127.0.0.1"; // адрес сервера
        static string KeyWord;
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        bool CheckConnection = true;


        public TCP_Client(string KeyWord)
        {
            InitializeComponent();
            socket.Connect(ipPoint);
            TCP_Client.KeyWord = KeyWord;
            string WordToExit = String.Format("Key Word = {0}", KeyWord);
            byte[] data = Encoding.Unicode.GetBytes(WordToExit);
            socket.Send(data);
            data = new byte[256];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            textBox1.Text += Environment.NewLine + "Сервер получил ключевое слово для завершения диалога.";
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (CheckConnection)
            {

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
                if (textBox2.Text != KeyWord)
                {

                    string message = textBox2.Text;
                    textBox2.Text = "";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    socket.Send(data);
                    data = new byte[256];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);
                    textBox1.Text += Environment.NewLine + "Ответ сервера: " + builder.ToString();
                }
                else
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    textBox1.Text += Environment.NewLine + "Соединение с сервером закрыто.";
                    CheckConnection = false;

                }
            }
            else textBox1.Text += Environment.NewLine + "Вы пытаетесь отправить сообщение, отключившись от сервера.";
        }
    }
}
