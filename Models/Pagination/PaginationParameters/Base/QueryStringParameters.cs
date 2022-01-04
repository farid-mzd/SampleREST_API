using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Models.Pagination.PaginationParameters.Base
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 10;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 5;

        public int PageSize { get { return _pageSize; } set { _pageSize = (value > maxPageSize) ? maxPageSize : value; } }

        public string Order { get; set; }

        public string Attribute { get; set; }
    }
}
