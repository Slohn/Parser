using Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Contracts;

namespace Parser.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        public async Task<Article> CreateAsync(Article obj) 
        {
            try
            {
                return new Article();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Article> UpdateAsync(Article obj)
        {
            try
            {
                return new Article();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task DeleteAsync(Article obj)
        {
            try
            {

            }
            catch (Exception) 
            {
                throw;
            }
        }

    }
}
