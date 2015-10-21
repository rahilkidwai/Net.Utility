using System;
using System.Globalization;

namespace Rk.Net.Utility
{
    /// <summary>
    /// The helper class provides static datetime related helper methods.
    /// </summary>
    public static class DateTimeHelper
    {
        #region Methods
        /// <summary>
        /// Tries to convert a given string to DateTime instance. Valid formats are "yyyyMMdd" and "yyyyMMdd HHmm".
        /// </summary>
        /// <param name="text">String to be converted.</param>
        /// <returns>DateTime object.</returns>
        public static bool TryParse(string value, out DateTime datetime)
        {
            datetime = DateTime.MinValue;
            if (string.IsNullOrWhiteSpace(value)) return false;
            string[] validFormats = new string[] 
            {
                "yyyyMMdd",
                "yyyyMMdd HHmm"
            };
            return DateTime.TryParseExact(value.Trim(), validFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime);
        }

        /// <summary>
        /// Gets the date time from given date time strings.
        /// </summary>
        /// <param name="yyyyMMdd">The date in format yyyyMMDD.</param>
        /// <param name="HHmm">The time in format HHmm.</param>
        /// <returns></returns>
        public static bool TryParse(string yyyyMMdd, string HHmm, out DateTime datetime)
        {
            if (string.IsNullOrWhiteSpace(yyyyMMdd)) yyyyMMdd = string.Empty;
            if (string.IsNullOrWhiteSpace(HHmm)) HHmm = string.Empty;
            return DateTimeHelper.TryParse(string.Format("{0} {1}", yyyyMMdd, HHmm), out datetime);
        }
        
        /// <summary>
        /// Gets the utc date time from given date time strings.
        /// </summary>
        /// <param name="value">The date in utc format.</param>
        /// <returns></returns>
        public static bool TryParseUtc(string value, out DateTime datetime)
        {
            return DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out datetime);
        }

        /// <summary>
        /// Gets the formatted date after converting a given string to DateTime instance. Valid formats are "yyyyMMdd" and "yyyyMMdd HHmm".
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static string GetFormattedDate(string value, string format = "{0:MM/dd/yyyy}")
        {
            DateTime dateTime;
            if (TryParse(value, out dateTime))
            {
                return string.Format(format, dateTime);
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the formatted date after converting a given string to DateTime instance. Valid formats are "yyyyMMdd" and "yyyyMMdd HHmm".
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static string GetFormattedDateTime(string value, string format = "{0:MM/dd/yyyy H:mm:ss}")
        {
            DateTime dateTime;
            if (TryParse(value, out dateTime))
            {
                return string.Format(format, dateTime);
            }
            return string.Empty;
        }

        /// <summary>
        /// Return formated time string given HHmm, if AMPM is tru the time is given as AM/PM else 24 hour format
        /// </summary>
        /// <param name="HHmm">time in 24 hour format, i.e 1502</param>
        /// <param name="AMPM">true or false, if true</param>
        /// <returns>format time,  03:02 PM</returns>
        public static string GetFormattedTime(string HHmm, bool AMPM)
        {
            if (string.IsNullOrWhiteSpace(HHmm)) return string.Empty;
            HHmm = HHmm.Trim();
            if (HHmm.Length >= 4)
            {
                short hours, minutes;
                if (!Int16.TryParse(HHmm.Substring(0, 2), out hours)) return string.Empty;
                if (Int16.TryParse(HHmm.Substring(2, 2), out minutes)) return string.Empty;
                if (AMPM)
                {
                    if (hours >= 12)
                    {
                        if (hours > 12) hours -= 12;
                        return string.Format("{0}:{1} PM", hours.ToString("00"), minutes.ToString("00"));
                    }
                    else
                    {
                        return string.Format("{0}:{1} AM", hours.ToString("00"), minutes.ToString("00"));
                    }
                }
                else
                {
                    return string.Format("{0}:{1}", hours.ToString("00"), minutes.ToString("00"));
                }
            }
            return string.Empty;
        }
        #endregion
    }
}