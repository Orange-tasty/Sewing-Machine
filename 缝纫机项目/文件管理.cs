using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace 缝纫机项目
{
    public class 文件初始化
    {
        public static void 创建文件夹()
        {

            if (!Directory.Exists(GLV._默认地址_系统文件夹))
            {
                // Create the directory it does not exist.
                Directory.CreateDirectory(GLV._默认地址_系统文件夹);
            }
        }
    }

    public class INI文件管理
    {
        public static string path;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSection(string lpAppName, IntPtr lpReturnedString, uint nSize, string lpFileName);
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern uint GetPrivateProfileStringA(string section, string key,
            string def, Byte[] retVal, int size, string filePath);



        /// <summary>
        /// 写INI
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool IniWrite(string path0, string Section, string Key, string Value)
        {
            if (File.Exists(path0))
            {
                long Op = WritePrivateProfileString(Section, Key, Value, path0);
                if (Op == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 读INI
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string IniRead(string path0, string Section, string Key)
        {
            if (File.Exists(path0))
            {
                StringBuilder temp = new StringBuilder(1024);
                int i = GetPrivateProfileString(Section, Key, "", temp, 1024, path0);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }

        }

        public static void IniReadAllSeciton()
        {
            //IniWrite();
        }
        public static List<string> ReadSections(string path0)
        {


            List<string> result = new List<string>();
            Byte[] buf = new Byte[65536];
            uint len = GetPrivateProfileStringA(null, null, null, buf, buf.Length, path0);
            int j = 0;
            for (int i = 0; i < len; i++)
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            return result;

        }



        public static string[] IniReadSection(string path0, string Section)
        {
            string[] items = new string[0];
            uint MAX_BUFFER = 32767;    //默认为32767
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));
            uint bytesReturned = GetPrivateProfileSection(Section, pReturnedString, MAX_BUFFER, path0);


            if (!(bytesReturned == MAX_BUFFER - 2) || (bytesReturned == 0))
            {

                string returnedString = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned);
                items = returnedString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }
            Marshal.FreeCoTaskMem(pReturnedString);     //释放内存

            return items;
        }

        /// <summary>
        /// 获取SECTION下的所有参数名和参数
        /// </summary>
        /// <param name="Section">SECTION</param>
        /// <param name="name">参数名</param>
        /// <param name="Value">参数</param>
        public static void GetSectionData(string path0, string Section, ref string[] name, ref string[] Value, ref int lenth)
        {
            string[] items = IniReadSection(path0, Section);
            try
            {
                for (int i = 0; i < items.Length; i++)
                {
                    string[] 截取 = items[i].Split('=');
                    name[i] = 截取[0];
                    Value[i] = 截取[1];
                }
            }
            catch
            {
                if (items.Length > 10)
                {
                    MessageBox.Show("数据异常:数据长度超限", "错误！");
                }
            }

            lenth = items.Length;


        }

    }


    public class TXT文件管理
    {
        public static void 数据保存(string path, string[] msg)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write);//创建写入文件
            StreamWriter sw = new StreamWriter(fs1);

            for (int i = 0; i < msg.Length; i++)
            {
                sw.WriteLine(msg[i]);
            }

            sw.Close();
            sw.Dispose();
            fs1.Close();
        }

        public static void 数据添加(string path, string[] msg)
        {
            long txt_lenth = 0;

            if (!File.Exists(path))
            {
                FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write);//创建写入文件
                StreamWriter sw = new StreamWriter(fs1);


                for (int i = 0; i < msg.Length; i++)
                {
                    sw.WriteLine(msg[i]);
                }
                sw.Close();
                sw.Dispose();
                fs1.Close();
            }
            else
            {
                FileStream fs1 = new FileStream(path, FileMode.Append);//打开
                StreamWriter sw = new StreamWriter(fs1);

                for (int i = 0; i < msg.Length; i++)
                {
                    sw.WriteLine(msg[i]);
                }
                sw.Close();
                sw.Dispose();
                fs1.Close();
            }


        }
    }




}

