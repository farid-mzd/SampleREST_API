using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Models.Sorting
{
    public interface ISortHelper<T>
    {
        //IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString);
        IQueryable<T> ApplySort(IQueryable<T> entities, string attrName, string orderBy);
    }
}
