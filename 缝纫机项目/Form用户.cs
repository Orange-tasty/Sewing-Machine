using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 缝纫机项目
{
    public partial class Form用户 : Form
    {
        public Form用户()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 0：登录界面
        /// 1：注册界面
        /// </summary>
        private ushort 界面 = 0;

        private void Form用户_Load(object sender, EventArgs e)
        {
            this.Text = "用户界面";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            
            上传用户名到界面(comboBox_用户名);
            登录界面显示();

            comboBox_用户名.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_用户名.SelectedIndex = 0;
            textBox_password.PasswordChar = '*';
            textBox_password_recall.PasswordChar = '*';

        }

        private void Form用户_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void 上传用户名到界面(ComboBox cb)
        {
            cb.Items.Clear();
            用户._用户列表.Clear();
            DataTable dt = 数据库.所有内容(数据库.默认地址, "用户");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i][1].ToString();
                string password = dt.Rows[i][2].ToString();
                ushort permission = Convert.ToUInt16(dt.Rows[i][3]);

                
                用户 user = new 用户(name, password, permission);
                cb.Items.Add(user.名.ToString());
                
            }
        }



        private void 登录界面显示()
        {
            textBox_用户名.Visible = false;
            comboBox_用户名.Visible = true;
            button_登录.Visible = true;
            button_注册.Visible = false;
            label_确认密码.Visible = false;
            textBox_password_recall.Visible = false;
            comboBox_permission.Visible = false;

            textBox_password.Text = "";
            textBox_password_recall.Text = "";
            textBox_用户名.Text = "";
            上传用户名到界面(comboBox_用户名);
        }

        

        private void 注册界面显示()
        {
            textBox_用户名.Visible = true;
            comboBox_用户名.Visible = false;
            button_登录.Visible = false;
            button_注册.Visible = true;
            label_确认密码.Visible = true;
            textBox_password_recall.Visible = true;
            comboBox_permission.Visible = true;
            comboBox_permission.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_permission.SelectedIndex = 0;

            textBox_password.Text = "";
            textBox_password_recall.Text = "";
            textBox_用户名.Text = "";
        }

        private void comboBox_用户名_DropDown(object sender, EventArgs e)
        {
            //上传用户名到界面(comboBox_用户名);
            textBox_password.Text = "";
            textBox_password_recall.Text = "";
        }

        private void button_登录界面_Click(object sender, EventArgs e)
        {
            登录界面显示();
        }

        private void button_注册界面_Click(object sender, EventArgs e)
        {
            注册界面显示();
        }

        private void button_登录_Click(object sender, EventArgs e)
        {
            string password = textBox_password.Text.ToString();
            string name = comboBox_用户名.Text.ToString();
            
            string truepassword = 数据库.用户_获取密码_通过用户名(name, 数据库.默认地址, 数据库.表名_用户);

            if (string.Compare(password, truepassword) == 0)
            {
                //密码正确
                登录成功();
                MessageBox.Show("登录成功", "提示");
            }
            else
            {
                MessageBox.Show("密码错误", "提示");
            }

            textBox_password.Text = "";
            textBox_password_recall.Text = "";

        }

        private void 登录成功()
        {
            int num = 0;
            string name = comboBox_用户名.Text.ToString();
            for (int i = 0; i < 用户._用户列表.Count; i++)
            {
                if (用户._用户列表[i].名 == name)
                {
                    num = i;
                    break;
                }
            }
            MainProgram._当前用户 = 用户._用户列表[num];

            Task任务.系统输出("当前用户是:" + MainProgram._当前用户.名);

            this.Close();

        }

        private void button_注册_Click(object sender, EventArgs e)
        {
            


            if (MainProgram._当前用户.权限 < (ushort)用户.权限选择.高级权限)
            {
                MessageBox.Show("权限不够", "提示");
                //return;
            }
            else
            {
                注册用户();
            }

            textBox_password.Text = "";
            textBox_password_recall.Text = "";

        }

        private void 注册用户()
        {
            

            //if (MainProgram._当前用户.权限 < (ushort)用户.权限选择.高级权限)
            //{

            //}

            if (textBox_用户名.Text == "" || textBox_password.Text == ""|| textBox_password_recall.Text == "")
            {
                MessageBox.Show("不能为空", "提示");
                return;
            }
            string name = textBox_用户名.Text;
            string password = textBox_password.Text;
            string password_recall = textBox_password_recall.Text;
            ushort permission = Convert.ToUInt16(comboBox_permission.SelectedIndex);

            if (string.Compare(password, password_recall) == 0)
            {
                数据库.用户_增加用户(name, password_recall, permission, 数据库.默认地址, 数据库.表名_用户);
                MessageBox.Show("用户注册成功", "提示");
            }
            else
            {
                MessageBox.Show("两次密码输入不同", "提示");
                return;
            }
            
        }

        private void button_退出_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }

    
}
