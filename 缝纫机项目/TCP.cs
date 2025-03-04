using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 缝纫机项目
{

    internal class 客户端类
    {
        public static bool tcpok;
        public string m_x;
        Socket socket;
        IPEndPoint iPEndPoint;

        /// <summary>
        /// 返回客户端 socket 对象
        /// </summary>
        public Socket 客户端Socket()
        {
            return socket;
        }

        /// <summary>
        /// 连接到指定 IP 和端口的服务器
        /// </summary>
        public Socket 连接(string ip, string port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse(ip);
            iPEndPoint = new IPEndPoint(iPAddress, int.Parse(port));

            try
            {
                socket.Connect(iPEndPoint);
            }
            catch (Exception)
            {
                MessageBox.Show("连接失败", "提示");
                socket = null;
            }
            return socket;
        }

        /// <summary>
        /// 检查指定的 socket 是否连接
        /// </summary>
        public bool 检查连接(Socket socket)
        {
            TcpClient tcp = new TcpClient();
            tcp.Client = socket;
            bool b1 = tcp.Connected;
            return b1;
        }

        /// <summary>
        /// 从指定 socket 接收数据，返回接收到的字符串
        /// </summary>
        public string 接收(Socket socketClieent1)
        {
            string read = null;
            int 字节数 = 0;
            int a = socketClieent1.Available;
            byte[] 字节流 = new byte[a];
            try
            {
                字节数 = socketClieent1.Receive(字节流);
            }
            catch (Exception)
            {
                // 捕获异常
            }
            if (字节数 == 0)
            {
                // 无数据
            }
            else
            {
                string 接收内容 = Encoding.UTF8.GetString(字节流, 0, 字节数);
                read = 接收内容;
            }
            return read;
        }

        /// <summary>
        /// 向指定 socket 发送字符串数据
        /// </summary>
        public void 发送(Socket socket, string str)
        {
            if (socket != null && socket.Connected)
            {
                socket.Send(Encoding.UTF8.GetBytes(str));
            }
        }
        public static bool TCP初始化()
        {
            string ip = "127.0.0.1";
            string port = "8888";
            Socket socketk;
            客户端类 客户端 = new 客户端类();
            Form主界面 主界面 = new Form主界面();
            socketk = 客户端.连接(ip, port);
            if (socketk != null)
            {
                tcpok = true;//表示连接状态
                Thread readk = new Thread(主界面.客户端接收);//创建客户端接收线程
                readk.IsBackground = true;//设置为后台线程
                readk.Start(socketk);//启动线程
            }
            return tcpok;
        }
    }

    public class 服务器类
    {
        Socket socket;
        Dictionary<string, Socket> dic1 = new Dictionary<string, Socket>();
        Dictionary<string, Thread> dic2 = new Dictionary<string, Thread>();
        string ips;
        string read;
        string rsip;

        /// <summary>
        /// 返回服务器 socket 对象
        /// </summary>
        public Socket 服务器ip()
        {
            return socket;
        }

        /// <summary>
        /// 启动服务器，绑定指定 IP 和端口，并开始监听客户端连接
        /// </summary>
        public void 服务器(string ip, string port, out Socket socketf)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, int.Parse(port));
            try
            {
                socket.Bind(iPEndPoint);
                socket.Listen(10);
                socketf = socket;
                Thread threadClient = new Thread(监听);
                threadClient.IsBackground = true;
                threadClient.Start();
            }
            catch (Exception)
            {
                socketf = null;
            }
        }

        /// <summary>
        /// 检查指定 IP 对应的客户端连接状态
        /// </summary>
        public bool ip连接状态(string str)
        {
            bool a = dic1[str].Poll(0, SelectMode.SelectRead);
            return a;
        }

        /// <summary>
        /// 监听客户端连接，接收到客户端后启动接收线程
        /// </summary>
        public void 监听()
        {
            while (true)
            {
                try
                {
                    Socket socketClieent = socket.Accept();
                    string strClient = socketClieent.RemoteEndPoint.ToString();
                    dic1.Add(strClient, socketClieent);
                    ips = strClient;
                    Thread readThread = new Thread(接收);
                    readThread.IsBackground = true;
                    readThread.Start(socketClieent);
                    dic2.Add(strClient, readThread);
                }
                catch (Exception)
                {
                    // 异常处理
                }
            }
        }

        /// <summary>
        /// 获取最新接入的客户端 IP，返回后清空临时变量
        /// </summary>
        public string 接入ip()
        {
            string str = null;
            if (ips != null)
            {
                str = ips;
                ips = null;
                return str;
            }
            return str;
        }

        /// <summary>
        /// 清空客户端列表
        /// </summary>
        public void dix1_Clear()
        {
            dic1.Clear();
        }

        /// <summary>
        /// 返回当前接入的 IP（暂存变量）
        /// </summary>
        public string ip()
        {
            return ips;
        }

        /// <summary>
        /// 向指定 IP 的客户端发送字符串数据
        /// </summary>
        public void 发送(string str, string ip)
        {
            try
            {
                dic1[ip].Send(Encoding.UTF8.GetBytes(str));
            }
            catch (Exception)
            {
                // 异常处理
            }
        }

        /// <summary>
        /// 关闭服务器，结束所有客户端线程并关闭所有连接
        /// </summary>
        public void 服务器关闭()
        {
            foreach (string item in dic2.Keys)
            {
                dic2[item].Abort();
            }
            foreach (string item in dic1.Keys)
            {
                dic1[item].Close();
            }
        }

        /// <summary>
        /// 客户端数据接收线程执行方法
        /// </summary>
        public void 接收(object soc)
        {
            while (true)
            {
                Socket socketread = soc as Socket;
                string ip = socketread.RemoteEndPoint.ToString();
                int 字节数 = 0;
                int a = socketread.Available;
                byte[] 字节流 = new byte[a];
                try
                {
                    字节数 = socketread.Receive(字节流);
                }
                catch (Exception)
                {
                    // 异常处理
                }
                if (字节数 != 0)
                {
                    string 接收内容 = ip + " " + Encoding.UTF8.GetString(字节流, 0, 字节数);
                    read = 接收内容;
                }
                TcpClient tcp = new TcpClient();
                tcp.Client = dic1[ip];
                bool b1 = tcp.Connected;
                if (b1 == false)
                {
                    rsip = ip;
                    Thread strint = dic2[ip];
                    dic2.Remove(ip);
                    strint.Abort();
                }
            }
        }

        /// <summary>
        /// 获取接收到的数据，并清空保存变量
        /// </summary>
        public string 接收数据()
        {
            string str = read;
            read = null;
            return str;
        }

        /// <summary>
        /// 获取异常断开的客户端 IP（返回后清空变量）
        /// </summary>
        public string 异常断开ip()
        {
            string str = null;
            if (rsip != null)
            {
                str = rsip;
                rsip = null;
                return str;
            }
            return str;
        }

        
    }
}
