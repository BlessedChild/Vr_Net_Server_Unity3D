using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace ConsoleApp2
{
    class Program
    {
        public static byte[][] bt = new byte[2][] {new byte[1024], new byte[1024] }; //有[]多个byte[1024]
        public static byte[] bttemp = new byte[1024];
        public static byte[] handlerbuffer = new byte[1024];
        private static Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static Thread[] acceptClientList = new Thread[2];
        private static Thread[] sendClientList = new Thread[2];
        private static int acchose = 0;


        static bool isrec = false;

        static void Main(string[] args)
        {
            byte[] ToClient = new byte[112];
            byte bLoop;
            for (int ib = 0; ib < 2; ib++)
            {
                for (int i = 0; i < 56; i++)
                {
                    bLoop = bt[ib][i];
                    ToClient[ib * 56 + i] += bLoop;
                }
            }
            Thread service = new Thread(Program.listen_socket);
            service.Start();
            
            Console.ReadKey();
        }

        public static void listen_socket()
        {
            string ip = "192.168.15.155";
            Console.WriteLine("server:" + ip + " start working: ....");
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint ipe = new IPEndPoint(ipAddress, 6666);
            listenSocket.Bind(ipe);
            listenSocket.Listen(2);

            while (true)
            {
                for(int i = 0; i < 2; i++)
                {
                    Socket s = listenSocket.Accept(); //a.Accept()。执行这一句的时候，程序就在这个地方等待，直到有新的连接请求的时候程序才会执行下一句。这是同步执行，当然也可以异步执行
                    if(i == 0)
                    {
                        sendClientList[i] = new Thread(sendmsg);
                        sendClientList[i].Start(s);
                        acceptClientList[i] = new Thread(acceptmessage);
                        acceptClientList[i].Start(s);
                        Console.WriteLine("来自" + s.LocalEndPoint.ToString() + "连接了");
                    }
                    if(i == 1)
                    {
                        sendClientList[i] = new Thread(sendmsg);
                        sendClientList[i].Start(s);
                        acceptClientList[i] = new Thread(acceptmessage1);
                        acceptClientList[i].Start(s);
                        Console.WriteLine("来自" + s.LocalEndPoint.ToString() + "连接了");
                    }

                }
            }
        }

        
        public static void acceptmessage(object s)
        {
            Socket b = (Socket)s;
            while (true)
            {
                if (isrec = true)
                {
                    try
                    {
                        int rec = b.Receive(bttemp, 56, 0);
                        for (int v = 0; v < 56; v++)
                        {
                            bt[0][v] = bttemp[v];
                        }
                        string[] recint = Class1.ServerToClient_string(bt);
                        Console.WriteLine(recint[0]);
                        Console.WriteLine(recint[1]);
                        Thread.Sleep(10);
                        isrec = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public static void acceptmessage1(object s)
        {
            Socket b = (Socket)s;
            while (true)
            {
                if (isrec = true)
                {
                    try
                    {
                        int rec = b.Receive(bttemp, 56, 0);
                        for (int v = 0; v < 56; v++)
                        {
                            bt[1][v] = bttemp[v];
                        }
                        string[] recint = Class1.ServerToClient_string(bt);
                        Console.WriteLine(recint[0]);
                        Console.WriteLine(recint[1]);
                        Thread.Sleep(10);
                        isrec = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }


        public static void sendmsg(object s) //传入当前 所有已连接的Socket 数组
        {
            Socket ss = (Socket)s;
            while (true)
            {
                if (!isrec)
                {
                    try
                    {
                        handlerbuffer = Class1.ServerToClient_Byte(bt);
                        ss.Send(handlerbuffer);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    isrec = true;
                    Thread.Sleep(20);
                }
            }
        }
    }
}
