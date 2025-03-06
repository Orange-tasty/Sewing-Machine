namespace 缝纫机项目
{
    partial class Form主界面
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem文件 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem配方 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem退出 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem系统 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem系统参数 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem工具 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem调试窗口 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem记录 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem报警记录 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem生产记录 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem用户 = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_控制器状态 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_上传感器电压 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_下传感器电压 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_缝纫机输出电压 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_已执行针数 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_复位 = new System.Windows.Forms.Button();
            this.button_停止 = new System.Windows.Forms.Button();
            this.button_暂停 = new System.Windows.Forms.Button();
            this.button_启动 = new System.Windows.Forms.Button();
            this.button_抬压脚 = new System.Windows.Forms.Button();
            this.button_待机 = new System.Windows.Forms.Button();
            this.button_加速 = new System.Windows.Forms.Button();
            this.button_减速 = new System.Windows.Forms.Button();
            this.textBox_转速 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button4 = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem文件,
            this.ToolStripMenuItem系统,
            this.ToolStripMenuItem工具,
            this.ToolStripMenuItem记录,
            this.ToolStripMenuItem用户});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1232, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem文件
            // 
            this.ToolStripMenuItem文件.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem配方,
            this.toolStripSeparator1,
            this.ToolStripMenuItem退出});
            this.ToolStripMenuItem文件.Name = "ToolStripMenuItem文件";
            this.ToolStripMenuItem文件.Size = new System.Drawing.Size(66, 31);
            this.ToolStripMenuItem文件.Text = "文件";
            // 
            // ToolStripMenuItem配方
            // 
            this.ToolStripMenuItem配方.Name = "ToolStripMenuItem配方";
            this.ToolStripMenuItem配方.Size = new System.Drawing.Size(138, 32);
            this.ToolStripMenuItem配方.Text = "配方";
            this.ToolStripMenuItem配方.Click += new System.EventHandler(this.ToolStripMenuItem配方_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // ToolStripMenuItem退出
            // 
            this.ToolStripMenuItem退出.Name = "ToolStripMenuItem退出";
            this.ToolStripMenuItem退出.Size = new System.Drawing.Size(138, 32);
            this.ToolStripMenuItem退出.Text = "退出";
            // 
            // ToolStripMenuItem系统
            // 
            this.ToolStripMenuItem系统.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem系统参数});
            this.ToolStripMenuItem系统.Name = "ToolStripMenuItem系统";
            this.ToolStripMenuItem系统.Size = new System.Drawing.Size(66, 31);
            this.ToolStripMenuItem系统.Text = "系统";
            // 
            // ToolStripMenuItem系统参数
            // 
            this.ToolStripMenuItem系统参数.Name = "ToolStripMenuItem系统参数";
            this.ToolStripMenuItem系统参数.Size = new System.Drawing.Size(178, 32);
            this.ToolStripMenuItem系统参数.Text = "系统参数";
            this.ToolStripMenuItem系统参数.Click += new System.EventHandler(this.ToolStripMenuItem系统参数_Click);
            // 
            // ToolStripMenuItem工具
            // 
            this.ToolStripMenuItem工具.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem调试窗口});
            this.ToolStripMenuItem工具.Name = "ToolStripMenuItem工具";
            this.ToolStripMenuItem工具.Size = new System.Drawing.Size(66, 31);
            this.ToolStripMenuItem工具.Text = "工具";
            // 
            // ToolStripMenuItem调试窗口
            // 
            this.ToolStripMenuItem调试窗口.Name = "ToolStripMenuItem调试窗口";
            this.ToolStripMenuItem调试窗口.Size = new System.Drawing.Size(178, 32);
            this.ToolStripMenuItem调试窗口.Text = "调试窗口";
            this.ToolStripMenuItem调试窗口.Click += new System.EventHandler(this.ToolStripMenuItem调试窗口_Click);
            // 
            // ToolStripMenuItem记录
            // 
            this.ToolStripMenuItem记录.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem报警记录,
            this.ToolStripMenuItem生产记录});
            this.ToolStripMenuItem记录.Name = "ToolStripMenuItem记录";
            this.ToolStripMenuItem记录.Size = new System.Drawing.Size(66, 31);
            this.ToolStripMenuItem记录.Text = "记录";
            // 
            // ToolStripMenuItem报警记录
            // 
            this.ToolStripMenuItem报警记录.Name = "ToolStripMenuItem报警记录";
            this.ToolStripMenuItem报警记录.Size = new System.Drawing.Size(178, 32);
            this.ToolStripMenuItem报警记录.Text = "报警记录";
            this.ToolStripMenuItem报警记录.Click += new System.EventHandler(this.ToolStripMenuItem报警记录_Click);
            // 
            // ToolStripMenuItem生产记录
            // 
            this.ToolStripMenuItem生产记录.Name = "ToolStripMenuItem生产记录";
            this.ToolStripMenuItem生产记录.Size = new System.Drawing.Size(178, 32);
            this.ToolStripMenuItem生产记录.Text = "生产记录";
            // 
            // ToolStripMenuItem用户
            // 
            this.ToolStripMenuItem用户.Name = "ToolStripMenuItem用户";
            this.ToolStripMenuItem用户.Size = new System.Drawing.Size(66, 31);
            this.ToolStripMenuItem用户.Text = "用户";
            this.ToolStripMenuItem用户.Click += new System.EventHandler(this.ToolStripMenuItem用户_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(16, 51);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(900, 502);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_控制器状态,
            this.toolStripStatusLabel_上传感器电压,
            this.toolStripStatusLabel_下传感器电压,
            this.toolStripStatusLabel_缝纫机输出电压,
            this.toolStripStatusLabel_已执行针数});
            this.statusStrip1.Location = new System.Drawing.Point(0, 757);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1232, 33);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_控制器状态
            // 
            this.toolStripStatusLabel_控制器状态.Name = "toolStripStatusLabel_控制器状态";
            this.toolStripStatusLabel_控制器状态.Size = new System.Drawing.Size(112, 27);
            this.toolStripStatusLabel_控制器状态.Text = "控制器状态";
            this.toolStripStatusLabel_控制器状态.Click += new System.EventHandler(this.toolStripStatusLabel_控制器状态_Click);
            // 
            // toolStripStatusLabel_上传感器电压
            // 
            this.toolStripStatusLabel_上传感器电压.Name = "toolStripStatusLabel_上传感器电压";
            this.toolStripStatusLabel_上传感器电压.Size = new System.Drawing.Size(132, 27);
            this.toolStripStatusLabel_上传感器电压.Text = "上传感器电压";
            // 
            // toolStripStatusLabel_下传感器电压
            // 
            this.toolStripStatusLabel_下传感器电压.Name = "toolStripStatusLabel_下传感器电压";
            this.toolStripStatusLabel_下传感器电压.Size = new System.Drawing.Size(132, 27);
            this.toolStripStatusLabel_下传感器电压.Text = "下传感器电压";
            // 
            // toolStripStatusLabel_缝纫机输出电压
            // 
            this.toolStripStatusLabel_缝纫机输出电压.Name = "toolStripStatusLabel_缝纫机输出电压";
            this.toolStripStatusLabel_缝纫机输出电压.Size = new System.Drawing.Size(152, 27);
            this.toolStripStatusLabel_缝纫机输出电压.Text = "缝纫机输出电压";
            // 
            // toolStripStatusLabel_已执行针数
            // 
            this.toolStripStatusLabel_已执行针数.Name = "toolStripStatusLabel_已执行针数";
            this.toolStripStatusLabel_已执行针数.Size = new System.Drawing.Size(112, 27);
            this.toolStripStatusLabel_已执行针数.Text = "已执行针数";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_复位
            // 
            this.button_复位.BackColor = System.Drawing.Color.Gainsboro;
            this.button_复位.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_复位.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_复位.ForeColor = System.Drawing.Color.Black;
            this.button_复位.Location = new System.Drawing.Point(921, 561);
            this.button_复位.Margin = new System.Windows.Forms.Padding(4);
            this.button_复位.Name = "button_复位";
            this.button_复位.Size = new System.Drawing.Size(295, 151);
            this.button_复位.TabIndex = 11;
            this.button_复位.Text = "复位";
            this.button_复位.UseVisualStyleBackColor = false;
            this.button_复位.Click += new System.EventHandler(this.button_复位_Click);
            // 
            // button_停止
            // 
            this.button_停止.BackColor = System.Drawing.Color.Gainsboro;
            this.button_停止.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_停止.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_停止.ForeColor = System.Drawing.Color.Black;
            this.button_停止.Location = new System.Drawing.Point(621, 561);
            this.button_停止.Margin = new System.Windows.Forms.Padding(4);
            this.button_停止.Name = "button_停止";
            this.button_停止.Size = new System.Drawing.Size(295, 151);
            this.button_停止.TabIndex = 10;
            this.button_停止.Text = "停止";
            this.button_停止.UseVisualStyleBackColor = false;
            this.button_停止.Click += new System.EventHandler(this.button_停止_Click);
            // 
            // button_暂停
            // 
            this.button_暂停.BackColor = System.Drawing.Color.Gainsboro;
            this.button_暂停.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_暂停.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_暂停.ForeColor = System.Drawing.Color.Black;
            this.button_暂停.Location = new System.Drawing.Point(319, 561);
            this.button_暂停.Margin = new System.Windows.Forms.Padding(4);
            this.button_暂停.Name = "button_暂停";
            this.button_暂停.Size = new System.Drawing.Size(295, 151);
            this.button_暂停.TabIndex = 9;
            this.button_暂停.Text = "暂停";
            this.button_暂停.UseVisualStyleBackColor = false;
            this.button_暂停.Click += new System.EventHandler(this.button_暂停_Click);
            // 
            // button_启动
            // 
            this.button_启动.BackColor = System.Drawing.Color.Gainsboro;
            this.button_启动.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_启动.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_启动.ForeColor = System.Drawing.Color.Black;
            this.button_启动.Location = new System.Drawing.Point(16, 561);
            this.button_启动.Margin = new System.Windows.Forms.Padding(4);
            this.button_启动.Name = "button_启动";
            this.button_启动.Size = new System.Drawing.Size(295, 151);
            this.button_启动.TabIndex = 8;
            this.button_启动.Text = "启动";
            this.button_启动.UseVisualStyleBackColor = false;
            this.button_启动.Click += new System.EventHandler(this.button_启动_Click);
            // 
            // button_抬压脚
            // 
            this.button_抬压脚.BackColor = System.Drawing.Color.Gainsboro;
            this.button_抬压脚.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_抬压脚.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_抬压脚.ForeColor = System.Drawing.Color.Black;
            this.button_抬压脚.Location = new System.Drawing.Point(924, 51);
            this.button_抬压脚.Margin = new System.Windows.Forms.Padding(4);
            this.button_抬压脚.Name = "button_抬压脚";
            this.button_抬压脚.Size = new System.Drawing.Size(292, 125);
            this.button_抬压脚.TabIndex = 12;
            this.button_抬压脚.Text = "抬压脚";
            this.button_抬压脚.UseVisualStyleBackColor = false;
            this.button_抬压脚.Click += new System.EventHandler(this.button_抬压脚_Click);
            // 
            // button_待机
            // 
            this.button_待机.BackColor = System.Drawing.Color.Gainsboro;
            this.button_待机.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_待机.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_待机.ForeColor = System.Drawing.Color.Black;
            this.button_待机.Location = new System.Drawing.Point(924, 181);
            this.button_待机.Margin = new System.Windows.Forms.Padding(4);
            this.button_待机.Name = "button_待机";
            this.button_待机.Size = new System.Drawing.Size(292, 125);
            this.button_待机.TabIndex = 13;
            this.button_待机.Text = "待机";
            this.button_待机.UseVisualStyleBackColor = false;
            this.button_待机.Click += new System.EventHandler(this.button_待机_Click);
            // 
            // button_加速
            // 
            this.button_加速.BackColor = System.Drawing.Color.Gainsboro;
            this.button_加速.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_加速.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_加速.ForeColor = System.Drawing.Color.Black;
            this.button_加速.Location = new System.Drawing.Point(924, 312);
            this.button_加速.Margin = new System.Windows.Forms.Padding(4);
            this.button_加速.Name = "button_加速";
            this.button_加速.Size = new System.Drawing.Size(292, 99);
            this.button_加速.TabIndex = 14;
            this.button_加速.Text = "加速+";
            this.button_加速.UseVisualStyleBackColor = false;
            this.button_加速.Click += new System.EventHandler(this.button_加速_Click);
            // 
            // button_减速
            // 
            this.button_减速.BackColor = System.Drawing.Color.Gainsboro;
            this.button_减速.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_减速.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_减速.ForeColor = System.Drawing.Color.Black;
            this.button_减速.Location = new System.Drawing.Point(924, 455);
            this.button_减速.Margin = new System.Windows.Forms.Padding(4);
            this.button_减速.Name = "button_减速";
            this.button_减速.Size = new System.Drawing.Size(292, 99);
            this.button_减速.TabIndex = 15;
            this.button_减速.Text = "减速-";
            this.button_减速.UseVisualStyleBackColor = false;
            this.button_减速.Click += new System.EventHandler(this.button_减速_Click);
            // 
            // textBox_转速
            // 
            this.textBox_转速.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_转速.Location = new System.Drawing.Point(993, 415);
            this.textBox_转速.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_转速.Name = "textBox_转速";
            this.textBox_转速.ReadOnly = true;
            this.textBox_转速.Size = new System.Drawing.Size(221, 36);
            this.textBox_转速.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(921, 420);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 31);
            this.label1.TabIndex = 17;
            this.label1.Text = "转速:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(885, 655);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 80);
            this.button1.TabIndex = 18;
            this.button1.Text = "减速";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(1131, 655);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 80);
            this.button2.TabIndex = 19;
            this.button2.Text = "减速";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gainsboro;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(1224, 485);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 39);
            this.button3.TabIndex = 20;
            this.button3.Text = "待机";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.ScaleView.Size = 10D;
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(1224, 51);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "上传感器";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "下传感器";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(735, 284);
            this.chart1.TabIndex = 21;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chart2
            // 
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisX.ScaleView.Size = 10D;
            chartArea2.AxisX.ScaleView.Zoomable = false;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(1224, 342);
            this.chart2.Margin = new System.Windows.Forms.Padding(4);
            this.chart2.Name = "chart2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "上压紧电机";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "下压紧电机";
            this.chart2.Series.Add(series3);
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(735, 284);
            this.chart2.TabIndex = 22;
            this.chart2.Text = "chart2";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gainsboro;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(1825, 290);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 45);
            this.button4.TabIndex = 23;
            this.button4.Text = "TEST";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(114, 719);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(86, 35);
            this.Send.TabIndex = 24;
            this.Send.Text = "发送";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(239, 726);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 25);
            this.textBox1.TabIndex = 25;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form主界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 790);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox_转速);
            this.Controls.Add(this.button_待机);
            this.Controls.Add(this.button_抬压脚);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_减速);
            this.Controls.Add(this.button_加速);
            this.Controls.Add(this.button_复位);
            this.Controls.Add(this.button_停止);
            this.Controls.Add(this.button_暂停);
            this.Controls.Add(this.button_启动);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form主界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "缝纫机测试版程序FENGRENJI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form主界面_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form主界面_FormClosed);
            this.Load += new System.EventHandler(this.Form主界面_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem文件;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem系统;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem工具;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem记录;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_控制器状态;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem配方;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem退出;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem系统参数;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem调试窗口;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem报警记录;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_上传感器电压;
        private System.Windows.Forms.Button button_复位;
        private System.Windows.Forms.Button button_停止;
        private System.Windows.Forms.Button button_暂停;
        private System.Windows.Forms.Button button_启动;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_下传感器电压;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_已执行针数;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_缝纫机输出电压;
        private System.Windows.Forms.Button button_抬压脚;
        private System.Windows.Forms.Button button_待机;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem用户;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem生产记录;
        private System.Windows.Forms.Button button_加速;
        private System.Windows.Forms.Button button_减速;
        private System.Windows.Forms.TextBox textBox_转速;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox textBox1;
    }
}

