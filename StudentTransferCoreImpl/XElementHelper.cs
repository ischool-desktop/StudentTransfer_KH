using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace StudentTransferCoreImpl
{
    internal static class XLinqHelper
    {
        public static string String(this XElement elm)
        {
            if (elm == null)
                return string.Empty;
            else
                return elm.Value;
        }

        public static string String(this XAttribute att)
        {
            if (att == null)
                return string.Empty;
            else
                return att.Value;
        }

        public static int Int(this XAttribute att, int defaultValue)
        {
            if (att == null)
                return defaultValue;
            else
            {
                int result;
                if (int.TryParse(att.Value, out result))
                    return result;
                else
                    return defaultValue;
            }
        }

        public static string DateString(this XElement elm)
        {
            if (elm == null)
                return string.Empty;

            string date = elm.Value;
            DateTime dt;

            if (DateTime.TryParse(date, out dt))
                return dt.ToString("yyyy/MM/dd");
            else
                return string.Empty;
        }
    }
}
