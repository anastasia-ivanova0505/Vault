using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multicast
{
    public partial class ServerMulticast : Form
    {
        static string message = "Hello my dear friend!";
        static int Interval = 5000;
        static void multicastSend()
        {
            while (true)
            {
                Thread.Sleep(Interval);
                Socket soc = new Socket
                    (AddressFamily.InterNetwork,
                    SocketType.Dgram,
                    ProtocolType.Udp);
                soc.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
                IPAddress dest = IPAddress.Parse("224.5.5.5");
                soc.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(dest));
               
                IPEndPoint ipep = new IPEndPoint(dest, 4567);
                soc.Connect(ipep);
                soc.Send(Encoding.Default.GetBytes(message));
                soc.Close();
            }
        }
        Thread Sender = new Thread(new ThreadStart(multicastSend));
        public ServerMulticast()
        {
            InitializeComponent();
            Sender.IsBackground = true;
            Sender.Start();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            message = richTextBox1.Text;
        }
    }
}
