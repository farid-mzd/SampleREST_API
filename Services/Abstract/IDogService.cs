using SampleREST_API.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Services.Abstract
{
    public interface IDogService
    {
        Task<IEnumerable<Dog>> GetDogs();

        Task<Dog> AddDog(Dog dog);
    }
}
