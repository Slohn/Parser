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
            //Dictionary<string,string> month = new Dictionary<string, string>();
            //month.Add("января", "Jan");
            //month.Add("февраля", "Feb");
            //month.Add("марта", "Mar");
            //month.Add("апреля", "Apr");
            //month.Add("мая", "May");
            //month.Add("июня", "Jun");
            //month.Add("июля", "Jul");
            //month.Add("августа", "Aug");
            //month.Add("сентября", "Sep");
            //month.Add("октября", "Oct");
            //month.Add("ноября", "Nov");
            //month.Add("декабря", "Dec");

            Dictionary<string, int> month = new Dictionary<string, int>();
            month.Add("января",1);
            month.Add("февраля", 2);
            month.Add("марта", 3);
            month.Add("апреля",4);
            month.Add("мая", 5);
            month.Add("июня", 6);
            month.Add("июля", 7);
            month.Add("августа", 8);
            month.Add("сентября", 9);
            month.Add("октября", 10);
            month.Add("ноября", 11);
            month.Add("декабря", 12);
            DateTime res;
            var dateInput = str.Split(",").Last().Trim().Split(" ");
            if (str.Contains(","))
            {
                int d = int.Parse(dateInput[0]);
                int m;
                month.TryGetValue(dateInput[1], out m);
                int year = DateTime.Now.Year;
                res = new DateTime( year, m, d);
            }
            else 
            {
                res = DateTime.Now;
            }
            return res;
        }
    }
}
