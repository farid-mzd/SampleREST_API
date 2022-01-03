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
    public class Dog 
    {
        [Required(ErrorMessage ="Name must be provided")]
        [Column(TypeName = "nvarchar(500)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Color must be provided")]
        [Column(TypeName ="nvarchar(500)")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Tail length must be provided")]
        [Range(0, Double.MaxValue,ErrorMessage ="Tail length must be positive number")]
        public double? Tail_Length { get; set; }

        [Required(ErrorMessage = "Weight must be provided")]
        //[Range(0,Double.MaxValue, ErrorMessage = " must be positive number")]
        [MinLength(0, ErrorMessage = "Weight must be positive number")]
        public double? Weight { get; set; }

    }
}
