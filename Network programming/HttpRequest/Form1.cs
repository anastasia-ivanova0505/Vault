using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpRequest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(textBox1.Text);
                req.Method = "Get";
                if (checkBox1.Checked)
                {
                    WebProxy proxy = new WebProxy(textBox2.Text);
                    proxy.Credentials = new NetworkCredential(textBox3.Text, textBox4.Text);
                    req.Proxy = proxy;
                }
                HttpWebResponse rez = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(rez.GetResponseStream(), Encoding.Default);
                textBox5.Text = sr.ReadToEnd();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
