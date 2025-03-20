using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet;
using MathNet.Numerics;

namespace 缝纫机项目
{
    internal class PIDcontrol
    {
        //public static double X = 0;

        public static double A = 1;
        public static double B = 1;

        public static double et(double X,double t)
        {
            return A * X * Math.Pow(t, B);
        }
        public static double et_Integral(double X, double t)//积分
        {
            double re = Integrate.OnClosedInterval(x => A * X * Math.Pow(x, B), 0, t);
            return re;
        }
        public static double et_Differential(double X, double t)//微分
        {
            return A * X * B * Math.Pow(t, B - 1);
        }

        public static double N = 1;//常数
        public static double Kp = 1;//比例
        public static double Ki = 1;//积分
        public static double Kd = 1;//微分

        public static double ut(double X,double t)
        {
            double R1 = N;
            double R2 = Kp * et(X, t);
            double R3 = Ki * et_Integral(X, t);
            double R4 = Kd * et_Differential(X, t);
            return R1 + R2 + R3 + R4;
        }




    }


    public class PIDtest
    {
        //A+B*x^C
        public double K = 0;
        public double last_Ki_value = 0;
        public double last_Kd_value = 0;
        public List<double> Ki累计 = new List<double>();
        public List<double> 速度延迟生效 = new List<double>();
        public void Start()
        {
            last_Ki_value = 0;
            last_Kd_value = 0;
            Ki累计.Clear();
            速度延迟生效.Clear();
        }

        /// <summary>
        /// PID控制
        /// </summary>
        /// <param name="PID_A"></param>
        /// <param name="PID_B"></param>
        /// <param name="PID_C"></param>
        /// <param name="Kp"></param>
        /// <param name="Ki"></param>
        /// <param name="Kd"></param>
        /// <param name="N">差值</param>
        /// <param name="maxvel">最大速度</param>
        /// <returns></returns>
        public double Func(double PID_A, double PID_B, double PID_C, double Kp , double Ki,double Kd, double N, double maxvel,double minvel)
        {
            //double reKp = Kp * (PID_A + PID_B * Math.Pow(N, PID_C));
            //double reKi = Ki * Integrate.OnClosedInterval(x => PID_A + PID_B * Math.Pow(N, PID_C), 0, N);
            //double reKd = Kd * PID_B * PID_C * Math.Pow(N, PID_C - 1);
            //double value = reKp + reKi + reKd;
            //value = CheckVel(value, maxvel, minvel);



            //20240407优化PID算法

            K = PID_A + PID_B * Math.Pow(N, PID_C);
            //kp
            double reKp = Kp * (K);

            //ki
            Ki累计.Add(K);
            if (Ki累计.Count> 工艺测试._PID的KI累计.Value)
            {
                Ki累计.RemoveAt(0);
            }
            double num = 0;
            for (int i = 0; i < Ki累计.Count; i++)
            {
                num = num + Ki累计[i];
            }
            double reKi = Ki * (num);

            //kd
            double reKd = Kd * (K - last_Kd_value);
            last_Kd_value = K;



            double value = (reKp + reKi + reKd);
            //Task任务.信息输出("value is" + value.ToString());
            value = CheckVel(value, maxvel, minvel);
            //Task任务.信息输出("value_last is" + value.ToString());

            速度延迟生效.Add(value);
            if (速度延迟生效.Count > 工艺测试._PID的延迟针数.Value)
            {
                if (速度延迟生效.Count > 1)
                {
                    速度延迟生效.RemoveAt(0);
                }
                
            }

            //for (int i = 0; i < 速度延迟生效.Count; i++)
            //{
            //    Task任务.信息输出("延迟缓冲区第" + i + "位" + 速度延迟生效[i].ToString());
            //}
            //Task任务.信息输出(速度延迟生效[0].ToString());
            return 速度延迟生效[0];

        }


        private double CheckVel(double value, double maxvalue, double minvalue)
        {
            if (value > maxvalue)
            {
                return maxvalue;
            }
            if (value < minvalue)
            {
                return minvalue;
            }
            return value;
        }



        public void 工艺流程()
        {
            
        }
    }

    public class StepControl
    {
        
    }

    public class 剪口电机速度
    {
        public static double 速度计算(double 剪口电机基础速度, double 缝纫机修正比例, double 缝纫机速度, double 上下差值, double 剪口差修正比例, double 剪口差基本值,double 速度上限,double 速度下限)
        {

            double re = (剪口电机基础速度 + 缝纫机修正比例 * 缝纫机速度) + (上下差值 * 剪口差修正比例 + 剪口差基本值);
            if (re > 速度上限 &&  re>=0)
            {
                re = 速度上限;
            }
            if (re < 速度下限 && re < 0)
            {
                re = 速度下限;
            }
            return -re;

        }
    }
}
