using SampleREST_API.Models.Custom;
using SampleREST_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Services.Concrete
{
    public class DogService : IDogService
    {
        public Dog AddDog(Dog dog)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dog> GetDogs()
        {
            throw new NotImplementedException();
        }
    }
}
