using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public async Task<Order> ProcessPayment(decimal paymentValue, int customerId)
        {
            paymentValue += paymentValue * 0.10m;
            return new Order { Value = paymentValue, CustomerId = customerId, OrderDate = DateTime.Parse(DateTime.Now.ToLongTimeString()) };
        }
    }
}
