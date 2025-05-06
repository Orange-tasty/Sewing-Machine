using System;
using System.Threading;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using VM.GlobalScript.Methods;

namespace 缝纫机项目
{
    public class SnapThread
    {
        private Thread thread;
        public bool _running = false;

        // 以及超时机制
        //bool received = false;
        //const int maxRetry = 50;   // 最多等 50 x 1ms = 50ms

        //public event Action<string> 输出信息;   // 事件可用于UI绑定，比如输出日志

        public static async Task<bool> 等待数据接收(int 超时时间ms)
        {
            //var 计时器 = System.Diagnostics.Stopwatch.StartNew();
            Stopwatch 计时器 = Stopwatch.StartNew();
            int 检测间隔 = 1;

            while (计时器.Elapsed.TotalMilliseconds < 超时时间ms)
            {
                if (Volatile.Read(ref VM通讯.客户端.m_x) != null)
                {
                    return true;
                }
                工艺测试.Delay(检测间隔);
                //await Task.Delay(检测间隔);
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
            Task任务.信息输出("线程已启动");
        }

        public void Stop()
        {
            _running = false;
            VM通讯.发送("stop");
            Task任务.信息输出("停止线程请求已发送");
        }

        private Stopwatch stopwatch = new Stopwatch();
        private (double 平均距离1, int 数量1, int 数量2, double 平均距离2, int 数量3, int 数量4) _lastData = (0, 0, 0, 0, 0, 0);
        public static long totaltime;
        private async void ThreadMain()
        {
            int num = 0;
            int err_num = 0;
            VM通讯.发送("contisnap");
            while (_running)
            {
                try
                {
                    // 清空VM通讯数据
                    stopwatch.Start();
                    //VM通讯.客户端.m_x = null;
                    //VM通讯.发送("snap");
                    bool 是否收到数据 = await SnapThread.等待数据接收(70);
                    if (是否收到数据) 
                    {
                        if (VM通讯.接收信息拆解Try(VM通讯.客户端.m_x, out var data))
                        {                           
                            _lastData = data;
                            VM通讯.客户端.m_x = null;
                        }
                        else
                        {
                            Task任务.信息输出("接收信息错误");
                            data = _lastData;
                        }
                        //var now = DateTime.Now;
                        //string timestamp = now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        //Task任务.信息输出(timestamp + " 接收数据成功 " + data);
                        工艺测试.距离 = data.距离;
                        工艺测试.剪口数 = data.剪口数;
                        工艺测试.距离X = data.距离X;
                        工艺测试.剪口数X = data.剪口数X;
                        工艺测试.二次剪口数 = data.二次剪口数;
                        工艺测试.二次剪口数X = data.二次剪口数X;
                        num++;
                        VM通讯.客户端.m_x = null;
                    }
                    else
                    {
                        Task任务.信息输出("未接收到信息");
                        err_num++;
                    }

                    if (err_num > 10)
                    {                     
                        MainProgram._程序状态 = 7;
                        MainProgram.停止逻辑step = 1;
                        缝纫机.待机();
                        Stop();
                    }
                    
                    double pos = 0 * 缝纫机.当前转速() + 工艺测试.上电机PID.Func(工艺测试.配方_上A.Value, 工艺测试.配方_上B.Value, 工艺测试.配方_上C.Value, 工艺测试.配方_上P.Value, 工艺测试.配方_上I.Value, 工艺测试.配方_上D.Value, 工艺测试.距离 - 工艺测试.配方_上V.Value, 工艺测试._上电机速度上限.Value, 工艺测试._上电机速度下限.Value);
                    double posX = 0 * 缝纫机.当前转速() + 工艺测试.下电机PID.Func(工艺测试.配方_下A.Value, 工艺测试.配方_下B.Value, 工艺测试.配方_下C.Value, 工艺测试.配方_下P.Value, 工艺测试.配方_下I.Value, 工艺测试.配方_下D.Value, 工艺测试.距离X - 工艺测试.配方_下V.Value, 工艺测试._下电机速度上限.Value, 工艺测试._下电机速度下限.Value);
                    工艺测试.单轴速度控制(GLV._上电机, pos);
                    工艺测试.单轴速度控制(GLV._下电机, posX);
                    //if(num > 300) Task任务.信息输出("上电机速度为: " + pos.ToString());
                    stopwatch.Stop();
                    long mSeconds = stopwatch.ElapsedMilliseconds;
                    totaltime += mSeconds;
                    double cirile = 缝纫机.当前转速() * mSeconds / 60000;
                    //double cirile = _缝纫机初始工作转速.Value;
                    stopwatch.Reset();
                    //Task任务.信息输出("此次流程时间为" + mSeconds.ToString() + "ms");
                    //Task任务.信息输出(totaltime.ToString() + "ms");
                }
                catch (Exception ex)
                {
                    Task任务.信息输出("线程错误: " + ex.Message);
                }
                //int retry = 0;
                //while (_running && retry <= maxRetry )
                //{

                //        if (VM通讯.接收信息拆解Try(VM通讯.客户端.m_x, out var data))
                //        {
                //            var now = DateTime.Now;
                //            string timestamp = now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                //            //_lastData = data;
                //            //输出信息?.Invoke($"[{timestamp}] 接收数据成功：{data}");
                //            Task任务.信息输出(timestamp + " 接收数据成功 " + data);

                //            //received = true;
                //            VM通讯.发送("snap");
                //            break;
                //        }
                //        //else
                //        //{
                //        //    Task任务.信息输出("接收信息错误");
                //        //    data = _lastData;
                //        //}

                //    //Thread.Sleep(1); // 每1ms检查一次
                //    工艺测试.Delay(1);
                //    retry++;
                //}
                //if (!received)
                //{
                //    Task任务.信息输出("接收数据失败(超时)");
                //}


                // 如果还在运行，进入下一轮循环（收到数据后才继续）
                // 如果中途调用 Stop()，_running 会变为 false，跳出 while
            }
            运动控制.单轴停止(0, GLV._上电机);
            运动控制.单轴停止(0, GLV._上电机);
            Task任务.信息输出("线程已停止。 共检测" + num.ToString() + "次");
            Task任务.信息输出("总耗时为" + totaltime.ToString() + "ms");
            //Task任务.信息输出("总耗时为" + (totaltime/1000).ToString() + "s");
            totaltime = 0;
            err_num = 0;
        }

    }
}



