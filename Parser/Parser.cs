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
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='main-column']/div[@class='news-block item--animated isInView']");
            for (int i = 0; i < 5; i++)
            {
                nodes[i].Attributes.
            }
            await Repository.CreateAsync(new Article() {Date = DateTime.Now, PhotoUrl="",Title="test" });
        }


        public async Task SaveAsync(Article model) 
        {
            await Repository.CreateAsync(model);
        }

        public async Task<string> SavePhotoAsync(string url)
        {
            string fileName = url.Split('/').Last();
            string path = Directory.GetCurrentDirectory() /*+ "\\uploads\\" */+ fileName;
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, path);
            }
            return path;
        }

        public async Task StopAsync(CancellationToken stoppingToken)
        {

        }
    }
}
