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
    public partial class Form1 : Form
    {
        IPEndPoint ipep;
        Socket newsock;
        Socket client;
        byte[] data;
        
        public Form1()
        {

            InitializeComponent();
            ipep = new IPEndPoint(IPAddress.Any, 9050);
            newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(ipep);
            newsock.Listen(10);
            client = newsock.Accept();
            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add(Encoding.ASCII.GetString(data));
            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
            textBox1.Text = clientep.Address.ToString();
           
        }

        

        private void btnSend_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            listBox1.Items.Add(text);
            textBox2.Text = "";
            data = new byte[1024];
            data = Encoding.ASCII.GetBytes(text);
            client.Send(data);
            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add(Encoding.ASCII.GetString(data));
        }
    }
}
