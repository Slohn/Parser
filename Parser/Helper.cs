using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Helper
    {

        public static DateTime GetDateFromString(string str) 
        {
            string dateInput;
            Dictionary<string,string> month = new Dictionary<string, string>();
            month.Add("января", "Jan");
            month.Add("февраля", "Feb");
            month.Add("марта", "Mar");
            month.Add("апреля", "Apr");
            month.Add("мая", "May");
            month.Add("июня", "Jun");
            month.Add("июля", "Jul");
            month.Add("августа", "Aug");
            month.Add("сентября", "Sep");
            month.Add("октября", "Oct");
            month.Add("ноября", "Nov");
            month.Add("декабря", "Dec");
            month.TryGetValue(str.Split(" ").Last().ToLower(), out dateInput);
            DateTime res = DateTime.Parse(dateInput);
            return res;
        }
    }
}
