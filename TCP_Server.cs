using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class TCP_Server : Form
    {
        static int port = 8005; // порт для приема входящих запросов
        Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
        Socket handler = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public TCP_Server()
        {
            InitializeComponent();
            handler.Close();
            listenSocket.Close();
            handler = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Task ServerEnabled ()
            {
                return Task.Run(() =>
                {
                    bool PassGet = false;
                    string WordToExit = "";

                    // получаем адреса для запуска сокета


                    try
                    {
                        // связываем сокет с локальной точкой, по которой будем принимать данные
                        listenSocket.Bind(ipPoint);

                        // начинаем прослушивание
                        listenSocket.Listen(10);

                        TrashBox.Text += Environment.NewLine + "Сервер запущен. Ожидание подключений... " + Environment.NewLine;
                        bool fl = true;
                        while (fl)
                        {

                            void Find()
                            {
                                handler = listenSocket.Accept();
                            }
                            Task Find1 = new Task(Find);
                            Find1.Start();
                            Find1.Wait();
                            // получаем сообщение
                            StringBuilder builder = new StringBuilder();
                            int bytes = 0; // количество полученных байтов
                            byte[] data = new byte[256]; // буфер для получаемых данных

                            do
                            {
                                bytes = handler.Receive(data);
                                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                            }
                            while (handler.Available > 0);
                            if (builder.ToString().Contains("Key Word = ") && PassGet)
                            {
                                WordToExit = builder.ToString().Remove(0, builder.ToString().IndexOf('=') + 1);
                            }
                            if (builder.ToString() != WordToExit)
                            {
                                TrashBox.Text += Environment.NewLine + DateTime.Now.ToShortTimeString() + ": " + builder.ToString();
                            }
                            else
                            {
                                TrashBox.Text += Environment.NewLine + DateTime.Now.ToShortTimeString() + ": Пользователь пожелал закрыть соединение";
                                fl = false;

                            }
                            // отправляем ответ

                            string message = "ваше сообщение доставлено";
                            data = Encoding.Unicode.GetBytes(message);
                            handler.Send(data);
                            // закрываем сокет




                        }
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }
                    catch (Exception ex)
                    {
                        TrashBox.Text += Environment.NewLine + ex.Message + ex.StackTrace;
                    }
                });

            }
            async void CallingServerEnabled()
            {
                await ServerEnabled();
            }
            CallingServerEnabled();

        }

        private void TCP_Server_Shown(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            handler.Close();
            listenSocket.Close();
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.Close();
            TCP_Server TCP_SERVER = new TCP_Server();
            this.Visible = false;
            TCP_SERVER.ShowDialog();
            this.Visible = true;
        }

        private void TCP_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            handler.Close();
            listenSocket.Close();
            ipPoint = null;
        }
    }
}



