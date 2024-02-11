using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
	
	[ApiController]
	[Route("[controller]")]
	public class Parte2Controller :  ControllerBase
	{
		/// <summary>
		/// Precisamos fazer algumas alterações:
		/// 1 - Não importa qual page é informada, sempre são retornados os mesmos resultados. Faça a correção.
		/// 2 - Altere os códigos abaixo para evitar o uso de "new", como em "new ProductService()". Utilize a Injeção de Dependência para resolver esse problema
		/// 3 - Dê uma olhada nos arquivos /Models/CustomerList e /Models/ProductList. Veja que há uma estrutura que se repete. 
		/// Como você faria pra criar uma estrutura melhor, com menos repetição de código? E quanto ao CustomerService/ProductService. Você acha que seria possível evitar a repetição de código?
		/// 
		/// Resposta:
		/// 
		/// Para as listas eu vi que somente o tipo das listas elas eram diferentes, então eu criei uma classe generica, ondem as classes CustomerList e ProductList herdam dela passando o tipo T.
		/// E pasra os services criei uma classe abstrata com a mesma ideia (AbstractPagedService), então os CustomerService e ProductService herdam dela passando a entidade e qual lista.
		/// 
		/// </summary>
		/// 
		private readonly ProductService productService;
        private readonly CustomerService customerService;

		public Parte2Controller(ProductService productService, CustomerService customerService)
		{
			this.productService = productService;
			this.customerService = customerService;
		}

		[HttpGet("products")]
		public async Task<ProductList> ListProducts(int page)
		{
			return await this.productService.ListPagedService(page, 10);
		}

		[HttpGet("customers")]
		public async Task<CustomerList> ListCustomers(int page)
		{
			return await this.customerService.ListPagedService(page, 10);
		}
	}
}
