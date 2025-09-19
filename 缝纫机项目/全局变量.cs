using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 缝纫机项目
{
    public class GLV
    {

        //TRUE
        #region TRUE同义词:开/有/ON
        /// <summary>
        /// TRUE
        /// </summary>
        public const bool 开 = true;
        /// <summary>
        /// TRUE
        /// </summary>
        public const bool 有 = true;
        /// <summary>
        /// TRUE
        /// </summary>
        public const bool ON = true;
        #endregion

        //FALSE
        #region FALSE同义词:关/无/OFF
        /// <summary>
        /// FALSE
        /// </summary>
        public const bool 关 = false;
        /// <summary>
        /// FALSE
        /// </summary>
        public const bool 无 = false;
        /// <summary>
        /// FALSE
        /// </summary>
        public const bool OFF = false;
        #endregion

        #region 轴定义

        //public const ushort _顶升轴 = 5;
        //public const ushort _上料轴 = 3;
        //public const ushort _下料轴 = 4;
        //public const ushort _激光轴 = 2;
        //public const ushort _A划片轴 = 0;
        //public const ushort _B划片轴 = 1;

        public const ushort _axis0 = 0;
        public const ushort _axis1 = 1;
        public const ushort _axis2 = 2;
        public const ushort _axis3 = 3;
        public const ushort _axis4 = 4;
        public const ushort _axis5 = 5;

        public const ushort _上电机 = 0;
        public const ushort _下电机 = 1;
        public const ushort _上剪口电机 = 2;
        public const ushort _下剪口电机 = 3;
        public const ushort _缝纫机编码器 = 4;

        #endregion

        #region 模拟量接口定义
        public const ushort _上传感器 = 2;
        public const ushort _下传感器 = 3;

        public const ushort _缝纫机控制 = 3;
        #endregion

        #region 输入口输出口定义

        ///////IO定义关联



        ///////输入**********************************************************

        public const ushort _复位按钮 = 0;
        public const ushort _启动按钮 = 1;
        public const ushort _暂停按钮 = 2;
        public const ushort _停止按钮 = 3;
        public const ushort _抬压脚 = 4;

        public const ushort _上剪口传感器 = 8;
        public const ushort _下剪口传感器 = 9;

        public const ushort _上电机感应1 = 5;
        public const ushort _上电机感应2 = 6;
        public const ushort _上电机感应3 = 7;

        public const ushort _下电机感应1 = 8;
        public const ushort _下电机感应2 = 9;
        public const ushort _下电机感应3 = 10;





        ///////输出**********************************************************


        public const ushort _上拐弯电机气缸 = 0;
        public const ushort _下拐弯电机气缸 = 1;
        public const ushort _上直线电机气缸 = 2;



        #endregion

        //public static List<S系统参数> _系统参数列表 = new List<S系统参数>();//参数列表

        //public static List<P配方> _配方列表 = new List<P配方>();//配方列表

        public static string _当前文件名 = "配方文件路径";

        public static List<DXF数据> _DXF列表 = new List<DXF数据>();
        public static List<DXF数据> _轨迹列表 = new List<DXF数据>();
        public static List<划片轨迹> _划片轨迹列表 = new List<划片轨迹>();
        public static List<划片轨迹> _划片轨迹列表镜像 = new List<划片轨迹>();

        public static List<配方参数P> _配方参数列表 = new List<配方参数P>();//20240201

        public static List<分析信息> _分析信息列表 = new List<分析信息>();
        public static List<分析信息X> _分析信息列表X = new List<分析信息X>();
        public static string _默认地址_分析信息 = @"C:\app_data\分析信息.txt";
        public static string _默认地址_分析信息X = @"C:\app_data\分析信息X.txt";

        public static string _默认地址_系统文件夹 = @"C:\app_data";
        public static string _默认地址_系统参数 = @"C:\app_data\默认参数.ini";
        public static string _默认地址_配方参数 = @"C:\app_data\配方.txt";
        public static string _默认地址_采集数据 = @"C:\app_data\采集数据.xlsx";

        public static List<信息输出> _信息输出列表 = new List<信息输出>();

        public static bool _控制器连接状态 = false;

        public static 用户 _操作员 = new 用户("操作员", "", 0);
        public static 用户 _Admin = new 用户("管理员", "", 2);

        //public static 用户 _技术员 = new 用户("技术员", "Technician", "123456", 1);
        //public static 用户 _管理员 = new 用户("管理员", "Administrator", "888888", 2);
        public static 用户 _CZY = new 用户("NULL", "0", (ushort)用户.权限选择.超级权限);

        //参数权限
        public const ushort _高权限 = 2;
        public const ushort _中权限 = 1;
        public const ushort _低权限 = 0;

        //参数类型
        public const ushort _参数类型_系统参数 = 0;
        public const ushort _参数类型_测试参数 = 10;
        public const ushort _参数类型_复位动作参数 = 8;


        public const ushort _信息属性_普通信息 = 0;
        public const ushort _信息属性_报警信息 = 1;

        /// <summary>
        /// 主界面object
        /// </summary>
        public static object MianForm = null;

        //线程资源
        public static int _工艺运行等待时间 = 5;
        public static int _工艺结束后等待时间 = 30;
        public static int _工艺休眠时间 = 300;


        public static List<系统错误> _系统错误表 = new List<系统错误>();
        public static string _默认地址_系统错误记录 = @"C:\app_data\系统错误历史记录.txt";



        //
        public static double _整条线动作时间 = 0;
    }

    public class 用户
    {
        public enum 权限选择 : ushort
        {
            低级权限,
            中级权限,
            高级权限,
            超级权限
        }


        public string 名 = "";
        public string 密码 = "";

        /// <summary>
        /// 0:最低权限
        /// 1:中等权限
        /// 2:最高权限
        /// </summary>
        public ushort 权限 = (ushort)权限选择.低级权限;

        public bool 登录状态 = false;

        public 用户(string name, string password, ushort permision)
        {
            名 = name;
            密码 = password;
            权限 = permision;
            _用户列表.Add(this);
        }

        public static List<用户> _用户列表 = new List<用户>();


    }

    public class 分析信息
    {
        public string Date;
        public double time;
        public bool G1, G2, G3;
        public double Vel;
        public int Count;
        public 分析信息(string date, double time, bool g1, bool g2, bool g3, double vel, int count)
        {
            Date = date;
            this.time = time;
            G1 = g1;
            G2 = g2;
            G3 = g3;
            Vel = vel;
            Count = count;
            GLV._分析信息列表.Add(this);
        }
    }

    public class 分析信息X
    {
        public string Date;
        public double time;
        public bool G1, G2, G3;
        public double Vel;
        public int Count;
        public 分析信息X(string date, double time, bool g1, bool g2, bool g3, double vel, int count)
        {
            Date = date;
            this.time = time;
            G1 = g1;
            G2 = g2;
            G3 = g3;
            Vel = vel;
            Count = count;
            GLV._分析信息列表X.Add(this);
        }
    }

    public class S系统参数
    {
        public string Name = "未命名";
        public string Name_En = "null";
        public double Value = 0;
        public ushort 权限 = GLV._高权限;
        public ushort 分类 = GLV._参数类型_系统参数;
        public string Unit = "毫米";
        public string Unit_En = "mm";
        public string 解析 = " ";
        public string 解析_En = " ";


        public S系统参数(string 参数名, string 参数名英文, double 数值, string 单位, ushort 参数类型, ushort 参数权限)
        {
            Name = 参数名;
            Name_En = 参数名英文;
            Value = 数值;
            Unit = 单位;
            权限 = 参数权限;
            分类 = 参数类型;
        }

        public S系统参数(string 参数名, string 参数名英文, double 数值, string 单位, ushort 参数类型, ushort 参数权限, string 介绍)
        {
            Name = 参数名;
            Name_En = 参数名英文;
            Value = 数值;
            Unit = 单位;
            权限 = 参数权限;
            分类 = 参数类型;
            解析 = 介绍;
        }

        public S系统参数(ushort line, string 参数名, string 参数名英文, double 数值, string 单位, ushort 参数类型, ushort 参数权限)
        {
            Name = 参数名;
            Name_En = 参数名英文;
            Value = 数值;
            Unit = 单位;
            权限 = 参数权限;
            分类 = 参数类型;
        }
        public S系统参数(string 参数名, string 参数名英文, double 数值, string 单位, string 单位英文, ushort 参数类型, ushort 参数权限, string 介绍, string 介绍英文)
        {
            Name = 参数名;
            Name_En = 参数名英文;
            Value = 数值;
            Unit = 单位;
            Unit_En = 单位英文;
            权限 = 参数权限;
            分类 = 参数类型;
            解析 = 介绍;
            解析_En = 介绍英文;
        }

        public S系统参数(string 参数名, string 参数名英文, double 数值, string 单位, string 单位英文, ushort 参数类型, ushort 参数权限)
        {
            Name = 参数名;
            Name_En = 参数名英文;
            Value = 数值;
            Unit = 单位;
            Unit_En = 单位英文;
            权限 = 参数权限;
            分类 = 参数类型;
            解析 = "";
            解析_En = "";
        }

    }


    public class 配方参数P
    {
        public string Name = "未命名";
        public string Name_En = "null";
        public double Value = 0;

        public 配方参数P()
        {
            Name = "NULL";
            Name_En = Name;
            Value = 0;
            GLV._配方参数列表.Add(this);
        }
        public 配方参数P(string name, string name_En, double value)
        {
            Name = name;
            Name_En = name_En;
            Value = value;

            GLV._配方参数列表.Add(this);
        }

        public 配方参数P(string name, double value)
        {
            Name = name;
            Name_En = name;
            Value = value;
            GLV._配方参数列表.Add(this);
        }
    }
        

    

    //
    public class 缝纫机方向控制配方
    {
        public double 中值电压 = 0;
        public double 中值位移 = 0;

        public double 左1电压变化 = 0;
        public double 左2电压变化 = 0;
        public double 左3电压变化 = 0;
        public double 右1电压变化 = 0;
        public double 右2电压变化 = 0;
        public double 右3电压变化 = 0;

        public double 左1斜率 = 0;
        public double 左2斜率 = 0;
        public double 左3斜率 = 0;
        public double 右1斜率 = 0;
        public double 右2斜率 = 0;
        public double 右3斜率 = 0;


        public double x0 = 0;
        public double y0 = 0;

        public double xl1 = 0;
        public double xl2 = 0;
        public double xl3 = 0;
        public double xr1 = 0;
        public double xr2 = 0;
        public double xr3 = 0;

        public double yl1 = 0;
        public double yl2 = 0;
        public double yl3 = 0;
        public double yr1 = 0;
        public double yr2 = 0;
        public double yr3 = 0;

        public void 计算()
        {
            
            x0 = 工艺测试.配方_中值电压;
            y0 = 工艺测试.配方_中值位移;

            xl1 = x0 + 工艺测试.配方_左1电压变化;
            yl1 = y0 + 工艺测试.配方_左1斜率 * 工艺测试.配方_左1电压变化;

            xl2 = xl1 + 工艺测试.配方_左2电压变化;
            yl2 = yl1 + 工艺测试.配方_左2斜率 * 工艺测试.配方_左2电压变化;

            xl3 = xl2 + 工艺测试.配方_左3电压变化;
            yl3 = yl2 + 工艺测试.配方_左3斜率 * 工艺测试.配方_左3电压变化;


            xr1 = x0 + 工艺测试.配方_右1电压变化;
            yr1 = y0 + 工艺测试.配方_右1斜率 * 工艺测试.配方_右1电压变化;

            xr2 = xr1 + 工艺测试.配方_右2电压变化;
            yr2 = yr1 + 工艺测试.配方_右2斜率 * 工艺测试.配方_右2电压变化;

            xr3 = xr2 + 工艺测试.配方_右3电压变化;
            yr3 = yr2 + 工艺测试.配方_右3斜率 * 工艺测试.配方_右3电压变化;


        }


    }



    public class 信息输出
    {
        //public ushort line;//线路
        public ushort type;//属性
        public string msg;//信息

        public 信息输出(ushort 线路, ushort 属性, string 信息)
        {
            //line = 线路;
            type = 属性;
            msg = 信息;

            string time = System.DateTime.Now.Year + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Day
                + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;
            if (type == 0)
            {
                msg = time + " " + 信息;
            }
            else if (type == 1)
            {
                msg = time + " - <错误!!!> - " + 信息;
            }
            else if (type == 2)
            {
                msg = time + " " + 信息;
            }
        }
    }




    public class DXF数据
    {
        public int 编号 = 0;

        /// <summary>
        /// 0:直线,1:圆弧
        /// </summary>
        public ushort 类型 = 0;


        public double 起点X = 0;
        public double 起点Y = 0;

        public double 终点X = 0;
        public double 终点Y = 0;

        public double 圆心X = 0;
        public double 圆心Y = 0;

        public double 半径R = 0;
        public double 起点角度 = 0;
        public double 终点角度 = 0;

        /// <summary>
        /// 0:劣弧 1:优弧
        /// </summary>
        public ushort 优劣弧 = 0;


        public DXF数据(double x1, double y1, double x2, double y2)
        {
            类型 = 0;

            起点X = x1;
            起点Y = y1;

            终点X = x2;
            终点Y = y2;

        }

        public DXF数据(double orgx, double orgy, double r, double start_anlge, double end_angle)
        {
            类型 = 1;

            圆心X = orgx;
            圆心Y = orgy;

            半径R = r;
            起点角度 = start_anlge;
            终点角度 = end_angle;

            起点X = Math.Round(圆心X + 半径R * Math.Cos(起点角度 * 2 * Math.PI / 360), 3);
            起点Y = Math.Round(圆心Y + 半径R * Math.Sin(起点角度 * 2 * Math.PI / 360), 3);
            终点X = Math.Round(圆心X + 半径R * Math.Cos(终点角度 * 2 * Math.PI / 360), 3);
            终点Y = Math.Round(圆心Y + 半径R * Math.Sin(终点角度 * 2 * Math.PI / 360), 3);

            if (终点角度 < 起点角度)
            {
                if (起点角度 - 终点角度 > 180)
                {
                    优劣弧 = 0;
                }
                else
                {
                    优劣弧 = 1;
                }
            }
            else
            {
                if (终点角度 - 起点角度 > 180)
                {
                    优劣弧 = 1;
                }
                else
                {
                    优劣弧 = 0;
                }
            }

        }

    }

    public class 显示轨迹
    {


    }


    public class 划片轨迹
    {
        public int 编号 = 0;

        public ushort 类型 = 0;

        public double 起点X = 0;
        public double 起点Y = 0;

        public double 终点X = 0;
        public double 终点Y = 0;

        public double 圆心X = 0;
        public double 圆心Y = 0;

        public double 相对坐标_终点X = 0;
        public double 相对坐标_终点Y = 0;
        public double 相对坐标_圆心X = 0;
        public double 相对坐标_圆心Y = 0;

        public double 圆弧方向 = 0;


        public double 加减速时间 = 0.03;

        public double 速度 = 100;

        public bool 出光 = false;

        public 划片轨迹()
        {
        }

        public 划片轨迹(double x, double y, double vel, bool enable)
        {
            类型 = 0;
            相对坐标_终点X = x;
            相对坐标_终点Y = y;

            速度 = vel;

            出光 = enable;
        }

        public 划片轨迹(double dx, double dy, double ox, double oy, double vel, bool enable, double dir)
        {
            类型 = 1;
            相对坐标_圆心X = ox;
            相对坐标_圆心Y = oy;
            相对坐标_终点X = dx;
            相对坐标_终点Y = dy;

            速度 = vel;
            圆弧方向 = dir;

            出光 = enable;
        }

        public 划片轨迹(double x1, double y1, double x2, double y2, double vel, double acc, bool enable)
        {
            类型 = 0;

            起点X = x1;
            起点Y = y1;

            终点X = x2;
            终点Y = y2;

            相对坐标_终点X = 终点X - 起点X;
            相对坐标_终点Y = 终点Y - 起点Y;

            加减速时间 = acc;
            速度 = vel;

            出光 = enable;
        }

        public 划片轨迹(double x1, double y1, double x2, double y2, double ox, double oy, double arc_angle, double vel, double acc, bool enable)
        {
            类型 = 1;

            起点X = x1;
            起点Y = y1;

            终点X = x2;
            终点Y = y2;

            圆心X = ox;
            圆心Y = oy;

            相对坐标_终点X = 终点X - 起点X;
            相对坐标_终点Y = 终点Y - 起点Y;
            相对坐标_圆心X = 圆心X - 起点X;
            相对坐标_圆心Y = 圆心Y - 起点Y;




            double star = 0, end = 0;
            double X = 0;

            star = (Math.Atan2(起点Y - 圆心Y, 起点X - 圆心X)) * 180 / Math.PI;
            end = (Math.Atan2(终点Y - 圆心Y, 终点X - 圆心X)) * 180 / Math.PI;

            star = star % 360;
            end = end % 360;

            if (star < 0)
            {
                star = 360 + star;
            }
            if (end < 0)
            {
                end = 360 + end;
            }

            X = end - star;

            double DIR = 0;


            if (arc_angle == 0)
            {
                if (X > 0 && X < 180)
                {
                    DIR = 1;
                }
                else if (X > 0 && X > 180)
                {
                    DIR = 0;
                }
                else if (X < 0 && X > -180)
                {
                    DIR = 0;
                }
                else if (X < 0 && X < -180)
                {
                    DIR = 1;
                }
            }
            else
            {
                if (X > 0 && X < 180)
                {
                    DIR = 0;
                }
                else if (X > 0 && X > 180)
                {
                    DIR = 1;
                }
                else if (X < 0 && X > -180)
                {
                    DIR = 1;
                }
                else if (X < 0 && X < -180)
                {
                    DIR = 0;
                }
            }

            圆弧方向 = DIR;


            加减速时间 = acc;
            速度 = vel;

            出光 = enable;


        }



    }
    /// <summary>
    /// 系统错误
    /// </summary>
    public class 系统错误
    {
        public ushort 错误线路 = 0;
        //string 错误名称 = "";
        public string 错误内容 = "";
        public string 报错时间 = "";

        /// <summary>
        /// 新建一个错误
        /// </summary>
        /// <param name="line">线路选择</param>
        /// <param name="name">错误名称</param>
        /// <param name="msg">错误信息</param>
        public 系统错误(ushort line, string msg)
        {
            错误线路 = line;
            // 错误名称 = name;
            错误内容 = msg;
            报错时间 = System.DateTime.Now.Year + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Day
                + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;

        }

        /// <summary>
        /// 新建一个错误
        /// </summary>
        /// <param name="line">线路选择</param>
        /// <param name="name">错误名称</param>
        /// <param name="msg">错误信息</param>
        /// <param name="time">错误产生时间</param>
        public 系统错误(ushort line, string msg, string time)
        {
            错误线路 = line;
            //错误名称 = name;
            错误内容 = msg;
            报错时间 = time;

            //报警输出
            //TH报警输出窗口 th = new TH报警输出窗口();
            //th._输出类型 = 5;//报警输出
            //th._输出字段 = 报错时间 + " - <错误!!!> - " + msg;
            //th._线路 = line;
            //Thread t = new Thread(th.F添加字段);
            //t.IsBackground = true;
            //t.Start(GLV.MianForm);
        }



        
    }
    public class 剪口
    {
        /// <summary>
        /// 剪口名称
        /// </summary>
        public string 名称 { get;}

        /// <summary>
        /// 剪口数量
        /// </summary>
        public uint 数量;


        private ushort 剪口传感器编号;

        private ushort 剪口检测编码器编号;

        public 剪口(string 名称, uint 数量, ushort 剪口传感器编号,ushort 剪口检测编码器编号)
        {
            this.名称 = 名称;
            this.数量 = 数量;
            this.剪口传感器编号 = 剪口传感器编号;
            this.剪口检测编码器编号 = 剪口检测编码器编号;
        }

        private List<double> 剪口有列表 = new List<double>();
        private List<double> 剪口无列表 = new List<double>();
        private List<double> 剪口列表 = new List<double>();

        public uint 剪口计数 = 0;
        public bool 剪口有信号 = false;

        private double enc1 = 0;//剪口位置记录1
        private double enc2 = 0;//剪口位置记录2

        public void ACT清除()
        {
            剪口计数 = 0;
            剪口有信号 = false;
            enc1 = 0;
            enc2 = 0;
            剪口有列表.Clear();
            剪口无列表.Clear();
            剪口列表.Clear();


        }
        /// <summary>
        /// TRUE：剪口正常
        /// FALSE:异常：已超出设定的剪口数量
        /// </summary>
        /// <param name="num">剪口数量</param>
        /// <returns></returns>

        //public bool ACT剪口检测(uint num)
        //{
        //    数量 = num;
        //    if (剪口计数 >= 数量)
        //    {
        //        return false;
        //    }

        //    double enc = 运动控制.反馈位置(0, 剪口检测编码器编号); 

        //    if (!IO控制.IN(0, 剪口传感器编号) && !剪口有信号)
        //    {
        //        //Thread.Sleep(1);
        //        剪口有信号 = true;
        //        enc1 = enc;

        //    }
        //    if (IO控制.IN(0, 剪口传感器编号) && 剪口有信号)
        //    {
        //        //Thread.Sleep(1);
        //        剪口有信号 = false;
        //        enc2 = enc;
        //        if (enc2 - enc1 > 50)
        //        {
        //            剪口有列表.Add(enc1);
        //            剪口无列表.Add(enc2);
        //            剪口计数++;
        //            Task任务.信息输出(名称 + "的第"+ 剪口计数 + "个剪口剪口位置:" + enc1 + "和" + enc2);
        //        }                            

        //    }
        //    return true;
        //}

        public double 剪口冷却位置 = 0; // 记录上次剪口编码器位置
        //private double 剪口冷却阈值 = 工艺测试.配方_识别剪口间隔针数.Value * 1440; // 设定冷却距离（根据实际情况调整）
        //private double 剪口冷却阈值 = 20 * 1440;
        public bool ACT剪口检测(uint num, double num_new)
        {
            double 剪口冷却阈值 = 工艺测试.配方_识别剪口间隔针数.Value * 1440;
            数量 = num;
            if (剪口计数 >= 数量)
            {
                return false; // 已达到目标剪口数，停止检测
            }
            
            double 当前位置 = 运动控制.反馈位置(0, 剪口检测编码器编号);

            if ((剪口计数 == 0 && num_new > 0) ||
        (当前位置 - 剪口冷却位置 > 剪口冷却阈值 && num_new > 0))
            {
                剪口计数++;
                剪口冷却位置 = 当前位置;
                剪口列表.Add(剪口冷却位置);
                Task任务.信息输出(名称 + $"检测：第 {剪口计数} 个剪口，位置：{剪口冷却位置}");
                return  true;
            }


            return true;                      
        }

        public double ACT剪口位置获取(uint num)
        {
            if (num < 1)
            {
                return -1;
            }
            int numm = (int)num -1;
            try
            {
                double re = 剪口列表[numm];

                return re;
            }
            catch
            {
                Console.WriteLine("ACT剪口位置获取-error!!!");
                return -1;
            }

        }

    

    /// <summary>
    /// 返回计算后的剪口所对应的编码器位置
    /// 正数：OK
    /// 负数：NG
    /// </summary>
    /// <param name="num">第几个剪口</param>
    /// <returns></returns>
    public double ACT剪口位置计算(uint num)
    {
        if (num < 1)
        {
            return -1;
        }
        int numm = (int)num - 1;
        try 
        {
            double x1 = 剪口有列表[numm];
            double x2 = 剪口无列表[numm];
            double re = (x1 + x2) / 2;

            return re;
        }
        catch
        {
            Console.WriteLine("ACT剪口位置计算-error!!!");
            return -1;
        }
            
    }

    }
}
