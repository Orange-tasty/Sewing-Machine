using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

using NPOI.XSSF.UserModel; // 用于.xlsx格式  
using NPOI.SS.UserModel;
using NPOI.SS.Formula.Functions;

namespace 缝纫机项目
{

    public class 工艺测试
    {
        //客户端类 客户端 = new 客户端类();

        public static double 距离 = 0;
        public static double 剪口数 = 0;
        public static double 距离X = 0;
        public static double 剪口数X = 0;
        public static double 二次剪口数 = 0;
        public static double 二次剪口数X = 0;
        public static double 长度 = 0;
        public static double 长度X = 0;
        public static double 配方_上Dis = 500;
        public static double 配方_下Dis = 500;

        public static double[] 配方_上电机变化脉冲 = new double[8] { 100, 101, 102, 103, 104, 105, 106, 107 };
        public static double[] 配方_下电机变化脉冲 = new double[8] { 200, 201, 202, 203, 204, 205, 206, 207 };

        public static double 配方_中值电压 = 0;
        public static double 配方_中值位移 = 0;

        public static double 配方_左1电压变化 = 0;
        public static double 配方_左2电压变化 = 0;
        public static double 配方_左3电压变化 = 0;
        public static double 配方_右1电压变化 = 0;
        public static double 配方_右2电压变化 = 0;
        public static double 配方_右3电压变化 = 0;

        public static double 配方_左1斜率 = 0;
        public static double 配方_左2斜率 = 0;
        public static double 配方_左3斜率 = 0;
        public static double 配方_右1斜率 = 0;
        public static double 配方_右2斜率 = 0;
        public static double 配方_右3斜率 = 0;

        public static double 配方_中值电压X = 0;
        public static double 配方_中值位移X = 0;

        public static double 配方_左1电压变化X = 0;
        public static double 配方_左2电压变化X = 0;
        public static double 配方_左3电压变化X = 0;
        public static double 配方_右1电压变化X = 0;
        public static double 配方_右2电压变化X = 0;
        public static double 配方_右3电压变化X = 0;

        public static double 配方_左1斜率X = 0;
        public static double 配方_左2斜率X = 0;
        public static double 配方_左3斜率X = 0;
        public static double 配方_右1斜率X = 0;
        public static double 配方_右2斜率X = 0;
        public static double 配方_右3斜率X = 0;


        public static double 配方_X1 = 1;
        public static double 配方_X2 = 1;
        public static double 配方_X3 = 1;

        public static double 配方_V = 10;
        public static double 配方_A1 = 5;
        public static double 配方_B1 = 5;
        public static double 配方_C1 = 5;
        public static double 配方_A2 = 5;
        public static double 配方_B2 = 5;
        public static double 配方_C2 = 5;
        public static double 配方_A3 = 5;
        public static double 配方_B3 = 5;
        public static double 配方_C3 = 5;

        public static double 配方_X1_X = 1;
        public static double 配方_X2_X = 1;
        public static double 配方_X3_X = 1;

        public static double 配方_V_X = 10;
        public static double 配方_A1_X = 5;
        public static double 配方_B1_X = 5;
        public static double 配方_C1_X = 5;
        public static double 配方_A2_X = 5;
        public static double 配方_B2_X = 5;
        public static double 配方_C2_X = 5;
        public static double 配方_A3_X = 5;
        public static double 配方_B3_X = 5;
        public static double 配方_C3_X = 5;

        ////pid
        //public static double 配方_上A = 0;
        //public static double 配方_上B = 0;
        //public static double 配方_上C = 0;
        //public static double 配方_上P = 0;
        //public static double 配方_上I = 0;
        //public static double 配方_上D = 0;
        //public static double 配方_上V = 0;

        //public static double 配方_下A = 0;
        //public static double 配方_下B = 0;
        //public static double 配方_下C = 0;
        //public static double 配方_下P = 0;
        //public static double 配方_下I = 0;
        //public static double 配方_下D = 0;
        //public static double 配方_下V = 0;

        //pid20240201_配方方案修改
        public static 配方参数P 配方_上A = new 配方参数P("配方_上A", "配方_上A", 1);
        public static 配方参数P 配方_上B = new 配方参数P("配方_上B", "配方_上B", 0.01);
        public static 配方参数P 配方_上C = new 配方参数P("配方_上C", "配方_上C", 1);
        public static 配方参数P 配方_上P = new 配方参数P("配方_上P", "配方_上P", 3000);
        public static 配方参数P 配方_上I = new 配方参数P("配方_上I", "配方_上I", 0.05);
        public static 配方参数P 配方_上D = new 配方参数P("配方_上D", "配方_上D", 0.1);
        public static 配方参数P 配方_上V = new 配方参数P("配方_上V", "配方_上V", 0);
        //public static 配方参数P 配方_上Dis = new 配方参数P("配方_上Dis", "配方_上Dis", 530);

        public static 配方参数P 配方_下A = new 配方参数P("配方_下A", 0);
        public static 配方参数P 配方_下B = new 配方参数P("配方_下B", 0);
        public static 配方参数P 配方_下C = new 配方参数P("配方_下C", 0);
        public static 配方参数P 配方_下P = new 配方参数P("配方_下P", 0);
        public static 配方参数P 配方_下I = new 配方参数P("配方_下I", 0);
        public static 配方参数P 配方_下D = new 配方参数P("配方_下D", 0);
        public static 配方参数P 配方_下V = new 配方参数P("配方_下V", 0);
        //public static 配方参数P 配方_下Dis = new 配方参数P("配方_下Dis", 0);

        //剪口20240108//20240201_配方方案修改
        public static 配方参数P 配方_上剪口数量 = new 配方参数P("配方_上剪口数量", 10);
        public static 配方参数P 配方_上最后剪口后针数 = new 配方参数P("配方_上最后剪口后针数", 5);
        //public static 配方参数P 配方_上剪口电机速度 = new 配方参数P("配方_上剪口电机速度", 100);
        //public static 配方参数P 配方_上剪口电机速度系数 = new 配方参数P("配方_上剪口电机速度系数", 1);
        //public static 配方参数P 配方_上剪口电机速度比例 = new 配方参数P("配方_上剪口电机速度比例", 1);

        public static 配方参数P 配方_上剪口电机基础速度 = new 配方参数P("配方_上剪口电机基础速度", 100);
        public static 配方参数P 配方_上剪口缝纫机修正比例 = new 配方参数P("配方_上剪口缝纫机修正比例", 50);
        public static 配方参数P 配方_上剪口差修正比例 = new 配方参数P("配方_上剪口电机速度比例", 1);
        public static 配方参数P 配方_上剪口差基本值 = new 配方参数P("配方_上剪口差基本值", 1);

        public static 配方参数P 配方_下剪口数量 = new 配方参数P("配方_下剪口数量", 10);
        public static 配方参数P 配方_下最后剪口后针数 = new 配方参数P("配方_下最后剪口后针数", 5);
        //public static 配方参数P 配方_下剪口电机速度 = new 配方参数P("配方_下剪口电机速度", 100);
        //public static 配方参数P 配方_下剪口电机速度系数 = new 配方参数P("配方_下剪口电机速度系数", 1);
        //public static 配方参数P 配方_下剪口电机速度比例 = new 配方参数P("配方_下剪口电机速度比例", 1);

