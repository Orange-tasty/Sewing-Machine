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
    public partial class Form生产记录 : Form
    {
        public Form生产记录()
        {
            InitializeComponent();
        }

        private void Form生产记录_Load(object sender, EventArgs e)
        {
            this.Text = "轴与IO测试";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void Form生产记录_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
