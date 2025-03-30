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

        public static (double 平均距离1, int 数量1, int 数量2, double 平均距离2, int 数量3, int 数量4) 接收信息拆解(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("输入消息不能为空", nameof(message));

            string[] parts = message.Split(';');

            //if (parts.Length != 6)
            //    throw new FormatException("输入格式错误，应包含六个值（d1;d2;n1;d3;d4;n2）");

            double.TryParse(parts[0], out double d1);
            int.TryParse(parts[1], out int n1);
            int.TryParse(parts[2], out int n2);
            double.TryParse(parts[3], out double d2);
            int.TryParse(parts[4], out int n3);
            int.TryParse(parts[5], out int n4);


            return (d1, n1, n2, d2, n3, n4);
        }

        //public static (double 平均距离1, int 数量1) 接收信息拆解(string message)
        //{

        //    string[] parts = message.Split(';');

        //    double.TryParse(parts[0], out double d1);
        //    double.TryParse(parts[1], out double d2);
        //    int.TryParse(parts[2], out int n1);
        //    //double.TryParse(parts[3], out double d3);
        //    //double.TryParse(parts[4], out double d4);
        //    //int.TryParse(parts[5], out int n2);

        //    double 平均距离1 = (d1 + d2) / 2;
        //    //double 平均距离2 = (d3 + d4) / 2;

        //    return (平均距离1, n1);
        //}

        public static void 发送(string str)
        {
            客户端.发送(VM通讯.socketk, str);
        }


    }

    public class 测量值
    {
        public static double 距离(string message)
        {
            return VM通讯.接收信息拆解(message).平均距离1;
        }

        public static double 剪口数(string message)
        {
            return VM通讯.接收信息拆解(message).数量1;
        }

        public static double 距离X(string message)
        {
            return VM通讯.接收信息拆解(message).平均距离2;
        }

        public static double 剪口数X(string message)
        {
            return VM通讯.接收信息拆解(message).数量3;
        }

        public static double 二次剪口数(string message)
        {
            return VM通讯.接收信息拆解(message).数量2;
        }

        public static double 二次剪口数X(string message)
        {
            return VM通讯.接收信息拆解(message).数量4;
        }
    }
}
