using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Models
{
    public class Article
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public Article() { }

        public Article(int id, DateTime date, string title, string photoUrl)
        {
            Id = id;
            Date = date;
            Title = title;
            PhotoUrl = photoUrl;
        }
    }
}
