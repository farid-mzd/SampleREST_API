using SampleREST_API.Models;
using SampleREST_API.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private RESTAPIDbContext restApiContext;

        public UnitOfWork(RESTAPIDbContext restApiContext)
        {
            this.restApiContext = restApiContext;

            DogRepository = new DogRepository(restApiContext);
        }

        public IDogRepository DogRepository { get; private set; }

        public async Task<bool> Complete()
        {
            return await restApiContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
         restApiContext.Dispose();
        }
    }
}
