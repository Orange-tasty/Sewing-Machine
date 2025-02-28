using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace 缝纫机项目
{
    public partial class Form参数 : Form
    {
        public Form参数()
        {
            InitializeComponent();
        }
        public static List<S系统参数> 系统参数列表 = new List<S系统参数>();//参数列表

        private ushort 参数类型选择 = 99;


        private void Form参数_Load(object sender, EventArgs e)
        {
            this.Text = "系统参数";


            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            //列不许自动排序
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.ColumnCount = 6;

            dataGridView1.Columns[0].Name = "参数名";

            dataGridView1.Columns[0].Width = 320;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns[1].Name = "数值";

            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[1].ReadOnly = false;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridView1.Columns[2].Name = "权限";

            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].Visible = false;


            dataGridView1.Columns[3].Name = "分类";

            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].Visible = false;


            dataGridView1.Columns[4].Name = "单位";

            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridView1.Columns[5].Name = "介绍";


            dataGridView1.Columns[5].Width = 450;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;


            LS初始化(ref 系统参数列表);
            F数据上传到表格(dataGridView1);
        }

        private void Form参数_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }




        public static void LS初始化(ref List<S系统参数> L)
        {
            L.Clear();

            //系统参数
            L.Add(工艺测试._缝纫机初始工作转速);
            L.Add(工艺测试._缝纫机最大工作转速);
            L.Add(工艺测试._缝纫机最小工作转速);

            L.Add(工艺测试._缝纫机工作转速变化);
            L.Add(工艺测试._初次下针时编码器位置);
            L.Add(工艺测试._上电机速度上限);
            L.Add(工艺测试._上电机速度下限);
            L.Add(工艺测试._下电机速度上限);
            L.Add(工艺测试._下电机速度下限);
            L.Add(工艺测试._上剪口电机速度上限);
            L.Add(工艺测试._上剪口电机速度下限);
            L.Add(工艺测试._下剪口电机速度上限);
            L.Add(工艺测试._下剪口电机速度下限);
            L.Add(工艺测试._上下电机气缸动作延时);
            L.Add(工艺测试._上下电机气缸回位延时);
            L.Add(工艺测试._直线气缸动作延时);
            L.Add(工艺测试._直线气缸回位延时);
            L.Add(工艺测试._回针电机速度);
            L.Add(工艺测试._对剪口功能使能);
            L.Add(工艺测试._PID的KI累计);
            L.Add(工艺测试._PID的延迟针数);




            //复位参数

            L.Add(复位._复位气缸动作等待时间);



            //缝纫机转速标定参数
            L.Add(缝纫机转速标定._缝纫机转速标定电压1);
            L.Add(缝纫机转速标定._缝纫机转速标定电压2);
            L.Add(缝纫机转速标定._缝纫机转速标定时长1);
            L.Add(缝纫机转速标定._缝纫机转速标定时长2);
            L.Add(缝纫机转速标定._缝纫机转速标A);
            L.Add(缝纫机转速标定._缝纫机转速标B);

            //缝纫机系统参数
            L.Add(缝纫机._缝纫机待机电压);
            L.Add(缝纫机._缝纫机抬压脚电压);
            L.Add(缝纫机._缝纫机剪线电压);
            L.Add(缝纫机._缝纫机回针电压);


        }


        private void F数据上传到表格(DataGridView d)
        {
            F表格数据清空(d);
            for (int i = 0; i < 系统参数列表.Count; i++)
            {
                F表格数据载入(d, 系统参数列表[i]);
            }

            F检查();
        }
        private void F数据上传到表格(DataGridView d, ushort type)
        {
            F表格数据清空(d);
            for (int i = 0; i < 系统参数列表.Count; i++)
            {

                if (type == 99)
                {
                    F表格数据载入(d, 系统参数列表[i]);
                }
                else
                {
                    if (系统参数列表[i].分类 == type)
                    {
                        F表格数据载入(d, 系统参数列表[i]);
                    }

                }

            }

            F检查();
        }

        private void F检查()
        {
            //F数据上传到表格(dataGridView1);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //参数权限高于当前权限
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) > MainProgram._当前用户.权限)
                {
                    dataGridView1.Rows[i].Visible = false;
                    //break;
                }
            }
            //for (int i = 0; i < dataGridView1.Rows.Count;)
            //{
            //    if (F勾选哪一项显示() <= 100)
            //    {
            //        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) != F勾选哪一项显示())
            //        {
            //            dataGridView1.Rows.RemoveAt(i);
            //        }
            //        else
            //        {

            //            i++;
            //        }
            //    }
            //    else
            //    {
            //        i++;
            //    }
            //    //


            //}
        }


        private void F表格数据清空(DataGridView d)
        {
            d.Rows.Clear();
        }

        private void F表格数据载入(DataGridView d, S系统参数 s)
        {

            d.Rows.Add();


            //参数名
            d.Rows[d.RowCount - 1].Cells[0].Value = s.Name;
            d.Rows[d.RowCount - 1].Cells[1].Value = s.Value;
            d.Rows[d.RowCount - 1].Cells[2].Value = s.权限;
            d.Rows[d.RowCount - 1].Cells[3].Value = s.分类;
            d.Rows[d.RowCount - 1].Cells[4].Value = s.Unit;
            d.Rows[d.RowCount - 1].Cells[5].Value = s.解析;




        }
        private void F表格数据载入(DataGridView d, S系统参数 s, short line)
        {

            d.Rows.Add();

            //参数名
            d.Rows[d.RowCount - 1].Cells[0].Value = s.Name;
            d.Rows[d.RowCount - 1].Cells[1].Value = s.Value;
            d.Rows[d.RowCount - 1].Cells[2].Value = s.权限;
            d.Rows[d.RowCount - 1].Cells[3].Value = s.分类;
            d.Rows[d.RowCount - 1].Cells[4].Value = s.Unit;
            d.Rows[d.RowCount - 1].Cells[5].Value = s.解析;


        }

        private void button_导入_Click(object sender, EventArgs e)
        {
            F参数导入(ref dataGridView1, 0, "参数");

            F检查();
        }
        private void button_导出_Click(object sender, EventArgs e)
        {
            F参数导出(dataGridView1, 0, "参数");
        }


        #region 参数导入模块************************************************************************
        private void F参数导入(ref DataGridView d, ushort line, string HeadMessage)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择要打开的配置文件";
            ofd.Filter = "配置文件|*.ini";
            string inipath = "";
            ofd.ShowDialog();
            inipath = ofd.FileName;

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
                    MessageBox.Show("系统参数文件不正确!");
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
            F表格数据清空(d);
            for (int i = 0; i < lenth; i++)
            {
                d.Rows.Add();

                for (int j = 0; j < 系统参数列表.Count; j++)
                {
                    if (String.Compare(name[i], 系统参数列表[j].Name) == 0)
                    {
                        系统参数列表[j].Value = Convert.ToDouble(value[i]);

                        break;
                    }
                }

                ////参数名
                //d.Rows[d.RowCount - 1].Cells[0].Value = name[i];
                ////数值
                //d.Rows[d.RowCount - 1].Cells[1].Value = value[i];
            }




            F数据上传到表格(d);


        }
        #endregion

        #region 参数导出模块************************************************************************
        private void F参数导出(DataGridView d, ushort line, string HeadMessage)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = @"C:\Users\SpringRain\Desktop";
            sfd.Title = "请选择要保存的位置";
            sfd.FileName = "系统参数001";
            sfd.Filter = "配置文件|*.ini";
            DialogResult rr = sfd.ShowDialog();
            if (File.Exists(sfd.FileName))
            {
                File.Delete(sfd.FileName);
            }
            if (rr == DialogResult.Cancel)
            {
                return;
            }
            //获得要保存的文件的路径
            string inipath = sfd.FileName;
            if (inipath.Length < 2)
            {
                return;
            }
            else
            {
                //Console.WriteLine(inipath);
            }
            if (!File.Exists(inipath))
            {
                FileStream FS = new FileStream(inipath, FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(FS);
                sw.WriteLine(HeadMessage);//在第一行添加文本
                sw.Close();
                sw.Dispose();
                FS.Close();
            }
            int lenth = d.Rows.Count;
            if (lenth <= 0)
            {
                //表格为空
                return;
            }
            INI文件管理.path = inipath;
            //for (int i = 0; i < lenth; i++)
            //{
            //    INI文件管理.IniWrite("参数", d.Rows[i].Cells[0].Value.ToString(), d.Rows[i].Cells[1].Value.ToString());

            //}
            for (int i = 0; i < 系统参数列表.Count; i++)
            {
                INI文件管理.IniWrite(inipath, "参数", 系统参数列表[i].Name.ToString(), 系统参数列表[i].Value.ToString());
            }




            //GLV._默认地址_系统参数 = INI文件管理.path;

        }

        private static void F参数默认保存(DataGridView d, ushort line, string HeadMessage)
        {

            string inipath = GLV._默认地址_系统参数;

            if (!File.Exists(inipath))
            {
                FileStream FS = new FileStream(inipath, FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(FS);
                sw.WriteLine(HeadMessage);//在第一行添加文本
                sw.Close();
                sw.Dispose();
                FS.Close();
            }
            int lenth = d.Rows.Count;
            if (lenth <= 0)
            {
                //表格为空
                return;
            }
            INI文件管理.path = inipath;
            for (int i = 0; i < 系统参数列表.Count; i++)
            {
                INI文件管理.IniWrite(inipath, "参数", 系统参数列表[i].Name.ToString(), 系统参数列表[i].Value.ToString());
            }




            //GLV._默认地址_系统参数 = INI文件管理.path;

        }

        public static void F参数保存(string HeadMessage)
        {
            string inipath = GLV._默认地址_系统参数;

            if (!File.Exists(inipath))
            {
                FileStream FS = new FileStream(inipath, FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(FS);
                sw.WriteLine(HeadMessage);//在第一行添加文本
                sw.Close();
                sw.Dispose();
                FS.Close();
            }

            INI文件管理.path = inipath;
            for (int i = 0; i < 系统参数列表.Count; i++)
            {
                INI文件管理.IniWrite(inipath, "参数", 系统参数列表[i].Name.ToString(), 系统参数列表[i].Value.ToString());
            }

        }




        #endregion

        
        private void button_上传_Click(object sender, EventArgs e)
        {
            参数上传(dataGridView1);

            F检查();

            //按钮颜色();
            F数据上传到表格(dataGridView1, 参数类型选择);
        }


        private bool _参数下载按钮保护 = false;
        private void button_下载_Click(object sender, EventArgs e)
        {
            if (_参数下载按钮保护 == true)
            {
                MessageBox.Show("检测到按钮重复点击,请稍后再尝试");
                return;
            }
            else
            {
                _参数下载按钮保护 = true;
            }

            DialogResult dr = MessageBox.Show("是否确认将当前参数保存", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                //继续
            }
            else
            {
                _参数下载按钮保护 = false;
                return;
            }


            参数下载(dataGridView1);
            F参数默认保存(dataGridView1, 0, "参数");

            _参数下载按钮保护 = false;
            Task任务.系统输出("参数下载完成");
        }


        private void 参数下载(DataGridView d)
        {
            for (int i = 0; i < d.Rows.Count; i++)
            {
                for (int j = 0; j < 系统参数列表.Count; j++)
                {

                    if (String.Compare(d.Rows[i].Cells[0].Value.ToString(), 系统参数列表[j].Name) == 0)
                    {
                        系统参数列表[j].Value = Convert.ToDouble(d.Rows[i].Cells[1].Value);
                        //d.Rows[d.RowCount - 1].Cells[2].Value = s.权限;
                        //d.Rows[d.RowCount - 1].Cells[3].Value = s.分类;
                        //d.Rows[d.RowCount - 1].Cells[4].Value = s.Unit;
                        //d.Rows[d.RowCount - 1].Cells[5].Value = s.解析;
                        break;
                    }
                    //if (!Program.英文版)
                    //{
                    //    if (String.Compare(d.Rows[i].Cells[0].Value.ToString(), 系统参数列表[j].Name) == 0)
                    //    {
                    //        系统参数列表[j].Value = Convert.ToDouble(d.Rows[i].Cells[1].Value);
                    //        //d.Rows[d.RowCount - 1].Cells[2].Value = s.权限;
                    //        //d.Rows[d.RowCount - 1].Cells[3].Value = s.分类;
                    //        //d.Rows[d.RowCount - 1].Cells[4].Value = s.Unit;
                    //        //d.Rows[d.RowCount - 1].Cells[5].Value = s.解析;
                    //        break;
                    //    }
                    //}
                    //else
                    //{
                    //    if (String.Compare(d.Rows[i].Cells[0].Value.ToString(), 系统参数列表[j].Name_En) == 0)
                    //    {
                    //        系统参数列表[j].Value = Convert.ToDouble(d.Rows[i].Cells[1].Value);
                    //        //d.Rows[d.RowCount - 1].Cells[2].Value = s.权限;
                    //        //d.Rows[d.RowCount - 1].Cells[3].Value = s.分类;
                    //        //d.Rows[d.RowCount - 1].Cells[4].Value = s.Unit;
                    //        //d.Rows[d.RowCount - 1].Cells[5].Value = s.解析;
                    //        break;
                    //    }
                    //}

                }
            }
        }

        private void 参数上传(DataGridView d)
        {
            F数据上传到表格(d);
        }
    }
}
