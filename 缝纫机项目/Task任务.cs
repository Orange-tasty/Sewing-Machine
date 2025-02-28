using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 缝纫机项目
{
    internal class Task任务
    {
        public static void Thread1()
        {

            while (true)
            {

                MainProgram.主程序();
                Thread.Sleep(5);
                //Program_程序.ClearMenory();



            }
        }

        public static void Thread2()
        {

            while (true)
            {

                #region 轴报警输出

                轴报警输出();

                #endregion

                #region 轴限位报警输出

                轴限位报警输出();

                #endregion

                #region 控制器连接状态
                控制器连接状态();
                #endregion


                #region 外部按钮逻辑

                #endregion

                Thread.Sleep(100);
            }
        }


        /// <summary>
        /// 定时器
        /// </summary>
        public static void ThreadTimer()
        {
            while (true)
            {


                Thread.Sleep(1000);
            }

        }






        public static void 信息输出(string msg)
        {
            GLV._信息输出列表.Add(new 信息输出(0, 0, msg));//20210702改动
        }
        public static void 信息输出(string msg, string en_msg)
        {

            GLV._信息输出列表.Add(new 信息输出(0, 0, msg));//20210702改动


        }

        public static void 系统输出(string msg)
        {
            GLV._信息输出列表.Add(new 信息输出(0, 2, msg));//20210702改动
        }
        public static void 系统输出(string msg, string en_msg)
        {


            GLV._信息输出列表.Add(new 信息输出(0, 2, msg));//20210702改动


        }


        /// <summary>
        /// 报警,将程序状态改为12
        /// </summary>
        /// <param name="msg"></param>
        public static void 报警输出(string msg)
        {
            //if (MainProgram._程序状态 == 1 || MainProgram._程序状态 == 2 || MainProgram._程序状态 == 3 || MainProgram._程序状态 == 5 || MainProgram._程序状态 == 6)
            //{

            //}

            MainProgram._程序状态 = 12;//报警

            GLV._系统错误表.Add(new 系统错误(0, msg));
            GLV._信息输出列表.Add(new 信息输出(0, 1, msg));//20210702改动
        }
        public static void 报警输出(string msg, string en_msg)
        {


            MainProgram._程序状态 = 12;//报警

            GLV._系统错误表.Add(new 系统错误(0, msg));
            GLV._信息输出列表.Add(new 信息输出(0, 1, msg));//20210702改动


        }

        public static void 报警提示(string msg)
        {


            GLV._系统错误表.Add(new 系统错误(0, msg));
            GLV._信息输出列表.Add(new 信息输出(0, 1, msg));//20210702改动
        }
        public static void 报警提示(string msg, string en_msg)
        {

            GLV._系统错误表.Add(new 系统错误(0, msg));
            GLV._信息输出列表.Add(new 信息输出(0, 1, msg));//20210702改动

        }






        public static void 轴报警输出()
        {

            if (MainProgram._程序状态 == 12)//已经处于报警中了
            {
                return;
            }

            if (运动控制.轴报警(0, GLV._axis0))
            {
                Task任务.报警输出("顶升轴驱动器报警!!(" + GLV._axis0.ToString() + "号轴)", "JackingAxis driver alarm(" + GLV._axis0.ToString() + "Axis)");
            }
            if (运动控制.轴报警(0, GLV._axis1))
            {
                Task任务.报警输出("A划片轴驱动器报警!!(" + GLV._axis1.ToString() + "号轴)", "A-ScribingAxis driver alarm(" + GLV._axis1.ToString() + "Axis)");
            }
            if (运动控制.轴报警(0, GLV._axis2))
            {
                Task任务.报警输出("B划片轴驱动器报警!!(" + GLV._axis2.ToString() + "号轴)", "B-ScribingAxis driver alarm(" + GLV._axis2.ToString() + "Axis)");
            }
            if (运动控制.轴报警(0, GLV._axis3))
            {
                Task任务.报警输出("激光轴驱动器报警!!(" + GLV._axis3.ToString() + "号轴)", "LaserAxis driver alarm(" + GLV._axis3.ToString() + "Axis)");
            }
            if (运动控制.轴报警(0, GLV._axis4))
            {
                Task任务.报警输出("上料轴驱动器报警!!(" + GLV._axis4.ToString() + "号轴)", "UploadAxis driver alarm(" + GLV._axis4.ToString() + "Axis)");
            }
            if (运动控制.轴报警(0, GLV._axis5))
            {
                Task任务.报警输出("下料轴驱动器报警!!(" + GLV._axis5.ToString() + "号轴)", "DownloadAxis driver alarm(" + GLV._axis5.ToString() + "Axis)");
            }
        }

        public static void 轴限位报警输出()
        {
            if (MainProgram._程序状态 != 5)//没在运行
            {
                return;
            }



            if (运动控制.轴正限位(0, GLV._axis0))
            {
                Task任务.报警输出("A划片轴正限位触发(" + GLV._axis0.ToString() + "号轴)",
                    "A-ScribingAxis EL+ alarm(" + GLV._axis0.ToString() + "Axis)");
            }
            if (运动控制.轴负限位(0, GLV._axis0))
            {
                Task任务.报警输出("A划片轴负限位触发(" + GLV._axis0.ToString() + "号轴)",
                    "A-ScribingAxis EL- alarm(" + GLV._axis0.ToString() + "Axis)");
            }


            if (运动控制.轴正限位(0, GLV._axis1))
            {
                Task任务.报警输出("B划片轴正限位触发(" + GLV._axis1.ToString() + "号轴)",
                    "B-ScribingAxis EL+ alarm(" + GLV._axis1.ToString() + "Axis)");
            }
            if (运动控制.轴负限位(0, GLV._axis1))
            {
                Task任务.报警输出("B划片轴负限位触发(" + GLV._axis1.ToString() + "号轴)",
                    "B-ScribingAxis EL- alarm(" + GLV._axis1.ToString() + "Axis)");
            }


            if (运动控制.轴正限位(0, GLV._axis2))
            {
                Task任务.报警输出("激光轴正限位触发(" + GLV._axis2.ToString() + "号轴)",
                    "LaserAxis EL+ alarm(" + GLV._axis2.ToString() + "Axis)");
            }
            if (运动控制.轴负限位(0, GLV._axis2))
            {
                Task任务.报警输出("激光轴负限位触发(" + GLV._axis2.ToString() + "号轴)",
                    "LaserAxis EL- alarm(" + GLV._axis2.ToString() + "Axis)");
            }


            if (运动控制.轴正限位(0, GLV._axis3))
            {
                Task任务.报警输出("上料轴正限位触发(" + GLV._axis3.ToString() + "号轴)",
                    "UploadAxis EL+ alarm(" + GLV._axis3.ToString() + "Axis)");
            }
            if (运动控制.轴负限位(0, GLV._axis3))
            {
                Task任务.报警输出("上料轴负限位触发(" + GLV._axis3.ToString() + "号轴)",
                    "UploadAxis EL- alarm(" + GLV._axis3.ToString() + "Axis)");
            }


            if (运动控制.轴正限位(0, GLV._axis4))
            {
                Task任务.报警输出("下料轴正限位触发(" + GLV._axis4.ToString() + "号轴)",
                    "DowmloadAxis EL+ alarm(" + GLV._axis4.ToString() + "Axis)");
            }
            if (运动控制.轴负限位(0, GLV._axis4))
            {
                Task任务.报警输出("下料轴负限位触发(" + GLV._axis4.ToString() + "号轴)",
                    "DowmloadAxis EL- alarm(" + GLV._axis4.ToString() + "Axis)");
            }

            if (运动控制.轴正限位(0, GLV._axis5))
            {
                Task任务.报警输出("下料轴正限位触发(" + GLV._axis5.ToString() + "号轴)",
                    "DowmloadAxis EL+ alarm(" + GLV._axis5.ToString() + "Axis)");
            }
            if (运动控制.轴负限位(0, GLV._axis5))
            {
                Task任务.报警输出("下料轴负限位触发(" + GLV._axis5.ToString() + "号轴)",
                    "DowmloadAxis EL- alarm(" + GLV._axis5.ToString() + "Axis)");
            }
        }



        public static void 控制器连接状态()
        {
            GLV._控制器连接状态 = 控制器.控制器连接状态();
        }



       
    }
}
