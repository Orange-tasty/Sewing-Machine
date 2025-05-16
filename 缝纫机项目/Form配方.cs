using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet;
using MathNet.Numerics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 缝纫机项目
{
    public partial class Form配方 : Form
    {
        public Form配方()
        {
            InitializeComponent();
        }


        public static List<double> 配方列表 = new List<double>();

        private void Form配方_Load(object sender, EventArgs e)
        {
            //double v = Integrate.OnClosedInterval(x => x * x, 0, 10);
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;



            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.ColumnCount = 2;

            dataGridView1.Columns[0].Name = "上电机";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[0].ReadOnly = false;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns[1].Name = "下电机";
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[1].ReadOnly = false;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;


            配方初始化();

            配方导入(GLV._默认地址_配方参数);
            配方显示();


        }



        private void Form配方_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            工艺测试.配方_尾针数.Value = Convert.ToDouble(numericUpDown尾针数.Value);

            //
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(Convert.ToInt32(工艺测试.配方_尾针数.Value));


            //列不许自动排序
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }


        private static void 配方初始化()
        {
            工艺测试.配方_尾针表.Clear();
            工艺测试.配方_尾针表X.Clear();
            for (int i = 0; i < 20; i++)
            {
                工艺测试.配方_尾针表.Add(new 配方参数P("尾针" + i.ToString(), 0));
                工艺测试.配方_尾针表X.Add(new 配方参数P("尾针X" + i.ToString(), 0));
            }
            

        }

        

        private void 配方确认()
        {
            //工艺测试.配方_X1 = Convert.ToDouble(textBox_X1.Text);
            //工艺测试.配方_X2 = Convert.ToDouble(textBox_X2.Text);
            //工艺测试.配方_X3 = Convert.ToDouble(textBox_X3.Text);

            工艺测试.配方_上A.Value = Convert.ToDouble(numericUpDown_上A.Value);
            工艺测试.配方_上B.Value = Convert.ToDouble(numericUpDown_上B.Value);
            工艺测试.配方_上C.Value = Convert.ToDouble(numericUpDown_上C.Value);
            工艺测试.配方_上P.Value = Convert.ToDouble(numericUpDown_上P.Value);
            工艺测试.配方_上I.Value = Convert.ToDouble(numericUpDown_上I.Value);
            工艺测试.配方_上D.Value = Convert.ToDouble(numericUpDown_上D.Value);
            工艺测试.配方_上V.Value = Convert.ToDouble(numericUpDown_上V.Value);

            工艺测试.配方_下A.Value = Convert.ToDouble(numericUpDown_下A.Value);
            工艺测试.配方_下B.Value = Convert.ToDouble(numericUpDown_下B.Value);
            工艺测试.配方_下C.Value = Convert.ToDouble(numericUpDown_下C.Value);
            工艺测试.配方_下P.Value = Convert.ToDouble(numericUpDown_下P.Value);
            工艺测试.配方_下I.Value = Convert.ToDouble(numericUpDown_下I.Value);
            工艺测试.配方_下D.Value = Convert.ToDouble(numericUpDown_下D.Value);
            工艺测试.配方_下V.Value = Convert.ToDouble(numericUpDown_下V.Value);

            工艺测试.配方_上剪口数量.Value = Convert.ToDouble(numericUpDown_上剪口数量.Value);
            工艺测试.配方_上最后剪口后针数.Value = Convert.ToDouble(numericUpDown_上剪口后针数.Value);
            工艺测试.配方_上剪口电机基础速度.Value = Convert.ToDouble(numericUpDown_上剪口电机基础速度.Value);
            工艺测试.配方_上剪口差修正比例.Value = Convert.ToDouble(numericUpDown_上剪口差修正比例.Value);
            工艺测试.配方_上剪口缝纫机修正比例.Value = Convert.ToDouble(numericUpDown_上剪口缝纫机修正比例.Value);
            工艺测试.配方_上剪口差基本值.Value = Convert.ToDouble(numericUpDown_上剪口差基本值.Value);

            工艺测试.配方_下剪口数量.Value = Convert.ToDouble(numericUpDown_下剪口数量.Value);
            工艺测试.配方_下最后剪口后针数.Value = Convert.ToDouble(numericUpDown_下剪口后针数.Value);
            工艺测试.配方_下剪口电机基础速度.Value = Convert.ToDouble(numericUpDown_下剪口电机基础速度.Value);
            工艺测试.配方_下剪口差修正比例.Value = Convert.ToDouble(numericUpDown_下剪口差修正比例.Value);
            工艺测试.配方_下剪口缝纫机修正比例.Value = Convert.ToDouble(numericUpDown_下剪口缝纫机修正比例.Value);
            工艺测试.配方_下剪口差基本值.Value = Convert.ToDouble(numericUpDown_下剪口差基本值.Value);

            工艺测试.配方_总针数.Value = Convert.ToDouble(numericUpDown总针数.Value);
            工艺测试.配方_尾针数.Value = Convert.ToDouble(numericUpDown尾针数.Value);

            工艺测试.配方_针数后识别剪口.Value = Convert.ToDouble(numericUpDown1_针数后识别剪口.Value);
            工艺测试.配方_识别剪口间隔针数.Value = Convert.ToDouble(numericUpDown_识别剪口间隔针数.Value);
            工艺测试.配方_电缸压下脉冲数.Value = Convert.ToDouble(numericUpDown1_电缸压下脉冲数.Value);
            //工艺测试.配方_尾针表.Clear();
            //工艺测试.配方_尾针表X.Clear();
            int i = 0;  
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                
                工艺测试.配方_尾针表[i].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                工艺测试.配方_尾针表X[i].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                //工艺测试.配方_尾针表X.Add(new 配方参数P("尾针X" + i.ToString(), Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value)));
                //工艺测试.配方_尾针表X[i].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
            }
            for (; i < 20; i++)
            {
                //工艺测试.配方_尾针表.Add(new 配方参数P("尾针" + i.ToString(), 0));
                //工艺测试.配方_尾针表.Add(new 配方参数P("尾针X" + i.ToString(), 0));
            }

            //配方初始化(ref L);
        }

        private void 配方显示()
        {
            //textBox_X1.Text = 工艺测试.配方_X1.ToString();
            //textBox_X2.Text = 工艺测试.配方_X2.ToString();
            //textBox_X3.Text = 工艺测试.配方_X3.ToString();

            numericUpDown_上A.Value = Convert.ToDecimal(工艺测试.配方_上A.Value);
            numericUpDown_上B.Value = Convert.ToDecimal(工艺测试.配方_上B.Value);
            numericUpDown_上C.Value = Convert.ToDecimal(工艺测试.配方_上C.Value);
            numericUpDown_上P.Value = Convert.ToDecimal(工艺测试.配方_上P.Value);
            numericUpDown_上I.Value = Convert.ToDecimal(工艺测试.配方_上I.Value);
            numericUpDown_上D.Value = Convert.ToDecimal(工艺测试.配方_上D.Value);
            numericUpDown_上V.Value = Convert.ToDecimal(工艺测试.配方_上V.Value);

            numericUpDown_下A.Value = Convert.ToDecimal(工艺测试.配方_下A.Value);
            numericUpDown_下B.Value = Convert.ToDecimal(工艺测试.配方_下B.Value);
            numericUpDown_下C.Value = Convert.ToDecimal(工艺测试.配方_下C.Value);
            numericUpDown_下P.Value = Convert.ToDecimal(工艺测试.配方_下P.Value);
            numericUpDown_下I.Value = Convert.ToDecimal(工艺测试.配方_下I.Value);
            numericUpDown_下D.Value = Convert.ToDecimal(工艺测试.配方_下D.Value);
            numericUpDown_下V.Value = Convert.ToDecimal(工艺测试.配方_下V.Value);

            numericUpDown_上剪口数量.Value = Convert.ToDecimal(工艺测试.配方_上剪口数量.Value);
            numericUpDown_上剪口后针数.Value = Convert.ToDecimal(工艺测试.配方_上最后剪口后针数.Value);
            numericUpDown_上剪口电机基础速度.Value = Convert.ToDecimal(工艺测试.配方_上剪口电机基础速度.Value);
            numericUpDown_上剪口差修正比例.Value = Convert.ToDecimal(工艺测试.配方_上剪口差修正比例.Value);
            numericUpDown_上剪口缝纫机修正比例.Value = Convert.ToDecimal(工艺测试.配方_上剪口缝纫机修正比例.Value);
            numericUpDown_上剪口差基本值.Value = Convert.ToDecimal(工艺测试.配方_上剪口差基本值.Value);

            numericUpDown_下剪口数量.Value = Convert.ToDecimal(工艺测试.配方_下剪口数量.Value);
            numericUpDown_下剪口后针数.Value = Convert.ToDecimal(工艺测试.配方_下最后剪口后针数.Value);
            numericUpDown_下剪口电机基础速度.Value = Convert.ToDecimal(工艺测试.配方_下剪口电机基础速度.Value);
            numericUpDown_下剪口差修正比例.Value = Convert.ToDecimal(工艺测试.配方_下剪口差修正比例.Value);
            numericUpDown_下剪口缝纫机修正比例.Value = Convert.ToDecimal(工艺测试.配方_下剪口缝纫机修正比例.Value);
            numericUpDown_下剪口差基本值.Value = Convert.ToDecimal(工艺测试.配方_下剪口差基本值.Value);

            numericUpDown总针数.Value = Convert.ToDecimal(工艺测试.配方_总针数.Value);
            numericUpDown尾针数.Value = Convert.ToDecimal(工艺测试.配方_尾针数.Value);

            numericUpDown1_针数后识别剪口.Value = Convert.ToDecimal(工艺测试.配方_针数后识别剪口.Value);
            numericUpDown_识别剪口间隔针数.Value = Convert.ToDecimal(工艺测试.配方_识别剪口间隔针数.Value);
            numericUpDown1_电缸压下脉冲数.Value = Convert.ToDecimal(工艺测试.配方_电缸压下脉冲数.Value);
            try
            {
                
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(Convert.ToInt32(工艺测试.配方_尾针数.Value));
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = 工艺测试.配方_尾针表[i].Value;
                    dataGridView1.Rows[i].Cells[1].Value = 工艺测试.配方_尾针表X[i].Value;
                }
            }
            catch
            {
                MessageBox.Show("尾针表格,配方上传错误");
            }
            

        }

        private void 配方保存(string path)
        {
            string inipath = path;
            if (inipath.Length < 2)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                //sfd.InitialDirectory = @"C:\Users\SpringRain\Desktop";
                sfd.Title = "请选择要保存的位置";
                sfd.FileName = "配方文件001";
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
                inipath = sfd.FileName;
            }
            if (inipath.Length < 2)
            {
                return;
            }

            if (!File.Exists(inipath))
            {
                FileStream FS = new FileStream(inipath, FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(FS);
                sw.WriteLine("配方文件");//在第一行添加文本
                sw.Close();
                sw.Dispose();
                FS.Close();
            }
            INI文件管理.path = inipath;
            for (int i = 0; i <GLV._配方参数列表.Count; i++)
            {
                INI文件管理.IniWrite(inipath, "配方", GLV._配方参数列表[i].Name.ToString(), GLV._配方参数列表[i].Value.ToString());
            }

        }

        private void 配方导入(string path)
        {
            string inipath = "";
            if (path.Length < 2)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "请选择要打开的配方文件";
                ofd.Filter = "配方文件|*.ini";

                ofd.ShowDialog();
                inipath = ofd.FileName;

                if (!File.Exists(inipath))
                {
                    //MessageBox.Show("文件不存在");
                    return;
                }
            }
            else
            {
                inipath = path;
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
                if (string.Compare("配方文件", txt[0]) == 0)
                {
                    //Program.txtpath = Convert.ToString(txt[i + 1]);
                    //Program.numA = Convert.ToInt64(txt[i + 2]);
                    //Program.numB = Convert.ToInt64(txt[i + 3]);
                    //Program.sum = Convert.ToInt64(txt[i + 4]);
                }
                else
                {
                    MessageBox.Show("配方文件不正确!");
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
            INI文件管理.GetSectionData(inipath, "配方", ref name, ref value, ref lenth);
            for (int i = 0; i < lenth; i++)
            {
                
                for (int j = 0; j < GLV._配方参数列表.Count; j++)
                {
                    if (String.Compare(name[i], GLV._配方参数列表[j].Name) == 0)
                    {
                        GLV._配方参数列表[j].Value = Convert.ToDouble(value[i]);

                        break;
                    }
                }

            }
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            配方确认();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //配方初始化(ref 配方列表);
            配方确认();
            配方保存(GLV._默认地址_配方参数);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            配方导入("");
            配方显示();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            配方初始化();
            配方确认();
            配方保存("");
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown总针数_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }
    }


}