        public static 配方参数P 配方_下剪口电机基础速度 = new 配方参数P("配方_下剪口电机基础速度", 100);
        public static 配方参数P 配方_下剪口缝纫机修正比例 = new 配方参数P("配方_下剪口缝纫机修正比例", 50);
        public static 配方参数P 配方_下剪口差修正比例 = new 配方参数P("配方_下剪口差修正比例", 1);
        public static 配方参数P 配方_下剪口差基本值 = new 配方参数P("配方_下剪口差基本值", 1);

        public static 配方参数P 配方_总针数 = new 配方参数P("配方_总针数", 0);
        public static 配方参数P 配方_尾针数 = new 配方参数P("配方_尾针数", 0);

        public static List<配方参数P> 配方_尾针表 = new List<配方参数P>();
        public static List<配方参数P> 配方_尾针表X = new List<配方参数P>();

        public static 配方参数P 配方_回针针距 = new 配方参数P("配方_回针针距", 0);

        public static 配方参数P 配方_针数后识别剪口 = new 配方参数P("配方_针数后识别剪口", 0);
        public static 配方参数P 配方_识别剪口间隔针数 = new 配方参数P("配方_识别剪口间隔针数", 0);
        public static 配方参数P 配方_电缸压下脉冲数 = new 配方参数P("配方_电缸压下脉冲数", 0);

        ////剪口20240108
        //public static double 配方_上剪口数量 = 10;
        //public static double 配方_上最后剪口后针数 = 5;
        //public static double 配方_上剪口电机速度 = 100;
        //public static double 配方_上剪口电机速度系数 = 1.0;
        //public static double 配方_上剪口电机速度比例 = 1;//20240126

        //public static double 配方_下剪口数量 = 10;
        //public static double 配方_下最后剪口后针数 = 5;
        //public static double 配方_下剪口电机速度 = 100;
        //public static double 配方_下剪口电机速度系数 = 1.0;
        //public static double 配方_下剪口电机速度比例 = 1;//20240126

        //public static double 配方_总针数 = 0;
        //public static double 配方_尾针数 = 0;

        //public static double[] 配方_尾针表 = new double[20];
        //public static double[] 配方_尾针表X = new double[20];

        //public static double 配方_回针针距 = 0;

        public static System.Diagnostics.Stopwatch _生产数据_工艺计时 = new Stopwatch();

        public ushort step = 0;
        public static int 已执行针数 = 0;
        public static int 目标针数;
        public static bool 修改目前针数 = false;
       // public int 脉冲数 = (int)配方_电缸压下脉冲数.Value;

        public static List<double> 上传感器记录 = new List<double>();
        public static List<double> 下传感器记录 = new List<double>();

        //public static double 上剪口_剪口计数 = 0;

        public static 剪口 上剪口 = new 剪口("上剪口", 10, GLV._上剪口传感器, GLV._缝纫机编码器);
        public static 剪口 下剪口 = new 剪口("下剪口", 10, GLV._下剪口传感器, GLV._缝纫机编码器);

        public static 剪口 二次上剪口 = new 剪口("二次上剪口", 10, GLV._上剪口传感器, GLV._缝纫机编码器);
        public static 剪口 二次下剪口 = new 剪口("二次下剪口", 10, GLV._下剪口传感器, GLV._缝纫机编码器);

        //public static S系统参数 _缝纫机初始工作电压 = new S系统参数("缝纫机工作电压", "NULL", 2.4, "伏特", "V", GLV._参数类型_系统参数, GLV._低权限);
        //public static S系统参数 _缝纫机最大工作电压 = new S系统参数("缝纫机最大工作电压", "NULL", 5, "伏特", "V", GLV._参数类型_系统参数, (ushort)用户.权限选择.高级权限);

        public static S系统参数 _缝纫机初始工作转速 = new S系统参数("缝纫机初始工作转速", "NULL", 300, "转/分钟", "r/min", GLV._参数类型_系统参数, GLV._低权限);
        public static S系统参数 _缝纫机最大工作转速 = new S系统参数("缝纫机最大工作转速", "NULL", 1200, "转/分钟", "r/min", GLV._参数类型_系统参数, (ushort)用户.权限选择.高级权限);
        public static S系统参数 _缝纫机最小工作转速 = new S系统参数("缝纫机最小工作转速", "NULL", 100, "转/分钟", "r/min", GLV._参数类型_系统参数, (ushort)用户.权限选择.高级权限);

        public static S系统参数 _缝纫机工作转速变化 = new S系统参数("缝纫机工作转速变化", "NULL", 100, "转/分钟", "r/min", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限);

        public static S系统参数 _初次下针时编码器位置 = new S系统参数("初次下针时编码器位置", "NULL", 100, "脉冲", "pulse", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限);

        public static S系统参数 _上电机速度上限 = new S系统参数("上电机速度上限", "NULL", 10000, "脉冲/秒", "pul/s", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限);
        public static S系统参数 _上电机速度下限 = new S系统参数("上电机速度下限", "NULL", 300, "脉冲/秒", "pul/s", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限);
        public static S系统参数 _下电机速度上限 = new S系统参数("下电机速度上限", "NULL", 20000, "脉冲/秒", "pul/s", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限);
        public static S系统参数 _下电机速度下限 = new S系统参数("下电机速度下限", "NULL", 20000, "脉冲/秒", "pul/s", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限);

        public static S系统参数 _上剪口电机速度上限 = new S系统参数("上剪口电机速度上限", "NULL", 2000, "脉冲/秒", "pul/s", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限);
        public static S系统参数 _上剪口电机速度下限 = new S系统参数("上剪口电机速度下限", "NULL", -2000, "脉冲/秒", "pul/s", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限);
        public static S系统参数 _下剪口电机速度上限 = new S系统参数("下剪口电机速度上限", "NULL", 2000, "脉冲/秒", "pul/s", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限);
        public static S系统参数 _下剪口电机速度下限 = new S系统参数("下剪口电机速度下限", "NULL", -2000, "脉冲/秒", "pul/s", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限);



        public static S系统参数 _上下电机气缸动作延时 = new S系统参数("上下电机气缸动作延时", "NULL", 1000, "毫秒", "ms", GLV._参数类型_系统参数, (ushort)用户.权限选择.高级权限);
        public static S系统参数 _上下电机气缸回位延时 = new S系统参数("上下电机气缸回位延时", "NULL", 700, "毫秒", "ms", GLV._参数类型_系统参数, (ushort)用户.权限选择.高级权限);

        public static S系统参数 _直线气缸动作延时 = new S系统参数("直线气缸动作延时", "NULL", 1000, "毫秒", "ms", GLV._参数类型_系统参数, (ushort)用户.权限选择.高级权限);
        public static S系统参数 _直线气缸回位延时 = new S系统参数("直线气缸回位延时", "NULL", 600, "毫秒", "ms", GLV._参数类型_系统参数, (ushort)用户.权限选择.高级权限);
       
        public static S系统参数 _回针电机速度 = new S系统参数("回针电机速度", "NULL", 1000, "脉冲/秒", "pul/s", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限);

