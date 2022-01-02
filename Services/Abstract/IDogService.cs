using SampleREST_API.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Services.Abstract
{
    public interface IDogService
    {
        IEnumerable<Dog> GetDogs();

        Dog AddDog(Dog dog);
    }
}
