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
        public static byte[] bt = new byte[1024];
        static bool isrec = false;

        static void Main(string[] args)
        {
            Console.WriteLine("server start: ....");
            string ip = "127.0.0.1";
            byte[] buffer = new byte[1024];

            IPAddress ipAddress = IPAddress.Parse(ip);
            Socket a = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipe = new IPEndPoint(ipAddress, 6666);
            a.Bind(ipe);
            a.Listen(5);
            Socket b = a.Accept();


            Console.WriteLine("accept a client: ....");

            Thread pp = new Thread(Program.sendmessage);
            pp.Start(b);


            for (int i = 10; i < 30; i++)
            {
                Console.WriteLine(i);
                byte[] position = Class1.InttoByteArray(i);
                try
                {
                    b.Send(position);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            Thread newsendmsg = new Thread(Program.sendmsg);
            newsendmsg.Start(b);

            Console.ReadKey();
            b.Close();
            a.Close();
        }

        public static void sendmessage(object s)
        {
            isrec = true;
            Socket b = (Socket)s;
            int rec = b.Receive(bt, 4, 0);
            int recint = Class1.ByteArraytoInt(bt);
            Console.WriteLine(recint);
            Thread.Sleep(50);
        }

        public static void sendmsg(object s)
        {
            Socket b = (Socket)s;

            while (true)
            {
                if (!isrec)
                {
                    try
                    {
                        b.Send(bt);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                if(!b.Connected)
                {
                    Console.WriteLine("client is lost");
                }
            }
        }
    }
}
