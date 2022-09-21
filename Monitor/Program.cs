using System;
using System.Diagnostics;

namespace Monitor
{
    public class Program
    {
        public static string name;
        public static int lifetime;


        public static void Main()
        {
            GetAllProcess();
        }

        //Create a function that displays the process 
        //and then kills the process that has exceeded the imposed period
        static void GetAllProcess()
        {

            Process[] proc;

            proc = Process.GetProcessesByName(name);

            TimeSpan timeToKill = new TimeSpan(0, 0, lifetime, 0);
            foreach (Process p in proc)
            {

                //Create a variable that calculates the actual time 
                //minus the process startup time
                TimeSpan runningTime = DateTime.Now - p.StartTime;

                if (runningTime.TotalMinutes < timeToKill.Minutes)
                {
                    Console.WriteLine("Process Name: " + name + " is running (LifeTime): " + runningTime.TotalMinutes + " minute(s)");
                }
                else
                {
                    //if the process lifetime more than The specified time
                    //kill the process
                    p.Kill();
                    Console.WriteLine("Process Name: " + name + " with ID " + p.Id + "It was running for" + runningTime.ToString(@"hh\\:mm\\:ss\") + "was killed.");
                }
            }
            //frequency time 
            System.Threading.Thread.Sleep(100);

            Console.WriteLine("Enter ,,X,, to quit");
            while (true)
            {
                char ch = Console.ReadKey().KeyChar;
                switch (Char.ToLower(ch))
                {
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("\nPlease Enter Valid Choice");
                        break;
                }
            }
        }

    }
}