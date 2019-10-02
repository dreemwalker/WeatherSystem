using System;

namespace ConsoleReader.Core
{
    public static  class ConsoleLogger
    {
        static public void Error(string message, object sender)
        {
            Console.WriteLine(DateTime.Now+" ERROR: "+message+"  AT " + sender.ToString());
        }
        static public void Log(string message)
        {
            Console.WriteLine(DateTime.Now + " MESSAGE: " + message);
        }
        static public void Warning(string message)
        {
            Console.WriteLine(DateTime.Now + " WARNING: " + message);
        }
    }
}
