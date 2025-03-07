using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadshine;

namespace 缝纫机项目
{
    internal class VM通讯
    {
        public static 客户端类 客户端 = new 客户端类();
        public static bool tcpok;
        public static Socket socketk;

        public static bool TCP初始化()
        {
            string ip = "127.0.0.1";
            string port = "8888";
            //客户端类 客户端 = new 客户端类();
            Form主界面 主界面 = (Form主界面)Application.OpenForms["Form主界面"];
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

        public static double[] 接收信息拆解(string message)
        {
            double[] result = new double[2];
            char[] delimiterChars = { ';' };
            string[] parts = message.Split(delimiterChars);
            double distance = Convert.ToDouble(parts[0]);
            double num = Convert.ToDouble(parts[1]);
            result[0] = distance;
            result[1] = num;
            return result;
        }

        public static void 发送(string str)
        {
            客户端.发送(VM通讯.socketk, str);
        }


    }

    public class 测量值
    {
        public static double 距离(string message)
        {
            return VM通讯.接收信息拆解(message)[0];
        }

        public static double 剪口数(string message)
        {
            return VM通讯.接收信息拆解(message)[1];
        }
    }
}