        public static S系统参数 _缝纫机编码器细分 = new S系统参数("缝纫机编码器细分", "NULL", 1440, "脉冲/圈", "pul/r", GLV._参数类型_系统参数, GLV._高权限);//不显示到参数界面

        public static S系统参数 _对剪口功能使能 = new S系统参数("对剪口功能使能", "NULL", 1, "选择", "choose", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限,"0:关闭/1:开启","NULL");

        public static S系统参数 _发送功能使能 = new S系统参数("发送功能使能", "NULL", 1, "选择", "choose", GLV._参数类型_系统参数, (ushort)用户.权限选择.中级权限, "0:关闭/1:开启", "NULL");

        public static S系统参数 _PID的KI累计 = new S系统参数("PID的KI累计", "NULL", 20, "个数", "num", GLV._参数类型_系统参数, (ushort)用户.权限选择.高级权限);

        public static S系统参数 _PID的延迟针数 = new S系统参数("PID的延迟针数", "NULL", 5, "个数", "num", GLV._参数类型_系统参数, (ushort)用户.权限选择.高级权限);

        public static PIDtest 上电机PID = new PIDtest();
        public static PIDtest 下电机PID = new PIDtest();

        public static void GGG()
        {
            //MainProgram.TH上电机速度调节.Init(配方_V, 配方_A1, 配方_B1, 配方_C1, 配方_A2, 配方_B2, 配方_C2, 配方_A3, 配方_B3, 配方_C3);
            //MainProgram.TH上电机速度调节.run = true;

            //MainProgram.TH下电机速度调节.Init(配方_V_X, 配方_A1_X, 配方_B1_X, 配方_C1_X, 配方_A2_X, 配方_B2_X, 配方_C2_X, 配方_A3_X, 配方_B3_X, 配方_C3_X);
            //MainProgram.TH下电机速度调节.run = true;
        }

        double 编码器阈值 = 10;
        double 编码器计数值 = 0;
        int 编码器停下后计数 = 0;

        public bool 对剪口运行 = false;
        public bool 二次对剪口运行 = false;
        public bool 二次剪口检测 = true;
        public bool 上距离 = true;
        public bool 下距离 = true;
        int num1 = 0;
        int num2 = 0;
        double x1 = 0, x2 = 0;
        //public static async Task<bool> 等待数据接收(int 超时时间ms)
        //{
        //    Stopwatch 计时器 = Stopwatch.StartNew();
        //    int 检测间隔 = 5;

        //    while (计时器.Elapsed.TotalMilliseconds < 超时时间ms)
        //    {
        //        if (Volatile.Read(ref VM通讯.客户端.m_x) != null)
        //        {
        //            return true;
        //        }
        //        await Task.Delay(检测间隔);
        //    }
        //    return false;
        //}

        private Stopwatch stopwatch = new Stopwatch();
        // 
        private (double 平均距离1, int 数量1, int 数量2, double 平均距离2, int 数量3, int 数量4) _lastData = (0, 0, 0, 0, 0, 0);

        public enum STEP
        {
            默认,
            编码器位置清零,
            缝纫机初始化,
            开始回针动作,
            气缸动作1,
            等待气缸动作1,           
            缝纫机启动,
            缝纫机工作,
            缝纫机进入尾针,
            气缸动作2,
            等待气缸动作2,
            缝纫机进入回针,
            缝纫机回针动作,
            缝纫机回针等待,
            缝纫机回针完成,
            结束
        }

        public static void Delay(int milliSecond)
        {
            //int start = Environment.TickCount;
            //while (Math.Abs(Environment.TickCount - start) < milliSecond)
            //{
            //    Application.DoEvents();
            //}

            var sw = System.Diagnostics.Stopwatch.StartNew();
            while (sw.Elapsed.TotalMilliseconds < milliSecond)
            {
                // 可选：降低CPU占用
                Thread.SpinWait(100);
            }

        }

        public static SnapThread sendThread = new SnapThread();

