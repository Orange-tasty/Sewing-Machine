using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 缝纫机项目
{
    public partial class Form调试 : Form
    {
        public static Form功能验证 form功能验证 = new Form功能验证();

        public Form调试()
        {
            InitializeComponent();
        }


        delegate void 表格委托(List<DataGridView> ld);//委托
        delegate void 按钮委托(List<Button> bu);//委托
        delegate void 文本委托(List<Label> la);//委托

        private List<DataGridView> LD = new List<DataGridView>();
        private List<Button> BU = new List<Button>();
        private List<Label> LA = new List<Label>();

        private void Form调试_Load(object sender, EventArgs e)
        {
            this.Text = "轴与IO测试";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            #region dataGridView初始化


            //button2.Enabled = false;
            //if (Program.英文版)
            //{
            //    this.Text = "DebugForm";
            //    label1.Text = "IN";
            //    label2.Text = "OUT";
            //    groupBox1.Text = "Axis Test";
            //    label_0_轴名称.Text = "Lifting";
            //    label_1_轴名称.Text = "X-axis";
            //    label_2_轴名称.Text = "Y-axis";
            //    label_3_轴名称.Text = "Laser";
            //    label_4_轴名称.Text = "Upload";
            //    label_5_轴名称.Text = "Download";

            //    label4.Text = "Speed";
            //    label7.Text = "Speed";
            //    label10.Text = "Speed";
            //    label13.Text = "Speed";
            //    label11.Text = "Speed";
            //    label15.Text = "Speed";

            //    label5.Text = "Pos";
            //    label6.Text = "Pos";
            //    label9.Text = "Pos";
            //    label12.Text = "Pos";
            //    label8.Text = "Pos";
            //    label14.Text = "Pos";

            //    button_0_运动.Text = "Move";
            //    button_1_运动.Text = "Move";
            //    button_2_运动.Text = "Move";
            //    button_3_运动.Text = "Move";
            //    button_4_运动.Text = "Move";
            //    button_5_运动.Text = "Move";

            //    button_0_停止.Text = "Stop";
            //    button_1_停止.Text = "Stop";
            //    button_2_停止.Text = "Stop";
            //    button_3_停止.Text = "Stop";
            //    button_4_停止.Text = "Stop";
            //    button_5_停止.Text = "Stop";

            //    button_0_反方向.Text = "Jog-";
            //    button_1_反方向.Text = "Jog-";
            //    button_2_反方向.Text = "Jog-";
            //    button_3_反方向.Text = "Jog-";
            //    button_4_反方向.Text = "Jog-";
            //    button_5_反方向.Text = "Jog-";

            //    button_0_正方向.Text = "Jog+";
            //    button_1_正方向.Text = "Jog+";
            //    button_2_正方向.Text = "Jog+";
            //    button_3_正方向.Text = "Jog+";
            //    button_4_正方向.Text = "Jog+";
            //    button_5_正方向.Text = "Jog+";

            //    button_0_正限位.Text = "EL+";
            //    button_1_正限位.Text = "EL+";
            //    button_2_正限位.Text = "EL+";
            //    button_3_正限位.Text = "EL+";
            //    button_4_正限位.Text = "EL+";
            //    button_5_正限位.Text = "EL+";

            //    button_0_负限位.Text = "EL-";
            //    button_1_负限位.Text = "EL-";
            //    button_2_负限位.Text = "EL-";
            //    button_3_负限位.Text = "EL-";
            //    button_4_负限位.Text = "EL-";
            //    button_5_负限位.Text = "EL-";

            //    button_0_原点.Text = "ORG";
            //    button_1_原点.Text = "ORG";
            //    button_2_原点.Text = "ORG";
            //    button_3_原点.Text = "ORG";
            //    button_4_原点.Text = "ORG";
            //    button_5_原点.Text = "ORG";

            //    button_0_报警.Text = "ALM";
            //    button_1_报警.Text = "ALM";
            //    button_2_报警.Text = "ALM";
            //    button_3_报警.Text = "ALM";
            //    button_4_报警.Text = "ALM";
            //    button_5_报警.Text = "ALM";

            //    button_0_报警清除.Text = "ALM-RST";
            //    button_1_报警清除.Text = "ALM-RST";
            //    button_2_报警清除.Text = "ALM-RST";
            //    button_3_报警清除.Text = "ALM-RST";
            //    button_4_报警清除.Text = "ALM-RST";
            //    button_5_报警清除.Text = "ALM-RST";


            //}


            //////////
            ////1号线
            //输入口
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.ColumnCount = 3;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;


            dataGridView1.Columns[0].Name = "IN";



            dataGridView1.Columns[0].Width = 70;
            if (!Program.英文版)
                dataGridView1.Columns[1].Name = "名称";
            else
                dataGridView1.Columns[1].Name = "NAME";

            dataGridView1.Columns[1].Width = 300;

            if (!Program.英文版)
                dataGridView1.Columns[2].Name = "状态";
            else
                dataGridView1.Columns[2].Name = "STATE";
            dataGridView1.Columns[2].Width = 100;

            dataGridView1.Rows.Add(16);
            F输入口(dataGridView1, 0);

            //列不许自动排序
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            //输出口
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView2.ColumnCount = 4;
            dataGridView2.ColumnHeadersVisible = true;
            dataGridView2.ScrollBars = ScrollBars.Both;

            //DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            dataGridView2.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dataGridView2.Columns[0].Name = "OUT";
            dataGridView2.Columns[0].Width = 70;

            if (!Program.英文版)
                dataGridView2.Columns[1].Name = "名称";
            else
                dataGridView2.Columns[1].Name = "NAME";

            dataGridView2.Columns[1].Width = 300;

            if (!Program.英文版)
                dataGridView2.Columns[2].Name = "状态";
            else
                dataGridView2.Columns[2].Name = "STATE";
            dataGridView2.Columns[2].Width = 100;

            if (!Program.英文版)
                dataGridView2.Columns[3].Name = "编号";
            else
                dataGridView2.Columns[3].Name = "NUM";

            dataGridView2.Columns[3].Width = 100;
            dataGridView2.Columns[3].Visible = false;

            dataGridView2.Rows.Add(16);
            F输出口(dataGridView2, 0);
            //列不许自动排序
            for (int i = 0; i < this.dataGridView2.Columns.Count; i++)
            {
                this.dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            #endregion


            F初始化();
            ThreadStart ts = new ThreadStart(LoadData);
            Thread thread = new Thread(ts);
            thread.Name = "LoadData";
            thread.Start();

        }


        private void F初始化()
        {
            LD.Add(dataGridView1);
            LD.Add(dataGridView2);

            BU.Add(button_0_负限位);
            BU.Add(button_1_负限位);
            BU.Add(button_2_负限位);
            BU.Add(button_3_负限位);
            BU.Add(button_4_负限位);
            BU.Add(button_5_负限位);

            BU.Add(button_0_原点);
            BU.Add(button_1_原点);
            BU.Add(button_2_原点);
            BU.Add(button_3_原点);
            BU.Add(button_4_原点);
            BU.Add(button_5_原点);

            BU.Add(button_0_正限位);
            BU.Add(button_1_正限位);
            BU.Add(button_2_正限位);
            BU.Add(button_3_正限位);
            BU.Add(button_4_正限位);
            BU.Add(button_5_正限位);

            BU.Add(button_0_报警);
            BU.Add(button_1_报警);
            BU.Add(button_2_报警);
            BU.Add(button_3_报警);
            BU.Add(button_4_报警);
            BU.Add(button_5_报警);

            LA.Add(label_0_当前位置);
            LA.Add(label_1_当前位置);
            LA.Add(label_2_当前位置);
            LA.Add(label_3_当前位置);
            LA.Add(label_4_当前位置);
            LA.Add(label_5_当前位置);


        }

        private void LoadData()
        {

            while (true)
            {

                SetText(LD);
                SetText_1(BU);
                SetText_2(LA);

                Thread.Sleep(100);
            }

        }
        private void SetText(List<DataGridView> ld)
        {

            if (label1.InvokeRequired)
            {
                表格委托 stcb = new 表格委托(SetText);
                this.Invoke(stcb, new object[] { ld });
            }
            else
            {
                F输入口(ld[0], 0);
                F输出口(ld[1], 0);
                //if (Program_程序._程序状态[GLV._1号线] != 12)
                //{
                //    F输入口(ld[0], GLV._1号线);
                //    F输出口(ld[1], GLV._1号线);
                //}
                //if (Program_程序._程序状态[GLV._2号线] != 12)
                //{
                //    F输入口(ld[2], GLV._2号线);
                //    F输出口(ld[3], GLV._2号线);
                //}



                //label1.Text = "X:" + pos[0] + 换行 + 换行 + "Y:" + pos[1] + 换行 + 换行 + "Z:" + pos[2] + 换行 + 换行 + "R:" + pos[3];

            }

        }

        private void SetText_1(List<Button> bu)
        {

            if (label1.InvokeRequired)
            {
                按钮委托 stcb = new 按钮委托(SetText_1);
                this.Invoke(stcb, new object[] { bu });
            }
            else
            {
                int i = 0;
                F轴负限位输入信号(bu[i], 0, GLV._axis0); i++;
                F轴负限位输入信号(bu[i], 0, GLV._axis1); i++;
                F轴负限位输入信号(bu[i], 0, GLV._axis2); i++;
                F轴负限位输入信号(bu[i], 0, GLV._axis3); i++;
                F轴负限位输入信号(bu[i], 0, GLV._axis4); i++;
                F轴负限位输入信号(bu[i], 0, GLV._axis5); i++;

                F轴原点输入信号(bu[i], 0, GLV._axis0); i++;
                F轴原点输入信号(bu[i], 0, GLV._axis1); i++;
                F轴原点输入信号(bu[i], 0, GLV._axis2); i++;
                F轴原点输入信号(bu[i], 0, GLV._axis3); i++;
                F轴原点输入信号(bu[i], 0, GLV._axis4); i++;
                F轴原点输入信号(bu[i], 0, GLV._axis5); i++;

                F轴正限位输入信号(bu[i], 0, GLV._axis0); i++;
                F轴正限位输入信号(bu[i], 0, GLV._axis1); i++;
                F轴正限位输入信号(bu[i], 0, GLV._axis2); i++;
                F轴正限位输入信号(bu[i], 0, GLV._axis3); i++;
                F轴正限位输入信号(bu[i], 0, GLV._axis4); i++;
                F轴正限位输入信号(bu[i], 0, GLV._axis5); i++;

                F轴报警输入信号(bu[i], 0, GLV._axis0); i++;
                F轴报警输入信号(bu[i], 0, GLV._axis1); i++;
                F轴报警输入信号(bu[i], 0, GLV._axis2); i++;
                F轴报警输入信号(bu[i], 0, GLV._axis3); i++;
                F轴报警输入信号(bu[i], 0, GLV._axis4); i++;
                F轴报警输入信号(bu[i], 0, GLV._axis5); i++;


            }

        }


        private void SetText_2(List<Label> la)
        {

            if (label1.InvokeRequired)
            {
                文本委托 stcb = new 文本委托(SetText_2);
                this.Invoke(stcb, new object[] { la });
            }
            else
            {
                int i = 0;
                F轴当前位置(la[i], 0, GLV._axis0); i++;
                F轴当前位置(la[i], 0, GLV._axis1); i++;
                F轴当前位置(la[i], 0, GLV._axis2); i++;
                F轴当前位置(la[i], 0, GLV._axis3); i++;
                F轴当前位置(la[i], 0, GLV._axis4); i++;
                F轴当前位置(la[i], 0, GLV._axis5); i++;

            }

        }



        #region 输入口信号刷新
        private void F输入口(DataGridView d, ushort line)
        {
            int i = 0;
            if (!Program.英文版)
            {
                F输入(d, i, line, "_复位按钮", GLV._复位按钮); i++;
                F输入(d, i, line, "_启动按钮", GLV._启动按钮); i++;
                F输入(d, i, line, "_暂停按钮", GLV._暂停按钮); i++;
                F输入(d, i, line, "_停止按钮", GLV._停止按钮); i++;
                F输入(d, i, line, "_抬压脚", GLV._抬压脚); i++;

            }
            else
            {
                F输入(d, i, line, "_RESET", GLV._复位按钮); i++;
                F输入(d, i, line, "_START", GLV._启动按钮); i++;
                F输入(d, i, line, "_PAUSE", GLV._暂停按钮); i++;
                F输入(d, i, line, "_STOP", GLV._停止按钮); i++;
                F输入(d, i, line, "_UP", GLV._抬压脚); i++;


            }




        }
        private void F输入(DataGridView d, int i, ushort line, string name, ushort name_num)
        {
            d.Rows[i].Cells[0].Value = name_num;
            d.Rows[i].Cells[1].Value = name;
            d.Rows[i].Cells[2].Value = IO控制.IN(line, name_num);
            if (IO控制.IN(line, name_num))
            {
                d.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
            }
            else
            {
                d.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
        }

        private void F轴报警输入信号(Button d, ushort line, ushort axis)
        {
            //d.Rows[i].Cells[0].Value = i;
            //d.Rows[i].Cells[1].Value = name;
            //d.Rows[i].Cells[2].Value = 运动控制.轴报警(line, axis);
            if (运动控制.轴报警(line, axis))
            {
                d.BackColor = Color.Red;
            }
            else
            {
                d.BackColor = Color.WhiteSmoke;
            }
        }

        private void F轴正限位输入信号(Button d, ushort line, ushort axis)
        {
            //d.Rows[i].Cells[0].Value = i;
            //d.Rows[i].Cells[1].Value = name;
            //d.Rows[i].Cells[2].Value = 运动控制.轴正限位(line, axis);
            if (运动控制.轴正限位(line, axis))
            {
                d.BackColor = Color.LimeGreen;
            }
            else
            {
                d.BackColor = Color.WhiteSmoke;
            }
        }


        private void F轴负限位输入信号(Button d, ushort line, ushort axis)
        {
            //d.Rows[i].Cells[0].Value = i;
            //d.Rows[i].Cells[1].Value = name;
            //d.Rows[i].Cells[2].Value = 运动控制.轴正限位(line, axis);
            if (运动控制.轴负限位(line, axis))
            {
                d.BackColor = Color.LimeGreen;
            }
            else
            {
                d.BackColor = Color.WhiteSmoke;
            }
        }

        private void F轴原点输入信号(Button d, ushort line, ushort axis)
        {
            if (运动控制.轴原点(line, axis))
            {
                d.BackColor = Color.LimeGreen;
            }
            else
            {
                d.BackColor = Color.WhiteSmoke;
            }
        }

        private void F轴当前位置(Label d, ushort line, ushort axis)
        {

            //if (!Program.英文版)
            //{
            //    d.Text = "位置: " + Math.Round(运动控制.反馈位置(line, axis), 2).ToString();
            //}
            //else
            //{
            //    d.Text = "POS: " + Math.Round(运动控制.反馈位置(line, axis), 2).ToString();
            //}

            if (!Program.英文版)
            {
                d.Text = "位置: " + Math.Round(运动控制.指令位置(line, axis), 2).ToString();
            }
            else
            {
                d.Text = "POS: " + Math.Round(运动控制.指令位置(line, axis), 2).ToString();
            }

        }


        #endregion 

        #region 输出口信号刷新
        private void F输出口(DataGridView d, ushort line)
        {
            int i = 0;
            line = 0;

            if (!Program.英文版)
            {
                F输出(d, i, line, "_上拐弯电机气缸", GLV._上拐弯电机气缸); i++;
                F输出(d, i, line, "_下拐弯电机气缸", GLV._下拐弯电机气缸); i++;
                F输出(d, i, line, "_上直线电机气缸", GLV._上直线电机气缸); i++;
                
                

            }
            else
            {

                F输出(d, i, line, "_上拐弯电机气缸", GLV._上拐弯电机气缸); i++;
                F输出(d, i, line, "_下拐弯电机气缸", GLV._下拐弯电机气缸); i++;
                F输出(d, i, line, "_上直线电机气缸", GLV._上直线电机气缸); i++;


            }



        }
        private void F输出(DataGridView d, int i, ushort line, string name, ushort name_num)
        {
            //d.Rows.Add();
            d.Rows[i].Cells[0].Value = i;
            d.Rows[i].Cells[1].Value = name;
            d.Rows[i].Cells[2].Value = IO控制.OUT(line, name_num);
            d.Rows[i].Cells[3].Value = name_num;

            if (IO控制.OUT(line, name_num))
            {
                d.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
            }
            else
            {
                d.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
        }

        #endregion

        /// <summary>
        /// TRUE:安全,可操作
        /// FALSE:不安全,不可操作
        /// </summary>
        /// <returns></returns>
        private bool 安全保护()
        {
            if (MainProgram._程序状态 == (short)MainProgram._程序状态定义.运行)
            {
                MessageBox.Show("系统运行中,不允许操作");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form功能验证.TopMost = true;
            form功能验证.Show();
            form功能验证.TopMost = false;

        }

        private void Form调试_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button_1_运动_Click(object sender, EventArgs e)
        {
            if (安全保护())
                运动控制.点位运动(0, GLV._axis1, (double)numericUpDown_1_速度.Value, 0.1, (double)numericUpDown_1_定位.Value, 0);
             
            
        }

        private void button_1_停止_Click(object sender, EventArgs e)
        {
            if (安全保护())
                运动控制.单轴停止(0, GLV._axis1);



        }

        private void button_2_运动_Click(object sender, EventArgs e)
        {
            if (安全保护())
                运动控制.点位运动(0, GLV._axis2, (double)numericUpDown_2_速度.Value, 0.1, (double)numericUpDown_2_定位.Value, 0);

        }

        private void button_2_停止_Click(object sender, EventArgs e)
        {
            if (安全保护())
                运动控制.单轴停止(0, GLV._axis2);
        }

        private void button_1_反方向_MouseDown(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            运动控制.定速运动(0, GLV._axis1, (double)numericUpDown_1_速度.Value, 0.1, 0);
        }

        private void button_1_反方向_MouseUp(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            运动控制.单轴停止(0, GLV._axis1);
        }

        private void button_1_正方向_MouseDown(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            运动控制.定速运动(0, GLV._axis1, (double)numericUpDown_1_速度.Value, 0.1, 1);
        }

        private void button_1_正方向_MouseUp(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            运动控制.单轴停止(0, GLV._axis1);
        }

        private void button_2_反方向_MouseDown(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            运动控制.定速运动(0, GLV._axis2, (double)numericUpDown_2_速度.Value, 0.1, 0);
        }

        private void button_2_反方向_MouseUp(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            运动控制.单轴停止(0, GLV._axis2);
        }
        

        private void button_2_正方向_MouseDown(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            运动控制.定速运动(0, GLV._axis2, (double)numericUpDown_2_速度.Value, 0.1, 1);
        }

        private void button_2_正方向_MouseUp(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            运动控制.单轴停止(0, GLV._axis2);
        }

        private void button_电压输出_Click(object sender, EventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            缝纫机.控制((double)numericUpDown_缝纫机输出电压.Value);

        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void F输出控制(DataGridView d, ushort line, ushort num)
        {
            if (!安全保护())
            {
                return;
            }
            if (IO控制.OUT(line, num))
            {
                IO控制.OUT(line, num, false);
            }
            else
            {
                IO控制.OUT(line, num, true);
            }

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            try
            {
                ushort num = (ushort)dataGridView2.Rows[i].Cells[3].Value;
                F输出控制(dataGridView2, 0, num);
            }
            catch
            {

            }
        }

        private void button_3_运动_Click(object sender, EventArgs e)
        {
            
            运动控制.点位运动(0, GLV._axis3, (double)numericUpDown_3_速度.Value, 0.1, (double)numericUpDown_3_定位.Value, 0);
        }

        private void button_3_停止_Click(object sender, EventArgs e)
        {
            //if (!安全保护())
            //{
            //    return;
            //}
            //运动控制.单轴停止(0, GLV._回针电机);
            运动控制.单轴停止(0, GLV._axis3);
        }

        private void button_3_正方向_MouseDown(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            //运动控制.定速运动(0, GLV._回针电机, (double)numericUpDown_3_速度.Value, 0.1, 1);
            运动控制.定速运动(0, GLV._axis3, (double)numericUpDown_3_速度.Value, 0.1, 1);
        }

        private void button_3_正方向_MouseUp(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            运动控制.单轴停止(0, GLV._axis3);
        }

        private void button_3_反方向_MouseDown(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            //运动控制.定速运动(0, GLV._回针电机, (double)numericUpDown_3_速度.Value, 0.1, 0);
            运动控制.定速运动(0, GLV._axis3, (double)numericUpDown_3_速度.Value, 0.1, 0);
        }

        private void button_3_反方向_MouseUp(object sender, MouseEventArgs e)
        {
            if (!安全保护())
            {
                return;
            }
            运动控制.单轴停止(0, GLV._axis3);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button_开始速度标定_Click(object sender, EventArgs e)
        {
            if (MainProgram._当前用户.权限 != 2)
            {
                MessageBox.Show("权限不够!");
                return;
            }
            MainProgram._程序状态 = 9;
            MainProgram.TH缝纫机转速标定.step = (ushort)缝纫机转速标定.STEP.启动一次标定;
        }

        private void button_标定参数保存_Click(object sender, EventArgs e)
        {
            if (MainProgram._当前用户.权限 != 2)
            {
                MessageBox.Show("权限不够!");
                return;
            }
            if (MessageBox.Show("是否下载标定参数 A:"+缝纫机转速标定._缝纫机转速标A.Value +  "  B:"+ 缝纫机转速标定._缝纫机转速标B.Value+" ？", "Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form参数.F参数保存("参数");
            }
            else
            {
                return;
            }

            
        }

        private void button_停止速度标定_Click(object sender, EventArgs e)
        {
            if (MainProgram._当前用户.权限 != 2)
            {
                MessageBox.Show("权限不够!");
                return;
            }
            MainProgram._程序状态 = 7;
            MainProgram.TH缝纫机转速标定.step = (ushort)缝纫机转速标定.STEP.默认;
            缝纫机.待机();

        }

        private void button_0_运动_Click(object sender, EventArgs e)
        {
            运动控制.点位运动(0, GLV._axis0, (double)numericUpDown_0_速度.Value, 0.1, (double)numericUpDown_0_定位.Value, 0);
        }

        private void button_0_停止_Click(object sender, EventArgs e)
        {
            运动控制.单轴停止(0, GLV._axis0);
        }

        private void button_0_反方向_MouseDown(object sender, MouseEventArgs e)
        {
            运动控制.定速运动(0, GLV._axis0, (double)numericUpDown_0_速度.Value, 0.1, 0);
        }

        private void button_0_反方向_MouseUp(object sender, MouseEventArgs e)
        {
            运动控制.单轴停止(0, GLV._axis0);
        }

        private void button_0_正方向_MouseDown(object sender, MouseEventArgs e)
        {
            运动控制.定速运动(0, GLV._axis0, (double)numericUpDown_0_速度.Value, 0.1, 1);
        }

        private void button_0_正方向_MouseUp(object sender, MouseEventArgs e)
        {
            运动控制.单轴停止(0, GLV._axis0);
        }

        private void button_1_报警清除_Click(object sender, EventArgs e)
        {

        }
    }
}
