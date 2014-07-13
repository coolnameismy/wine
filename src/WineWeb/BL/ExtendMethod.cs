using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineWeb.BL
{
    public static class ExtendMethod
    {
        public static string QueryStringStringHelp(this string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return  "";
            }
            else
            {
                return str;
            }
        }
        public static int QueryStringIntHelp(this string str)
        {
            int temp;
            if (String.IsNullOrEmpty(str))
            {
                temp = 0 ;
            }
            else
            {
                try
                {
                    temp = Convert.ToInt16(str);
                }
                catch
                {
                    temp = 0;
                }
            }
            return temp;
        }
    }
}