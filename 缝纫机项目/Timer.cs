using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 缝纫机项目
{
    internal class TimerDispos
    {
        static Timer timer = null;
        static ManualResetEvent timerDisposed = null;//ManualResetEvent继承WaitHandle
        static int timeCount = 0;
        public static (double 平均距离1, int 数量1, int 数量2, double 平均距离2, int 数量3, int 数量4) _lastData = (0, 0, 0, 0, 0, 0);
        public static void CreateAndStartTimer()
        {
            //初始化Timer，设置触发间隔为2000毫秒，设置dueTime参数为Timeout.Infinite表示不启动Timer
            timer = new Timer(TimerCallBack, null, Timeout.Infinite, 400);
            //启动Timer，设置dueTime参数为0表示立刻启动Timer
            timer.Change(0, 400);
        }

        /// <summary>
        /// TimerCallBack方法是Timer每一次触发后的事件处理方法
        /// </summary>
        public static void TimerCallBack(object state)
        {
            VM通讯.客户端.m_x = null;
            VM通讯.发送("snap");

            if (VM通讯.接收信息拆解Try(VM通讯.客户端.m_x, out var data))
            {
                _lastData = data;
            }
            else
            {
                Task任务.信息输出("接收信息错误");
                data = _lastData;
            }
            double 距离 = data.平均距离1;
            double 剪口数 = data.数量1;
            double 距离X = data.平均距离2;
            double 剪口数X = data.数量3;
            //距离 = 测量值.距离(VM通讯.客户端.m_x);
            //剪口数 = 测量值.剪口数(VM通讯.客户端.m_x);
            //距离X = 测量值.距离X(VM通讯.客户端.m_x);
            //剪口数X = 测量值.剪口数X(VM通讯.客户端.m_x);
            VM通讯.客户端.m_x = null;
            
        }

        public static void StopTimer()
        {
            if (timer != null)
            {
                // 停止定时器的触发，不再执行回调
                timer.Change(Timeout.Infinite, Timeout.Infinite);

                // 或者直接释放定时器资源
                // timer.Dispose();
            }
        }

        //static void Main(string[] args)
        //{
        //    CreateAndStartTimer();

        //    Console.WriteLine("按任意键调用Timer.Dispose方法...");
        //    Console.ReadKey();

        //    timerDisposed = new ManualResetEvent(false);
        //    timer.Dispose(timerDisposed);//调用Timer的bool Dispose(WaitHandle notifyObject)重载方法，来结束Timer的触发，当线程池中的所有TimerCallBack方法都执行完毕后，Timer会发一个信号给timerDisposed

        //    timerDisposed.WaitOne();//WaitHandle.WaitOne()方法会等待收到一个信号，否则一直被阻塞
        //    timerDisposed.Dispose();

        //    Console.WriteLine("Timer已经结束，按任意键结束整个程序...");
        //    Console.ReadKey();
        //}
    }

}
