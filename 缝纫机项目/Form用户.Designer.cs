namespace 缝纫机项目
{
    partial class Form用户
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_用户名 = new System.Windows.Forms.ComboBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_password_recall = new System.Windows.Forms.TextBox();
            this.button_登录界面 = new System.Windows.Forms.Button();
            this.button_注册界面 = new System.Windows.Forms.Button();
            this.button_登录 = new System.Windows.Forms.Button();
            this.button_退出 = new System.Windows.Forms.Button();
            this.label_用户名 = new System.Windows.Forms.Label();
            this.label_密码 = new System.Windows.Forms.Label();
            this.textBox_用户名 = new System.Windows.Forms.TextBox();
            this.label_确认密码 = new System.Windows.Forms.Label();
            this.button_注册 = new System.Windows.Forms.Button();
            this.comboBox_permission = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox_用户名
            // 
            this.comboBox_用户名.FormattingEnabled = true;
            this.comboBox_用户名.Location = new System.Drawing.Point(228, 61);
            this.comboBox_用户名.Name = "comboBox_用户名";
            this.comboBox_用户名.Size = new System.Drawing.Size(185, 20);
            this.comboBox_用户名.TabIndex = 0;
            this.comboBox_用户名.DropDown += new System.EventHandler(this.comboBox_用户名_DropDown);
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(228, 110);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(185, 21);
            this.textBox_password.TabIndex = 1;
            // 
            // textBox_password_recall
            // 
            this.textBox_password_recall.Location = new System.Drawing.Point(228, 155);
            this.textBox_password_recall.Name = "textBox_password_recall";
            this.textBox_password_recall.Size = new System.Drawing.Size(185, 21);
            this.textBox_password_recall.TabIndex = 2;
            // 
            // button_登录界面
            // 
            this.button_登录界面.Location = new System.Drawing.Point(12, 51);
            this.button_登录界面.Name = "button_登录界面";
            this.button_登录界面.Size = new System.Drawing.Size(123, 51);
            this.button_登录界面.TabIndex = 3;
            this.button_登录界面.Text = "登录界面";
            this.button_登录界面.UseVisualStyleBackColor = true;
            this.button_登录界面.Click += new System.EventHandler(this.button_登录界面_Click);
            // 
            // button_注册界面
            // 
            this.button_注册界面.Location = new System.Drawing.Point(12, 101);
            this.button_注册界面.Name = "button_注册界面";
            this.button_注册界面.Size = new System.Drawing.Size(123, 51);
            this.button_注册界面.TabIndex = 4;
            this.button_注册界面.Text = "注册用户";
            this.button_注册界面.UseVisualStyleBackColor = true;
            this.button_注册界面.Click += new System.EventHandler(this.button_注册界面_Click);
            // 
            // button_登录
            // 
            this.button_登录.Location = new System.Drawing.Point(175, 201);
            this.button_登录.Name = "button_登录";
            this.button_登录.Size = new System.Drawing.Size(100, 46);
            this.button_登录.TabIndex = 5;
            this.button_登录.Text = "登录";
            this.button_登录.UseVisualStyleBackColor = true;
            this.button_登录.Click += new System.EventHandler(this.button_登录_Click);
            // 
            // button_退出
            // 
            this.button_退出.Location = new System.Drawing.Point(371, 201);
            this.button_退出.Name = "button_退出";
            this.button_退出.Size = new System.Drawing.Size(100, 46);
            this.button_退出.TabIndex = 6;
            this.button_退出.Text = "退出";
            this.button_退出.UseVisualStyleBackColor = true;
            this.button_退出.Click += new System.EventHandler(this.button_退出_Click);
            // 
            // label_用户名
            // 
            this.label_用户名.AutoSize = true;
            this.label_用户名.Location = new System.Drawing.Point(173, 64);
            this.label_用户名.Name = "label_用户名";
            this.label_用户名.Size = new System.Drawing.Size(41, 12);
            this.label_用户名.TabIndex = 7;
            this.label_用户名.Text = "用户名";
            // 
            // label_密码
            // 
            this.label_密码.AutoSize = true;
            this.label_密码.Location = new System.Drawing.Point(173, 113);
            this.label_密码.Name = "label_密码";
            this.label_密码.Size = new System.Drawing.Size(29, 12);
            this.label_密码.TabIndex = 8;
            this.label_密码.Text = "密码";
            // 
            // textBox_用户名
            // 
            this.textBox_用户名.Location = new System.Drawing.Point(228, 61);
            this.textBox_用户名.Name = "textBox_用户名";
            this.textBox_用户名.Size = new System.Drawing.Size(185, 21);
            this.textBox_用户名.TabIndex = 9;
            // 
            // label_确认密码
            // 
            this.label_确认密码.AutoSize = true;
            this.label_确认密码.Location = new System.Drawing.Point(173, 158);
            this.label_确认密码.Name = "label_确认密码";
            this.label_确认密码.Size = new System.Drawing.Size(53, 12);
            this.label_确认密码.TabIndex = 10;
            this.label_确认密码.Text = "确认密码";
            // 
            // button_注册
            // 
            this.button_注册.Location = new System.Drawing.Point(175, 201);
            this.button_注册.Name = "button_注册";
            this.button_注册.Size = new System.Drawing.Size(100, 46);
            this.button_注册.TabIndex = 11;
            this.button_注册.Text = "注册";
            this.button_注册.UseVisualStyleBackColor = true;
            this.button_注册.Click += new System.EventHandler(this.button_注册_Click);
            // 
            // comboBox_permission
            // 
            this.comboBox_permission.FormattingEnabled = true;
            this.comboBox_permission.Items.AddRange(new object[] {
            "操作员",
            "技术员"});
            this.comboBox_permission.Location = new System.Drawing.Point(428, 61);
            this.comboBox_permission.Name = "comboBox_permission";
            this.comboBox_permission.Size = new System.Drawing.Size(87, 20);
            this.comboBox_permission.TabIndex = 12;
            // 
            // Form用户
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 279);
            this.Controls.Add(this.comboBox_permission);
            this.Controls.Add(this.button_注册);
            this.Controls.Add(this.label_确认密码);
            this.Controls.Add(this.textBox_用户名);
            this.Controls.Add(this.label_密码);
            this.Controls.Add(this.label_用户名);
            this.Controls.Add(this.button_退出);
            this.Controls.Add(this.button_登录);
            this.Controls.Add(this.button_注册界面);
            this.Controls.Add(this.button_登录界面);
            this.Controls.Add(this.textBox_password_recall);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.comboBox_用户名);
            this.Name = "Form用户";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form用户";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form用户_FormClosing);
            this.Load += new System.EventHandler(this.Form用户_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_用户名;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_password_recall;
        private System.Windows.Forms.Button button_登录界面;
        private System.Windows.Forms.Button button_注册界面;
        private System.Windows.Forms.Button button_登录;
        private System.Windows.Forms.Button button_退出;
        private System.Windows.Forms.Label label_用户名;
        private System.Windows.Forms.Label label_密码;
        private System.Windows.Forms.TextBox textBox_用户名;
        private System.Windows.Forms.Label label_确认密码;
        private System.Windows.Forms.Button button_注册;
        private System.Windows.Forms.ComboBox comboBox_permission;
    }
}