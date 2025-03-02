
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 缝纫机项目
{

    //20230511还原
    class 配方管理
    {
        public static void 配方保存(string path)
        {
            if (path.Length < 2)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                //sfd.InitialDirectory = @"C:\Users\SpringRain\Desktop";
                //if (Program.Language == 1)
                //{
                //    sfd.Title = "Please select the file path to save";
                //}
                //else
                //{
                //    sfd.Title = "请选择要保存的文件路径";
                //}

                sfd.FileName = "ProgramFile";
                sfd.Filter = "文本文件|*.txt";
                DialogResult rr = sfd.ShowDialog();
                if (rr == DialogResult.Cancel)
                {
                    return;
                }
                //获得要保存的文件的路径
                path = sfd.FileName;

                GLV._当前文件名 = path;
            }


            if (path.Length < 2)
            {
                return;
            }

            if (path == "")
            {
                return;
            }
            if (path == null)
            {
                return;
            }

            FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write);//创建写入文件
            StreamWriter sw = new StreamWriter(fs1);


            sw.WriteLine("DataMessage:");


            sw.WriteLine(工艺测试.配方_中值位移.ToString());
            sw.WriteLine(工艺测试.配方_中值电压.ToString());

            sw.WriteLine(工艺测试.配方_左3电压变化.ToString());
            sw.WriteLine(工艺测试.配方_左2电压变化.ToString());
            sw.WriteLine(工艺测试.配方_左1电压变化.ToString());
            sw.WriteLine(工艺测试.配方_右1电压变化.ToString());
            sw.WriteLine(工艺测试.配方_右2电压变化.ToString());
            sw.WriteLine(工艺测试.配方_右3电压变化.ToString());

            sw.WriteLine(工艺测试.配方_左3斜率.ToString());
            sw.WriteLine(工艺测试.配方_左2斜率.ToString());
            sw.WriteLine(工艺测试.配方_左1斜率.ToString());
            sw.WriteLine(工艺测试.配方_右1斜率.ToString());
            sw.WriteLine(工艺测试.配方_右2斜率.ToString());
            sw.WriteLine(工艺测试.配方_右3斜率.ToString());



            sw.WriteLine(工艺测试.配方_中值位移X.ToString());
            sw.WriteLine(工艺测试.配方_中值电压X.ToString());

            sw.WriteLine(工艺测试.配方_左3电压变化X.ToString());
            sw.WriteLine(工艺测试.配方_左2电压变化X.ToString());
            sw.WriteLine(工艺测试.配方_左1电压变化X.ToString());
            sw.WriteLine(工艺测试.配方_右1电压变化X.ToString());
            sw.WriteLine(工艺测试.配方_右2电压变化X.ToString());
            sw.WriteLine(工艺测试.配方_右3电压变化X.ToString());

            sw.WriteLine(工艺测试.配方_左3斜率X.ToString());
            sw.WriteLine(工艺测试.配方_左2斜率X.ToString());
            sw.WriteLine(工艺测试.配方_左1斜率X.ToString());
            sw.WriteLine(工艺测试.配方_右1斜率X.ToString());
            sw.WriteLine(工艺测试.配方_右2斜率X.ToString());
            sw.WriteLine(工艺测试.配方_右3斜率X.ToString());

            sw.WriteLine(工艺测试.配方_总针数.ToString());
            sw.WriteLine(工艺测试.配方_尾针数.ToString());
            for (int i = 0; i < 20; i++)
            {
                sw.WriteLine(工艺测试.配方_尾针表[i].ToString());

            }
            for (int i = 0; i < 20; i++)
            {
                sw.WriteLine(工艺测试.配方_尾针表X[i].ToString());

            }
            sw.WriteLine(工艺测试.配方_回针针距.ToString());

            //double[] hang = new double[10];

            //int i = 0, j = 0;
            //if (GLV._划片轨迹列表.Count <= 0)
            //{
            //    return;
            //}
            //for (i = 0; i < GLV._划片轨迹列表.Count; i++)
            //{
            //    sw.Write(GLV._划片轨迹列表[i].类型);
            //    sw.Write(",");
            //    sw.Write(GLV._划片轨迹列表[i].相对坐标_终点X);
            //    sw.Write(",");
            //    sw.Write(GLV._划片轨迹列表[i].相对坐标_终点Y);
            //    sw.Write(",");
            //    sw.Write(GLV._划片轨迹列表[i].相对坐标_圆心X);
            //    sw.Write(",");
            //    sw.Write(GLV._划片轨迹列表[i].相对坐标_圆心Y);
            //    sw.Write(",");
            //    sw.Write(GLV._划片轨迹列表[i].速度);
            //    sw.Write(",");
            //    sw.Write(GLV._划片轨迹列表[i].圆弧方向);
            //    sw.Write(",");
            //    sw.Write(GLV._划片轨迹列表[i].出光);

            //    sw.Write(Environment.NewLine);



            //}


            sw.Close();
            fs1.Close();

        }

        public static void 配方导入()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //if (Program.Language == 1)
            //{
            //    ofd.Title = "Please select the storage file to open";
            //}
            //else
            //{
            //    ofd.Title = "请选择要打开的存储文件";
            //}

            //ofd.InitialDirectory = @"C:\Users\SpringRain\Desktop";
            //ofd.Multiselect = true;
            ofd.Filter = "文本文件|*.txt";
            ofd.ShowDialog();

            string fpath = ofd.FileName;
            if (fpath.Length < 2)
            {
                return;
            }


            TXT读取(fpath);

            GLV._当前文件名 = fpath;
        }

        public static void 新建配方()
        {
            //GLV._划片轨迹列表.Clear();


            //划片轨迹 新的划片轨迹 = new 划片轨迹();
            //GLV._划片轨迹列表.Add(新的划片轨迹);
        }



        public static void TXT读取(string path)
        {
            long filelenth;//文件行数
            string[] txt;

            try
            {
                txt = File.ReadAllLines(@path);
            }
            catch (Exception)
            {
                return;
            }

            filelenth = txt.Length;

            //Console.Write(txt[0]);

            //确定文件标题
            if (string.Compare("DataMessage:", txt[0]) != 0)
            {
                return;
            }


            try
            {
                int i = 1;
                工艺测试.配方_中值位移 = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_中值电压 = Convert.ToDouble(txt[i]); i++;

                工艺测试.配方_左3电压变化 = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_左2电压变化 = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_左1电压变化 = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右1电压变化 = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右2电压变化 = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右3电压变化 = Convert.ToDouble(txt[i]); i++;

                工艺测试.配方_左3斜率 = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_左2斜率 = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_左1斜率 = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右1斜率 = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右2斜率 = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右3斜率 = Convert.ToDouble(txt[i]); i++;



                工艺测试.配方_中值位移X = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_中值电压X = Convert.ToDouble(txt[i]); i++;

                工艺测试.配方_左3电压变化X = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_左2电压变化X = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_左1电压变化X = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右1电压变化X = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右2电压变化X = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右3电压变化X = Convert.ToDouble(txt[i]); i++;

                工艺测试.配方_左3斜率X = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_左2斜率X = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_左1斜率X = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右1斜率X = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右2斜率X = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_右3斜率X = Convert.ToDouble(txt[i]); i++;

                工艺测试.配方_总针数.Value = Convert.ToDouble(txt[i]); i++;
                工艺测试.配方_尾针数.Value = Convert.ToDouble(txt[i]); i++;

                for (int j = 0; j < 20; j++)
                {
                    工艺测试.配方_尾针表[j].Value = Convert.ToDouble(txt[i]); i++;

                }
                for (int j = 0; j < 20; j++)
                {
                    工艺测试.配方_尾针表X[j].Value = Convert.ToDouble(txt[i]); i++;

                }
                工艺测试.配方_回针针距.Value = Convert.ToDouble(txt[i]); i++;

            }
            catch (Exception)
            {
                Task任务.系统输出("配方上传出错");
            }
            //GLV._划片轨迹列表.Clear();

            //CAD._起始点X.Value = Convert.ToDouble(txt[1]);
            //CAD._起始点Y.Value = Convert.ToDouble(txt[2]);

            ////遍历TXT所有数据
            //for (int i = 3; i < filelenth; i++)
            //{
            //    //for (int j = i; j < filelenth; j++)
            //    //{

            //    //}
            //    string[] lin = txt[i].Split(',');
            //    int u = 0;
            //    划片轨迹 新的划片轨迹 = new 划片轨迹();
            //    新的划片轨迹.类型 = Convert.ToUInt16(lin[u]); u++;
            //    新的划片轨迹.相对坐标_终点X = Convert.ToDouble(lin[u]); u++;
            //    新的划片轨迹.相对坐标_终点Y = Convert.ToDouble(lin[u]); u++;
            //    新的划片轨迹.相对坐标_圆心X = Convert.ToDouble(lin[u]); u++;
            //    新的划片轨迹.相对坐标_圆心Y = Convert.ToDouble(lin[u]); u++;
            //    新的划片轨迹.速度 = Convert.ToDouble(lin[u]); u++;
            //    新的划片轨迹.圆弧方向 = Convert.ToDouble(lin[u]); u++;
            //    新的划片轨迹.出光 = Convert.ToBoolean(lin[u]); u++;
            //    GLV._划片轨迹列表.Add(新的划片轨迹);
            //    ////CAD数据读取
            //    //if (string.Compare("2000划片机轨迹信息:", txt[i]) == 0)
            //    //{


            //    //}


        }






    }
}