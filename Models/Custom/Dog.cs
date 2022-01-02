using Microsoft.EntityFrameworkCore;
using SampleREST_API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Models.Custom
{
    [Keyless]
    public class Dog : BusinessObject
    {
        //public override long Id { get; init; }

        public string Name { get; set; }

        public string Color { get; set; }

        public double Tail_Length { get; set; }

        public double Weight { get; set; }

    }
}
