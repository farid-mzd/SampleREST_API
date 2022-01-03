using Microsoft.EntityFrameworkCore;
using SampleREST_API.Models;
using SampleREST_API.Models.Custom;
using SampleREST_API.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Repositories.Concrete
{
    public class DogRepository : RepositoryEFCore<Dog>, IDogRepository
    {
        public RESTAPIDbContext RESTAPIDBcontext { get { return dbContext as RESTAPIDbContext; } }

        public DogRepository(RESTAPIDbContext context) : base(context)
        {
            
        }

        public async Task<Dog> GetWithName(string name)
        {
           return await RESTAPIDBcontext.Dogs.Where(d => d.Name == name ).FirstOrDefaultAsync();
        }
    }
}
