using System;

namespace TollFeeCalculator
{
    public class CalculateTollFee
    {
        private static void Main()
        {
            PrintTotalTollFeeFromFile(Environment.CurrentDirectory +
             "../../../../InputData.txt");
        }

        public static void PrintTotalTollFeeFromFile(string passingDatesFilePath)
        {
            try
            {
                DateTime[] passingDates =
                    GetDatesArrayFromFile(passingDatesFilePath);
                int totalFee = GetTotalTollFee(passingDates);
                Console.Write($"The total Fee for the input file is {totalFee}");
            }
            catch (Exception)
            {
                Console.Write($"The toll Fee could not be calculated");
            }
        }

        private static DateTime[] GetDatesArrayFromFile(string filePath)
        {
            string[] passingDates;
            try
            {
                passingDates = System.IO.File.ReadAllText(filePath)
                .Split(", ");
            }
            catch (Exception)
            {
                passingDates = new [] { string.Empty };
            }
            DateTime[] parsedPassingDates =
                new DateTime[passingDates.Length - 1];
            for (int i = 0; i < parsedPassingDates.Length; i++)
            {
                parsedPassingDates[i] = DateTime.Parse(passingDates[i]);
            }
            Array.Sort(parsedPassingDates);
            return parsedPassingDates;
        }

        public static int GetTotalTollFee(DateTime[] passageDates)
        {
            int totalTollFee = 0;
            if(passageDates.Length != 0)
            {
                int totalTollFeeCost = 0;
                DateTime oneHourPeriodEndTime = passageDates[0].AddHours(1);
                int oneHourPeriodFee = 0;
                foreach (DateTime passageDate in passageDates)
                {
                    if (passageDate < oneHourPeriodEndTime)
                    {
                        int passageDateFee = GetTollFeeByDate(passageDate);
                        int periodFeeMargin = passageDateFee - oneHourPeriodFee;
                        oneHourPeriodFee = Math.Max(
                            passageDateFee,
                            oneHourPeriodFee);
                        totalTollFeeCost += Math.Max(periodFeeMargin, 0);
                        continue;
                    }
                    oneHourPeriodEndTime = passageDate.AddHours(1);
                    oneHourPeriodFee = GetTollFeeByDate(passageDate);
                    totalTollFeeCost += oneHourPeriodFee;
                }
                totalTollFee = Math.Min(totalTollFeeCost, 60);
            }
            return totalTollFee;
        }

        public static int GetTollFeeByDate(DateTime passageDate)
        {
            int tollFeeByDate = GetTollFeeByTime(passageDate);
            if (IsDateTollFree(passageDate)) tollFeeByDate = 0;
            return tollFeeByDate;
        }

        public static int GetTollFeeByTime(in DateTime passageDate)
        {
            TimeSpan passingTime = passageDate.TimeOfDay;
            int tollFee = 0;
            foreach (TollFee period in TollFee.FeeSchedule)
            {
                if (passingTime < period.EndTime) 
                {
                    tollFee = period.Fee;
                    break;
                }
            }
            return tollFee;
        }

        public static bool IsDateTollFree(DateTime passingDate)
        {
            return (int)passingDate.DayOfWeek == 6
                || passingDate.DayOfWeek == 0
                || passingDate.Month == 7;
        }
    }
}