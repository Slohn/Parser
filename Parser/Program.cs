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
    static void Main(string[] args)
    {

        var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
        {
            var cns = context.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-FAMH71F\\LOCALHOST;Initial Catalog=Parser;Integrated security=True;TrustServerCertificate=true"));
            services.AddScoped<IRepository<Article>, ArticleRepository>();
            services.AddHostedService<Parser>();
        })
        .Build();
        
        host.Run();
    }
}
