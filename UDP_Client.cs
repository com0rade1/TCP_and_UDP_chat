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
    public partial class UDP_Client : Form
    {
        public static string KeyWord, FromKeyWord;
        public static int localPort; // порт приема сообщений
        public static int remotePort; // порт для отправки сообщений
        public static Socket listeningSocket;
        bool CheckQuit = false;
        bool CheckQuitUser = false;
        public bool Closed = false;
        public UDP_Client(string KeyWord, string LocalPort, string RemotePort)
        {

            InitializeComponent();
            UDP_Client.KeyWord = KeyWord;
            UDP_Client.localPort = Int32.Parse(LocalPort);
            UDP_Client.remotePort = Int32.Parse(RemotePort);
            listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            void Listen()
            {
                try
                {
                    //Прослушиваем по адресу
                    IPEndPoint localIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), localPort);
                    if (!Closed) listeningSocket.Bind(localIP);

                    while (true)
                    {
                        if (!CheckQuit)
                        {
                            // получаем сообщение
                            StringBuilder builder = new StringBuilder();
                            int bytes = 0; // количество полученных байтов
                            byte[] data = new byte[256]; // буфер для получаемых данных

                            //адрес, с которого пришли данные
                            EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);

                            do
                            {
                                bytes = listeningSocket.ReceiveFrom(data, ref remoteIp);
                                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                            }
                            while (listeningSocket.Available > 0);
                            // получаем данные о подключении
                            IPEndPoint remoteFullIp = remoteIp as IPEndPoint;
                            // выводим сообщение
                            if (builder.ToString().Contains("Key Word = "))
                            {
                                textBox1.Text += Environment.NewLine + "Получено кодовое слово клиента для закрытия соединения.";
                                FromKeyWord = builder.ToString().Remove(0, builder.ToString().IndexOf('=') + 1);
                                FromKeyWord = FromKeyWord.Trim();
                            }
                            if (builder.ToString() == FromKeyWord)
                            {
                                textBox1.Text += Environment.NewLine + "Собеседник покинул чат.";
                                CheckQuit = true;
                            }
                            else
                            {
                                textBox1.Text += Environment.NewLine + String.Format("{0}:{1} - {2}", remoteFullIp.Address.ToString(), remoteFullIp.Port, builder.ToString());
                            }
                        }
                        else
                        {
                            textBox1.Text += Environment.NewLine + "Вы не можете отправлять сообщения отключившемуся пользователю.";
                            break;
                        }

                    }
                }
                catch (Exception ex)
                {
                    textBox1.Text += Environment.NewLine + ex.Message;
                }
                finally
                {
                        Close();
                    Closed = true;
                }
            }
            Task ListeningTask = new Task(Listen);
            ListeningTask.Start();

        }

        private void UDP_Client_Shown(object sender, EventArgs e)
        {
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!CheckQuitUser)
            {
                try
                {

                    // отправка сообщений на разные порты
                    string message = textBox2.Text;
                    textBox2.Text = "";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    EndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), remotePort);
                    if (!Closed) listeningSocket.SendTo(data, remotePoint);
                    if (message == KeyWord)
                    {
                        textBox1.Text += Environment.NewLine + "Вы покинули чат.";
                        CheckQuitUser = true;
                    }
                   
                }
                catch (Exception ex)
                {
                    textBox1.Text += Environment.NewLine + ex.Message;
                }
            }
            else textBox1.Text += Environment.NewLine + "Соединения отсутствуют.";
        }
        private static void Close()
        {
            if (listeningSocket != null)
            {
                listeningSocket.Shutdown(SocketShutdown.Both);
                listeningSocket.Close();
                listeningSocket = null;
                
            }
        }

        private void UDP_Client_Load(object sender, EventArgs e)
        {

        }

    }
}
