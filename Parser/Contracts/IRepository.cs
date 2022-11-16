using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Contracts
{
    public interface IRepository<T>
    {
        public Task<T> CreateAsync(T obj);
        public Task<T> UpdateAsync(T obj);
        public Task DeleteAsync (T obj);
    }
}
