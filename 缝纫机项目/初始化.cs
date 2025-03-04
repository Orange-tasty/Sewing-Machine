using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace 缝纫机项目
{

    internal class 初始化
    {
        public static bool tcpok;
        public static bool _初始化完成 = false;
        public static Socket socketk;
        public static void F初始化()
        {
            try
            {
                F控制卡初始化();
                F设置初始化();
                FTCP初始化();
                _初始化完成 = true;
                ThreadPool.SetMinThreads(200, 200);

                Task任务.系统输出("初始化完成,当前为测试版程序7YR42IH87WE....");
                Task任务.系统输出("程序版本:" + Program.系统版本);
            }
            catch
            {
                MessageBox.Show("系统初始化失败,请重启!");
                _初始化完成 = false;

            }

            //数据库.所有内容(数据库.默认地址, "用户");
            //数据库.用户_增加用户("操作员", "", 0, 数据库.默认地址, 数据库.表名_用户);

        }

        private static void F控制卡初始化()
        {
            //载入控制卡
            bool bnum = 控制器.初始化();
            if (!bnum)
            {
                Task任务.系统输出("控制器连接失败,请检查！！！", "Connection failed,check please!!!");
            }
            else
            {
                Task任务.系统输出("控制器连接正常", "Connection successful!");
            }


            //控制卡固定参数
            运动控制.设置脉冲当量(0, GLV._上电机, 1);
            运动控制.设置脉冲当量(0, GLV._下电机, 1);
            运动控制.设置脉冲当量(0, GLV._上剪口电机, 1);
            运动控制.设置脉冲当量(0, GLV._下剪口电机, 1);

            运动控制.设置轴异常减速停止时间(0, GLV._上电机, 0.03);
            运动控制.设置轴异常减速停止时间(0, GLV._下电机, 0.03);
            运动控制.设置轴异常减速停止时间(0, GLV._上剪口电机, 0.05);
            运动控制.设置轴异常减速停止时间(0, GLV._下剪口电机, 0.05);

            //运动控制.设置报警有效电平(0, GLV._A划片轴, 0);
            //运动控制.设置报警有效电平(0, GLV._B划片轴, 0);

            //运动控制.设置插补异常减速停止时间(0, 0, 0.1);

        }



        private static void F设置初始化()
        {
            //MainProgram._当前用户 = GLV._操作员;
            //Task任务.系统输出("当前用户为操作员,权限有限", "Current user is operator");

            MainProgram._当前用户 = GLV._Admin;
            Task任务.系统输出("当前用户为管理员,测试中", "Current user is operator");

            Thread t1 = new Thread(Task任务.Thread1);
            t1.Priority = ThreadPriority.AboveNormal;
            t1.IsBackground = true;
            t1.Start();
            Thread t2 = new Thread(Task任务.Thread2);
            t2.Priority = ThreadPriority.AboveNormal;
            t2.IsBackground = true;
            t2.Start();

            Thread threadtimer1 = new Thread(Task任务.ThreadTimer);
            threadtimer1.Priority = ThreadPriority.Normal;
            threadtimer1.IsBackground = true;
            threadtimer1.Start();



            Thread th_test = new Thread(MainProgram.TH工艺测试.工艺流程);
            th_test.Priority = ThreadPriority.Normal;
            th_test.IsBackground = true;
            th_test.Start();

            Thread th_reset = new Thread(MainProgram.TH复位.工艺流程);
            th_reset.Priority = ThreadPriority.Normal;
            th_reset.IsBackground = true;
            th_reset.Start();

            Thread th_getspeed = new Thread(MainProgram.TH缝纫机转速标定.工艺流程);
            th_getspeed.Priority = ThreadPriority.Normal;
            th_getspeed.IsBackground = true;
            th_getspeed.Start();

            //Thread th_up = new Thread(MainProgram.TH上电机速度调节.Func);
            //th_up.Priority = ThreadPriority.Normal;
            //th_up.IsBackground = true;
            //th_up.Start();

            //Thread th_down = new Thread(MainProgram.TH下电机速度调节.FuncX);
            //th_down.Priority = ThreadPriority.Normal;
            //th_down.IsBackground = true;
            //th_down.Start();

            //Thread th0_0 = new Thread(MainProgram.THA划台流程.工艺流程);
            //th0_0.Priority = ThreadPriority.Normal;
            //th0_0.IsBackground = true;
            //th0_0.Start();
            //Thread th0_1 = new Thread(MainProgram.THB划台流程.工艺流程);
            //th0_1.Priority = ThreadPriority.Normal;
            //th0_1.IsBackground = true;
            //th0_1.Start();
            //Thread th0_2 = new Thread(MainProgram.TH顶升流程.工艺流程);
            //th0_2.Priority = ThreadPriority.Normal;
            //th0_2.IsBackground = true;
            //th0_2.Start();
            //Thread th0_3 = new Thread(MainProgram.TH复位流程.工艺流程);
            //th0_3.Priority = ThreadPriority.Normal;
            //th0_3.IsBackground = true;
            //th0_3.Start();
            //Thread th0_4 = new Thread(MainProgram.TH上料流程.工艺流程);
            //th0_4.Priority = ThreadPriority.Normal;
            //th0_4.IsBackground = true;
            //th0_4.Start();
            //Thread th0_5 = new Thread(MainProgram.TH下料流程.工艺流程);
            //th0_5.Priority = ThreadPriority.Normal;
            //th0_5.IsBackground = true;
            //th0_5.Start();
            //Thread th0_6 = new Thread(MainProgram.TH划片流程.工艺流程);
            //th0_6.Priority = ThreadPriority.Normal;
            //th0_6.IsBackground = true;
            //th0_6.Start();


        }

        public static bool TCP初始化()
        {
            string ip = "127.0.0.1";
            string port = "8888";
            //Socket socketk;
            客户端类 客户端 = new 客户端类();
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

        private static void FTCP初始化()
        {
            bool bnum = TCP初始化();
          
            if (!bnum)
            {
                Task任务.系统输出("VM连接失败,请检查！！！", "Connection failed,check please!!!");
            } 
            else
            {
                Task任务.系统输出("VM连接正常", "Connection successful!");
            }
        }
    }
}
