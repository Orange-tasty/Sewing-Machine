using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace 缝纫机项目
{
    //public class 速度调节
    //{
    //    private bool G1, G2, G3;
    //    private ushort Axis;


    //    public double V = 0;
    //    public double A1, B1, C1, A2, B2, C2, A3, B3, C3 = 0;
    //    public bool run = false;


    //    private ushort Y1 = 0, Y2 = 0, Y3 = 0, lastY1, lastY2, lastY3;
    //    private long LastTime, NowTime, Time;

    //    public void Init(double v, double a1, double b1, double c1, double a2, double b2, double c2, double a3, double b3, double c3)
    //    {
    //        V = v;
    //        A1 = a1;
    //        B1 = b1;
    //        C1 = c1;
    //        A2 = a2;
    //        B2 = b2;
    //        C2 = c2;
    //        A3 = a3;
    //        B3 = b3;
    //        C3 = c3;
    //    }

    //    public void Func()
    //    {
    //        while (true)
    //        {
    //            Axis = GLV._上电机;
    //            G1 = IO控制.IN(0, GLV._上电机感应1);
    //            G2 = IO控制.IN(0, GLV._上电机感应2);
    //            G3 = IO控制.IN(0, GLV._上电机感应3);

    //            //G1 = Form主界面.gg1;
    //            //G2 = Form主界面.gg2;
    //            //G3 = Form主界面.gg3;

    //            if (!run)
    //            {
    //                运动控制.单轴停止(0, Axis);
    //                Thread.Sleep(1000);
    //                continue;
    //            }

    //            if (G1 == true && G2 == true && G3 == false)
    //            {
    //                Y1 = 0; Y2 = 0; Y3 = 0;
    //            }
    //            else if (G1 == true && G2 == false && G3 == false)
    //            {
    //                Y1 = 1; Y2 = 0; Y3 = 0;
    //            }
    //            else if (G1 == false && G2 == false && G3 == false)
    //            {
    //                Y1 = 0; Y2 = 1; Y3 = 0;
    //            }
    //            else if (G1 == true && G2 == true && G3 == true)
    //            {
    //                Y1 = 0; Y2 = 0; Y3 = 1;
    //            }
    //            else
    //            {
    //                Y1 = 0; Y2 = 0; Y3 = 0;
    //            }

    //            if (Y1 == lastY1 && Y2 == lastY2 && Y3 == lastY3)
    //            {
    //                NowTime = DateTime.Now.Ticks / 10000;
    //                Time = NowTime - LastTime;
    //            }
    //            else
    //            {
    //                LastTime = DateTime.Now.Ticks / 10000;
    //                Time = 0;
    //            }
    //            double vel = V + (A1 + B1 * Math.Pow(Time, C1)) * Y1 + (A2 + B2 * Math.Pow(Time, C2)) * Y2 + (A3 + B3 * Math.Pow(Time, C3)) * Y3;
    //            if (运动控制.运动状态(0, Axis))
    //            {
    //                运动控制.定速运动(0, Axis, vel, 0.002, 1);
    //            }
    //            else
    //            {
    //                运动控制.在线变速(0, Axis, vel, 0.002);
    //            }
    //            //Console.WriteLine(vel);


    //            lastY1 = Y1; lastY2 = Y2; lastY3 = Y3;



    //            分析信息 f = new 分析信息(System.DateTime.Now.ToString(), Time, G1, G2, G3, vel, 工艺测试.已执行针数);


    //            Thread.Sleep(10);

    //        }
    //    }


    //    public void FuncX()
    //    {
    //        while (true)
    //        {
    //            Axis = GLV._下电机;
    //            G1 = IO控制.IN(0, GLV._下电机感应1);
    //            G2 = IO控制.IN(0, GLV._下电机感应2);
    //            G3 = IO控制.IN(0, GLV._下电机感应3);

    //            if (!run)
    //            {
    //                运动控制.单轴停止(0, Axis);
    //                Thread.Sleep(1000);
    //                continue;
    //            }

    //            if (G1 == true && G2 == true && G3 == false)
    //            {
    //                Y1 = 0; Y2 = 0; Y3 = 0;
    //            }
    //            else if (G1 == true && G2 == false && G3 == false)
    //            {
    //                Y1 = 1; Y2 = 0; Y3 = 0;
    //            }
    //            else if (G1 == false && G2 == false && G3 == false)
    //            {
    //                Y1 = 0; Y2 = 1; Y3 = 0;
    //            }
    //            else if (G1 == true && G2 == true && G3 == true)
    //            {
    //                Y1 = 0; Y2 = 0; Y3 = 1;
    //            }
    //            else
    //            {
    //                Y1 = 0; Y2 = 0; Y3 = 0;
    //            }

    //            if (Y1 == lastY1 && Y2 == lastY2 && Y3 == lastY3)
    //            {
    //                NowTime = DateTime.Now.Ticks / 10000;
    //                Time = NowTime - LastTime;
    //            }
    //            else
    //            {
    //                LastTime = DateTime.Now.Ticks / 10000;
    //                Time = 0;
    //            }
    //            double vel = V + (A1 + B1 * Math.Pow(Time, C1)) * Y1 + (A2 + B2 * Math.Pow(Time, C2)) * Y2 + (A3 + B3 * Math.Pow(Time, C3)) * Y3;
    //            if (运动控制.运动状态(0, Axis))
    //            {
    //                运动控制.定速运动(0, Axis, vel, 0.002, 1);
    //            }
    //            else
    //            {
    //                运动控制.在线变速(0, Axis, vel, 0.002);
    //            }


    //            lastY1 = Y1; lastY2 = Y2; lastY2 = Y2;


    //            分析信息X f = new 分析信息X(System.DateTime.Now.ToString(), Time, G1, G2, G3, vel, 工艺测试.已执行针数);





    //            Thread.Sleep(10);

    //        }
    //    }
    //}





}
