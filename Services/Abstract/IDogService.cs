using SampleREST_API.Models.Custom;
using SampleREST_API.Models.Pagination;
using SampleREST_API.Models.Pagination.PaginationParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Services.Abstract
{
    public interface IDogService
    {
        Task<PagedList<Dog>> GetDogs(DogParameters dogParameters);

        Task<Dog> AddDog(Dog dog);
    }
}
