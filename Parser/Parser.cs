using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Contracts;
using Parser.Models;
using Parser.Data;
using Microsoft.Extensions.Hosting;

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
            await Repository.CreateAsync(new Article());
        }

        public async Task StopAsync(CancellationToken stoppingToken)
        {

        }
    }
}
