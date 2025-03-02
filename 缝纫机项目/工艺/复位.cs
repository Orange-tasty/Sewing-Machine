using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 缝纫机项目
{
    internal class 复位
    {

        public static S系统参数 _复位气缸动作等待时间 = new S系统参数("复位气缸动作等待时间", "NULL", 2000, "毫秒", "ms", GLV._参数类型_复位动作参数, GLV._低权限);

        public ushort step = 0;
        public enum STEP
        {
            默认,
            复位启动,
            气缸回初始位置,
            等待气缸动作完成,
            复位结束

        }


        public void 工艺流程()
        {

            while (true)
            {
                if (可运行条件())
                {
                    switch (step)
                    {
                        case (ushort)STEP.复位启动:


                            Task任务.信息输出("复位动作" + step);
                            step = (ushort)STEP.气缸回初始位置;
                            break;


                            

                        case (ushort)STEP.气缸回初始位置:
                            Task任务.信息输出("复位动作" + step);
                            ACT气缸回初始位置();

                            step = (ushort)STEP.等待气缸动作完成;
                            break;


                        case (ushort)STEP.等待气缸动作完成:
                            Task任务.信息输出("复位动作" + step);
                            ACT等待气缸动作完成();

                            step = (ushort)STEP.复位结束;
                            break;


                        case (ushort)STEP.复位结束:
                            Task任务.信息输出("复位动作" + step);
                            Task任务.信息输出("复位动作完成");
                            step = (ushort)STEP.默认;
                            //MainProgram._程序状态 = 7;
                            工艺测试.已执行针数 = 0;
                            MainProgram._程序状态 = 3;

                            工艺测试.上剪口.ACT清除();//20240108
                            工艺测试.下剪口.ACT清除();//20240108

                            运动控制.反馈位置清零(0, GLV._缝纫机编码器);//20231229清除编码器

                            

                            //MainProgram.TH上电机速度调节.run = false;
                            //MainProgram.TH下电机速度调节.run = false;

                            break;


                    }

                    Thread.Sleep(20);
                }
                else
                {
                    Thread.Sleep(100);
                }

               
            }

        }


        public bool 可运行条件()
        {
            if (MainProgram._程序状态 == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void ACT气缸回初始位置()
        {
            缝纫机.待机();
            IO控制.OUT(0, GLV._上拐弯电机气缸, GLV.ON);
            IO控制.OUT(0, GLV._下拐弯电机气缸, GLV.OFF);
            IO控制.OUT(0, GLV._上直线电机气缸, GLV.ON);

        }

        public void ACT等待气缸动作完成()
        {
            Thread.Sleep((int)_复位气缸动作等待时间.Value);
        }



    }
}
