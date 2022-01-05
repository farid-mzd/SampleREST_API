using SampleREST_API.Models.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleREST_API.Models.Sorting
{
    public class SortHelper<T> : ISortHelper<T>
    {
       
        public IQueryable<T> ApplySort(IQueryable<T> entities, string attrName, string orderBy)
        {
            string queryString = string.Empty;

            if (!entities.Any() || string.IsNullOrWhiteSpace(attrName) || string.IsNullOrWhiteSpace(orderBy))
                return entities;

            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var objectProperty = propertyInfos.FirstOrDefault(p => p.Name.ToUpper().Equals(attrName.ToUpper()));

            if (objectProperty != null)
            {
                
                    if (orderBy.ToUpper().Equals("DESC"))
                    {
                        queryString = $"{objectProperty.Name.ToString()} descending";
                    }
                    else if (orderBy.ToUpper().Equals("ASC"))
                    {
                        queryString = $"{objectProperty.Name.ToString()} ascending";
                    }
                    else
                    {
                        throw new InvalidQueryStringException("order query must be either 'desc' or 'asc'");
                    }
                
                    return entities.OrderBy(queryString);
            }
            else
            {
                //should return exception
                throw new InvalidQueryStringException("Attribute given name does not exists. Please provide valid attribute name!");
            }

           
        }
    }
}
