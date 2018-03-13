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

namespace client
{
    public partial class Form1 : Form
    {
        Socket client;
        byte[] data;
        IPEndPoint ipServer;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            string text = textBox2.Text;
            data = new byte[1024];
            data = Encoding.ASCII.GetBytes(text);
            textBox2.Text = "";
            listBox1.Items.Add(text);
            client.Send(data);
            data = new byte[1024];
            client.Receive(data);
            text = Encoding.ASCII.GetString(data);
            listBox1.Items.Add(text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ipServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipServer);
        }
    }
}
