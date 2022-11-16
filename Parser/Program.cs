using HtmlAgilityPack;
using Microsoft.Extensions.Hosting;
using System.Net;
using Parser.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Parser.Repositories;
using Parser.Contracts;
using Parser.Models;

namespace Parser;
public class Program
{
    public static string PhotoPath = "";

    static void Main(string[] args)
    {

        var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
        {
            var cns = context.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cns));
            services.AddScoped<IRepository<Article>, ArticleRepository>();
            services.AddHostedService<Parser>();
        })
        .Build();
        
        host.Run();

        //var url = "https://sarnovosti.ru/news/";
        //HtmlWeb web = new HtmlWeb();

        //var htmlDoc = web.Load(url);
        //var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='main-column']/div[@class='news-block item--animated isInView']");
        //for (int i = 0; i < 5; i++) 
        //{
        //    nodes[i].Attributes.
        //}
    }
}
