using System;
using System.Collections.Generic;
using System.Text;
using LibraryData.Models;

namespace LibraryServices
{
    public class DataHelpers
    {
        public static List<string> HumanizeBizHours(IEnumerable<BranchHours> branchHours)
        {
            var hours = new List<string>();

            foreach (var time in branchHours)
            {
                var day = HumanizeDay(time.DayOfWeek);
                var openTime = HumanizeTime(time.OpenTime);
                var closeTime = HumanizeTime(time.CloseTime);

                var timeEntry = $"{day} {openTime} to {closeTime}";
                hours.Add(timeEntry);
            }

            return hours;
        }

        private static object HumanizeTime(int time)
        {
            return TimeSpan.FromHours(time).ToString("hh':'mm");
        }

        public static object HumanizeDay(int number)
        {
            // our data correalated 1-> Sunday, so subtract 1
            return Enum.GetName(typeof(DayOfWeek), number - 1);
        }
    }
}
