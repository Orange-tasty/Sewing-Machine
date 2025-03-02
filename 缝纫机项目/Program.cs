using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 缝纫机项目
{
    internal static class Program
    {

        public const string 系统名称 = "缝纫机_";

        /// <summary>
        /// /// ♦20221125:
        /// 测试参数窗口
        /// 测试速度自动规划
        /// ♦20230222:
        /// 修改了主界面刷新控制器状态的逻辑,从主界面直接刷新,变为线程扫描刷新
        /// 主界面显示转速,从实际转速转变为设定转速,不再有大的跳变
        /// 增加了标定后保存参数功能,并增加了标定操作权限
        /// 修复BUG:工艺中的下电机<电压位置计算>改为了<电压位置计算X>
        /// 在主界面的加减速按钮,增加了新速度自动保存功能
        /// ♦20230328:
        /// 从模拟量控制改为数字量控制
        /// 增加了转速与电压标定功能
        /// ♦20230511:
        /// 改回模拟量控制
        /// ♦20230512:
        /// 从一个模拟量模块变为两个模拟量模块,缝纫机控制从1改为3
        /// ♦20230522:
        /// 将位置模式变成速度模式
        /// ♦20230628:
        /// 改为PID控制
        /// ♦20230907:
        /// 新增检测剪口功能
        /// ♦20240201:
        /// 把配方的TXT文件改为了INI文件
        /// ♦20240224:
        /// 修改了缝纫机上下剪口电机控制逻辑
        /// ♦20240319:
        /// 修改了上下剪口电机的速度上下限参数
        /// ♦20240326:
        /// 修改了上下电机的速度上下限参数
        /// ♦20240407_1:
        /// 优化PID算法
        /// ♦20240723:
        /// 修复了标定工艺时显示圈数的BUG
        /// 增加了缝纫机控制后的信息输出,同时打印出转速以及对应的电压
        /// </summary>
        public const string 系统版本 = 系统名称 + "20240723";






        /// <summary>
        /// 语言选择
        /// </summary>
        public static bool 英文版 = false;


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form主界面());
        }
    }
}
