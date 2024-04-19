using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Filters
{
    public class GenericRepo<T> where T : class
    {
        private readonly DbSet<T> dbSet;

        public GenericRepo(ShopDbContext dbContext)
        {
            dbSet = dbContext.Set<T>();
        }

        public IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? pageSize = null, int? pageNumber = null
            )
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            if (filter is not null) query = query.Where(filter);

            if (orderBy is not null) query = orderBy(query);

            foreach (var property in includeProperties.Split(
                new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }

            return (pageNumber is not null && pageSize is not null) ?
                query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value): query;
        }
    }
}
