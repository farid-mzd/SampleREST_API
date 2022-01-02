using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Models.Base
{
    public class BusinessObject
    {
        [NotMapped]
        public virtual long Id { get; init; }

    }
}