        public async void 工艺流程()
        {
            Form主界面 主界面 = (Form主界面)Application.OpenForms["Form主界面"];
            while (true)
            {
                if (可运行条件())
                {

                    switch (step)
                    {
                        case (ushort)STEP.默认:
                            break;

                        case (ushort)STEP.编码器位置清零:
                            Task任务.信息输出("启动！");

                            运动控制.反馈位置清零(0, GLV._缝纫机编码器);
                            已执行针数 = 0;

                            step = (ushort)STEP.缝纫机初始化;
                            break;

                        case (ushort)STEP.缝纫机初始化:
                            Task任务.信息输出("缝纫机初始化");
                            缝纫机.待机();
                            step = (ushort)STEP.开始回针动作;
                            break;

                        case (ushort)STEP.开始回针动作:
                            //Task任务.信息输出("开始回针动作");
                            //IO控制.OUT(0, GLV._上拐弯电机气缸, GLV.OFF);
                            //IO控制.OUT(0, GLV._下拐弯电机气缸, GLV.ON);

                            //运动控制.点位运动(0, GLV._下剪口电机, 8000, 0.02, -2000, 1);

                            //缝纫机.控制(缝纫机转速标定.已知转速求电压(_缝纫机初始工作转速.Value));
                            double 当前编码器位置 = 运动控制.反馈位置(0, GLV._缝纫机编码器);
                            //if (当前编码器位置 >= _缝纫机编码器细分.Value * 已执行针数)
                            //{
                            //    已执行针数++;
                            //    //数据采集.采集(已执行针数);   //20240201
                            //}
                            ////if (已执行针数 >= 3 && 已执行针数 < 5)
                            ////{
                            ////    IO控制.OUT(0, GLV._上拐弯电机气缸, GLV.ON);
                            ////    IO控制.OUT(0, GLV._下拐弯电机气缸, GLV.OFF);
                            ////}
                            //if (已执行针数 >= 5)
                            //{
                            //    Thread.Sleep((int)_上下电机气缸动作延时.Value);
                            //    Task任务.信息输出("开始回针结束");
                            //    缝纫机.待机();
                            //    step = (ushort)STEP.气缸动作1;
                            //}
                            step = (ushort)STEP.气缸动作1;
                            break;

                        case (ushort)STEP.气缸动作1:
                            Task任务.信息输出("气缸动作");
                            IO控制.OUT(0, GLV._上拐弯电机气缸, GLV.OFF);
                            IO控制.OUT(0, GLV._下拐弯电机气缸, GLV.ON);

                            step = (ushort)STEP.等待气缸动作1;
                            break;

                        case (ushort)STEP.等待气缸动作1:
                            Thread.Sleep((int)_上下电机气缸动作延时.Value);

                            运动控制.反馈位置清零(0, GLV._缝纫机编码器);
                            已执行针数 = 0;

                            step = (ushort)STEP.缝纫机启动;
                            // 20240723，把缝纫机启动放到这个步骤中
                            //缝纫机.控制(缝纫机转速标定.已知转速求电压(_缝纫机初始工作转速.Value));

                            Task任务.信息输出("缝纫机启动,转速:"+ _缝纫机初始工作转速+",电压:"+ 缝纫机转速标定.已知转速求电压(_缝纫机初始工作转速.Value));

                            上电机PID.Start();
                            下电机PID.Start();
                            Task任务.信息输出("PID启动");

                            break;

                        case (ushort)STEP.缝纫机启动:
                            //double 当前电压 = 模拟量.输入(0, GLV._上传感器);
                            ////double pos = 电压位置计算(当前电压);

                            //double 当前电压X = 模拟量.输入(0, GLV._下传感器);
                            //double posX = 电压位置计算X(当前电压X);

                            //Console.WriteLine("pos:" + pos);
                            //Console.WriteLine("posX:" + posX);

                            当前编码器位置 = 运动控制.反馈位置(0, GLV._缝纫机编码器);
                            if (当前编码器位置 >= _初次下针时编码器位置.Value)
                            {
                                //TimerDispos.CreateAndStartTimer();
                                //VM通讯.客户端.m_x = null;
                                //VM通讯.发送("snap");
                                //bool 是否收到数据 = await SnapThread.等待数据接收(120); 
                                //if (是否收到数据)
                                //{
                                //    if (VM通讯.接收信息拆解Try(VM通讯.客户端.m_x, out var data))
                                //    {
                                //        _lastData = data;
                                //    }
                                //    else
                                //    {
                                //        Task任务.信息输出("接收信息错误");
                                //        data = _lastData;
                                //    }
                                //    距离 = data.平均距离1;
                                //    剪口数 = data.数量1;
                                //    距离X = data.平均距离2;
                                //    剪口数X = data.数量3;
                                //    //距离 = 测量值.距离(VM通讯.客户端.m_x);
                                //    //剪口数 = 测量值.剪口数(VM通讯.客户端.m_x);
                                //    //距离X = 测量值.距离X(VM通讯.客户端.m_x);
                                //    //剪口数X = 测量值.剪口数X(VM通讯.客户端.m_x);
                                //    VM通讯.客户端.m_x = null;
                                //}
                                

                                Task任务.信息输出("达到初次下针时编码器位置");
                                运动控制.反馈位置清零(0, GLV._缝纫机编码器);

                                double tim = 花费时间();
                                //Console.WriteLine(tim);

                                //double pos = 0 * 缝纫机.当前转速() + 上电机PID.Func(配方_上A.Value, 配方_上B.Value, 配方_上C.Value, 配方_上P.Value, 配方_上I.Value, 配方_上D.Value, 距离 - 配方_上V.Value, _上电机速度上限.Value, _上电机速度下限.Value);                                
                                //double posX = 0 * 缝纫机.当前转速() + 下电机PID.Func(配方_下A.Value, 配方_下B.Value, 配方_下C.Value, 配方_下P.Value, 配方_下I.Value, 配方_下D.Value, 距离X - 配方_下V.Value, _下电机速度上限.Value, _下电机速度下限.Value);
                                //double pos = 上电机PID.Func(配方_上A.Value, 配方_上B.Value, 配方_上C.Value, 配方_上P.Value, 配方_上I.Value, 配方_上D.Value, 当前电压 - 配方_上V.Value, _上电机速度上限.Value, _上电机速度下限.Value);
                                //double posX = 下电机PID.Func(配方_下A.Value, 配方_下B.Value, 配方_下C.Value, 配方_下P.Value, 配方_下I.Value, 配方_下D.Value, 当前电压X - 配方_下V.Value, _下电机速度上限.Value, _下电机速度下限.Value);

                                //Task任务.信息输出("当前上电机速度为" + pos.ToString());
                                //单轴速度控制(GLV._上电机, pos);
                                //单轴速度控制(GLV._下电机, posX);

                                Task任务.信息输出("缝纫机工作");
                                ///////////////////20250428/////////////////////////////
                                sendThread.Start();
                                已执行针数++;
                                

                                目标针数 = (int)配方_总针数.Value;

                                对剪口运行 = false;
                                double vel1 = 0;
                                double vel2 = 0;
                                vel1 = 剪口电机速度.速度计算(配方_上剪口电机基础速度.Value, 配方_上剪口缝纫机修正比例.Value, 缝纫机.当前转速(), 0, 配方_上剪口差修正比例.Value, 配方_上剪口差基本值.Value, _上剪口电机速度上限.Value, _上剪口电机速度下限.Value);
                                vel2 = 剪口电机速度.速度计算(配方_下剪口电机基础速度.Value, 配方_下剪口缝纫机修正比例.Value, 缝纫机.当前转速(), 0, 配方_下剪口差修正比例.Value, 配方_下剪口差基本值.Value, _下剪口电机速度上限.Value, _下剪口电机速度下限.Value);
                                //vel2 = 配方_下剪口电机速度.Value;

                                //单轴速度控制(GLV._上剪口电机, vel1);
                                //单轴速度控制(GLV._下剪口电机, vel2);

                                数据采集.清零();//20240201

                                step = (ushort)STEP.缝纫机工作;
                            }
                            break;

                        case (ushort)STEP.缝纫机工作:
                            //当前电压 = 模拟量.输入(0, GLV._上传感器);
                            ////pos = PIDtest.Func(配方_上A.Value, 配方_上B.Value, 配方_上C.Value, 配方_上P.Value, 配方_上I.Value, 配方_上D.Value, 当前电压 - 配方_上V.Value, _上电机速度上限.Value, _上电机速度下限.Value);

                            //当前电压X = 模拟量.输入(0, GLV._下传感器);
                            //posX = PIDtest.Func(配方_下A.Value, 配方_下B.Value, 配方_下C.Value, 配方_下P.Value, 配方_下I.Value, 配方_下D.Value, 当前电压X - 配方_下V.Value, _下电机速度上限.Value, _下电机速度下限.Value);

                            if (已执行针数 < (目标针数 - 配方_尾针数.Value))
                            {
                                //    if (_发送功能使能.Value == 1)
                                //    {
                                //        VM通讯.客户端.m_x = null;
                                //        VM通讯.发送("snap");
                                //        bool 是否收到数据 = await SnapThread.等待数据接收(120);
                                //        if (是否收到数据)
                                //        {
                                //            if (VM通讯.接收信息拆解Try(VM通讯.客户端.m_x, out var data))
                                //            {
                                //                _lastData = data;
                                //            }
                                //            else
                                //            {
                                //                Task任务.信息输出("接收信息错误");
                                //                data = _lastData;
                                //            }
                                //            距离 = data.平均距离1;
                                //            剪口数 = data.数量1;
                                //            距离X = data.平均距离2;
                                //            剪口数X = data.数量3;
                                //            二次剪口数 = data.数量2;
                                //            二次剪口数X = data.数量4;
                                //            //距离 = 测量值.距离(VM通讯.客户端wwd.m_x);
                                //            //剪口数 = 测量值.剪口数(VM通讯.客户端.m_x);
                                //            //距离X = 测量值.距离X(VM通讯.客户端.m_x);
                                //            //剪口数X = 测量值.剪口数X(VM通讯.客户端.m_x);
                                //            //二次剪口数 = 测量值.二次剪口数(VM通讯.客户端.m_x);
                                //            //二次剪口数X = 测量值.二次剪口数X(VM通讯.客户端.m_x);
                                //            VM通讯.客户端.m_x = null;
                                //        }
                                //        _发送功能使能.Value = 0;
                                //    }
                                ///////////////////20240108/////////////////////////////
                                if (_对剪口功能使能.Value == 1 && 已执行针数 >= 配方_针数后识别剪口.Value)//对剪口功能是否启用//20250507
                                //if (_对剪口功能使能.Value == 1 && 已执行针数 >= 19)
                                {
                                    bool re1 = 上剪口.ACT剪口检测((uint)配方_上剪口数量.Value, 剪口数);
                                    bool re2 = 下剪口.ACT剪口检测((uint)配方_下剪口数量.Value, 剪口数X);
                                    
                                    //bool re1 = 上剪口.ACT剪口检测((uint)配方_上剪口数量.Value);
                                    //bool re2 = 下剪口.ACT剪口检测((uint)配方_下剪口数量.Value);

                                    if (上剪口.剪口计数 == 1 && 上距离)
                                    {
                                        x1 = 工艺测试.长度;
                                        num1 = 已执行针数;
                                        上距离 = false;
                                    }

                                    if (下剪口.剪口计数 == 1 && 下距离)
                                    {
                                        x2 = 工艺测试.长度X;
                                        num2 = 已执行针数;
                                        下距离 = false;
                                    }

                                    if ((!re1 || !re2) && !修改目前针数)
                                    {
                                        目标针数 = (int)(已执行针数 + 配方_上最后剪口后针数.Value + 配方_尾针数.Value);
                                        Task任务.信息输出("目标针数从总针数" + 配方_总针数.Value + "针改为" + 目标针数 + "针");                                        
                                        修改目前针数 = true;
                                    }

                                    if (上剪口.剪口计数 == 下剪口.剪口计数 && 上剪口.剪口计数 > 0)
                                    {                                      
                                        if (!对剪口运行)
                                        {
                                            二次剪口检测 = false;
                                            对剪口运行 = true;


                                            //double 差值 = 上剪口.ACT剪口位置计算(上剪口.剪口计数) - 下剪口.ACT剪口位置计算(下剪口.剪口计数);
                                            double 差值 = 上剪口.ACT剪口位置获取(上剪口.剪口计数) - 下剪口.ACT剪口位置获取(下剪口.剪口计数);
                                            double 距离差 = x1 - x2 + (num2 - num1) * 3;
                                            Task任务.信息输出("距离差" + 距离差 + "qitashu" + x1 + ","+ x2 + "," + num1 + ","+ num2);
                                            //x1 = 0 ; x2 = 0; num1 = 0 ; num2 = 0 ;
                                            //double 差值 = (上剪口.剪口冷却位置 - 下剪口.剪口冷却位置);
                                            //Task任务.信息输出("第" + 上剪口.剪口计数 + "个剪口的上下差值:" + 差值);
                                            double vel1 = 0;
                                            double vel2 = 0;
                                            double t1 = 0;
                                            double t2 = 0;



                                            if (距离差 >= 0)
                                            {
                                                t2 = 剪口电机速度.时间计算(缝纫机.当前转速(), 差值, 1);
                                                单轴位置控制(GLV._下剪口电机, t2, 差值, (int)配方_电缸压下脉冲数.Value);
                                                Task任务.信息输出("第" + 上剪口.剪口计数 + "个剪口的上下差值:" + 距离差 + "mm。要压下的时间为:" + (int)t2 + " ms");
                                                //vel1 = 剪口电机速度.速度计算(配方_上剪口电机基础速度.Value, 配方_上剪口缝纫机修正比例.Value, 缝纫机.当前转速(), 0, 配方_上剪口差修正比例.Value, 配方_上剪口差基本值.Value, _上剪口电机速度上限.Value, _上剪口电机速度下限.Value);
                                                //vel2 = 剪口电机速度.速度计算(配方_下剪口电机基础速度.Value, 配方_下剪口缝纫机修正比例.Value, 缝纫机.当前转速(), -差值, 配方_下剪口差修正比例.Value, 配方_下剪口差基本值.Value, _下剪口电机速度上限.Value, _下剪口电机速度下限.Value);

                                            }
                                            else
                                            {
                                                
                                                //vel1 = 剪口电机速度.速度计算(配方_上剪口电机基础速度.Value, 配方_上剪口缝纫机修正比例.Value, 缝纫机.当前转速(), 差值, 配方_上剪口差修正比例.Value, 配方_上剪口差基本值.Value, _上剪口电机速度上限.Value, _上剪口电机速度下限.Value);
                                                //vel2 = 剪口电机速度.速度计算(配方_下剪口电机基础速度.Value, 配方_下剪口缝纫机修正比例.Value, 缝纫机.当前转速(), 0, 配方_下剪口差修正比例.Value, 配方_下剪口差基本值.Value, _下剪口电机速度上限.Value, _下剪口电机速度下限.Value);
                                            }

                                            

                                            //double pos = 上电机PID.Func(配方_上A.Value, 配方_上B.Value, 配方_上C.Value, 配方_上P.Value, 配方_上I.Value, 配方_上D.Value, 距离 - 配方_上Dis, _上电机速度上限.Value, _上电机速度下限.Value);
                                            //double posX = 下电机PID.Func(配方_下A.Value, 配方_下B.Value, 配方_下C.Value, 配方_下P.Value, 配方_下I.Value, 配方_下D.Value, 距离X - 配方_下V.Value, _下电机速度上限.Value, _下电机速度下限.Value)
                                            //vel1 = 剪口电机速度.速度计算(配方_上剪口电机基础速度.Value, 配方_上剪口缝纫机修正比例.Value, 缝纫机.当前转速(), 0, 配方_上剪口差修正比例.Value, 配方_上剪口差基本值.Value, _上剪口电机速度上限.Value, _上剪口电机速度下限.Value);
                                            //单轴速度控制(GLV._上剪口电机, vel1);
                                            //单轴速度控制(GLV._下剪口电机, vel2);

                                            //Task任务.信息输出("第" + 上剪口.剪口计数 + "个剪口的上下差值:" + 差值 + "。此时上剪口电机速度改为:" + vel1 + " ,下剪口电机速度改为:" + vel2);
                                            
                                        }
                                        //if (!二次剪口检测)
                                        //{
                                        //    bool dre1 = 二次上剪口.ACT剪口检测((uint)配方_上剪口数量.Value, 二次剪口数);
                                        //    bool dre2 = 二次下剪口.ACT剪口检测((uint)配方_下剪口数量.Value, 二次剪口数X);
                                        //    if (二次上剪口.剪口计数 == 二次下剪口.剪口计数 && 二次上剪口.剪口计数 > 0)
                                        //    {
                                        //        if (!二次对剪口运行)
                                        //        {
                                        //            二次对剪口运行 = true;

                                        //            double 差值 = 二次上剪口.ACT剪口位置获取(二次上剪口.剪口计数) - 二次下剪口.ACT剪口位置获取(二次下剪口.剪口计数);

                                        //            double t1 = 0;
                                        //            double t2 = 0;

                                        //            if (差值 >= 0)
                                        //            {


                                        //            }
                                        //            else
                                        //            {
                                        //                //t2 = 剪口电机速度.时间计算(缝纫机.当前转速(), -差值, 1);          
                                        //            }
                                        //            Task任务.信息输出("修改后的差值为" + 差值.ToString());
                                        //            //Task任务.信息输出("t2=" + t2.ToString());
                                        //            //单轴位置控制(GLV._下剪口电机, t2);


                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        二次对剪口运行 = false;
                                        //    }
                                        //}
                                    }                                   
                                    else
                                    {
                                        //double vel1 = 剪口电机速度.速度计算(配方_上剪口电机基础速度.Value, 配方_上剪口缝纫机修正比例.Value, 缝纫机.当前转速(), 0, 配方_上剪口差修正比例.Value, 配方_上剪口差基本值.Value, _上剪口电机速度上限.Value, _上剪口电机速度下限.Value);
                                        //double vel2 = 剪口电机速度.速度计算(配方_下剪口电机基础速度.Value, 配方_下剪口缝纫机修正比例.Value, 缝纫机.当前转速(), 0, 配方_下剪口差修正比例.Value, 配方_下剪口差基本值.Value, _下剪口电机速度上限.Value, _下剪口电机速度下限.Value);
                                        //单轴速度控制(GLV._上剪口电机, vel1);
                                        //单轴速度控制(GLV._下剪口电机, vel2);
                                        对剪口运行 = false;
                                    }
                                }
                                else    //对剪口使能始终为true,不会进
                                {
                                    //double vel1 = 剪口电机速度.速度计算(配方_上剪口电机基础速度.Value, 配方_上剪口缝纫机修正比例.Value, 缝纫机.当前转速(), 0, 配方_上剪口差修正比例.Value, 配方_上剪口差基本值.Value, _上剪口电机速度上限.Value, _上剪口电机速度下限.Value);
                                    //double vel2 = 剪口电机速度.速度计算(配方_下剪口电机基础速度.Value, 配方_下剪口缝纫机修正比例.Value, 缝纫机.当前转速(), 0, 配方_下剪口差修正比例.Value, 配方_下剪口差基本值.Value, _下剪口电机速度上限.Value, _下剪口电机速度下限.Value);
                                    //单轴速度控制(GLV._上剪口电机, vel1);
                                    //单轴速度控制(GLV._下剪口电机, vel2);
                                }
                                ///////////////20240108///////////////////

                                当前编码器位置 = 运动控制.反馈位置(0, GLV._缝纫机编码器);
                                if (当前编码器位置 >= _缝纫机编码器细分.Value * 已执行针数)
                                {
                                    //double pos = 上电机PID.Func(配方_上A.Value, 配方_上B.Value, 配方_上C.Value, 配方_上P.Value, 配方_上I.Value, 配方_上D.Value, 配方_上V.Value - 距离, _上电机速度上限.Value, _上电机速度下限.Value);
                                    //double pos = 0 * 缝纫机.当前转速() + 上电机PID.Func(配方_上A.Value, 配方_上B.Value, 配方_上C.Value, 配方_上P.Value, 配方_上I.Value, 配方_上D.Value, 距离 - 配方_上V.Value, _上电机速度上限.Value, _上电机速度下限.Value);
                                    //double posX = 0 * 缝纫机.当前转速() + 下电机PID.Func(配方_下A.Value, 配方_下B.Value, 配方_下C.Value, 配方_下P.Value, 配方_下I.Value, 配方_下D.Value, 距离X - 配方_下V.Value, _下电机速度上限.Value, _下电机速度下限.Value);
                                    //double pos = 上电机PID.Func(配方_上A.Value, 配方_上B.Value, 配方_上C.Value, 配方_上P.Value, 配方_上I.Value, 配方_上D.Value, 当前电压 - 配方_上V.Value, _上电机速度上限.Value, _上电机速度下限.Value);
                                    //double posX = 下电机PID.Func(配方_下A.Value, 配方_下B.Value, 配方_下C.Value, 配方_下P.Value, 配方_下I.Value, 配方_下D.Value, 当前电压X - 配方_下V.Value, _下电机速度上限.Value, _下电机速度下限.Value);
                                    //Task任务.信息输出("距离为" + 距离X.ToString());
                                    //Task任务.信息输出("当前电机速度为" + posX.ToString());

                                    //PID控制
                                    //单轴速度控制(GLV._上电机, pos);
                                    //单轴速度控制(GLV._下电机, posX);

                                    已执行针数++;

                                    //_发送功能使能.Value = 1;

                                    数据采集.采集(已执行针数);//20240201
                                }
                                //20240201曲线记录
                            }
                            else
                            {
                                Task任务.信息输出("进入尾针阶段");
                                sendThread.Stop();
                                step = (ushort)STEP.缝纫机进入尾针;

                                对剪口运行 = false;
                                二次对剪口运行 = false;
                                二次剪口检测 = true;
                            }


                            //step = 3;

                            break;
                        case (ushort)STEP.缝纫机进入尾针:
                            if (已执行针数 < (目标针数))
                            {
                                if (运动控制.反馈位置(0, GLV._缝纫机编码器) >= _缝纫机编码器细分.Value * 已执行针数)
                                {
                                    //运动控制.反馈位置清零(0, GLV._缝纫机编码器);

                                    //double tim = 花费时间();
                                    // Console.WriteLine(tim);
                                    
                                    double pos = 配方_尾针表[(int)(配方_尾针数.Value - (目标针数 - 已执行针数))].Value;
                                    double posX = 配方_尾针表[(int)(配方_尾针数.Value - (目标针数 - 已执行针数))].Value;

                                    单轴速度控制(GLV._上电机, pos);
                                    单轴速度控制(GLV._下电机, posX);

                                    已执行针数++; 
                                    数据采集.采集(已执行针数);//20240201

                                }

                            }
                            else
                            {
                                工艺测试.上剪口.ACT清除();//20240108
                                工艺测试.下剪口.ACT清除();//20240108
                                工艺测试.二次上剪口.ACT清除();
                                工艺测试.二次下剪口.ACT清除();
                                修改目前针数 = false;

                                运动控制.轴全部停止(0);//20230522
                                Task任务.信息输出("尾针动作完成");

                                数据采集.输出();//20240201

                                step = (ushort)STEP.气缸动作2;
                                  
                            }


                            //step = 4;
                            break;
                        case (ushort)STEP.气缸动作2:
                            /////////////////////////////////////////////////////////////信息输出
                            //string[] msg = new string[GLV._分析信息列表.Count];
                            //for (int i = 0; i < GLV._分析信息列表.Count; i++)
                            //{
                            //    msg[i] = GLV._分析信息列表[i].Date + "," + GLV._分析信息列表[i].time + "," + GLV._分析信息列表[i].G1 + "," + GLV._分析信息列表[i].G2 + "," + GLV._分析信息列表[i].G3 + "," + GLV._分析信息列表[i].Vel + "," + GLV._分析信息列表[i].Count;

                            //}
                            //TXT文件管理.数据保存(GLV._默认地址_分析信息, msg);


                            //string[] msgX = new string[GLV._分析信息列表X.Count];
                            //for (int i = 0; i < GLV._分析信息列表X.Count; i++)
                            //{
                            //    msgX[i] = GLV._分析信息列表X[i].Date + "," + GLV._分析信息列表X[i].time + "," + GLV._分析信息列表X[i].G1 + "," + GLV._分析信息列表X[i].G2 + "," + GLV._分析信息列表X[i].G3 + "," + GLV._分析信息列表X[i].Vel + "," + GLV._分析信息列表X[i].Count;

                            //}
                            //TXT文件管理.数据保存(GLV._默认地址_分析信息X, msgX);
                            ///////////////////////////////////////////////////////////
                            缝纫机.待机();

                            IO控制.OUT(0, GLV._上拐弯电机气缸, GLV.ON);
                            IO控制.OUT(0, GLV._下拐弯电机气缸, GLV.OFF);
                            IO控制.OUT(0, GLV._上直线电机气缸, GLV.OFF);

                            已执行针数 = 0;

                            step = (ushort)STEP.等待气缸动作2;
                            break;


                        case (ushort)STEP.等待气缸动作2:

                            double delay_time = 0;
                            if (_直线气缸动作延时.Value > _上下电机气缸回位延时.Value)
                            {
                                delay_time = _直线气缸动作延时.Value;
                            }
                            else
                            {
                                delay_time = _上下电机气缸回位延时.Value;
                            }

                            Thread.Sleep((int)delay_time);

                            step = (ushort)STEP.缝纫机进入回针;
                            break;


                        case (ushort)STEP.缝纫机进入回针:

                            缝纫机.回针();

                            编码器计数值 = 运动控制.反馈位置(0, GLV._缝纫机编码器);
                            编码器停下后计数 = 0;
                            step = (ushort)STEP.缝纫机回针动作;

                            break;

                        case (ushort)STEP.缝纫机回针动作:


                            if (缝纫机停下())
                            {
                                
                                if (编码器停下后计数 > 15)
                                {
                                    编码器停下后计数 = 0;
                                    step = (ushort)STEP.缝纫机回针等待;
                                    Task任务.信息输出("回针编码器停下");
                                }
                                else
                                {
                                    //Task任务.信息输出("检测到回针编码器停下计数" + 编码器停下后计数);
                                    编码器停下后计数++;
                                    Thread.Sleep(50);
                                }
                                
                            }
                            else
                            {
                                编码器停下后计数 = 0;

                            }
                            

                            break;
                        case (ushort)STEP.缝纫机回针等待:
                            Thread.Sleep(200);
                            step = (ushort)STEP.缝纫机回针完成;

                            break;

                        case (ushort)STEP.缝纫机回针完成:

                            IO控制.OUT(0, GLV._上直线电机气缸, GLV.ON);
                            缝纫机.待机();

                            Thread.Sleep((int)_直线气缸回位延时.Value);

                            step = (ushort)STEP.结束;
                            break;

                        case (ushort)STEP.结束:
                            Task任务.信息输出("缝纫机动作完成");

                            MainProgram._程序状态 = 6;
                            step = (ushort)STEP.默认;
                            break;


                        default:
                            Task任务.系统输出("缝纫机工艺跳转异常:" + step + ",请停机检查");
                            break;
                    }

                }
                else
                {
                    
                }
            }

        }

