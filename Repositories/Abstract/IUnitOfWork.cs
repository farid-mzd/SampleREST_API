using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Repositories.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IDogRepository DogRepository { get; }

        Task<bool> Complete();

    }
}
