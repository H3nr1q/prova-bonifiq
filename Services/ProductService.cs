using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class ProductService : AbstractPagedService<Product, ProductList>
    {
        public ProductService(TestDbContext ctx) : base(ctx)
        {
        }
    }
}
