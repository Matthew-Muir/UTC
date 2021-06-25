using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Sockets;

namespace UTC
{
    class Program
    {
        static void Main(string[] args)
        {
            //****Stored Values****
            var timeStampFromXML = "2021-06-13T10:40:00";

            //Spring Forward 2022 PDT
            var dstTwoAM = "Sunday, March 13, 2022, 02:00 am";
            var dstTwoHalfAM = "Sunday, March 13, 2022, 02:30 am";
            var dstThreeAM = "Sunday, March 13, 2022, 03:00 am";
            var dstThreeHalfAM = "Sunday, March 13, 2022, 03:30 am";

            //Fall Back 2021 PST
            var pstOneAM = "Sunday November 7, 2021, 01:00 am";
            var pstOneHalfAM = "Sunday November 7, 2021, 01:30 am";
            var pstTwoAM = "Sunday November 7, 2021, 02:00 am";
            var pstTwoHalfAM = "Sunday November 7, 2021, 02:30 am";


            //Parse our string into a DateTime obj and set it's timezone to local (So whatever the TZ of the machine running this codes is).
            var dateTime = DateTime.Parse(pstOneAM);
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Local);

            Console.WriteLine($"{pstOneAM} - " + ConvertToUTC(dateTime));

        }

        public static DateTime ConvertToUTC(DateTime dateTime)
        {
            //Creates list containing the 1st Sunday in Nov for the next ten years.
            List<DateTime> listOf1stSundayInNov = new List<DateTime>();
            for (int year = 2021; year <= 2031; year++)
            {
                DateTime dt = new DateTime(year, 11, 1);
                while (dt.DayOfWeek != DayOfWeek.Sunday)
                {
                    dt = dt.AddDays(1);
                }
                listOf1stSundayInNov.Add(dt);
            }

            //Used to determine if the dateTime falls between 1am and 2am and is in Nov list.
            TimeSpan dtHrsPastMidnight = dateTime.TimeOfDay;
            TimeSpan twoAMLimit = new TimeSpan(2, 0, 0);
            TimeSpan oneAMLimit = new TimeSpan(1, 0, 0);

            bool isInNovList = listOf1stSundayInNov.Contains(DateTime.Parse(dateTime.ToLongDateString()));
            bool isInTimeFrame = dtHrsPastMidnight >= oneAMLimit && dtHrsPastMidnight <= twoAMLimit;

            //DateTime obj to store conversion
            DateTime convertedToUTC;
            var pdtOffset = 7;
            var pstOffset = 8;

            if (isInNovList && isInTimeFrame)
            {
                //If the computer where the code is running is in DST then converts to UTC from PDT else convert to UTC from PST.
                if (DateTime.Now.IsDaylightSavingTime())
                {
                    convertedToUTC = dateTime.AddHours(pdtOffset);
                }
                else
                {
                    convertedToUTC = dateTime.AddHours(pstOffset);
                }
            }
            else
            {
                convertedToUTC = dateTime.ToUniversalTime();
            }

            return convertedToUTC;
        }

        


    }
}
