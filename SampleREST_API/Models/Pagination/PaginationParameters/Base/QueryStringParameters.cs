using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Models.Pagination.PaginationParameters.Base
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 10;

        private int _pageNumber = 1;

        public int PageNumber { get { return _pageNumber; } set { _pageNumber = (value <= 0) ? _pageNumber : value; } } 

        private int _pageSize = 5;

        public int PageSize { get { return _pageSize; } set { _pageSize = (value > maxPageSize) || value <=0 ? maxPageSize : value; } }

        public string Order { get; set; }

        public string Attribute { get; set; }
    }
}
