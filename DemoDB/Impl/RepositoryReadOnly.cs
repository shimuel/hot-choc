
using Microsoft.EntityFrameworkCore;
using DemoDB;

namespace DemoDB.Impl
{
    public class RepositoryReadOnly<T> : BaseRepository<T>, IRepositoryReadOnly<T> where T : class
    {
        public RepositoryReadOnly(DbContext context) : base(context)
        {
        }
    }
}