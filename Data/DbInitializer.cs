using SampleREST_API.Models;
using SampleREST_API.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Data
{
    public static class DbInitializer
    {
        public  static void Initialize(RESTAPIDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (dbContext.Dogs.Any())
            {
                return; // DB has been seeded
            }

            var dogs = new Dog[]
            {
                new Dog { Name= "Neo", Color="red & amber", Tail_Length=22, Weight=32},
                new Dog { Name= "Jessy", Color="black & white", Tail_Length=7, Weight=14}
            };

             dbContext.SaveChanges();
        }
    }
}
