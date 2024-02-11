using Microsoft.AspNetCore.Mvc;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{

    /// <summary>
    /// Esse teste simula um pagamento de uma compra.
    /// O método PayOrder aceita diversas formas de pagamento. Dentro desse método é feita uma estrutura de diversos "if" para cada um deles.
    /// Sabemos, no entanto, que esse formato não é adequado, em especial para futuras inclusões de formas de pagamento.
    /// Como você reestruturaria o método PayOrder para que ele ficasse mais aderente com as boas práticas de arquitetura de sistemas?
    /// 
    /// Resposta:
    /// Apliquei o conceito de strategy, onde eu crio uma interface que implementa a criação de pagamento (IPaymentStrategyFactory) e 
    /// ela implementa outra interface (IPaymentStrategy) e usando o open close criei um método para cada pagamento
    /// em vez de if usei um switch como estrutura
    /// 
    /// </summary>
    [ApiController]
	[Route("[controller]")]
	public class Parte3Controller :  ControllerBase
	{
		private readonly IPaymentStrategyFactory paymentStrategyFactory;

        public Parte3Controller(IPaymentStrategyFactory paymentStrategyFactory)
        {
            this.paymentStrategyFactory = paymentStrategyFactory;
        }

        [HttpPost("orders")]
        public async Task<Order> PlaceOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            var paymentStrategy = this.paymentStrategyFactory.CreatePaymentStrategy(paymentMethod);
            return await new OrderService(paymentStrategy).PlaceOrder(paymentValue, customerId);
        }
    }
}
