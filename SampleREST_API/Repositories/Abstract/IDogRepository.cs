using SampleREST_API.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Repositories.Abstract
{
    public interface IDogRepository : IRepository<Dog>
    {
        Task<Dog> GetWithName(string name);
    }
}
