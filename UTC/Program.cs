using System;

namespace UTC
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Need to write a program that...
             * parse a timestamp string
             * creates a dateTime obj
             * sets dateTime obj to local
             * converts dateTime into UTC
             * Prove that it handles PST PDT transitions
             * 
             * Have a time date object increase while printing time stamps to show it's working
             */

            //****Stored Values****
            var timeStampFromXML = "2021-06-13T10:40:00";

            var dstStart = "Sunday, March 14, 2021, 2:00:00 am";
            var dstStartedNonExistent = "Sunday, March 14, 2021, 2:30:00 am";
            var dstStartDuplicate = "Sunday, March 14, 2021, 3:00:00 am";

            var dstEnd2AM01 = "Sunday, November 7, 2021, 2:00:00 am";
            var dstEnd2AM02 = "Sunday, November 7, 2021, 2:00:00 am";
            var dstEnd1AM01 = "Sunday, November 7, 2021, 1:00:00 am";
            var dstEnd1AM02 = "Sunday, November 7, 2021, 1:00:00 am";

            //****Creation of Objects****

            var currentLocalDTS = DateTime.Now;
            var currentUtcDTS = DateTime.UtcNow;

            Console.WriteLine($"Local Time: {currentLocalDTS}");
            Console.WriteLine($" UTC  Time: {currentUtcDTS}");














        }
    }
}
