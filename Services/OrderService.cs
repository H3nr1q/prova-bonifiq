using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
	public class OrderService
	{
        private readonly IPaymentStrategy paymentStrategy;

        public OrderService(IPaymentStrategy paymentStrategy)
        {
            this.paymentStrategy = paymentStrategy;
        }

        public async Task<Order> PlaceOrder(decimal paymentValue, int customerId)
        {
            return await this.paymentStrategy.ProcessPayment(paymentValue, customerId);
        }
    }
}
