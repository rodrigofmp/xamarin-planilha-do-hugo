using System;
using System.Collections.Generic;
using System.Text;

namespace PlanilhaDoHugo.Utils
{
    public static class DateTimeUtils
    {
        /// <summary>
        /// Receives an hour as a int and returns the minutes
        /// </summary>
        /// <param name="time">13:12 should be 1312</param>
        /// <returns>Returns only 12</returns>
        public static int GetMinutesPart(int time)
        {
            double fValue = time / 100;
            double fHour = Math.Truncate(fValue);
            double fMinutes = fValue - Math.Truncate(fValue);
            return (int) (Math.Truncate(fMinutes * 100));
        }

        /// <summary>
        /// Receives an hour as a int and returns the hours
        /// </summary>
        /// <param name="time">13:12 should be 1312</param>
        /// <returns>Returns only 13</returns>
        public static int GetHoursPart(int time)
        {
            double fValue = time / 100;
            return (int) Math.Truncate(fValue);
        }

        /// <summary>
        /// Returns how many minutes there are in the time
        /// </summary>
        /// <param name="time">1312</param>
        /// <returns>Returns 792</returns>
        public static int TimeToMinutes(int time)
        {
            return (GetHoursPart(time) * 60) + GetMinutesPart(time);
        }

        /// <summary>
        /// Returns how many hours there are in the minutes counting
        /// </summary>
        /// <param name="minutes">792</param>
        /// <returns>1312</returns>
        public static int MinutesToTime(int minutes)
        {
            double timeDecimal = minutes / 60;
            double hours = Math.Truncate(timeDecimal);
            double decimalPart = timeDecimal - hours;
            return (int) Math.Truncate(60 * (decimalPart * 100) / 100);
        }
    }
}
