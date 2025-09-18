using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Leadshine;


namespace 缝纫机项目
{
    public class 控制器
    {
        public static bool 初始化()
        {
            LTSMC.smc_set_connect_timeout(2);
            short re = LTSMC.smc_board_init(0, 2, "192.168.5.11", 115200);
            LTSMC.smc_set_connect_timeout(2);
            if (re != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void 断开链接()
        {
            LTSMC.smc_board_close(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool 控制器连接状态()
        {
            uint axisnum = 0;
            LTSMC.smc_get_total_axes(0, ref axisnum);
            if (axisnum == 6)
            {
                ushort state_can = 999;
                LTSMC.nmcs_get_errcode(0, 0, ref state_can);
                if (state_can == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }

    public class 运动控制
    {
        /// <summary>
        /// 单轴运动
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <param name="vel">速度</param>
        /// <param name="acc">加减速时间</param>
        /// <param name="pos">位置</param>
        /// <param name="mod">0:相对  1:绝对</param>
        /// <returns></returns>
        public static short 点位运动(ushort card, ushort axis, double vel, double acc, double pos, ushort mod)
        {
            LTSMC.smc_set_profile_unit(card, axis, vel / 5, vel, acc, acc, vel / 10);
            LTSMC.smc_set_s_profile(card, axis, 0, acc / 2);
            short re = LTSMC.smc_pmove_unit(card, axis, pos, mod);
            return re;
        }

        /// <summary>
        /// 单轴连续运动
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <param name="vel">速度</param>
        /// <param name="acc">加减速时间</param>
        /// <param name="dir">方向:0负向/1正向</param>
        /// <returns></returns>
        public static short 定速运动(ushort card, ushort axis, double vel, double acc, ushort dir)
        {
            short re = LTSMC.smc_set_profile_unit(card, axis, vel / 5, vel, acc, acc, vel / 10);
            re = LTSMC.smc_set_s_profile(card, axis, 0, acc / 4);

            //double v1 = 0; double v2 = 0; double v3 = 0; double v4 = 0; double v5 = 0;
            //LTSMC.smc_get_profile_unit(card, axis, ref v1, ref v2, ref v3, ref v4, ref v5);
            re = LTSMC.smc_vmove(card, axis, dir);
            return re;

        }

        public static short 在线变速(ushort card, ushort axis, double vel, double acc)
        {
            short re = LTSMC.smc_change_speed_unit(card, axis, vel, acc);
            return re;
        }

        /// <summary>
        /// 强制改变目标位置
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <param name="newpos">新位置(绝对位置)</param>
        /// <returns></returns>
        public static short 在线改变目标位置(ushort card, ushort axis, double newpos)
        {
            short re = LTSMC.smc_update_target_position_unit(card, axis, newpos);
            return re;
        }

        /// <summary>
        /// 单轴停止
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        public static void 单轴停止(ushort card, ushort axis)
        {
            LTSMC.smc_set_dec_stop_time(card, axis, 0.1);
            LTSMC.smc_stop(card, axis, 0);
        }

        /// <summary>
        /// 软着陆单轴运动
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <param name="T1">第一段加速时间</param>
        /// <param name="T2">第一段减速时间</param>
        /// <param name="T3">第二段减速时间</param>
        /// <param name="Vmax">第一段高速</param>
        /// <param name="Vmin">第二段低速</param>
        /// <param name="POSm">单轴运动总长</param>
        /// <param name="POS2">软着陆段距离</param>
        /// <param name="dir">运动方向  0:负向/1:正向</param>
        public static void PVT运动(ushort card, ushort axis, double T1, double T2, double T3, double Vmax, double Vmin, double POSm, double POS2, ushort dir)
        {
            double[] pvt_t = new double[12];
            double[] pvt_p = new double[12];
            double[] pvt_v = new double[12];

            int i = 0;

            //启动
            pvt_p[i] = 0;
            pvt_v[i] = 0;
            pvt_t[i] = 0;
            i++;

            //加速
            pvt_p[i] = (Vmax * T1) / (4 * 18);
            pvt_v[i] = (Vmax) * (1 / 6.0);

            pvt_t[i] = T1 / 4;
            i++;


            pvt_p[i] = (Vmax * T1) / (4) + pvt_p[i - 1];
            pvt_v[i] = Vmax * (5 / 6.0);
            pvt_t[i] = T1 / 2 + pvt_t[i - 1];
            i++;

            pvt_p[i] = (Vmax * T1) * 17 / (4 * 18) + pvt_p[i - 1];
            pvt_v[i] = Vmax * (6 / 6.0);
            pvt_t[i] = T1 / 4 + pvt_t[i - 1];
            i++;

            //匀速
            double p1 = (POSm - POS2) - Vmax * T1 / 2 - (Vmax + Vmin) * T2 / 2;
            pvt_p[i] = p1 + pvt_p[i - 1];
            pvt_v[i] = Vmax * (6 / 6.0);
            pvt_t[i] = p1 / Vmax + pvt_t[i - 1];
            i++;

            //减速
            pvt_p[i] = ((Vmax - Vmin) * T2) * 17 / (4 * 18) + Vmin * T2 / 4 + pvt_p[i - 1];
            pvt_v[i] = (Vmax - Vmin) * (5 / 6.0) + Vmin;
            pvt_t[i] = T2 / 4 + pvt_t[i - 1];
            i++;

            pvt_p[i] = ((Vmax - Vmin) * T2) / 4 + Vmin * T2 / 2 + pvt_p[i - 1];
            pvt_v[i] = (Vmax - Vmin) * (1 / 6.0) + Vmin;
            pvt_t[i] = T2 / 2 + pvt_t[i - 1];
            i++;

            pvt_p[i] = ((Vmax - Vmin) * T2) / (4 * 18) + Vmin * T2 / 4 + pvt_p[i - 1];
            pvt_v[i] = Vmin;
            pvt_t[i] = T2 / 4 + pvt_t[i - 1];
            i++;

            //匀速
            double p2 = POS2 - Vmin * T3 / 2;
            pvt_p[i] = p2 + pvt_p[i - 1];
            pvt_v[i] = Vmin;
            pvt_t[i] = p2 / Vmin + pvt_t[i - 1];
            i++;

            //减速
            pvt_p[i] = (Vmin * T3) * 17 / (4 * 18) + pvt_p[i - 1];
            pvt_v[i] = Vmin * (5 / 6.0);
            pvt_t[i] = T3 / 4 + pvt_t[i - 1];
            i++;

            pvt_p[i] = (Vmin * T3) / 4 + pvt_p[i - 1];
            pvt_v[i] = Vmin * (1 / 4.0);
            pvt_t[i] = T3 / 2 + pvt_t[i - 1];
            i++;

            pvt_p[i] = (Vmin * T3) / (4 * 18) + pvt_p[i - 1];
            pvt_v[i] = 0;
            pvt_t[i] = T3 / 4 + pvt_t[i - 1];

            if (dir == 0)
            {
                for (i = 0; i < 12; i++)
                {
                    pvt_p[i] = -pvt_p[i];
                    pvt_v[i] = -pvt_v[i];
                    //Console.WriteLine("  " + i + "  ");
                    //Console.WriteLine(pvt_p[i]);
                    //Console.WriteLine(pvt_v[i]);
                    //Console.WriteLine(pvt_t[i]);
                    //Console.WriteLine("  ");
                }

            }




            ushort[] ax = new ushort[1];
            ax[0] = axis;

            short tt = LTSMC.smc_pvt_table_unit(0, axis, 13, pvt_t, pvt_p, pvt_v);
            //Console.WriteLine(tt);
            tt = LTSMC.smc_pvt_move(0, 1, ax);
            //Console.WriteLine(tt);

            //Console.WriteLine("  " + i + "  ");
            //Console.WriteLine(pvt_p[i]);
            //Console.WriteLine(pvt_v[i]);
            //Console.WriteLine(pvt_t[i]);




        }


        /// <summary>
        /// 直线插补
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="crd">插补系号</param>
        /// <param name="axix0">插补轴0编号</param>
        /// <param name="axis1">插补轴1编号</param>
        /// <param name="pos0">插补轴0位置</param>
        /// <param name="pos1">插补轴1位置</param>
        /// <param name="vel">插补速度</param>
        /// <param name="acc">插补加减速时间</param>
        /// <param name="mod">0:相对,1绝对</param>
        /// <returns></returns>
        public static short 直线插补(ushort card, ushort crd, ushort axix0, ushort axis1, double pos0, double pos1, double vel, double acc, ushort mod)
        {

            ushort[] axis = { axix0, axis1 };
            double[] pos = { pos0, pos1 };
            LTSMC.smc_set_vector_profile_unit(card, crd, vel / 5, vel, acc, acc, vel / 5);
            LTSMC.smc_set_vector_s_profile(card, crd, 0, acc / 2);
            short re = LTSMC.smc_line_unit(card, crd, 2, axis, pos, 0);
            //Console.WriteLine("X:" + pos[0]);
            //Console.WriteLine("Y:" + pos[1]);
            return re;
        }

        /// <summary>
        /// 圆弧插补
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="crd">插补系号</param>
        /// <param name="axix0">插补轴0编号</param>
        /// <param name="axis1">插补轴1编号</param>
        /// <param name="pos0">插补轴0终点位置</param>
        /// <param name="pos1">插补轴1终点位置</param>
        /// <param name="org0">插补轴0圆心位置</param>
        /// <param name="org1">插补轴1圆心位置</param>
        /// <param name="dir">圆弧方向:0顺时针,1逆时针</param>
        /// <param name="vel">插补速度</param>
        /// <param name="acc">插补加减速时间</param>
        /// <param name="mod">0:相对,1绝对</param>
        /// <returns></returns>
        public static short 圆弧插补(ushort card, ushort crd, ushort axix0, ushort axis1, double pos0, double pos1, double org0, double org1, ushort dir, double vel, double acc, ushort mod)
        {
            ushort[] axis = { axix0, axis1 };
            double[] pos = { pos0, pos1 };
            double[] org = { org0, org1 };
            LTSMC.smc_set_vector_profile_unit(card, crd, vel / 5, vel, acc, acc, vel / 5);
            LTSMC.smc_set_vector_s_profile(card, crd, 0, acc / 2);
            short re = LTSMC.smc_arc_move_center_unit(0, 0, 2, axis, pos, org, dir, 0, 0);//0圈
            return re;
        }

        /// <summary>
        /// 插补停止
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="crd">插补系号</param>
        public static void 插补停止(ushort card, ushort crd)
        {
            LTSMC.smc_set_vector_dec_stop_time(card, crd, 0.01);
            LTSMC.smc_stop_multicoor(card, crd, 0);
        }

        /// <summary>
        /// 回零运动
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <param name="dir">1:正方向  0:负方向</param>
        /// <param name="vel_max">回零高速</param>
        /// <param name="vel_min">回零低速</param>
        /// <param name="acc">回零加减速时间</param>
        /// <param name="offset">回零偏移</param>
        /// <returns></returns>
        public static short 回零运动(ushort card, ushort axis, ushort dir, double vel_max, double vel_min, double acc, double offset)
        {
            LTSMC.smc_set_profile_unit(card, axis, vel_min, vel_max, acc, acc, 0);
            //参数：ConnectNo 指定链接号：0-7,默认值0
            //axis 指定轴号，取值范围：0-控制器最大轴数-1
            //home_dir 回原点方向  0：负向，1：正向
            //vel 回原点速度模式，默认值：1
            //mode 回原点模式
            //Source 回零计数源，0：指令位置计数器，1：编码器计数器
            LTSMC.smc_set_homemode(card, axis, dir, 1, 1, 0);
            //ConnectNo 指定链接号：0-7,默认值0
            //axis 指定轴号，取值范围：0-控制器最大轴数-1
            //Low_Vel 设置回原点起始速度
            //High_Vel 设置回原点运行速度
            //Tacc 设置回原点加速、减速时间，单位：s
            //Tdec 保留值0
            LTSMC.smc_set_home_profile_unit(card, axis, vel_min, vel_max, acc, 0);
            //ConnectNo 指定链接号：0-7,默认值0
            //axis 指定轴号，取值范围：0-控制器最大轴数-1
            //enable 使能参数
            //0：禁止。
            //1: 先清0，然后运动到指定位置（相对位置）。
            //2: 先运动到指定位置（相对位置），再清0
            //position 设置回原点位置
            LTSMC.smc_set_home_position_unit(card, axis, 2, offset);
            //ConnectNo 指定链接号：0-7,默认值0
            //axis 指定轴号，取值范围：0-控制器最大轴数-1
            LTSMC.smc_home_move(card, axis);

            return 0;
        }



        /// <summary>
        /// 检测回零是否完成
        /// TRUE 回零完成
        /// FALSE 回零未完成
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public static bool 回零完成(ushort card, ushort axis)
        {
            ushort re = 0;
            LTSMC.smc_get_home_result(card, axis, ref re);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double 当前速度(ushort card, ushort axis)
        {
            double vel = 0;
            LTSMC.smc_read_current_speed_unit(card, axis, ref vel);
            return vel;
        }

        /// <summary>
        /// 返回轴当前指令位置
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public static double 指令位置(ushort card, ushort axis)
        {
            double re = 0;
            LTSMC.smc_get_position_unit(card, axis, ref re);
            return re;

        }

        public static double 指令位置清零(ushort card, ushort axis)
        {
            double pos = 0;
            LTSMC.smc_set_encoder_unit(card, axis, pos);
            short re = LTSMC.smc_set_position_unit(card, axis, pos);
            //Task任务.信息输出(re.ToString());
            return re;

        }

        /// <summary>
        /// 返回轴当前反馈位置
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public static double 反馈位置(ushort card, ushort axis)
        {
            double re = 0;
            LTSMC.smc_get_encoder_unit(card, axis, ref re);
            return re;

        }

        public static double 反馈位置清零(ushort card, ushort axis)
        {
            double re = 0;
            LTSMC.smc_set_encoder_unit(card, axis, 0);
            return re;

        }

        /// <summary>
        /// 获取运动状态
        /// True:已停止
        /// False:运动中
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public static bool 运动状态(ushort card, ushort axis)
        {
            if (LTSMC.smc_check_done(card, axis) == 0)
            {
                //运动中
                return false;
            }
            else
            {
                //已停止
                return true;
            }
        }


        /// <summary>
        /// 获取插补运动状态
        /// True:已停止
        /// False:运动中
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="crd">插补系号</param>
        /// <returns></returns>
        public static bool 插补运动状态(ushort card, ushort crd)
        {
            if (LTSMC.smc_check_done_multicoor(card, crd) == 0)
            {
                //运动中
                return false;
            }
            else
            {
                //已停止
                return true;
            }
        }




        /// <summary>
        /// TRUE;报警
        /// FALSE:正常
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public static bool 轴报警(ushort card, ushort axis)
        {
            uint re = LTSMC.smc_axis_io_status(card, axis);
            re = re & (1);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// TRUE:正限位触发
        /// FALSE:正限位未触发
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public static bool 轴正限位(ushort card, ushort axis)
        {
            uint re = LTSMC.smc_axis_io_status(card, axis);
            re = re & (2);
            if (re == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// TRUE:负限位触发
        /// FALSE:负限位未触发
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public static bool 轴负限位(ushort card, ushort axis)
        {
            uint re = LTSMC.smc_axis_io_status(card, axis);
            re = re & (4);
            if (re == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// TRUE:原点触发
        /// FALSE:原点未触发
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public static bool 轴原点(ushort card, ushort axis)
        {
            uint re = LTSMC.smc_axis_io_status(card, axis);
            re = re & (16);
            if (re == 16)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        


        /// <summary>
        /// 设置脉冲当量
        /// TRUE:设置成功
        /// FALSEL:设置失败
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <param name="unit">脉冲当量</param>
        /// <returns></returns>
        public static bool 设置脉冲当量(ushort card, ushort axis, double unit)
        {
            short re = LTSMC.smc_set_equiv(card, axis, unit);
            if (re == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 设置轴报警的有效电平
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="axis">轴号</param>
        /// <param name="logic">0:低电平  1:高电平</param>
        /// <returns></returns>
        public static void 设置报警有效电平(ushort card, ushort axis, ushort logic)
        {

            LTSMC.smc_set_alm_mode(card, axis, 1, logic, 0);

        }


        public static void 设置轴异常减速停止时间(ushort card, ushort axis, double time)
        {
            LTSMC.smc_set_dec_stop_time(card, axis, time);
        }
        public static void 设置插补异常减速停止时间(ushort card, ushort crd, double time)
        {
            LTSMC.smc_set_vector_dec_stop_time(card, crd, time);
        }

        public static void 轴全部停止(ushort card)
        {
            插补停止(card, 0);
            ushort i = 0;
            单轴停止(card, i); i++;
            单轴停止(card, i); i++;
            单轴停止(card, i); i++;
            单轴停止(card, i); i++;
            单轴停止(card, i); i++;
            单轴停止(card, i);
        }



        

    }
    public class 模拟量
    {
        public static double 输入(ushort card, ushort port)
        {
            return LTSMC.smc_get_ain(card, port);
        }

        public static double 输出(ushort card, ushort port)
        {
            double re = 0;
            LTSMC.smc_get_da_output(card, port,ref re);
            return re;
        }

        public static void 输出(ushort card, ushort port,double value)
        {
            LTSMC.smc_set_da_output(card, port, value);
        }

    }


    public class 缝纫机
    {
        //20240619
        public static S系统参数 _缝纫机待机电压 = new S系统参数("缝纫机待机电压", "NULL", 1.9, "伏特", "V", GLV._参数类型_测试参数, GLV._高权限);
        public static S系统参数 _缝纫机抬压脚电压 = new S系统参数("缝纫机抬压脚电压", "NULL", 0, "伏特", "V", GLV._参数类型_测试参数, GLV._高权限);
        public static S系统参数 _缝纫机剪线电压 = new S系统参数("缝纫机剪线电压", "NULL", 0, "伏特", "V", GLV._参数类型_系统参数, GLV._高权限);
        public static S系统参数 _缝纫机回针电压 = new S系统参数("缝纫机回针电压", "NULL", 0, "伏特", "V", GLV._参数类型_系统参数, GLV._高权限);

        //private static double 待机电压 = 2.0;
        //private static double 抬压脚电压 = 1.0;
        //private static double 剪线电压 = 1.0;
        //private static double 回针电压 = 0.5;

        

        public static void 待机()
        {
            模拟量.输出(0, GLV._缝纫机控制, _缝纫机待机电压.Value);
            
        }

        public static void 抬压脚()
        {
            模拟量.输出(0, GLV._缝纫机控制, _缝纫机抬压脚电压.Value);

        }

        public static void 剪线()
        {
            模拟量.输出(0, GLV._缝纫机控制, _缝纫机剪线电压.Value);

        }

        public static void 回针()
        {
            模拟量.输出(0, GLV._缝纫机控制, _缝纫机回针电压.Value);
        }

        public static void 控制(double V)
        {
            模拟量.输出(0, GLV._缝纫机控制, V);
        }

        public static double 获取电压()
        {
            return 模拟量.输出(0, GLV._缝纫机控制);
        }

        public static double 当前转速()
        {
            return Math.Round(缝纫机转速标定.已知电压求转速(模拟量.输出(0, GLV._缝纫机控制)), 2);
        }

    }


    public class IO控制
    {

        /// <summary>
        /// 读输入口IN/FALSE关,TRUE开
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="bitno">输入口号</param>
        /// <returns></returns>
        public static bool IN(ushort card, ushort bitno)
        {
            try
            {
                if (LTSMC.smc_read_inbit(card, bitno) == 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                //报错
                return false;
            }
        }

        /// <summary>
        /// 写输出口OUT
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="bitno">输出口号</param>
        /// <param name="state">输出状态:FALSE关,TRUE开</param>
        public static void OUT(ushort card, ushort bitno, bool state)
        {
            try
            {
                if (state)
                {
                    LTSMC.smc_write_outbit(card, bitno, 0);//开
                }
                else
                {
                    LTSMC.smc_write_outbit(card, bitno, 1);//关
                }
            }
            catch
            {
                //报错
            }

        }

        /// <summary>
        /// 读输出口OUT/FALSE关,TRUE开
        /// </summary>
        /// <param name="card">卡号</param>
        /// <param name="bitno">输出口号</param>
        /// <returns></returns>
        public static bool OUT(ushort card, ushort bitno)
        {
            try
            {
                if (LTSMC.smc_read_outbit(card, bitno) == 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }


    }




    
}

