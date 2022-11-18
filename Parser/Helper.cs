using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Helper
    {
        public static Dictionary<string, int> month = new Dictionary<string, int>() 
        {
            { "января",1},
            {"февраля", 2 },
            {"марта", 3 },
            {"апреля", 4 },
            {"мая",5 },
            {"июня",6 },
            {"июля", 7 },
            {"августа", 8  },
            {"сентября", 9 },
            {"октября", 10 },
            {"ноября", 11 },
            {"декабря", 12 },
        };

        public static DateTime GetDateFromString(string str) 
        {
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
