using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        TcpClient client;
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.88.131"), Convert.ToInt32("1025"));
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {

                
                client = new TcpClient();
                client.Connect(endPoint);
                var nstream = client.GetStream();
                StreamReader sr = new StreamReader(nstream, Encoding.Unicode);
                string s = sr.ReadLine();
                textBox1.Text = s;
                nstream.Close();


                //NetworkStream networkStream = client.GetStream();
                //byte[] barray = Encoding.Unicode.GetBytes(textBox1.Text);
                //networkStream.Write(barray, 0, barray.Length);
                client.Close();

            }
            catch (SocketException sockEx)
            {
                MessageBox.Show("Ошибка сокета:" + sockEx.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка:" + Ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(client!=null)
            client.Close();
            this.Close();
        }
    }
}
