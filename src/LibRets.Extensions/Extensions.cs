using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using librets;

namespace LibRets.Extensions
{
    public static class LibRetsExtensions
    {
        public static string GetSafeString(this SearchResultSet source, string columnName)
        {
            if (source.GetString(columnName) == null)
            {
                Debug.WriteLine("{0} has a null value", columnName);
            }

            return source.GetString(columnName) ?? string.Empty;
        }

        public static string GetSafePhoneNumber(this SearchResultSet source, string columnName)
        {
            if (source.GetString(columnName) == null)
            {
                Debug.WriteLine("{0} has a null value", columnName);
            }

            var phone = source.GetString(columnName) ?? string.Empty;
            if (phone.Length >= 7)
            {
                phone = phone.Insert(3, "-");
            }

            return phone;
        }

        public static DateTime GetSafeDateTime(this SearchResultSet source, string columnName, DateTime defaultDateTime)
        {
            var dateTime = GetSafeDateTime(source, columnName);
            if (!dateTime.HasValue)
            {
                dateTime = defaultDateTime;
            }

            return dateTime.Value;
        }

        public static DateTime? GetSafeDateTime(this SearchResultSet source, string columnName)
        {
            if (source.GetString(columnName) == null)
            {
                Debug.WriteLine("{0} has a null value", columnName);
            }

            var stringValue = source.GetString(columnName);

            if (string.IsNullOrEmpty(stringValue))
            {
                return null;
            }

            DateTime dateValue;
            if (!DateTime.TryParse(stringValue, out dateValue))
            {
                return null;
            }

            return dateValue;
        }

        public static int GetSafeInteger(this SearchResultSet source, string columnName)
        {
            if (source.GetString(columnName) == null)
            {
                Debug.WriteLine("{0} has a null value", columnName);
            }

            return GetSafeInteger(source, columnName, 0);
        }

        public static int GetSafeInteger(this SearchResultSet source, string columnName, int defaultValue)
        {
            if (source.GetString(columnName) == null)
            {
                Debug.WriteLine("{0} has a null value", columnName);
            }

            var stringValue = source.GetString(columnName);

            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            int intValue;
            if (!int.TryParse(stringValue, out intValue))
            {
                return defaultValue;
            }

            return intValue;
        }

        public static decimal GetSafeDecimal(this SearchResultSet source, string columnName)
        {
            if (source.GetString(columnName) == null)
            {
                Debug.WriteLine("{0} has a null value", columnName);
            }

            return GetSafeDecimal(source, columnName, 0);
        }

        public static decimal GetSafeDecimal(this SearchResultSet source, string columnName, decimal defaultValue)
        {
            if (source.GetString(columnName) == null)
            {
                Debug.WriteLine("{0} has a null value", columnName);
            }

            var stringValue = source.GetString(columnName);

            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            decimal decimalValue;
            if (!decimal.TryParse(stringValue, out decimalValue))
            {
                return defaultValue;
            }

            return decimalValue;
        }
    }
}
