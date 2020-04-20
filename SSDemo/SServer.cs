using SSDemo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SSDemo
{
    public class SServer : IDisposable
    {

        private Socket serverSocket { get; set; }
        public static event MessageReceive MessageReceiveEvent;
        private Thread myThread { get; set; }
        private Thread receiveThread { get; set; }
        public SServer()
        {
            IPAddress ip = IPAddress.Parse(Configs.IP);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, Configs.Port));  //绑定IP地址：端口 
            serverSocket.Listen(10);    //设定最多10个排队连接请求 
            MessageReceiveEvent?.Invoke($"启动监听{serverSocket.LocalEndPoint.ToString()}成功");
            //通过Clientsoket发送数据 
            myThread = new Thread(ListenClientConnect);
            myThread.IsBackground = true;
            myThread.Start();
        }

        private List<Socket> Clients { get; set; } = new List<Socket>();

        /// <summary> 
        /// 监听客户端连接 
        /// </summary> 
        private void ListenClientConnect()
        {

            while (true)
            {
                try
                {
                    Socket clientSocket = serverSocket.Accept();
                    if (!Clients.Contains(clientSocket))
                    {
                        Clients.Add(clientSocket);
                    }
                    MessageReceiveEvent?.Invoke($"{clientSocket.RemoteEndPoint} Connected");
                    receiveThread = new Thread(ReceiveMessage);
                    receiveThread.IsBackground = true;
                    receiveThread.Start(clientSocket);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        /// <summary> 
        /// 接收消息 
        /// </summary> 
        /// <param name="clientSocket"></param> 
        private void ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    byte[] result = new byte[1024 * 1024 * 10];
                    //通过clientSocket接收数据 
                    int receiveNumber = myClientSocket.Receive(result);
                    if (receiveNumber > 0)
                    {
                        var content = Configs.Encoding.GetString(result);
                        MessageReceiveEvent?.Invoke(content);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    myClientSocket.Close();
                    break;
                }
            }
        }
        public void SendMessage(string cmd)
        {
            var enableClient = Clients.Where(x => x.Connected).ToList();
            if (enableClient.Count() == 0)
            {
                MessageReceiveEvent?.Invoke("没有可用的客户端");
                return;
            }
            for (int i = 0; i < enableClient.Count; i++)
            {
                try
                {
                    if (enableClient[i].Connected)
                    {
                        enableClient[i].Send(Configs.Encoding.GetBytes(cmd));
                    }

                }
                catch (Exception) { }
            }
        }

        public void Dispose()
        {
            serverSocket?.Close();
            serverSocket = null;
            for (int i = 0; i < Clients.Count; i++)
            {
                try
                {
                    Clients[i].Close();
                    Clients[i] = null;
                }
                catch (Exception) { }
            }
            try
            {
                receiveThread?.Abort();
            }
            catch (Exception) { }
            try
            {
                myThread?.Abort();
            }
            catch (Exception) { }

            serverSocket?.Dispose();


        }
    }
    public delegate void MessageReceive(string msg);
}
