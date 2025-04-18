using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 缝纫机项目
{
    public class 缝纫机转速标定
    {
        

        public static S系统参数 _缝纫机转速标定电压1 = new S系统参数("缝纫机转速标定电压1", "NULL", 2.4, "伏特", "V", GLV._参数类型_测试参数, GLV._高权限);
        public static S系统参数 _缝纫机转速标定时长1 = new S系统参数("缝纫机转速标定时长1", "NULL", 5, "秒", "s", GLV._参数类型_测试参数, GLV._高权限);

        public static S系统参数 _缝纫机转速标定电压2 = new S系统参数("缝纫机转速标定电压2", "NULL", 4.2, "伏特", "V", GLV._参数类型_测试参数, GLV._高权限);
        public static S系统参数 _缝纫机转速标定时长2 = new S系统参数("缝纫机转速标定时长2", "NULL", 5, "秒", "s", GLV._参数类型_测试参数, GLV._高权限);

        public static S系统参数 _缝纫机转速标A = new S系统参数("缝纫机转速标A", "NULL", 2.4, "数值", "num", GLV._参数类型_系统参数, GLV._高权限);
        public static S系统参数 _缝纫机转速标B = new S系统参数("缝纫机转速标B", "NULL", 2.4, "数值", "num", GLV._参数类型_系统参数, GLV._高权限);

        public double rol1 = 0;
        public double rol2 = 0;

        public double testV1 = 0;
        public double testV2 = 0;

        public ushort step = 0;
        public enum STEP
        {
            默认,
            启动一次标定,
            等待一次,
            结束一次标定,
            计算一次标定结果,
            启动二次标定,
            等待二次,
            结束二次标定,
            计算二次标定结果,
            结束

        }
        public void 工艺流程()
        {

            while (true)
            {
                if (可运行条件())
                {
                    switch (step)
                    {
                        case (ushort)STEP.默认:

                            break;


                        case (ushort)STEP.启动一次标定:

                            rol1 = 0;
                            rol2 = 0;

                            testV1 = 0;
                            testV2 = 0;

                            运动控制.反馈位置清零(0, GLV._缝纫机编码器);
                            缝纫机.控制(_缝纫机转速标定电压1.Value);


                            step = (ushort)STEP.等待一次;
                            break;

                        case (ushort)STEP.等待一次:
                            Task任务.信息输出("标定一次延时启动");
                            Thread.Sleep((int)_缝纫机转速标定时长1.Value * 1000);

                            testV1 = 缝纫机.获取电压();

                            step = (ushort)STEP.结束一次标定;
                            break;

                        case (ushort)STEP.结束一次标定:

                            缝纫机.待机();
                            rol1 = Math.Abs(运动控制.反馈位置(0, GLV._缝纫机编码器) / 工艺测试._缝纫机编码器细分.Value);
                            

                            Task任务.信息输出("标定一次延时结束");


                            step = (ushort)STEP.计算一次标定结果;
                            break;

                        case (ushort)STEP.计算一次标定结果:

                            Task任务.信息输出("标定一次时长为"+ _缝纫机转速标定时长1.Value.ToString()+"秒,输出电压"+ testV1+"V,缝纫机转" + rol1.ToString()+ "圈");
                            step = (ushort)STEP.启动二次标定;

                            break;

                        case (ushort)STEP.启动二次标定:

                            运动控制.反馈位置清零(0, GLV._缝纫机编码器);
                            缝纫机.控制(_缝纫机转速标定电压2.Value);


                            step = (ushort)STEP.等待二次;
                            break;

                        case (ushort)STEP.等待二次:
                            Task任务.信息输出("标定二次延时启动");
                            Thread.Sleep((int)_缝纫机转速标定时长2.Value * 1000);
                            testV2 = 缝纫机.获取电压();
                            step = (ushort)STEP.结束二次标定;
                            break;

                        case (ushort)STEP.结束二次标定:

                            缝纫机.待机();
                            rol2 = Math.Abs(运动控制.反馈位置(0, GLV._缝纫机编码器) / 工艺测试._缝纫机编码器细分.Value);


                            Task任务.信息输出("标定二次延时结束");


                            step = (ushort)STEP.计算二次标定结果;
                            break;

                        case (ushort)STEP.计算二次标定结果:

                            Task任务.信息输出("标定二次时长为" + _缝纫机转速标定时长1.Value.ToString() + "秒,输出电压"+ testV2+"V,,缝纫机转" + rol2.ToString() + "圈");
                            step = (ushort)STEP.结束;

                            break;

                        case (ushort)STEP.结束:

                            运动控制.反馈位置清零(0, GLV._缝纫机编码器);

                            double vel1 = (rol1 / _缝纫机转速标定时长1.Value) * 60;
                            double vel2 = (rol2 / _缝纫机转速标定时长2.Value) * 60;

                            //vel1 = 300;
                            //vel2 = 1000;

                            double V1 = _缝纫机转速标定电压1.Value;
                            double V2 = _缝纫机转速标定电压2.Value;

                            double a = (V1 - V2) / (vel1 - vel2);
                            double b = (vel1* V2 - vel2 * V1) / (vel1 - vel2);

                            _缝纫机转速标A.Value = a;
                            _缝纫机转速标B.Value = b;

                            Task任务.信息输出("标定结束: a = " + a + " , b = " + b);

                            MainProgram._程序状态 = 7;

                            step = (ushort)STEP.默认;

                            break;

                    }


                }
            }
        }


        public bool 可运行条件()
        {
            if (MainProgram._程序状态 == 9)
            {
                return true;
            }
            else
            {
                return false;
            }



        }


        public static double 已知转速求电压(double vel)
        {
            return _缝纫机转速标A.Value * vel + _缝纫机转速标B.Value;
        }

        public static double 已知电压求转速(double V)
        {
            if (V < _缝纫机转速标B.Value)
            {
                return 0;
            }
            return (V - _缝纫机转速标B.Value)/ _缝纫机转速标A.Value;
        }


    }
}
