using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework_4_2
{
    public class Clock
    {
        private int hour;
        private int minute;
        private int second;
        private int h;
        private int m;
        private int s;
        public Clock(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public Clock()
        {
            hour = 0;
            minute = 0;
            second = 0;
        }
        public event Action Tick;
        public event Action Alarm;
        public void Tick1()
        {
            second = second + 1;
            if (second >= 60)
            {
                minute += 1;
                second = 0;
            }
            if (minute >= 60)
            {
                hour += 1;
                minute = 0;
            }
            if (hour >= 24)
                hour = 0;
        }
        public void ShowTime()
        {
            Console.WriteLine($"{hour}:{minute}:{second}");
        }

        public void SetAlarm()
        {
            Console.WriteLine("请设置闹铃的时间(分别输入时钟分钟秒钟)：");
            h = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
            s = int.Parse(Console.ReadLine());
            Console.WriteLine($"闹铃的时间为：{h}:{m}:{s}");
        }

        public void Alarm1()
        {
            if (h == hour && m == minute && s == second)
                Console.WriteLine("Clock Alarming!");
        }

        public void StartClock()
        {
            while (true)
            {
                Tick();
                Alarm();
                Thread.Sleep(1000);
            }
        }
        class Form
        {
            public Clock clock = new Clock(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            public Form()
            {
                clock.Tick += clock.ShowTime;
                clock.Tick += clock.Tick1;
                clock.Alarm += clock.Alarm1;
            }

        }
        class Program
        {
            static void Main(string[] args)
            {
                Form form = new Form();
                Console.Write("当前时间为:");
                form.clock.ShowTime();
                form.clock.SetAlarm();
                form.clock.StartClock();
            }
        }
    }
}
