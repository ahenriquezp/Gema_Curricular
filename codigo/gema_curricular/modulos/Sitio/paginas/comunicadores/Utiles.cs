using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular.web
{
    public class Utiles
    {
        public static String DateTime_to_String(DateTime value)
        {
            return value.ToString("dd-MM-yyyy");
        }

        public static DateTime String_to_DateTime(string value)
        {
            return Convert.ToDateTime(value);
        }
    }
}
