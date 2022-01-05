using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Models.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly double givenValue;

        public MinValueAttribute(double value) : base("Value is Invalid")
        {
            givenValue = value;

        }


        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var inputValue = Convert.ToInt64(value);

                if (inputValue > givenValue)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
