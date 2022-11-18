using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Contracts;
using Parser.Models;
using Parser.Data;
using Microsoft.Extensions.Hosting;
using HtmlAgilityPack;
using System.Net;

namespace Parser
{
    public class Parser : IHostedService
    {
        private readonly IRepository<Article> Repository;
        public Parser(IRepository<Article> repository) 
        {
            Repository = repository;
        }
        public async Task StartAsync(CancellationToken stoppingToken) 
        {
            var url = "https://sarnovosti.ru/news/";
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(url);
            var pages = htmlDoc.DocumentNode.SelectNodes("//div[@class='page-layout']/div[@class='page-section page-section--reverse']/div[@class='main-column']/div[@class='pgnt']/div[@class='pgnt-item']/a").Select(item => item.Attributes["href"].Value).ToList();
            pages = pages.Select(item => item = "https://sarnovosti.ru" + item).ToList();
            pages.Insert(0, url);
            for(int i = 0; i< pages.Count; i++)
            {
                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='main-column']/div[@class='news-block item--animated isInView']");
                foreach (var node in nodes)
                {
                    DateTime date = Helper.GetDateFromString(node.ChildNodes["div"].ChildNodes["time"].InnerText);
                    string title = node.ChildNodes["div"].ChildNodes["a"].InnerText;
                    string photoUrl = await SavePhotoAsync("https://sarnovosti.ru/" + node.ChildNodes["a"]?.ChildNodes["img"].Attributes["src"].Value);
                    await Repository.CreateAsync(new Article { Title = title, Date = date, PhotoUrl = photoUrl });
                }
                if (i != pages.Count-1)
                {
                    htmlDoc = web.Load(pages[i+1]);
                }
            }
            stoppingToken.ThrowIfCancellationRequested();
        }


        public async Task SaveAsync(Article model) 
        {
            await Repository.CreateAsync(model);
        }

        private async Task<string> SavePhotoAsync(string url)
        {
            string path ="";
            if (url != "https://sarnovosti.ru/")
            {
                string fileName = url.Split('/').Last();
                path = Directory.GetCurrentDirectory() + fileName;
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, path);
                }
            }
            return path;
        }

        public async Task StopAsync(CancellationToken stoppingToken)
        {

        }
    }
}
