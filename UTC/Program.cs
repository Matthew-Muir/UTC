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


            var boo = "Saturday, March 13, 2021, 12:00 am"; // dst should be false
            var dstExpired = "Sunday, March 14, 2021, 12:00 am";
            var foo = "Monday, March 15, 2021, 12:00 am";  // dst should be true
            var doo = "Tuesday, June 22, 2021, 12:00 am"; //dst should be true
            var pstStart = "Sunday November 7, 2021, 12:00 am";
            var dstStart = "Sunday, March 13, 2022, 12:00 am";

            //****Creation of Objects****

            var dtsTest = DateTime.Parse(dstExpired);
            dtsTest = DateTime.SpecifyKind(dtsTest, DateTimeKind.Local);

            TimePeriodCheck(dtsTest);
        }

        public static void TimePeriodCheck(DateTime dateTime)
        {
            var utcDTS = dateTime.ToUniversalTime();
            Console.WriteLine($"");

            for (int i = 0; i <= 1440; i += 60)
            {
                
                Console.WriteLine($"PST: {dateTime.AddMinutes(i)} - UTC {utcDTS.AddMinutes(i)} - K: {dateTime.AddMinutes(i).Kind} - DST: {dateTime.AddMinutes(i).IsDaylightSavingTime()}");
                
            }
            
        }
    }
}
