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
    public class SClient : IDisposable
    {

        private Socket serverSocket { get; set; }
        public static event MessageReceive MessageReceiveEvent;
        private Thread myThread { get; set; }
        private Thread receiveThread { get; set; }
        public SClient( )
        {
            IPAddress ip = IPAddress.Parse(Configs.IP);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Connect(new IPEndPoint(ip, Configs.Port));
            MessageReceiveEvent?.Invoke($"连接{serverSocket.LocalEndPoint.ToString()}成功");

            receiveThread = new Thread(ReceiveMessage);
            receiveThread.IsBackground = true;
            receiveThread.Start();

        }




        /// <summary> 
        /// 接收消息 
        /// </summary> 
        /// <param name="clientSocket"></param> 
        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] result = new byte[1024 * 1024 * 10];
                    //通过clientSocket接收数据 
                    int receiveNumber = serverSocket.Receive(result);
                    if (receiveNumber > 0)
                    {
                        var content = Configs.Encoding.GetString(result);
                        MessageReceiveEvent?.Invoke(content);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    serverSocket.Close();
                }
            }

        }
        public void SendMessage(string cmd)
        {
            serverSocket.Send(Configs.Encoding.GetBytes(cmd));



        }

        public void Dispose()
        {
            serverSocket?.Close();
            serverSocket = null;
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
}
