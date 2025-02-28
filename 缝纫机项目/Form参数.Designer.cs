namespace 缝纫机项目
{
    partial class Form参数
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_下载 = new System.Windows.Forms.Button();
            this.button_上传 = new System.Windows.Forms.Button();
            this.button_导出 = new System.Windows.Forms.Button();
            this.button_导入 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(53, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1040, 514);
            this.dataGridView1.TabIndex = 1;
            // 
            // button_下载
            // 
            this.button_下载.Location = new System.Drawing.Point(791, 545);
            this.button_下载.Name = "button_下载";
            this.button_下载.Size = new System.Drawing.Size(178, 48);
            this.button_下载.TabIndex = 8;
            this.button_下载.Text = "下载";
            this.button_下载.UseVisualStyleBackColor = true;
            this.button_下载.Click += new System.EventHandler(this.button_下载_Click);
            // 
            // button_上传
            // 
            this.button_上传.Location = new System.Drawing.Point(568, 545);
            this.button_上传.Name = "button_上传";
            this.button_上传.Size = new System.Drawing.Size(178, 48);
            this.button_上传.TabIndex = 7;
            this.button_上传.Text = "上传";
            this.button_上传.UseVisualStyleBackColor = true;
            this.button_上传.Click += new System.EventHandler(this.button_上传_Click);
            // 
            // button_导出
            // 
            this.button_导出.Location = new System.Drawing.Point(345, 545);
            this.button_导出.Name = "button_导出";
            this.button_导出.Size = new System.Drawing.Size(178, 48);
            this.button_导出.TabIndex = 6;
            this.button_导出.Text = "导出";
            this.button_导出.UseVisualStyleBackColor = true;
            this.button_导出.Click += new System.EventHandler(this.button_导出_Click);
            // 
            // button_导入
            // 
            this.button_导入.Location = new System.Drawing.Point(123, 545);
            this.button_导入.Name = "button_导入";
            this.button_导入.Size = new System.Drawing.Size(178, 48);
            this.button_导入.TabIndex = 5;
            this.button_导入.Text = "导入";
            this.button_导入.UseVisualStyleBackColor = true;
            this.button_导入.Click += new System.EventHandler(this.button_导入_Click);
            // 
            // Form参数
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 602);
            this.Controls.Add(this.button_下载);
            this.Controls.Add(this.button_上传);
            this.Controls.Add(this.button_导出);
            this.Controls.Add(this.button_导入);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form参数";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统参数";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form参数_FormClosing);
            this.Load += new System.EventHandler(this.Form参数_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_下载;
        private System.Windows.Forms.Button button_上传;
        private System.Windows.Forms.Button button_导出;
        private System.Windows.Forms.Button button_导入;
    }
}