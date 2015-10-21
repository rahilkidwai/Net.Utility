using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Rk.Net.Utility
{
    /// <summary>
    /// Provides string helper methods
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Removes the special characters.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static string GetAlphaNumeric(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converts the given number to words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static string NumberToWords(int number)
        {
            if (number == 0) return "Zero";
            if (number < 0) return "Minus " + NumberToWords(Math.Abs(number));
            string words = "";
            int quotient = number / 1000000000;
            if (quotient > 0)
            {
                words += NumberToWords(quotient) + " Billion ";
                number %= 1000000000;
            }
            quotient = number / 1000000;
            if (quotient > 0)
            {
                words += NumberToWords(quotient) + " Million ";
                number %= 1000000;
            }
            quotient = number / 1000;
            if (quotient > 0)
            {
                words += NumberToWords(quotient) + " Thousand ";
                number %= 1000;
            }
            quotient = number / 100;
            if (quotient > 0)
            {
                words += NumberToWords(quotient) + " Hundred ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "") words += "And ";
                string[] unitsMap = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                string[] tensMap = new string[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                if (number < 20)
                {
                    words += unitsMap[number];
                }
                else
                {
                    words += tensMap[number / 10];

                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words.TrimEnd();
        }

        /// <summary>
        /// Numbers to words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static string NumberToWords(double number)
        {
            string numberText = number.ToString();
            string[] stringParts = numberText.Split('.');
            StringBuilder words = new StringBuilder();
            if (stringParts.Length > 0)
            {
                int integerValue = 0;
                int.TryParse(stringParts[0], out integerValue);
                words.Append(NumberToWords(integerValue));
                if (stringParts.Length == 2)
                {
                    words.Append(" Point ");

                    for (int i = 0; i < stringParts[1].Length; i++)
                    {
                        int decimalValue = 0;
                        int.TryParse(stringParts[1].Substring(i, 1), out decimalValue);
                        
                        words.Append(NumberToWords(decimalValue));

                        if (i + 1 != stringParts[1].Length)
                        {
                            words.Append(" ");
                        }                        
                    }
                }
            }
            return words.ToString();
        }

        /// <summary>
        /// Escapes apostrophes from a string value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SqlClean(string value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.Replace("'", "''").Replace("|", "");
        }
        
        /// <summary>
        /// Removes the leading zeros.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string RemoveLeadingZeros(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            value = value.TrimStart();            
            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i].Equals('0')) ++count;
                else break;
            }
            if (count > 0) value = value.Substring(count);
            return value;
        }

        /// <summary>
        /// Units the type of to dose unit.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns></returns>
        public static string UnitToDoseUnitType(string val)
        {
            val.ToUpper();
            if (val.Contains("INHALATION") ||
                val.Contains("INHALATIONS") ||
                val.Contains("PUFF") ||
                val.Contains("PUFF(S)") ||
                val.Contains("PUFFS") ||
                val.Contains("SPR") ||
                val.Contains("SPRAY") ||
                val.Contains("SPRAY(S)") ||
                val.Contains("SPRAYS") ||
                val.Contains("SQUIRT") ||
                val.Contains("SQUIRTS") ||
                val.Contains("INHL"))
            {
                return "INH";
            }
            else
            {
                return "EA";
            }
        }

        /// <summary>
        /// Return list of strings based on given string for full text search.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <returns></returns>
        public static List<string> FullTextSearchString(string str)
        {
            StringBuilder sb = new StringBuilder();            
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' ')
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append(" ");
                }
            }
            StringParser parser = new StringParser(sb.ToString(), " ", StringSplitOptions.RemoveEmptyEntries);            
            List<string> list = new List<string>();
            foreach (string token in parser)
            {
                if (token.Length > 1 && !list.Contains(token))
                {
                    list.Add(token);
                }
            }
            return list;
        }
    }
}