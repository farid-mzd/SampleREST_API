using Microsoft.EntityFrameworkCore;
using SampleREST_API.Models.Base;
using SampleREST_API.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Repositories.Concrete
{
    public class RepositoryEFCore<T> : IRepository<T> where T : class
    {
        //defining accesibility as protected in order to let derived classes to use it 
        protected readonly DbContext dbContext;

        private DbSet<T> dbset;

        public RepositoryEFCore(DbContext dbContext)
        {
            this.dbContext = dbContext;

            this.dbset = dbContext.Set<T>();
        }

        public void Add(T obj)
        {
              dbset.Add(obj);
            
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await dbset.ToListAsync();
        }
    }
}