        public bool 可运行条件()
        {
            if (MainProgram._程序状态 == 5)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private double 合速度(double vel1,double vel2)
        {
            double t1 = Math.Pow(vel1, 2) + Math.Pow(vel2, 2);
            return Math.Sqrt(t1);
        }
        


        private double 电压位置计算(double 电压)
        {
            double x0 = 0;
            double y0 = 0;

            double xl1 = 0;
            double xl2 = 0;
            double xl3 = 0;
            double xr1 = 0;
            double xr2 = 0;
            double xr3 = 0;

            double yl1 = 0;
            double yl2 = 0;
            double yl3 = 0;
            double yr1 = 0;
            double yr2 = 0;
            double yr3 = 0;

            double value = 0;

            x0 = 配方_中值电压;
            y0 = 配方_中值位移;

            xl1 = x0 + 配方_左1电压变化;
            yl1 = y0 + 配方_左1斜率 * 配方_左1电压变化;

            xl2 = xl1 + 配方_左2电压变化;
            yl2 = yl1 + 配方_左2斜率 * 配方_左2电压变化;

            xl3 = xl2 + 配方_左3电压变化;
            yl3 = yl2 + 配方_左3斜率 * 配方_左3电压变化;


            xr1 = x0 + 配方_右1电压变化;
            yr1 = y0 + 配方_右1斜率 * 配方_右1电压变化;

            xr2 = xr1 + 配方_右2电压变化;
            yr2 = yr1 + 配方_右2斜率 * 配方_右2电压变化;

            xr3 = xr2 + 配方_右3电压变化;
            yr3 = yr2 + 配方_右3斜率 * 配方_右3电压变化;

            if (电压 < 配方_中值电压)
            {
                if (电压 >= xl1)
                {
                    value = 配方_中值电压 + (电压 - 配方_中值电压) * 配方_左1斜率;
                }
                else if (电压 >= xl2)
                {
                    value = xl1 + (电压 - xl1) * 配方_左2斜率;
                }
                else if (电压 >= xl3)
                {
                    value = xl2 + (电压 - xl2) * 配方_左3斜率;
                }
                else
                {
                    //错误
                }
            }
            else if (电压 > 配方_中值电压)
            {
                if (电压 <= xr1)
                {
                    value = 配方_中值电压 + (电压 - 配方_中值电压) * 配方_右1斜率;
                }
                else if (电压 <= xr2)
                {
                    value = xr1 + (电压 - xr1) * 配方_右2斜率;
                }
                else if (电压 <= xr3)
                {
                    value = xr2 + (电压 - xr2) * 配方_右3斜率;
                }
                else
                {
                    //错误
                }
            }
            else
            {
                value = 配方_中值位移;
            }

            return value;
        }


        private double 电压位置计算X(double 电压)
        {
            double x0 = 0;
            double y0 = 0;

            double xl1 = 0;
            double xl2 = 0;
            double xl3 = 0;
            double xr1 = 0;
            double xr2 = 0;
            double xr3 = 0;

            double yl1 = 0;
            double yl2 = 0;
            double yl3 = 0;
            double yr1 = 0;
            double yr2 = 0;
            double yr3 = 0;

            double value = 0;

            x0 = 配方_中值电压X;
            y0 = 配方_中值位移X;

            xl1 = x0 + 配方_左1电压变化X;
            yl1 = y0 + 配方_左1斜率X * 配方_左1电压变化X;

            xl2 = xl1 + 配方_左2电压变化X;
            yl2 = yl1 + 配方_左2斜率X * 配方_左2电压变化X;

            xl3 = xl2 + 配方_左3电压变化X;
            yl3 = yl2 + 配方_左3斜率X * 配方_左3电压变化X;


            xr1 = x0 + 配方_右1电压变化X;
            yr1 = y0 + 配方_右1斜率X * 配方_右1电压变化X;

            xr2 = xr1 + 配方_右2电压变化X;
            yr2 = yr1 + 配方_右2斜率X * 配方_右2电压变化X;

            xr3 = xr2 + 配方_右3电压变化X;
            yr3 = yr2 + 配方_右3斜率X * 配方_右3电压变化X;

            if (电压 < 配方_中值电压X)
            {
                if (电压 >= xl1)
                {
                    value = 配方_中值电压X + (电压 - 配方_中值电压X) * 配方_左1斜率X;
                }
                else if (电压 >= xl2)
                {
                    value = xl1 + (电压 - xl1) * 配方_左2斜率X;
                }
                else if (电压 >= xl3)
                {
                    value = xl2 + (电压 - xl2) * 配方_左3斜率X;
                }
                else
                {
                    //错误
                }
            }
            else if (电压 > 配方_中值电压X)
            {
                if (电压 <= xr1)
                {
                    value = 配方_中值电压X + (电压 - 配方_中值电压X) * 配方_右1斜率X;
                }
                else if (电压 <= xr2)
                {
                    value = xr1 + (电压 - xr1) * 配方_右2斜率X;
                }
                else if (电压 <= xr3)
                {
                    value = xr2 + (电压 - xr2) * 配方_右3斜率X;
                }
                else
                {
                    //错误
                }
            }
            else
            {
                value = 配方_中值位移X;
            }

            return value;
        }


        

        /// <summary>
        /// TRUE:缝纫机已经停下
        /// FALSE:缝纫机还在运行中
        /// </summary>
        /// <returns></returns>
        private bool 缝纫机停下()
        {
            if (编码器计数值 <= (运动控制.反馈位置(0, GLV._缝纫机编码器) + 编码器阈值) && 编码器计数值 >= (运动控制.反馈位置(0, GLV._缝纫机编码器) - 编码器阈值))
            {
                return true;
                //Thread.Sleep(100);
            }
            else
            {
                编码器计数值 = 运动控制.反馈位置(0, GLV._缝纫机编码器);

                return false;
            }

        }

        public static double 花费时间()
        {
            if (_生产数据_工艺计时 != null)
            {
                _生产数据_工艺计时.Stop();
                TimeSpan timespan = _生产数据_工艺计时.Elapsed;
                GLV._整条线动作时间 = timespan.TotalMilliseconds;

                _生产数据_工艺计时.Reset();
                _生产数据_工艺计时.Start();

            }
            return GLV._整条线动作时间;
        }

        public static void 单轴速度控制(ushort 轴号,double 速度)
        {
            if (运动控制.运动状态(0, 轴号))
            {
                if (速度 > 0)
                {
                    运动控制.定速运动(0, 轴号, 速度, 0.02, 1);
                }
                else
                {
                    运动控制.定速运动(0, 轴号, -速度, 0.02, 0);
                }
            }
            else
            {
                运动控制.在线变速(0, 轴号, 速度, 0.002);
            }
        }


        private async void 单轴位置控制(ushort 轴号, double 时间, double 差值, int 脉冲)
        {
            if (运动控制.运动状态(0, 轴号))
            {
                if(差值 > 1440 || 差值 < -1440)
                {
                    运动控制.点位运动(0, 轴号, 30000, 0.02, 脉冲, 1);
                    await Task.Delay((int)时间);  // 异步延迟，不阻塞主线程
                    运动控制.点位运动(0, 轴号, 30000, 0.02, 0, 1);
                }             
            }
        }


        private int step上 = 0;
        private int step下 = 0;
        private void 剪口监视0()
        {
            double new编码器位置 = 运动控制.反馈位置(0, GLV._缝纫机编码器);
            if (!IO控制.IN(0, GLV._上剪口传感器) && step上 == 0)
            {
                step上 = 1;
                上传感器记录.Add(new编码器位置);
                Console.WriteLine("up-on:"+ new编码器位置);
            }
            if (IO控制.IN(0, GLV._上剪口传感器) && step上 == 1)
            {
                step上 = 0;
                上传感器记录.Add(new编码器位置);
                Console.WriteLine("up-off:" + new编码器位置);
            }
            
            
            if (!IO控制.IN(0, GLV._下剪口传感器) && step下 == 0)
            {
                step下 = 1;
                下传感器记录.Add(new编码器位置);
                Console.WriteLine("down-on:" + new编码器位置);
            }
            if (IO控制.IN(0, GLV._下剪口传感器) && step下 == 1)
            {
                step下 = 0;
                下传感器记录.Add(new编码器位置);
                Console.WriteLine("down-off:" + new编码器位置);
            }
        }

        private void 剪口监视清除0()
        {
            上传感器记录.Clear();
            下传感器记录.Clear();
        }
    }










