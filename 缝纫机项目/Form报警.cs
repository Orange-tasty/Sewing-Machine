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
using System.IO;

namespace 缝纫机项目
{
    public partial class Form报警 : Form
    {
        public Form报警()
        {
            InitializeComponent();
        }

        delegate void 表格委托(DataGridView d);//委托
        private int _报警数量 = 0;


        private void Form报警_Load(object sender, EventArgs e)
        {
            if (!Program.英文版)
            {
                this.Text = "错误记录";
            }
            else
            {
                this.Text = "Error Logging";
                tabPage1.Text = "Current error";
                tabPage2.Text = "History error";

                dataGridView1.Columns[0].HeaderText = "Error message";
                dataGridView2.Columns[0].HeaderText = "Error message";

                button1.Text = "Save on";
                button2.Text = "Clear error";

                button5.Text = "Clear all error";
                button3.Text = "Show all history error";
                button4.Text = "All history error save on";
            }

            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView2.ScrollBars = ScrollBars.Both;


            显示历史错误(dataGridView2);

            ThreadStart ts = new ThreadStart(LoadData);
            Thread thread = new Thread(ts);
            thread.Name = "LoadData";
            thread.Start();
        }

        private void Form报警_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void LoadData()
        {

            while (true)
            {

                SetText(dataGridView1);

                Thread.Sleep(500);
            }

        }
        private void SetText(DataGridView d)
        {
            //需要修改

            if (dataGridView1.InvokeRequired)
            {
                表格委托 stcb = new 表格委托(SetText);
                this.Invoke(stcb, new object[] { d });
            }
            else
            {
                try
                {
                    if (_报警数量 != GLV._系统错误表.Count)
                    {
                        _报警数量 = GLV._系统错误表.Count;

                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < GLV._系统错误表.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            if (GLV._系统错误表[i].错误线路 == 0)
                            {
                                dataGridView1.Rows[i].Cells[0].Value = GLV._系统错误表[i].报错时间 + "- " + GLV._系统错误表[i].错误内容;
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[0].Value = GLV._系统错误表[i].报错时间 + "- " + GLV._系统错误表[i].错误内容;

                            }

                        }
                    }
                    else
                    {

                    }


                }
                catch
                {

                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = @"C:\Users\SpringRain\Desktop";
            sfd.Title = "请选择要保存的位置";
            sfd.FileName = "LED系统错误记录";
            sfd.Filter = "文本文件|*.txt";
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

            string[] str = new string[GLV._系统错误表.Count];
            for (int i = 0; i < GLV._系统错误表.Count; i++)
            {
                str[i] = GLV._系统错误表[i].错误线路 + GLV._系统错误表[i].报错时间 + GLV._系统错误表[i].错误内容;

            }
            TXT文件管理.数据保存(inipath, str);


            //string[] str = new string[2];
            //str[0] = "111";
            //str[1] = "222";
            //TXT文件管理.数据添加(@"C:\app_data\系统错误历史记录.txt", str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GLV._系统错误表.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            显示历史错误(dataGridView2);
            //dataGridView2.Rows.Clear();
            //try
            //{
            //    long filelenth;//文件行数
            //    string[] txt;
            //    string path = GLV._默认地址_系统错误记录;
            //    try
            //    {
            //        txt = File.ReadAllLines(@path);
            //    }
            //    catch (Exception)
            //    {
            //        txt = null;
            //    }

            //    filelenth = txt.Length;
            //    //遍历TXT所有数据
            //    for (int i = 0; i < filelenth; i++)
            //    {
            //        //
            //        dataGridView2.Rows.Add();
            //        dataGridView2.Rows[i].Cells[0].Value = txt[i];

            //    }

            //}
            //catch
            //{
            //    return;
            //}
        }


        private void 显示历史错误(DataGridView d)
        {
            d.Rows.Clear();
            try
            {
                long filelenth;//文件行数
                string[] txt;
                string path = GLV._默认地址_系统错误记录;
                try
                {
                    txt = File.ReadAllLines(@path);
                }
                catch (Exception)
                {
                    txt = null;
                }

                filelenth = txt.Length;
                //遍历TXT所有数据
                for (int i = 0; i < filelenth; i++)
                {
                    //
                    d.Rows.Add();
                    d.Rows[i].Cells[0].Value = txt[i];

                }

            }
            catch
            {
                return;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string str = GLV._默认地址_系统错误记录;
            try
            {
                if (!File.Exists(str))
                {
                    MessageBox.Show("没有历史记录");
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                //sfd.InitialDirectory = @"C:\Users\SpringRain\Desktop";
                sfd.Title = "请选择要保存的位置";
                sfd.FileName = "LED系统错误记录";
                sfd.Filter = "文本文件|*.txt";
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

                File.Copy(str, inipath, true);//文件复制

            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否确定删除所有历史记录?", "警告!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                dataGridView2.Rows.Clear();
                string str = GLV._默认地址_系统错误记录;
                try
                {
                    if (File.Exists(str))
                    {
                        File.Delete(str);
                    }
                }
                catch
                {

                }
            }
            else
            {
                return;
            }
        }
    }
    class 错误列表操作
    {
        public static void F系统错误添加到文件(string path)
        {
            try
            {
                string[] str = new string[GLV._系统错误表.Count];
                for (int i = 0; i < GLV._系统错误表.Count; i++)
                {
                    str[i] = GLV._系统错误表[i].报错时间 + " " + GLV._系统错误表[i].错误内容;

                }
                TXT文件管理.数据添加(path, str);
            }
            catch
            {

            }

        }





    }

}
