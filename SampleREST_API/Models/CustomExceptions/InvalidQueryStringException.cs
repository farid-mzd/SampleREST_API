using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Models.CustomExceptions
{
    public class InvalidQueryStringException : Exception
    {
       
            public InvalidQueryStringException()
            {
            }

            public InvalidQueryStringException(string message)
                : base(message)
            {
            }

            public InvalidQueryStringException(string message, Exception inner)
                : base(message, inner)
            {
            }
        
    }
}