    public class 数据采集
    {
        public static List<double> 上电压 = new List<double>();
        public static List<double> 下电压 = new List<double>();

        public static List<double> 上电机速度 = new List<double>();
        public static List<double> 下电机速度 = new List<double>();

        public static List<int> 针数 = new List<int>();
        public static void 采集(int num)
        {
            针数.Add(num);
            上电压.Add(模拟量.输入(0, GLV._上传感器));
            下电压.Add(模拟量.输入(0, GLV._下传感器));
            上电机速度.Add(运动控制.当前速度(0, GLV._上电机));
            下电机速度.Add(运动控制.当前速度(0, GLV._下电机));
            
        }
        public static void 清零()
        {
            针数.Clear();
            上电压.Clear();
            下电压.Clear();
            上电机速度.Clear();
            下电机速度.Clear();
            
        }
        public static void 输出()
        {
            
            string time = "_" + System.DateTime.Now.Year + "_" + System.DateTime.Now.Month + "_" + System.DateTime.Now.Day
                + "_" + System.DateTime.Now.Hour + "_" + System.DateTime.Now.Minute + "_" + System.DateTime.Now.Second;

            string inipath = GLV._默认地址_系统文件夹 + "\\数据采集" + time + ".xlsx";
            if (!File.Exists(inipath))
            {

                // 创建一个新的Excel工作簿  
                IWorkbook workbook = new XSSFWorkbook(); // 创建.xlsx格式的Excel工作簿  
                ISheet sheet1 = workbook.CreateSheet("Sheet1"); // 创建一个新的工作表  

                IRow headrow = sheet1.CreateRow(0); // 创建首行
                headrow.CreateCell(0).SetCellValue("针数");
                headrow.CreateCell(1).SetCellValue("上电压");
                headrow.CreateCell(2).SetCellValue("下电压");
                headrow.CreateCell(3).SetCellValue("上电机速度");
                headrow.CreateCell(4).SetCellValue("下电机速度");       // 

                for (int i = 1; i < 针数.Count; i++)
                {
                    IRow row = sheet1.CreateRow(i); // 创建行  
                    row.CreateCell(0).SetCellValue(针数[i]);
                    row.CreateCell(1).SetCellValue(上电压[i]);
                    row.CreateCell(2).SetCellValue(下电压[i]);
                    row.CreateCell(3).SetCellValue(上电机速度[i]);
                    row.CreateCell(4).SetCellValue(下电机速度[i]);
                }

                using (FileStream file = new FileStream(inipath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(file); // 将工作簿写入文件流中  
                }
                //Console.WriteLine("Excel file created successfully!");

            }


        }
        
    }



}






