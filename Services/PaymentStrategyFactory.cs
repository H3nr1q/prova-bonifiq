using ProvaPub.Interfaces;

namespace ProvaPub.Services
{
    public class PaymentStrategyFactory : IPaymentStrategyFactory
    {
        private readonly PixPaymentStrategy pixPaymentStrategy;
        private readonly CreditCardPaymentStrategy creditCardPaymentStrategy;
        private readonly PaypalPaymentStrategy paypalPaymentStrategy;

        public PaymentStrategyFactory(PixPaymentStrategy pixPaymentStrategy, CreditCardPaymentStrategy creditCardPaymentStrategy, PaypalPaymentStrategy paypalPaymentStrategy)
        {
            this.pixPaymentStrategy = pixPaymentStrategy;
            this.creditCardPaymentStrategy = creditCardPaymentStrategy;
            this.paypalPaymentStrategy = paypalPaymentStrategy;
        }

        public IPaymentStrategy CreatePaymentStrategy(string paymentMethod)
        {
            switch (paymentMethod)
            {
                case "pix":
                    return this.pixPaymentStrategy;
                case "creditcard":
                    return this.creditCardPaymentStrategy;
                case "paypal":
                    return this.paypalPaymentStrategy;
                default:
                    throw new ArgumentException($"Invalid payment method: {paymentMethod}");
            }
        }
    }
}



