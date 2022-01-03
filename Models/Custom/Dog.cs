using Microsoft.EntityFrameworkCore;
using SampleREST_API.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Models.Custom
{
    [Keyless]
    public class Dog : BusinessObject
    {
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(500)")]
        public string Color { get; set; }

        [Required]
        public double? Tail_Length { get; set; }

        [Required]
        public double? Weight { get; set; }

    }
}
