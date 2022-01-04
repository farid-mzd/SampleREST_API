using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Models.Pagination
{
    public class PagedList<T> : List<T> where T : class
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public PagedList(Task<List<T>> items, Task<int> count, int pageNumber, int pageSize)
        {
            TotalCount = count.Result;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
            AddRange((IEnumerable<T>)items);
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
           
            var count = source.Count();

            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        public async static Task<PagedList<T>> ToPagedListAsync(DbSet<T> dbSet, int pageNumber, int pageSize)
        {

            var items = await dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            var count = await dbSet.CountAsync();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
