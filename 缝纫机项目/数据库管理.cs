using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 缝纫机项目
{
    public class 数据库
    {
        /// <summary>
        /// 数据库地址
        /// </summary>
        public static string 默认地址 = "Provider=Microsoft.ACE.OLEDB.12.0;;Data Source=" + System.IO.Directory.GetCurrentDirectory() + "\\Database.accdb" + ";Persist Security Info=True;Jet OLEDB:Database Password=13607111469;";

        public static string 表名_用户 = "用户";
        public static string 表名_生产数据 = "生产数据";

        public static DataTable 所有内容(string path,string chart)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(path);
            oleDbConnection.Open();

            string sql = "select * from " + chart;//从表里读出所有内容
            OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection);
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();

            oleDbDataAdapter.Fill(dt);

            oleDbDataAdapter.Dispose();
            oleDbConnection.Close();


            return dt;


            //dt.Rows[0][0] = 0;

        }

        public static string 用户_获取密码_通过用户名(string name, string path, string chart)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(path);
            oleDbConnection.Open();

            string sql = "select * from " + chart + " where 用户名 = " + "'" + name + "'";
            OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection);
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            oleDbDataAdapter.Fill(dt);

            oleDbDataAdapter.Dispose();
            oleDbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][2].ToString();
            }
            else
            {
                return "error";
            }
            
        }

        public static void 用户_增加用户(string name, string password, ushort permission, string path, string chart)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(path);
            oleDbConnection.Open();

            string sql = "insert into " + chart + "(用户名,密码,权限) values('" + name + "','" + password + "'," + permission + ")";

            OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection);
            cmd.ExecuteNonQuery();

            oleDbConnection.Close();

        }

        
    }
}
