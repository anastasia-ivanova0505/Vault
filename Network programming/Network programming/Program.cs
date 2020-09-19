using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Network_programming
{
    class Program
    {
        static readonly TcpListener server = new TcpListener(IPAddress.Parse("192.168.88.131"), Convert.ToInt32("1025"));
        static void Main(string[] args)
        {
            try {
                
                Thread thread = new Thread(new ThreadStart(ThreadFun))
                {
                    IsBackground = true
                };
                thread.Start();
                server.Start();
                Console.WriteLine("Server is running");
                Console.ReadKey();
            }
            catch (SocketException sockEx)
            {
                Console.WriteLine(sockEx.Message);
            }   
    }
    
      static void ThreadFun()
      { 
            while (true)
            {
                if (server.Pending())
                {
                    var client = server.AcceptTcpClient();
                    //var task = Task.Run(() =>
                    //{
                          var nstream = client.GetStream();
                          byte[] barray = Encoding.Unicode.GetBytes("This is..");
                          nstream.Write(barray, 0, barray.Length);
                        nstream.Close();
                    //});
                    client.Close();


                    //StreamReader sr = new StreamReader(
                    //cl.GetStream(), Encoding.Unicode
                    //);
                    //string s = sr.ReadLine();
                    //Console.WriteLine(s);
                    
                    //if (s.ToUpper() == "EXIT")
                    //{
                    //    server.Stop();
                    //}
                }
            }
      }
    }
}
