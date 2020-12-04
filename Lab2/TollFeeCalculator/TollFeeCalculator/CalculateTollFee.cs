using System;
using System.Collections.Generic;

namespace TollFeeCalculator
{
    public class CalculateTollFee
    {
        static void Main()
        {
            PrintTotalTollFeeFromFile(Environment.CurrentDirectory + "../../../../testData.txt");
        }

        //TODO Return message if path is not found or content is empty or not convertable. DONE!

        public static void PrintTotalTollFeeFromFile(string passingDatesFilePath)
        {
            try
            {
                DateTime[] passingDates = GetDatesArrayFromFile(passingDatesFilePath);
                int totalFee = GetTotalTollFeeCost(passingDates);
                Console.Write($"The total fee for the inputfile is {totalFee}");
            }
            catch (Exception)
            {
                Console.Write($"The toll fee could not be calculated");
                Environment.Exit(0);
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
                passingDates = new string[] { string.Empty };
            }
            DateTime[] parsedPassingDates = new DateTime[passingDates.Length - 1];
            for (int i = 0; i < parsedPassingDates.Length; i++)
            {
                parsedPassingDates[i] = DateTime.Parse(passingDates[i]);
            }
            Array.Sort(parsedPassingDates);
            return parsedPassingDates;
        }

        public static int GetTotalTollFeeCost(DateTime[] passageDates)
        {
            if (passageDates.Length == 0)
            {
                return 0;
            }
            int TotalTollFeeCost = 0;
            DateTime oneHourPeriodEndTime = passageDates[0].AddHours(1);
            int oneHourPeriodFee = 0;
            foreach (DateTime passageDate in passageDates)
            {
                if (passageDate < oneHourPeriodEndTime)
                {
                    int passageDateFee = GetTollFeeByDate(passageDate);
                    int periodFeeMargin = passageDateFee - oneHourPeriodFee;
                    oneHourPeriodFee = Math.Max(passageDateFee, oneHourPeriodFee);
                    TotalTollFeeCost += Math.Max(periodFeeMargin, 0);
                    continue;
                }
                oneHourPeriodEndTime = passageDate.AddHours(1);
                oneHourPeriodFee = GetTollFeeByDate(passageDate);
                TotalTollFeeCost += oneHourPeriodFee;
            }
            return Math.Min(TotalTollFeeCost, 60);
        }

        public static int GetTollFeeByDate(DateTime passageDate)
        {
            int tollFeeByDate = GetTollFeeByTime(passageDate);
            if (IsDateTollFree(passageDate)) tollFeeByDate = 0;
            return tollFeeByDate;
        }

        public static int GetTollFeeByTime(in DateTime passageDate)
        {
            var passingTime = passageDate.TimeOfDay;
            foreach(var period in TollFee.feeSchedule)
            {
                if (passingTime < period.endTime) return period.fee;
            }
            return 0;
        }

        public static bool IsDateTollFree(DateTime passingDate)
        {
            return (int)passingDate.DayOfWeek == 6 
                || (int)passingDate.DayOfWeek == 0 
                || (int)passingDate.Month == 7;
        }
    }
}