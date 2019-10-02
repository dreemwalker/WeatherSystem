using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleReader.Core;
using ConsoleReader.Core.Gismeteo;
using ConsoleReader.Core.DBClasses;
using System.Timers;
namespace ConsoleReader
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        private static UserActionsLocker exitLocker;
        static void Main(string[] args)
        {
           
            exitLocker = new UserActionsLocker();
            SetTimer();
            while (true)
            {
                Console.ReadLine();
                if (!exitLocker.GetState())
                {
                   
                    aTimer.Stop();
                    aTimer.Dispose();
                    ConsoleLogger.Log("Terminating the application...");
                  
                    break;
                }
                else
                {
                    ConsoleLogger.Log("Please wait for weather update...");
                }
            }

        }
        private static void SetTimer()
        {
          
           // Run();
            aTimer = new System.Timers.Timer(300000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            ApplicationWorker applicationWorker = new ApplicationWorker(exitLocker);
            applicationWorker.Run();

            aTimer.Start();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            ApplicationWorker applicationWorker = new ApplicationWorker(exitLocker);
            applicationWorker.Run();
         
        }
     
    }
}
