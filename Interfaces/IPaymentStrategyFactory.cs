namespace ProvaPub.Interfaces
{
    public interface IPaymentStrategyFactory
    {
        IPaymentStrategy CreatePaymentStrategy(string paymentMethod);
    }
}
