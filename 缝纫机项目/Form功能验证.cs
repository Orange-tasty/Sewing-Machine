using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using Leadshine;

namespace 缝纫机项目
{
    public partial class Form功能验证 : Form
    {
        public Form功能验证()
        {
            InitializeComponent();
        }



        缝纫机方向控制配方 上电机P = new 缝纫机方向控制配方();
        缝纫机方向控制配方 下电机P = new 缝纫机方向控制配方();


        private void Form功能验证_Load(object sender, EventArgs e)
        {
            //chart1.Series[0].Points.AddXY(0, -401.2);
            //chart1.Series[0].Points.AddXY(1, -100.2);
            //chart1.Series[0].Points.AddXY(2, 0);
            //chart1.Series[0].Points.AddXY(3, 102.3);
            //chart1.Series[0].Points.AddXY(4, 501.21);

            //for (int i = 0; i < 5; i++)
            //{
            //    chart1.Series[0].Points[i].MarkerSize = 5;
            //    chart1.Series[0].Points[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            //    chart1.Series[0].Points[i].MarkerBorderColor = Color.Red;
            //    chart1.Series[0].Points[i].LabelForeColor = Color.Red;
            //    chart1.Series[0].Points[i].Label = "电压:" + chart1.Series[0].Points[i].XValue + "V" +
            //        " 位移:" + chart1.Series[0].Points[i].YValues[0] + "pul";

            //}

            //chart2.Series[0].Points.AddXY(0, -401.2);
            //chart2.Series[0].Points.AddXY(1, -100.2);
            //chart2.Series[0].Points.AddXY(2, 0);
            //chart2.Series[0].Points.AddXY(3, 102.3);
            //chart2.Series[0].Points.AddXY(4, 501.21);

            //for (int i = 0; i < 5; i++)
            //{
            //    chart2.Series[0].Points[i].MarkerSize = 5;
            //    chart2.Series[0].Points[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            //    chart2.Series[0].Points[i].MarkerBorderColor = Color.Red;
            //    chart2.Series[0].Points[i].LabelForeColor = Color.Red;
            //    chart2.Series[0].Points[i].Label = "电压:" + chart1.Series[0].Points[i].XValue + "V" +
            //        " 位移:" + chart1.Series[0].Points[i].YValues[0] + "pul";

            //}





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






            dataGridView2.ColumnHeadersVisible = true;
            dataGridView2.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle columnHeaderStyle2 = new DataGridViewCellStyle();
            dataGridView2.ColumnHeadersDefaultCellStyle = columnHeaderStyle2;


            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView2.ColumnCount = 6;

            dataGridView2.Columns[0].Name = "编号";
            dataGridView2.Columns[0].Width = 40;
            dataGridView2.Columns[0].ReadOnly = true;
            dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView2.Columns[1].Name = "内感应";
            dataGridView2.Columns[1].Width = 70;
            dataGridView2.Columns[1].ReadOnly = true;
            dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView2.Columns[2].Name = "外感应1";
            dataGridView2.Columns[2].Width = 70;
            dataGridView2.Columns[2].ReadOnly = true;
            dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView2.Columns[3].Name = "外感应2";
            dataGridView2.Columns[3].Width = 70;
            dataGridView2.Columns[3].ReadOnly = true;
            dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView2.Columns[4].Name = "上电机位移";
            dataGridView2.Columns[4].Width = 100;
            dataGridView2.Columns[4].ReadOnly = false;
            dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView2.Columns[5].Name = "下电机位移";
            dataGridView2.Columns[5].Width = 100;
            dataGridView2.Columns[5].ReadOnly = false;
            dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            


            默认配方导入();


            double x0 = 0;
            double y0 = 0;

            double xl1 = 0;
            double xl2 = 0;
            double xl3 = 0;
            double xr1 = 0;
            double xr2 = 0;
            double xr3 = 0;

            double yl1 = 0;
            double yl2 = 0;
            double yl3 = 0;
            double yr1 = 0;
            double yr2 = 0;
            double yr3 = 0;


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


            chart1.Series[0].Points.Clear();

            chart1.Series[0].Points.AddXY(xl3, yl3);
            chart1.Series[0].Points.AddXY(xl2, yl2);
            chart1.Series[0].Points.AddXY(xl1, yl1);
            chart1.Series[0].Points.AddXY(x0, y0);
            chart1.Series[0].Points.AddXY(xr1, yr1);
            chart1.Series[0].Points.AddXY(xr2, yr2);
            chart1.Series[0].Points.AddXY(xr3, yr3);

            for (int i = 0; i < 7; i++)
            {
                chart1.Series[0].Points[i].MarkerSize = 5;
                chart1.Series[0].Points[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chart1.Series[0].Points[i].MarkerBorderColor = Color.Red;
                chart1.Series[0].Points[i].LabelForeColor = Color.Red;
                chart1.Series[0].Points[i].Label = "电压:" + chart1.Series[0].Points[i].XValue + "V" +
                    " 位移:" + chart1.Series[0].Points[i].YValues[0] + "pul";

            }



            double x0X = 0;
            double y0X = 0;

            double xl1X = 0;
            double xl2X = 0;
            double xl3X = 0;
            double xr1X = 0;
            double xr2X = 0;
            double xr3X = 0;

            double yl1X = 0;
            double yl2X = 0;
            double yl3X = 0;
            double yr1X = 0;
            double yr2X = 0;
            double yr3X = 0;


            x0X = 工艺测试.配方_中值电压X;
            y0X = 工艺测试.配方_中值位移X;

            xl1X = x0X + 工艺测试.配方_左1电压变化X;
            yl1X = y0X + 工艺测试.配方_左1斜率X * 工艺测试.配方_左1电压变化X;

            xl2X = xl1X + 工艺测试.配方_左2电压变化X;
            yl2X = yl1X + 工艺测试.配方_左2斜率X * 工艺测试.配方_左2电压变化X;

            xl3X = xl2X + 工艺测试.配方_左3电压变化X;
            yl3X = yl2X + 工艺测试.配方_左3斜率X * 工艺测试.配方_左3电压变化X;


            xr1X = x0X + 工艺测试.配方_右1电压变化X;
            yr1X = y0X + 工艺测试.配方_右1斜率X * 工艺测试.配方_右1电压变化X;

            xr2X = xr1X + 工艺测试.配方_右2电压变化X;
            yr2X = yr1X + 工艺测试.配方_右2斜率X * 工艺测试.配方_右2电压变化X;

            xr3X = xr2X + 工艺测试.配方_右3电压变化X;
            yr3X = yr2X + 工艺测试.配方_右3斜率X * 工艺测试.配方_右3电压变化X;


            chart2.Series[0].Points.Clear();

            chart2.Series[0].Points.AddXY(xl3X, yl3X);
            chart2.Series[0].Points.AddXY(xl2X, yl2X);
            chart2.Series[0].Points.AddXY(xl1X, yl1X);
            chart2.Series[0].Points.AddXY(x0X, y0X);
            chart2.Series[0].Points.AddXY(xr1X, yr1X);
            chart2.Series[0].Points.AddXY(xr2X, yr2X);
            chart2.Series[0].Points.AddXY(xr3X, yr3X);

            for (int i = 0; i < 7; i++)
            {
                chart2.Series[0].Points[i].MarkerSize = 5;
                chart2.Series[0].Points[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chart2.Series[0].Points[i].MarkerBorderColor = Color.Red;
                chart2.Series[0].Points[i].LabelForeColor = Color.Red;
                chart2.Series[0].Points[i].Label = "电压:" + chart2.Series[0].Points[i].XValue + "V" +
                    " 位移:" + chart2.Series[0].Points[i].YValues[0] + "pul";

            }

        }

        private void Form功能验证_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            工艺测试.配方_中值位移 = Convert.ToDouble(中值位移.Value);
            工艺测试.配方_中值电压 = Convert.ToDouble(中值电压.Value);

            工艺测试.配方_左3电压变化 = Convert.ToDouble(左3电压变化.Value);
            工艺测试.配方_左2电压变化 = Convert.ToDouble(左2电压变化.Value);
            工艺测试.配方_左1电压变化 = Convert.ToDouble(左1电压变化.Value);
            工艺测试.配方_右1电压变化 = Convert.ToDouble(右1电压变化.Value);
            工艺测试.配方_右2电压变化 = Convert.ToDouble(右2电压变化.Value);
            工艺测试.配方_右3电压变化 = Convert.ToDouble(右3电压变化.Value);

            工艺测试.配方_左3斜率 = Convert.ToDouble(左3斜率.Value);
            工艺测试.配方_左2斜率 = Convert.ToDouble(左2斜率.Value);
            工艺测试.配方_左1斜率 = Convert.ToDouble(左1斜率.Value);
            工艺测试.配方_右1斜率 = Convert.ToDouble(右1斜率.Value);
            工艺测试.配方_右2斜率 = Convert.ToDouble(右2斜率.Value);
            工艺测试.配方_右3斜率 = Convert.ToDouble(右3斜率.Value);



            工艺测试.配方_中值位移X = Convert.ToDouble(中值位移X.Value);
            工艺测试.配方_中值电压X = Convert.ToDouble(中值电压X.Value);

            工艺测试.配方_左3电压变化X = Convert.ToDouble(左3电压变化X.Value);
            工艺测试.配方_左2电压变化X = Convert.ToDouble(左2电压变化X.Value);
            工艺测试.配方_左1电压变化X = Convert.ToDouble(左1电压变化X.Value);
            工艺测试.配方_右1电压变化X = Convert.ToDouble(右1电压变化X.Value);
            工艺测试.配方_右2电压变化X = Convert.ToDouble(右2电压变化X.Value);
            工艺测试.配方_右3电压变化X = Convert.ToDouble(右3电压变化X.Value);

            工艺测试.配方_左3斜率X = Convert.ToDouble(左3斜率X.Value);
            工艺测试.配方_左2斜率X = Convert.ToDouble(左2斜率X.Value);
            工艺测试.配方_左1斜率X = Convert.ToDouble(左1斜率X.Value);
            工艺测试.配方_右1斜率X = Convert.ToDouble(右1斜率X.Value);
            工艺测试.配方_右2斜率X = Convert.ToDouble(右2斜率X.Value);
            工艺测试.配方_右3斜率X = Convert.ToDouble(右3斜率X.Value);




            double x0 = 0;
            double y0 = 0;

            double xl1 = 0;
            double xl2 = 0;
            double xl3 = 0;
            double xr1 = 0;
            double xr2 = 0;
            double xr3 = 0;

            double yl1 = 0;
            double yl2 = 0;
            double yl3 = 0;
            double yr1 = 0;
            double yr2 = 0;
            double yr3 = 0;


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


            chart1.Series[0].Points.Clear();

            chart1.Series[0].Points.AddXY(xl3, yl3);
            chart1.Series[0].Points.AddXY(xl2, yl2);
            chart1.Series[0].Points.AddXY(xl1, yl1);
            chart1.Series[0].Points.AddXY(x0, y0);
            chart1.Series[0].Points.AddXY(xr1, yr1);
            chart1.Series[0].Points.AddXY(xr2, yr2);
            chart1.Series[0].Points.AddXY(xr3, yr3);

            for (int i = 0; i < 7; i++)
            {
                chart1.Series[0].Points[i].MarkerSize = 5;
                chart1.Series[0].Points[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chart1.Series[0].Points[i].MarkerBorderColor = Color.Red;
                chart1.Series[0].Points[i].LabelForeColor = Color.Red;
                chart1.Series[0].Points[i].Label = "电压:" + chart1.Series[0].Points[i].XValue + "V" +
                    " 位移:" + chart1.Series[0].Points[i].YValues[0] + "pul";

            }



            double x0X = 0;
            double y0X = 0;

            double xl1X = 0;
            double xl2X = 0;
            double xl3X = 0;
            double xr1X = 0;
            double xr2X = 0;
            double xr3X = 0;

            double yl1X = 0;
            double yl2X = 0;
            double yl3X = 0;
            double yr1X = 0;
            double yr2X = 0;
            double yr3X = 0;


            x0X = 工艺测试.配方_中值电压X;
            y0X = 工艺测试.配方_中值位移X;

            xl1X = x0X + 工艺测试.配方_左1电压变化X;
            yl1X = y0X + 工艺测试.配方_左1斜率X * 工艺测试.配方_左1电压变化X;

            xl2X = xl1X + 工艺测试.配方_左2电压变化X;
            yl2X = yl1X + 工艺测试.配方_左2斜率X * 工艺测试.配方_左2电压变化X;

            xl3X = xl2X + 工艺测试.配方_左3电压变化X;
            yl3X = yl2X + 工艺测试.配方_左3斜率X * 工艺测试.配方_左3电压变化X;


            xr1X = x0X + 工艺测试.配方_右1电压变化X;
            yr1X = y0X + 工艺测试.配方_右1斜率X * 工艺测试.配方_右1电压变化X;

            xr2X = xr1X + 工艺测试.配方_右2电压变化X;
            yr2X = yr1X + 工艺测试.配方_右2斜率X * 工艺测试.配方_右2电压变化X;

            xr3X = xr2X + 工艺测试.配方_右3电压变化X;
            yr3X = yr2X + 工艺测试.配方_右3斜率X * 工艺测试.配方_右3电压变化X;


            chart2.Series[0].Points.Clear();

            chart2.Series[0].Points.AddXY(xl3X, yl3X);
            chart2.Series[0].Points.AddXY(xl2X, yl2X);
            chart2.Series[0].Points.AddXY(xl1X, yl1X);
            chart2.Series[0].Points.AddXY(x0X, y0X);
            chart2.Series[0].Points.AddXY(xr1X, yr1X);
            chart2.Series[0].Points.AddXY(xr2X, yr2X);
            chart2.Series[0].Points.AddXY(xr3X, yr3X);

            for (int i = 0; i < 7; i++)
            {
                chart2.Series[0].Points[i].MarkerSize = 5;
                chart2.Series[0].Points[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chart2.Series[0].Points[i].MarkerBorderColor = Color.Red;
                chart2.Series[0].Points[i].LabelForeColor = Color.Red;
                chart2.Series[0].Points[i].Label = "电压:" + chart2.Series[0].Points[i].XValue + "V" +
                    " 位移:" + chart2.Series[0].Points[i].YValues[0] + "pul";

            }






            //
            工艺测试.配方_总针数.Value = Convert.ToDouble(numericUpDown总针数.Value);
            工艺测试.配方_尾针数.Value = Convert.ToDouble(numericUpDown尾针数.Value);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                工艺测试.配方_尾针表[i].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                工艺测试.配方_尾针表X[i].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);

            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                工艺测试.配方_上电机变化脉冲[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
                工艺测试.配方_下电机变化脉冲[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
            }


            工艺测试.配方_回针针距.Value = Convert.ToDouble(回针针距.Value);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            工艺测试.配方_中值位移 = Convert.ToDouble(中值位移.Value);
            工艺测试.配方_中值电压 = Convert.ToDouble(中值电压.Value);

            工艺测试.配方_左3电压变化 = Convert.ToDouble(左3电压变化.Value);
            工艺测试.配方_左2电压变化 = Convert.ToDouble(左2电压变化.Value);
            工艺测试.配方_左1电压变化 = Convert.ToDouble(左1电压变化.Value);
            工艺测试.配方_右1电压变化 = Convert.ToDouble(右1电压变化.Value);
            工艺测试.配方_右2电压变化 = Convert.ToDouble(右2电压变化.Value);
            工艺测试.配方_右3电压变化 = Convert.ToDouble(右3电压变化.Value);

            工艺测试.配方_左3斜率 = Convert.ToDouble(左3斜率.Value);
            工艺测试.配方_左2斜率 = Convert.ToDouble(左2斜率.Value);
            工艺测试.配方_左1斜率 = Convert.ToDouble(左1斜率.Value);
            工艺测试.配方_右1斜率 = Convert.ToDouble(右1斜率.Value);
            工艺测试.配方_右2斜率 = Convert.ToDouble(右2斜率.Value);
            工艺测试.配方_右3斜率 = Convert.ToDouble(右3斜率.Value);


            工艺测试.配方_中值位移X = Convert.ToDouble(中值位移X.Value);
            工艺测试.配方_中值电压X = Convert.ToDouble(中值电压X.Value);

            工艺测试.配方_左3电压变化X = Convert.ToDouble(左3电压变化X.Value);
            工艺测试.配方_左2电压变化X = Convert.ToDouble(左2电压变化X.Value);
            工艺测试.配方_左1电压变化X = Convert.ToDouble(左1电压变化X.Value);
            工艺测试.配方_右1电压变化X = Convert.ToDouble(右1电压变化X.Value);
            工艺测试.配方_右2电压变化X = Convert.ToDouble(右2电压变化X.Value);
            工艺测试.配方_右3电压变化X = Convert.ToDouble(右3电压变化X.Value);

            工艺测试.配方_左3斜率X = Convert.ToDouble(左3斜率X.Value);
            工艺测试.配方_左2斜率X = Convert.ToDouble(左2斜率X.Value);
            工艺测试.配方_左1斜率X = Convert.ToDouble(左1斜率X.Value);
            工艺测试.配方_右1斜率X = Convert.ToDouble(右1斜率X.Value);
            工艺测试.配方_右2斜率X = Convert.ToDouble(右2斜率X.Value);
            工艺测试.配方_右3斜率X = Convert.ToDouble(右3斜率X.Value);

            工艺测试.配方_总针数.Value = Convert.ToDouble(numericUpDown总针数.Value);
            工艺测试.配方_尾针数.Value = Convert.ToDouble(numericUpDown尾针数.Value);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                工艺测试.配方_尾针表[i].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                工艺测试.配方_尾针表X[i].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
            }

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                工艺测试.配方_上电机变化脉冲[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
                工艺测试.配方_下电机变化脉冲[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
            }
            工艺测试.配方_回针针距.Value = Convert.ToDouble(回针针距.Value);




            //配方管理.配方保存("");
            配方管理.配方保存(GLV._默认地址_配方参数);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            配方管理.配方导入();
            //配方管理.TXT读取(GLV._默认地址_配方参数);

            中值位移.Value = Convert.ToDecimal(工艺测试.配方_中值位移);
            中值电压.Value = Convert.ToDecimal(工艺测试.配方_中值电压);

            左3电压变化.Value = Convert.ToDecimal(工艺测试.配方_左3电压变化);
            左2电压变化.Value = Convert.ToDecimal(工艺测试.配方_左2电压变化);
            左1电压变化.Value = Convert.ToDecimal(工艺测试.配方_左1电压变化);
            右1电压变化.Value = Convert.ToDecimal(工艺测试.配方_右1电压变化);
            右2电压变化.Value = Convert.ToDecimal(工艺测试.配方_右2电压变化);
            右3电压变化.Value = Convert.ToDecimal(工艺测试.配方_右3电压变化);

            左3斜率.Value = Convert.ToDecimal(工艺测试.配方_左3斜率);
            左2斜率.Value = Convert.ToDecimal(工艺测试.配方_左2斜率);
            左1斜率.Value = Convert.ToDecimal(工艺测试.配方_左1斜率);
            右1斜率.Value = Convert.ToDecimal(工艺测试.配方_右1斜率);
            右2斜率.Value = Convert.ToDecimal(工艺测试.配方_右2斜率);
            右3斜率.Value = Convert.ToDecimal(工艺测试.配方_右3斜率);


            中值位移X.Value = Convert.ToDecimal(工艺测试.配方_中值位移X);
            中值电压X.Value = Convert.ToDecimal(工艺测试.配方_中值电压X);

            左3电压变化X.Value = Convert.ToDecimal(工艺测试.配方_左3电压变化X);
            左2电压变化X.Value = Convert.ToDecimal(工艺测试.配方_左2电压变化X);
            左1电压变化X.Value = Convert.ToDecimal(工艺测试.配方_左1电压变化X);
            右1电压变化X.Value = Convert.ToDecimal(工艺测试.配方_右1电压变化X);
            右2电压变化X.Value = Convert.ToDecimal(工艺测试.配方_右2电压变化X);
            右3电压变化X.Value = Convert.ToDecimal(工艺测试.配方_右3电压变化X);

            左3斜率X.Value = Convert.ToDecimal(工艺测试.配方_左3斜率X);
            左2斜率X.Value = Convert.ToDecimal(工艺测试.配方_左2斜率X);
            左1斜率X.Value = Convert.ToDecimal(工艺测试.配方_左1斜率X);
            右1斜率X.Value = Convert.ToDecimal(工艺测试.配方_右1斜率X);
            右2斜率X.Value = Convert.ToDecimal(工艺测试.配方_右2斜率X);
            右3斜率X.Value = Convert.ToDecimal(工艺测试.配方_右3斜率X);

            numericUpDown总针数.Value = Convert.ToDecimal(工艺测试.配方_总针数);
            numericUpDown尾针数.Value = Convert.ToDecimal(工艺测试.配方_尾针数);

            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(Convert.ToInt32(工艺测试.配方_尾针数));
                for (int i = 0; i < 工艺测试.配方_尾针数.Value; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = 工艺测试.配方_尾针表[i];
                    dataGridView1.Rows[i].Cells[1].Value = 工艺测试.配方_尾针表X[i];
                    //工艺测试.配方_尾针表[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                }
            }
            catch
            { }
            

            

            dataGridView2.Rows.Clear();
            dataGridView2.Rows.Add(8);
            for (int i = 0; i < 8; i++)
            {
                dataGridView2.Rows[i].Cells[4].Value = 工艺测试.配方_上电机变化脉冲[i];
                dataGridView2.Rows[i].Cells[5].Value = 工艺测试.配方_下电机变化脉冲[i];



                dataGridView2.Rows[i].Cells[0].Value = i;
                string num = Convert.ToString(i, 2);

                uint re = Convert.ToUInt32(num);
                if (1 == (re & (1)))
                    dataGridView2.Rows[i].Cells[3].Value = 1;
                else
                    dataGridView2.Rows[i].Cells[3].Value = 0;

                if (2 == (re & (2)))
                    dataGridView2.Rows[i].Cells[2].Value = 1;
                else
                    dataGridView2.Rows[i].Cells[2].Value = 0;
                if (4 == (re & (4)))
                    dataGridView2.Rows[i].Cells[1].Value = 1;
                else
                    dataGridView2.Rows[i].Cells[1].Value = 0;


            }


            回针针距.Value = Convert.ToDecimal(工艺测试.配方_回针针距);
        }

        public void 默认配方导入()
        {
            配方管理.TXT读取(GLV._默认地址_配方参数);

            中值位移.Value = Convert.ToDecimal(工艺测试.配方_中值位移);
            中值电压.Value = Convert.ToDecimal(工艺测试.配方_中值电压);

            左3电压变化.Value = Convert.ToDecimal(工艺测试.配方_左3电压变化);
            左2电压变化.Value = Convert.ToDecimal(工艺测试.配方_左2电压变化);
            左1电压变化.Value = Convert.ToDecimal(工艺测试.配方_左1电压变化);
            右1电压变化.Value = Convert.ToDecimal(工艺测试.配方_右1电压变化);
            右2电压变化.Value = Convert.ToDecimal(工艺测试.配方_右2电压变化);
            右3电压变化.Value = Convert.ToDecimal(工艺测试.配方_右3电压变化);

            左3斜率.Value = Convert.ToDecimal(工艺测试.配方_左3斜率);
            左2斜率.Value = Convert.ToDecimal(工艺测试.配方_左2斜率);
            左1斜率.Value = Convert.ToDecimal(工艺测试.配方_左1斜率);
            右1斜率.Value = Convert.ToDecimal(工艺测试.配方_右1斜率);
            右2斜率.Value = Convert.ToDecimal(工艺测试.配方_右2斜率);
            右3斜率.Value = Convert.ToDecimal(工艺测试.配方_右3斜率);


            中值位移X.Value = Convert.ToDecimal(工艺测试.配方_中值位移X);
            中值电压X.Value = Convert.ToDecimal(工艺测试.配方_中值电压X);

            左3电压变化X.Value = Convert.ToDecimal(工艺测试.配方_左3电压变化X);
            左2电压变化X.Value = Convert.ToDecimal(工艺测试.配方_左2电压变化X);
            左1电压变化X.Value = Convert.ToDecimal(工艺测试.配方_左1电压变化X);
            右1电压变化X.Value = Convert.ToDecimal(工艺测试.配方_右1电压变化X);
            右2电压变化X.Value = Convert.ToDecimal(工艺测试.配方_右2电压变化X);
            右3电压变化X.Value = Convert.ToDecimal(工艺测试.配方_右3电压变化X);

            左3斜率X.Value = Convert.ToDecimal(工艺测试.配方_左3斜率X);
            左2斜率X.Value = Convert.ToDecimal(工艺测试.配方_左2斜率X);
            左1斜率X.Value = Convert.ToDecimal(工艺测试.配方_左1斜率X);
            右1斜率X.Value = Convert.ToDecimal(工艺测试.配方_右1斜率X);
            右2斜率X.Value = Convert.ToDecimal(工艺测试.配方_右2斜率X);
            右3斜率X.Value = Convert.ToDecimal(工艺测试.配方_右3斜率X);

            numericUpDown总针数.Value = Convert.ToDecimal(工艺测试.配方_总针数);
            numericUpDown尾针数.Value = Convert.ToDecimal(工艺测试.配方_尾针数);
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            try
            {
                dataGridView1.Rows.Add(Convert.ToInt32(工艺测试.配方_尾针数));
                for (int i = 0; i < 工艺测试.配方_尾针数.Value; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = 工艺测试.配方_尾针表[i];
                    dataGridView1.Rows[i].Cells[1].Value = 工艺测试.配方_尾针表X[i];
                    //工艺测试.配方_尾针表[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                }
            }
            catch
            {

            }

            try
            {
                dataGridView2.Rows.Add(8);
                for (int i = 0; i < 8; i++)
                {
                    

                    dataGridView2.Rows[i].Cells[4].Value = 工艺测试.配方_上电机变化脉冲[i];
                    dataGridView2.Rows[i].Cells[5].Value = 工艺测试.配方_下电机变化脉冲[i];


                    dataGridView2.Rows[i].Cells[0].Value = i;
                    string num = Convert.ToString(i, 2);

                    uint re = Convert.ToUInt32(num);
                    if (1 == (re & (1)))
                        dataGridView2.Rows[i].Cells[3].Value = 1;
                    else
                        dataGridView2.Rows[i].Cells[3].Value = 0;

                    if (2 == (re & (2)))
                        dataGridView2.Rows[i].Cells[2].Value = 1;
                    else
                        dataGridView2.Rows[i].Cells[2].Value = 0;
                    if (4 == (re & (4)))
                        dataGridView2.Rows[i].Cells[1].Value = 1;
                    else
                        dataGridView2.Rows[i].Cells[1].Value = 0;



                }
                


            }
            catch
            {

            }


            回针针距.Value = Convert.ToDecimal(工艺测试.配方_回针针距);

            Task任务.系统输出("默认配方加载完毕");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            工艺测试.配方_尾针数.Value = Convert.ToDouble(numericUpDown尾针数.Value);



            if (工艺测试.配方_尾针数.Value <= 0)
            {
                return;
            }
            //
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(Convert.ToInt32(工艺测试.配方_尾针数.Value));
            

            //列不许自动排序
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            工艺测试.配方_中值位移 = Convert.ToDouble(中值位移.Value);
            工艺测试.配方_中值电压 = Convert.ToDouble(中值电压.Value);

            工艺测试.配方_左3电压变化 = Convert.ToDouble(左3电压变化.Value);
            工艺测试.配方_左2电压变化 = Convert.ToDouble(左2电压变化.Value);
            工艺测试.配方_左1电压变化 = Convert.ToDouble(左1电压变化.Value);
            工艺测试.配方_右1电压变化 = Convert.ToDouble(右1电压变化.Value);
            工艺测试.配方_右2电压变化 = Convert.ToDouble(右2电压变化.Value);
            工艺测试.配方_右3电压变化 = Convert.ToDouble(右3电压变化.Value);

            工艺测试.配方_左3斜率 = Convert.ToDouble(左3斜率.Value);
            工艺测试.配方_左2斜率 = Convert.ToDouble(左2斜率.Value);
            工艺测试.配方_左1斜率 = Convert.ToDouble(左1斜率.Value);
            工艺测试.配方_右1斜率 = Convert.ToDouble(右1斜率.Value);
            工艺测试.配方_右2斜率 = Convert.ToDouble(右2斜率.Value);
            工艺测试.配方_右3斜率 = Convert.ToDouble(右3斜率.Value);


            工艺测试.配方_中值位移X = Convert.ToDouble(中值位移X.Value);
            工艺测试.配方_中值电压X = Convert.ToDouble(中值电压X.Value);

            工艺测试.配方_左3电压变化X = Convert.ToDouble(左3电压变化X.Value);
            工艺测试.配方_左2电压变化X = Convert.ToDouble(左2电压变化X.Value);
            工艺测试.配方_左1电压变化X = Convert.ToDouble(左1电压变化X.Value);
            工艺测试.配方_右1电压变化X = Convert.ToDouble(右1电压变化X.Value);
            工艺测试.配方_右2电压变化X = Convert.ToDouble(右2电压变化X.Value);
            工艺测试.配方_右3电压变化X = Convert.ToDouble(右3电压变化X.Value);

            工艺测试.配方_左3斜率X = Convert.ToDouble(左3斜率X.Value);
            工艺测试.配方_左2斜率X = Convert.ToDouble(左2斜率X.Value);
            工艺测试.配方_左1斜率X = Convert.ToDouble(左1斜率X.Value);
            工艺测试.配方_右1斜率X = Convert.ToDouble(右1斜率X.Value);
            工艺测试.配方_右2斜率X = Convert.ToDouble(右2斜率X.Value);
            工艺测试.配方_右3斜率X = Convert.ToDouble(右3斜率X.Value);

            工艺测试.配方_总针数.Value = Convert.ToDouble(numericUpDown总针数.Value);
            工艺测试.配方_尾针数.Value = Convert.ToDouble(numericUpDown尾针数.Value);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                工艺测试.配方_尾针表[i].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                工艺测试.配方_尾针表X[i].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                工艺测试.配方_上电机变化脉冲[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
                工艺测试.配方_下电机变化脉冲[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
            }
            工艺测试.配方_回针针距.Value = Convert.ToDouble(回针针距.Value);



            配方管理.配方保存("");
            //配方管理.配方保存(GLV._默认地址_配方参数);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //double re = Math.Pow(-2, 2);
            //Console.WriteLine(re);
        }
    }
}
