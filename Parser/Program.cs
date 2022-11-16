using HtmlAgilityPack;
using System.Net;

namespace Parser;
public class Program
{
    public static string PhotoPath = "";

    static void Main(string[] args)
    {
        var url = "https://sarnovosti.ru/news/";
        HtmlWeb web = new HtmlWeb();

        var htmlDoc = web.Load(url);
        var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='main-column']/div[@class='news-block item--animated isInView']");
        for (int i = 0; i < 5; i++) 
        {
            
        }
    }
}
