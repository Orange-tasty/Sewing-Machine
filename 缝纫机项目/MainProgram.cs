using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 缝纫机项目
{
    class MainProgram
    {
        public static 用户 _当前用户 = GLV._操作员;//GLV._操作员


        /// <summary>
        /// 程序状态
        /// 0:默认
        /// 1:复位
        /// 2:复位停止
        /// 3:复位完成
        /// 4:
        /// 5:运行
        /// 6:暂停
        /// 7:停止
        /// 8:结束生产中
        /// 9:标定
        /// 10:手动
        /// 12:程序异常
        /// </summary>
        public static ushort _程序状态 = 0;
        public enum _程序状态定义
        {
            默认,
            复位,
            复位停止,
            复位完成,
            T4,
            运行,
            暂停,
            停止,
            结束生产中,
            T9,
            T10,
            T11,
            T12

        }

        /// <summary>
        /// TRUE:空运行,不检测真空到位信号
        /// FALSE:正常运行
        /// </summary>
        public static bool _空运行 = false;

        

        /// <summary>
        /// 默认值1:正常速度
        /// 范围0~1
        /// </summary>
        public static double _运行速度比例 = 0.8;



        public static long _产量 = 0;
        public static long _总产量 = 0;

        public static 工艺测试 TH工艺测试 = new 工艺测试();
        public static 复位 TH复位 = new 复位();
        public static 缝纫机转速标定 TH缝纫机转速标定 = new 缝纫机转速标定();
        //public static 速度调节 TH上电机速度调节 = new 速度调节();
        //public static 速度调节 TH下电机速度调节 = new 速度调节();

        public static void 主程序()
        {
            switch (_程序状态)
            {
                case 0://默认


                    break;

                case 1://复位

                    //20221125测试
                    //MainProgram.TH工艺测试.step = 0;
                    //_程序状态 = 3;
                    break;

                case 2://复位停止


                    break;

                case 3://复位完成


                    break;

                case 4:


                    break;

                case 5://运行




                    break;
                case 6://暂停
                    //程序暂停逻辑();

                    break;
                case 7://停止

                    
                    停止逻辑();

                    //_程序状态 = 0;
                    //程序停止逻辑();


                    break;
                case 8://结束生产中


                    break;
                case 12://程序异常


                    break;
            }
        }

        public static ushort 停止逻辑step = 0;
        private static void 停止逻辑()
        {
            if (停止逻辑step == 1)
            {
                运动控制.轴全部停止(0);

                工艺测试.已执行针数 = 0;
                MainProgram.TH工艺测试.step = 0;
                MainProgram.TH复位.step = 0;

                //MainProgram.TH上电机速度调节.run = false;
                //MainProgram.TH下电机速度调节.run = false;

                停止逻辑step = 2;
            }
            else if (停止逻辑step == 2)
            {

                
            }
            
            

        }


        public static System.Diagnostics.Stopwatch _生产数据_工艺计时 = new Stopwatch();
        public static void 花费时间()
        {
            if (_生产数据_工艺计时 != null)
            {
                _生产数据_工艺计时.Stop();
                TimeSpan timespan = _生产数据_工艺计时.Elapsed;
                GLV._整条线动作时间 = timespan.TotalMilliseconds;

                _生产数据_工艺计时.Reset();
                _生产数据_工艺计时.Start();
            }
        }


    }
}
