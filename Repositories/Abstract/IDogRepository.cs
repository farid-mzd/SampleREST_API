using SampleREST_API.Models.Custom;
using SampleREST_API.Models.Pagination;
using SampleREST_API.Models.Pagination.PaginationParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Repositories.Abstract
{
    public interface IDogRepository : IRepository<Dog>
    {
        Task<Dog> GetWithName(string name);

        Task<PagedList<Dog>> GetDogsWithPaginationDirectlyAsync(DogParameters dogParameters);
    }
}
