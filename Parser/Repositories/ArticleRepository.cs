using Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Contracts;
using Parser.Data;

namespace Parser.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {

        private readonly AppDbContext _appDbContext;

        public ArticleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task CreateAsync(Article obj) 
        {
            try
            {
                _appDbContext.Add<Article>(obj);
                await _appDbContext.SaveChangesAsync();
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
