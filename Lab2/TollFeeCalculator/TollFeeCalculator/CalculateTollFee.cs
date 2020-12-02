using System;

namespace TollFeeCalculator
{
    public class CalculateTollFee
    {
        static void Main()
        {
            Console.WriteLine(GetTollFeeByTime(new DateTime(2020, 6, 30, 16, 50, 00)));
            run(Environment.CurrentDirectory + "../../../../testData.txt");
        }

        public static void run(string passingDatesFile)
        {
            string passingDatesString = System.IO.File.ReadAllText(passingDatesFile);
            string[] passingDatesStringArray = passingDatesString.Split(", ");
            DateTime[] passingDates = new DateTime[passingDatesStringArray.Length - 1];
            for (int i = 0; i < passingDates.Length; i++)
            {
                passingDates[i] = DateTime.Parse(passingDatesStringArray[i]);
            }
            Console.Write("The total fee for the inputfile is " + TotalFeeCost(passingDates));
        }

        public static int TotalFeeCost(DateTime[] dateTimes)
        {
            int fee = 0;
            DateTime startDate = dateTimes[0]; //Starting interval
            foreach (var date in dateTimes)
            {
                long diffInMinutes = (date - startDate).Minutes;
                if (diffInMinutes > 60)
                {
                    fee += GetTollFee(date);
                    startDate = date;
                }
                else
                {
                    fee += Math.Max(GetTollFee(date), GetTollFee(startDate));
                }
            }
            return Math.Max(fee, 60);
        }

        public static int GetTollFee(DateTime dateTime)
        {
            int fee = GetTollFeeByTime(dateTime);
            if (isFreeFeeDay(dateTime)) fee = 0;

            return fee;
        }

        private static int GetTollFeeByTime(in DateTime dateTime)
        {
            var time = dateTime.TimeOfDay;
            foreach(var period in feeSchedule)
            {
                if (time < period.endTime) return period.fee;
            }
            return 0;
        }

        private static readonly FeeSchedule[] feeSchedule =
        {
            new FeeSchedule(new TimeSpan(6,0,0), 0),
            new FeeSchedule(new TimeSpan(6,30,0), 8),
            new FeeSchedule(new TimeSpan(7,0,0), 13),
            new FeeSchedule(new TimeSpan(8,0,0), 18),
            new FeeSchedule(new TimeSpan(8,30,0), 13),
            new FeeSchedule(new TimeSpan(15,0,0), 8),
            new FeeSchedule(new TimeSpan(15,30,0), 13),
            new FeeSchedule(new TimeSpan(17,0,0), 18),
            new FeeSchedule(new TimeSpan(18,0,0), 13),
            new FeeSchedule(new TimeSpan(18,30,0), 8),
        };

        public static bool isFreeFeeDay(DateTime dateTime)
        {
            return (int)dateTime.DayOfWeek == 6 
                || (int)dateTime.DayOfWeek == 0 
                || (int)dateTime.Month == 7;
        }
    }
}
