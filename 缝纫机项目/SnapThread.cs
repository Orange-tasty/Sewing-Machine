using System;
using System.Threading;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace 缝纫机项目
{
    public class SnapThread
    {
        private Thread thread;
        public bool _running = false;

        // 以及超时机制
        bool received = false;
        const int maxRetry = 50;   // 最多等 50 x 1ms = 50ms
        
        public event Action<string> 输出信息;   // 事件可用于UI绑定，比如输出日志

        public static async Task<bool> 等待数据接收(int 超时时间ms)
        {
            Stopwatch 计时器 = Stopwatch.StartNew();
            int 检测间隔 = 5;

            while (计时器.Elapsed.TotalMilliseconds < 超时时间ms)
            {
                if (Volatile.Read(ref VM通讯.客户端.m_x) != null)
                {
                    return true;
                }
                await Task.Delay(检测间隔);
            }
            return false;
        }

        public void Start()
        {
            if (_running) return;

            _running = true;
            thread = new Thread(ThreadMain);
            thread.IsBackground = true;
            thread.Start();
            输出信息?.Invoke("线程已启动");
            Task任务.信息输出("线程已启动");
        }

        public void Stop()
        {
            _running = false;
            输出信息?.Invoke("停止线程请求已发送");
            Task任务.信息输出("停止线程请求已发送");
        }

        private void ThreadMain()
        {
            VM通讯.发送("snap");
            while (_running)
            {
                try
                {
                    // 清空VM通讯数据
                    VM通讯.客户端.m_x = null;

                    // 发送snap指令
                    
                    
                    
                    //var sendStart = DateTime.Now;
                    //工艺测试.Delay(1);
                    //var sendEnd = DateTime.Now;
                    //Task任务.信息输出("发送耗时:" + (sendEnd - sendStart).TotalMilliseconds + "ms");

                    int retry = 0;
                    while (_running && retry < maxRetry)
                    {
                        if (VM通讯.接收信息拆解Try(VM通讯.客户端.m_x, out var data))
                        {
                            var now = DateTime.Now;
                            string timestamp = now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            //输出信息?.Invoke($"[{timestamp}] 接收数据成功：{data}");
                            Task任务.信息输出(timestamp + " 接收数据成功 " + data);

                            received = true;
                            VM通讯.发送("snap");
                            break;
                        }

                        //Thread.Sleep(1); // 每1ms检查一次
                        工艺测试.Delay(1);
                        retry++;
                    }

                    if (!received)
                    {
                        //输出信息?.Invoke("接收数据失败（超时）");
                        Task任务.信息输出("接收数据失败(超时)");
                    }
                }
                catch (Exception ex)
                {
                    //输出信息?.Invoke("线程错误: " + ex.Message);
                    Task任务.信息输出("线程错误: " + ex.Message);
                }

                // 如果还在运行，进入下一轮循环（收到数据后才继续）
                // 如果中途调用 Stop()，_running 会变为 false，跳出 while
            }

            //输出信息?.Invoke("线程已停止");
            Task任务.信息输出("线程已停止");
        }

    }
}
