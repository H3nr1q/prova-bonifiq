using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService
	{
		TestDbContext _ctx;

		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

		public ProductList ListProducts(int page)
		{
			const int pageSize = 10;

			var startIndex = (page -1) * pageSize;

			var products = _ctx.Products.Skip(startIndex).Take(pageSize).ToList();

			var hastNext = _ctx.Products.Count() > startIndex + pageSize;

			return new ProductList() {  HasNext=hastNext, TotalCount = _ctx.Products.Count(), Products = products };
		}

	}
}
