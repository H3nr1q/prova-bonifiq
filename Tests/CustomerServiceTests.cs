using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using Xunit;

namespace ProvaPub.Tests
{
    public class CustomerServiceTests : IClassFixture<TestDbContextFixture>
    {
        private readonly TestDbContext dbContext;
        private readonly CustomerService customerService;

        List<Customer> customersList = new List<Customer>() {
            new Customer { Id = 2, Name = "Henrique" },
            new Customer { Id = 3, Name = "Carlos" }
        };

        Order order = new Order { CustomerId = 2, OrderDate = DateTime.UtcNow.AddMonths(-1).AddDays(1) };

        public CustomerServiceTests(TestDbContextFixture fixture)
        {
            this.dbContext = fixture.TestDbContext;
            this.customerService = new CustomerService(this.dbContext);
            
            this.dbContext.Orders.Add(order);
            this.dbContext.Customers.AddRange(customersList);
            this.dbContext.SaveChangesAsync();
        }

        // Teste para validações de exceções
        [Fact]
        public async Task ShouldThrowException_WhenCustomerDoesNotExists()
        {
            var customerId = 1;
            var purchaseValue = 101;

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await this.customerService.CanPurchase(customerId, purchaseValue)
            );

            Assert.Equal("Customer Id 1 does not exists", exception.Message);
            finish();
        }

        [Fact]
        public async Task ShouldThrowException_WhenCustomerIdIsZero()
        {
            var customerId = 0;
            var purchaseValue = 101;

            var exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
                await this.customerService.CanPurchase(customerId, purchaseValue)
            );

            Assert.Equal("customerId", exception.ParamName);
            finish();
        }

        [Fact]
        public async Task ShouldThrowException_WhenPurchaseValueIsZero()
        {
            var customerId = 1;
            var purchaseValue = 0;

            var exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
                await this.customerService.CanPurchase(customerId, purchaseValue)
            );

            Assert.Equal("purchaseValue", exception.ParamName);
            finish();
        }


        // Teste para verificar se o método CanPurchase retorna false quando um cliente nunca comprou antes e o valor da compra é maior que 100.
        [Fact]
        public async Task ShouldReturnFalse_WhenCustomerHasNotBoughtBeforeAndPurchaseValueIsGreaterThan100()
        {
            var customerId = 2;
            var purchaseValue = 101;

            var result = await this.customerService.CanPurchase(customerId, purchaseValue);

            Assert.False(result);
            finish();

        }

        //Teste para verificar se o método CanPurchase retorna false quando um cliente já comprou no mês atual.
        [Fact]
        public async Task ShouldReturnFalse_WhenCustomerHasBoughtInLastMonth()
        {
            var customerId = 2;
            var purchaseValue = 101;           

            var result = await this.customerService.CanPurchase(customerId, purchaseValue);

            Assert.False(result);
            finish();
        }
        //Teste para verificar se o método CanPurchase retorna true quando um cliente ainda não comprou nada no mês atual e o valor da compra é menor ou igual a 100.
        [Fact]
        public async Task ShouldReturnTrue_WhenCustomerHasNotBoughtThisMonthAndPurchaseValueIsLessThanOrEqualTo100()
        {
            var customerId = 3;
            var purchaseValue = 100;

            var result = await this.customerService.CanPurchase(customerId, purchaseValue);

            Assert.True(result);
            finish();
        }


        void finish()
        {
            this.dbContext.Orders.Remove(order);
            this.dbContext.Customers.RemoveRange(customersList);
            this.dbContext.SaveChangesAsync();
        }
    }
}
