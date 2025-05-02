using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Net.Sockets;
using Leadshine;
using System.Timers;
using System.Windows.Forms.DataVisualization.Charting;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace 缝纫机项目
{
    public partial class Form主界面 : Form
    {
        public static Form报警 form报警 = new Form报警();
        public static Form参数 form参数 = new Form参数();
        public static Form调试 form调试 = new Form调试();
        public static Form配方 form配方 = new Form配方();
        public static Form功能验证 form功能验证 = new Form功能验证();
        public static Form用户 form用户 = new Form用户();
        public static Form生产记录 form生产记录 = new Form生产记录();

        //private SnapThread sendThread = new SnapThread();




        客户端类 客户端 = new 客户端类();
        delegate void 委托打印客户端接收数据(string str);//创建委托
        委托打印客户端接收数据 readkhd;//创建委托字段
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        int lastSentCircle = -1;
        short ret = 0;
        short res = 0;
        ushort CardNo = 0;
        ushort axis = 0;
        ushort mode = 1;
        double Encoder_value = 0;
        double start_speed = 0;
        double speed = 1000;
        double stop_speed = 0;
        double tacc = 0.1;  //加速时间
        double tdec = 0.1;  //减速时间  
        double s_pare = 0.05;
        double dist = 1000;


        public Form主界面()
        {
            InitializeComponent();
        }

        //private void Callback(object sender, EventArgs e)
        //{

        //    ret = LTSMC.smc_set_counter_inmode(CardNo, axis, mode);
        //    res = LTSMC.smc_get_encoder_unit(CardNo, axis, ref Encoder_value);

        //    LTSMC.smc_set_profile_unit(CardNo, axis, start_speed, speed, tacc, tdec, stop_speed);
        //    LTSMC.smc_set_s_profile(CardNo, axis, 0, s_pare);
        //    double temp = Encoder_value / 2000;
        //    int circle = (int)temp;
        //    textBox1.Text = (circle).ToString();
        //    if (circle != lastSentCircle)
        //    {
        //        if (circle != 0 && circle % 1 == 0)
        //        {

        //            lastSentCircle = circle;
        //            客户端.发送(初始化.socketk, "abc");
        //            if (客户端.m_x != null)
        //            {
        //                char[] delimiterChars = { ';' };
        //                string[] cmd1 = 客户端.m_x.Split(delimiterChars);
        //                double angle = Convert.ToDouble(cmd1[0]);
        //                int num = Convert.ToInt16(cmd1[1]);

        //                if (angle <= 88 || angle >= 92)
        //                {
        //                    LTSMC.smc_pmove_unit(CardNo, axis, dist, 0);
        //                    //Delay(2000);              
        //                    //LTSMC.smc_stop(CardNo,axis, mode);
        //                }

        //                if (num >= 1)
        //                {

        //                    LTSMC.smc_pmove_unit(CardNo, axis, 3 * dist, 0);
        //                }

        //                //MessageBox.Show(tcpk.m_x);
        //            }
        //        }
        //    }
        //}


        private bool _是否清空richtextbox1 = false;

        private int 当前针数 = 0;
        private int iii = 0;

        public static Queue<double> 针数队列 = new Queue<double>(200);
        public static Queue<double> 上传感器状态队列 = new Queue<double>(200);
        public static Queue<double> 下传感器状态队列 = new Queue<double>(200);
        public static Queue<double> 上电机位置队列 = new Queue<double>(200);
        public static Queue<double> 下电机位置队列 = new Queue<double>(200);

        

       

        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            #region 按钮显示
            switch (MainProgram._程序状态)
            {
                case 0:

                    break;


                case 1:

                    break;

                case 2:

                    break;

                case 3:
                    //Console.WriteLine("3");
                    break;

            }



            #endregion

            #region 控制器状态

            if (GLV._控制器连接状态)
            {
                toolStripStatusLabel_控制器状态.BackColor = Color.LimeGreen;
                toolStripStatusLabel_控制器状态.Text = "控制器连接正常";


                外部按钮();
            }
            else
            {
                toolStripStatusLabel_控制器状态.BackColor = Color.Red;
                toolStripStatusLabel_控制器状态.Text = "控制器连接已断开,点击重连";
            }

            #endregion

            #region 信息输出列表

            int num = GLV._信息输出列表.Count;//指获取现有的个数,后面新加的等到下次
            for (int i = 0; i < num; i++)
            {
                try
                {
                    if (i > 100)//40改到100
                    {
                        GLV._信息输出列表.Clear();
                        break;
                    }

                    richTextBox1.SelectionStart = richTextBox1.TextLength;
                    richTextBox1.SelectionLength = 0;
                    if (GLV._信息输出列表[0].type == 0)//输出类型
                    { //普通输出
                        richTextBox1.SelectionColor = Color.Black;
                    }
                    else if (GLV._信息输出列表[0].type == 1)
                    { //报警输出
                        richTextBox1.SelectionColor = Color.Red;
                        _是否清空richtextbox1 = false;
                    }
                    else if (GLV._信息输出列表[0].type == 2)
                    { //系统信息
                        richTextBox1.SelectionColor = Color.Blue;
                        _是否清空richtextbox1 = false;
                    }
                    richTextBox1.AppendText(GLV._信息输出列表[0].msg);
                    richTextBox1.AppendText("\r\n");
                    GLV._信息输出列表.RemoveAt(0);
                    richTextBox1.ScrollToCaret();

                }
                catch
                {//没有数据

                }
            }
            if (richTextBox1.Lines.Length > 150 && _是否清空richtextbox1)
            {
                richTextBox1.Clear();
            }
            _是否清空richtextbox1 = true;

            #endregion

            toolStripStatusLabel_上传感器电压.Text = "上布料中心x:" + ((int)工艺测试.距离).ToString();
            toolStripStatusLabel_下传感器电压.Text = "下布料中心x:" + ((int)工艺测试.距离X).ToString();
            //toolStripStatusLabel_上传感器电压.Text = "上布料中心x:" + 模拟量.输入(0, GLV._上传感器).ToString() + "V";
            //toolStripStatusLabel_下传感器电压.Text = "下布料中心x:" + 模拟量.输入(0, GLV._下传感器).ToString() + "V";
            toolStripStatusLabel_缝纫机输出电压.Text = "缝纫机输出电压:" + 模拟量.输出(0, GLV._缝纫机控制).ToString() + "V";
            toolStripStatusLabel_已执行针数.Text = "已执行针数:" + 工艺测试.已执行针数;

            //textBox_转速.Text = Convert.ToString((工艺测试.已执行针数 - 当前针数) * 1000 * 60 / (double)timer1.Interval);
            //textBox_转速.Text = Convert.ToString(Math.Round(缝纫机转速标定.已知电压求转速(模拟量.输出(0, GLV._缝纫机控制)), 2));
            textBox_转速.Text = 缝纫机.当前转速().ToString();

            当前针数 = 工艺测试.已执行针数;




            #region 剪口显示



            //if (MainProgram._程序状态 == 5)
            //{
            //    针数队列.Enqueue(运动控制.反馈位置(0, GLV._缝纫机编码器));
            //    if (IO控制.IN(0, GLV._上剪口传感器))
            //    {
            //        step上 = 1;
            //        上传感器记录.Add(运动控制.反馈位置(0, GLV._缝纫机编码器));
            //        //上传感器状态队列.Enqueue(1);
            //    }
            //    else if (step上 == 1 && !IO控制.IN(0, GLV._上剪口传感器)
            //    {

            //    }

            //    chart1.Series[0].Points.DataBindXY(针数队列, 上传感器状态队列);
            //    if (IO控制.IN(0, GLV._下剪口传感器))
            //    {
            //        下传感器状态队列.Enqueue(-1);

            //    }
            //    else
            //    {
            //        下传感器状态队列.Enqueue(0);
            //    }
            //    chart1.Series[1].Points.DataBindXY(针数队列, 下传感器状态队列);

            //    chart1.ChartAreas[0].AxisX.ScaleView.Scroll(System.Windows.Forms.DataVisualization.Charting.ScrollType.Last);

            //    //chart1.Series[0].Points.AddXY(针数队列, 上传感器状态队列);
            //    //chart1.Series[1].Points.AddXY(针数队列, 下传感器状态队列);
            //    //chart1.Series[0].Points.DataBindXY(针数队列, 上传感器状态队列);
            //    //chart1.Series[1].Points.DataBindXY(针数队列, 下传感器状态队列);
            //    chart1.ChartAreas[0].AxisX.ScaleView.Scroll(System.Windows.Forms.DataVisualization.Charting.ScrollType.Last);
            //}
            //else if (MainProgram._程序状态 == 3)
            //{
            //    chart1.Series[0].Points.Clear();
            //    chart1.Series[1].Points.Clear();
            //    上传感器状态队列.Clear();
            //    下传感器状态队列.Clear();
            //}
            #endregion

            //#region 剪口电机运动显示
            //if (MainProgram._程序状态 == 5)
            //{
            //    //针数队列.Enqueue(当前针数);
            //    上电机位置队列.Enqueue(运动控制.指令位置(0, GLV._上压紧电机));
            //    chart2.Series[0].Points.DataBindXY(针数队列, 上电机位置队列);
            //    下电机位置队列.Enqueue(运动控制.指令位置(0, GLV._下压紧电机));
            //    chart2.Series[1].Points.DataBindXY(针数队列, 下电机位置队列);

            //    chart2.ChartAreas[0].AxisX.ScaleView.Scroll(System.Windows.Forms.DataVisualization.Charting.ScrollType.Last);
            //}
            //else if (MainProgram._程序状态 == 3)
            //{
            //    chart2.Series[0].Points.Clear();
            //    chart2.Series[1].Points.Clear();
            //    上电机位置队列.Clear();
            //    下电机位置队列.Clear();
            //}
            //#endregion
            timer1.Enabled = true;
        }

       
        private void Form主界面_Load(object sender, EventArgs e)
        {
            readkhd = KHDread;//委托绑定执行方法

            初始化.F初始化();    

            Form参数.LS初始化(ref Form参数.系统参数列表);
            F默认参数载入(0, GLV._默认地址_系统参数, "参数");

            
            form配方.Show();
            form配方.Hide();
            //form功能验证.Show();
            //form功能验证.Hide();

            form报警.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form参数.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form调试.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form配方.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form功能验证.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            

            timer1.Enabled = true;




            chart1.ChartAreas[0].AxisY.Maximum = 2;
            chart1.ChartAreas[0].AxisY.Minimum = -2;

            chart2.ChartAreas[0].AxisY.Maximum = 10000;
            chart2.ChartAreas[0].AxisY.Minimum = -10000;
        }
        private void F默认参数载入(ushort line, string path, string HeadMessage)
        {

            string inipath = path;

            if (!File.Exists(inipath))
            {
                //MessageBox.Show("文件不存在");
                return;
            }


            //读取文件第一行
            string[] txt;
            try
            {
                txt = File.ReadAllLines(@inipath);
            }
            catch (Exception)
            {
                return;
            }
            if (txt.Length > 0)
            {
                if (string.Compare(HeadMessage, txt[0]) == 0)
                {
                    //Program.txtpath = Convert.ToString(txt[i + 1]);
                    //Program.numA = Convert.ToInt64(txt[i + 2]);
                    //Program.numB = Convert.ToInt64(txt[i + 3]);
                    //Program.sum = Convert.ToInt64(txt[i + 4]);
                }
                else
                {
                    MessageBox.Show("系统参数文件不正确!", "The system parameter file is incorrect!");
                    return;
                }

            }
            else
            {
                return;
            }

            //
            INI文件管理.path = inipath;
            string[] name = new string[1000];
            string[] value = new string[1000];
            int lenth = 0;
            INI文件管理.GetSectionData(inipath, "参数", ref name, ref value, ref lenth);

            for (int i = 0; i < name.Length; i++)
            {
                for (int j = 0; j < Form参数.系统参数列表.Count; j++)
                {
                    if (String.Compare(name[i], Form参数.系统参数列表[j].Name) == 0)
                    {
                        Form参数.系统参数列表[j].Value = Convert.ToDouble(value[i]);
                        //d.Rows[i].Cells[2].Value = UC_参数设置1.系统参数列表[j].权限;
                        //d.Rows[i].Cells[3].Value = UC_参数设置1.系统参数列表[j].分类;
                        break;
                    }
                }
            }

        }
        private void ToolStripMenuItem系统参数_Click(object sender, EventArgs e)
        {
            form参数.TopMost = true;
            form参数.Visible = true;
            form参数.TopMost = false;
        }

        private void ToolStripMenuItem调试窗口_Click(object sender, EventArgs e)
        {
            form调试.TopMost = true;
            form调试.Visible = true;
            form调试.TopMost = false;
        }

        private void ToolStripMenuItem报警记录_Click(object sender, EventArgs e)
        {
            form报警.TopMost = true;
            form报警.Visible = true;
            form报警.TopMost = false;
        }

        private void ToolStripMenuItem配方_Click(object sender, EventArgs e)
        {
            //form功能验证.TopMost = true;
            //form功能验证.Visible = true;
            //form功能验证.TopMost = false;

            form配方.TopMost = true;
            form配方.Visible = true;
            form配方.TopMost = false;
        }

        private void button_启动_Click(object sender, EventArgs e)
        {
            MainProgram._程序状态 = 5;
            MainProgram.TH工艺测试.step = (ushort)工艺测试.STEP.编码器位置清零;
        }

        private void button_暂停_Click(object sender, EventArgs e)
        {

        }

        private void button_停止_Click(object sender, EventArgs e)
        {
            工艺测试.sendThread.Stop();
            MainProgram._程序状态 = 7;
            MainProgram.停止逻辑step = 1;
            缝纫机.待机();
        }

        private void button_复位_Click(object sender, EventArgs e)
        {
            MainProgram._程序状态 = 1;
            MainProgram.TH复位.step = 1;
            

        }

        private bool 压脚状态 = false;
        private void 外部按钮()
        {
            if (IO控制.IN(0, GLV._启动按钮))
            {
                button_启动_Click(null, null);
            }
            if (IO控制.IN(0, GLV._停止按钮))
            {
                button_停止_Click(null, null);
            }
            if (IO控制.IN(0, GLV._复位按钮))
            {
                button_复位_Click(null, null);
            }

            if (IO控制.IN(0, GLV._抬压脚)&& !压脚状态)//抬压脚
            {
                button_抬压脚_Click(null, null);
                压脚状态 = true;
            }
            if (!IO控制.IN(0, GLV._抬压脚) && 压脚状态)//待机
            {
                button_待机_Click(null, null);
                压脚状态 = false;
            }

        }

        private void Form主界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.英文版)
            {
                if (MessageBox.Show("Are you sure to quit？", "Exit tips", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (MessageBox.Show("确定退出？", "退出程序提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form主界面_FormClosed(object sender, FormClosedEventArgs e)
        {
            //释放资源
            this.Dispose();
            this.DialogResult = DialogResult.OK;

            //结束所有线程
            Application.ExitThread();
            Application.Exit();
            Thread.Sleep(20);
            //控制卡断开链接


            //程序退出
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void toolStripStatusLabel_控制器状态_Click(object sender, EventArgs e)
        {
            //点击重连
            if (!控制器.控制器连接状态())
            {
                控制器.初始化();
                
            }
        }

        private void button_抬压脚_Click(object sender, EventArgs e)
        {
            缝纫机.抬压脚();
        }

        private void button_待机_Click(object sender, EventArgs e)
        {
            缝纫机.待机();
        }

        private void ToolStripMenuItem用户_Click(object sender, EventArgs e)
        {
            form用户.TopMost = true;
            form用户.Visible = true;
            form用户.TopMost = false;
        }

        private void button_加速_Click(object sender, EventArgs e)
        {
            double 当前设置的转速 = 缝纫机转速标定.已知电压求转速(模拟量.输出(0, GLV._缝纫机控制));
            double 新转速 = 0;
            if (当前设置的转速 < 工艺测试._缝纫机最大工作转速.Value - 工艺测试._缝纫机工作转速变化.Value)
            {
                新转速 = 当前设置的转速 + 工艺测试._缝纫机工作转速变化.Value;
                缝纫机.控制(缝纫机转速标定.已知转速求电压(新转速));
                Task任务.信息输出("缝纫机转速变化,转速:" + 新转速 + ",电压:" + 缝纫机转速标定.已知转速求电压(新转速));

                //新转速直接保存20230322
                工艺测试._缝纫机初始工作转速.Value = 新转速;
                INI文件管理.IniWrite(GLV._默认地址_系统参数, "参数", 工艺测试._缝纫机初始工作转速.Name.ToString(), 工艺测试._缝纫机初始工作转速.Value.ToString());
            }
        }

        private void button_减速_Click(object sender, EventArgs e)
        {
            double 当前设置的转速 = 缝纫机转速标定.已知电压求转速(模拟量.输出(0, GLV._缝纫机控制));
            double 新转速 = 0;
            if (当前设置的转速 > 工艺测试._缝纫机最小工作转速.Value + 工艺测试._缝纫机工作转速变化.Value)
            {
                新转速 = 当前设置的转速 - 工艺测试._缝纫机工作转速变化.Value;
                缝纫机.控制(缝纫机转速标定.已知转速求电压(新转速));
                Task任务.信息输出("缝纫机转速变化,转速:" + 新转速 + ",电压:" + 缝纫机转速标定.已知转速求电压(新转速));

                //新转速直接保存20230322
                工艺测试._缝纫机初始工作转速.Value = 新转速;
                INI文件管理.IniWrite(GLV._默认地址_系统参数, "参数", 工艺测试._缝纫机初始工作转速.Name.ToString(), 工艺测试._缝纫机初始工作转速.Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            工艺测试.GGG();
        }
        public static bool gg1, gg2, gg3;

        private void button2_Click(object sender, EventArgs e)
        {
            string[] msg = new string[GLV._分析信息列表.Count];
            for (int i = 0; i < GLV._分析信息列表.Count; i++)
            {
                msg[i] = GLV._分析信息列表[i].Date + "," + GLV._分析信息列表[i].time + "," + GLV._分析信息列表[i].G1 + "," + GLV._分析信息列表[i].G2 + "," + GLV._分析信息列表[i].G3 + "," + GLV._分析信息列表[i].Vel + "," + GLV._分析信息列表[i].Count;

            }
            TXT文件管理.数据保存(GLV._默认地址_分析信息, msg);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 工艺测试.上传感器记录.Count; i++)
            {
                Console.WriteLine("上剪口位置:" + 工艺测试.上传感器记录[i]);
            }
            for (int i = 0; i < 工艺测试.下传感器记录.Count; i++)
            {
                Console.WriteLine("下剪口位置:" + 工艺测试.下传感器记录[i]);
            }
            //chart1.Series[0].Points.DataBindXY(针数队列, 上传感器状态队列);
            //chart1.Series[1].Points.DataBindXY(针数队列, 下传感器状态队列);
            //chart1.ChartAreas[0].AxisX.ScaleView.Scroll(System.Windows.Forms.DataVisualization.Charting.ScrollType.Last);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //工艺测试.GGG();
            数据采集.清零();
            数据采集.采集(0);
            数据采集.采集(1);
            数据采集.采集(2);
            数据采集.输出();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //if (trackBar1.Value < 20)
            //{
            //    gg1 = false; gg2 = false; gg3 = false;
            //}
            //else if (trackBar1.Value > 20 && trackBar1.Value < 40)
            //{
            //    gg1 = true; gg2 = false; gg3 = false;
            //}
            //else if (trackBar1.Value > 60)
            //{
            //    gg1 = true; gg2 = true; gg3 = true;
            //}
            //else
            //{
            //    gg1 = true; gg2 = true; gg3 = false;
            //}
        }
        //    private (double 平均距离1, int 数量1, int 数量2, double 平均距离2, int 数量3, int 数量4) _lastData
        //= (0, 0, 0, 0, 0, 0);
        private Stopwatch stopwatch = new Stopwatch();
        public double 编码器位置 = 0;
        private async void Send_ClickAsync(object sender, EventArgs e)
        {
            //var sendStart = DateTime.Now;

            //sendThread.Start();


            //TimerDispos.CreateAndStartTimer();



            //运动控制.反馈位置清零(0, GLV._下剪口电机);
            //stopwatch.Start();

            VM通讯.客户端.m_x = null;
            VM通讯.发送("snap");
            bool 是否收到数据 = await SnapThread.等待数据接收(80);
            if (是否收到数据)
            {
                if (VM通讯.接收信息拆解Try(VM通讯.客户端.m_x, out var data))
                {
                    工艺测试.距离 = data.距离;
                    工艺测试.距离X = data.距离X;
                }
                else
                {
                    Task任务.信息输出("超时");
                }
            }

            //运动控制.定速运动(0, GLV._上电机, 1000, 0.02, 1);
            //stopwatch.Stop();
            //long mSeconds = stopwatch.ElapsedMilliseconds;
            //stopwatch.Reset();
            //Task任务.信息输出("C#发送信息到电机响应约为" + mSeconds.ToString() + "ms");
            //for (int i = 0; i < 1000; i++)
            //{
            //    编码器位置 = 运动控制.反馈位置(0, GLV._下剪口电机);
            //    Task任务.信息输出(编码器位置.ToString());
            //    //Thread.Sleep(1);
            //    if (编码器位置 >= 1)
            //    {
            //        stopwatch.Stop();
            //        运动控制.单轴停止(0, GLV._上电机);

            //        long mSeconds = stopwatch.ElapsedMilliseconds;
            //        stopwatch.Reset();
            //        Task任务.信息输出("C#发送信息到电机响应约为" + mSeconds.ToString() + "ms");
            //        break;
            //    }
            //}

            //运动控制.点位运动(0, 3, 8000, 0.02, -1000, 1);
            //Delay((int)2000);
            //运动控制.点位运动(0, 3, 8000, 0.02, 0, 1);

            //VM通讯.发送("abc");

            //LTSMC.smc_set_encoder_unit(0, 0, 0);

            //myTimer.Tick += new EventHandler(Callback); //给timer挂起事件

            //myTimer.Enabled = true;//使timer可用

            //myTimer.Interval = 100;//设置时间间隔，以毫秒为单位
            //Task任务.信息输出(运动控制.反馈位置(0, GLV._缝纫机编码器).ToString());
            ////运动控制.反馈位置清零(0, GLV._缝纫机编码器);
            //缝纫机.控制(3.8);
            //double 当前编码器位置 = 运动控制.反馈位置(0, GLV._缝纫机编码器);
            //if (当前编码器位置 < 1440 * 10)
            //{
            //    缝纫机.待机();
            //}
            //else
            //{

            //}


        }

        public void 客户端接收(object socketk)
        {
            while (true)
            {

                Socket socket = socketk as Socket;//转换类型

                string str = 客户端.接收(socket);//接收服务器数据
                VM通讯.客户端.m_x = str;
                if (str != null)//判断接收内容是否为空
                {
                    Invoke(readkhd, str);//执行委托
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
        private TimerDispos timerdispos = new TimerDispos();
        private void button5_Click(object sender, EventArgs e)
        {
            //sendThread.Stop();

            //var sendEnd = DateTime.Now;
            //Task任务.信息输出("总耗时:" + (sendEnd - sendStart).TotalMilliseconds + "ms");



            TimerDispos.StopTimer();
            模拟量.输出(0, GLV._缝纫机控制, 1.9);
            Thread.Sleep(500);
            模拟量.输出(0, GLV._缝纫机控制, 0);
        }

        private void KHDread(string str)//客户端接收委托关联方法
        {
            //textBox1.AppendText(str + "\r\n");//添加数据并换行
        }

        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }
    }





}
