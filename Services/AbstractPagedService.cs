using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public abstract class AbstractPagedService<TEntity, TList>
    where TEntity : class
    where TList : GenericList<TEntity>, new()
    {
        private readonly TestDbContext _ctx;

        public AbstractPagedService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<TList> ListPagedService(int page, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var startIndex = (page - 1) * pageSize;

            IQueryable<TEntity> query = _ctx.Set<TEntity>();

            if (orderBy != null)
                query = orderBy(query);

            var entities = query.Skip(startIndex).Take(pageSize).ToList();

            var hasNext = _ctx.Set<TEntity>().Count() > startIndex + pageSize;

            return new TList { HasNext = hasNext, TotalCount = _ctx.Set<TEntity>().Count(), ListItems = entities };
        }
    }


}
