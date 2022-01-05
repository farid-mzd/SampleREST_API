using SampleREST_API.Models.Custom;
using SampleREST_API.Models.Pagination;
using SampleREST_API.Models.Pagination.PaginationParameters;
using SampleREST_API.Models.Sorting;
using SampleREST_API.Repositories.Abstract;
using SampleREST_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Services.Concrete
{
    public class DogService : IDogService
    {
        private IUnitOfWork UW { get; set; }

        public ISortHelper<Dog> sortHelper { get; set; }

        public DogService(IUnitOfWork UW, ISortHelper<Dog> sortHelper)
        {
            this.UW = UW;
            this.sortHelper = sortHelper;
        }

        public async Task<Dog> AddDog(Dog dog)
        {
            if (await UW.DogRepository.GetWithName(dog.Name) == null)
            {
                UW.DogRepository.Add(dog);

                await UW.Complete();

                return await UW.DogRepository.GetWithName(dog.Name);
            }
            else
            {
                throw new Exception("Dog with the given name already exists!");
            }

        }

        public async Task<PagedList<Dog>> GetDogs(DogParameters dogParameters)
        {
            var result = await UW.DogRepository.Get();

            result = sortHelper.ApplySort(result.AsQueryable(), dogParameters.Attribute, dogParameters.Order);

            return PagedList<Dog>.ToPagedList(result, dogParameters.PageNumber, dogParameters.PageSize);
        }
    }
}
