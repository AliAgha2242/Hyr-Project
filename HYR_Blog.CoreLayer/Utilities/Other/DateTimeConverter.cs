using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Utilities.Other
{
    public class DateTimeConverter
    {
        public static string ConvertToPersian(DateTime EuroDateTime)
        {
            PersianCalendar persian = new PersianCalendar();
            return string.Format(@"{0}/{1}/{2} ({3}:{4})",
                persian.GetYear(EuroDateTime),
                persian.GetMonth(EuroDateTime),
                persian.GetDayOfMonth(EuroDateTime),
                persian.GetHour(EuroDateTime),
                persian.GetMinute(EuroDateTime)
                );
        } 
    }
}
