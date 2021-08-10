using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace DemoDB
{
    public interface IRepositoryReadOnly<T> : IReadRepository<T> where T : class
    {

    }
}

