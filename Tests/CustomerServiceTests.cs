using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using Xunit;

public class CustomerServiceTests
{
    [Fact]
    public async Task CanPurchase_NonRegisteredCustomer_ReturnsFalse()
    {
        // Arrange
        var dbContextMock = new Mock<TestDbContext>();
        var customerService = new CustomerService(dbContextMock.Object);

        // Act
        var result = await customerService.CanPurchase(1, 100);

        // Assert
        Assert.False(result);
    }

    //[Fact]
    //public async Task CanPurchase_CustomerWithRecentPurchase_ReturnsFalse()
    //{
    //    // Arrange
    //    var dbContextMock = new Mock<TestDbContext>();
    //    dbContextMock.Setup(c => c.Orders.CountAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Order, bool>>>()))
    //                 .ReturnsAsync(1); // Simula um pedido no último mês

    //    var customerService = new CustomerService(dbContextMock.Object);

    //    // Act
    //    var result = await customerService.CanPurchase(1, 100);

    //    // Assert
    //    Assert.False(result);
    //}

    //[Fact]
    //public async Task CanPurchase_FirstTimeCustomerWithExcessivePurchaseValue_ReturnsFalse()
    //{
    //    // Arrange
    //    var dbContextMock = new Mock<TestDbContext>();
    //    dbContextMock.Setup(c => c.Customers.CountAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Customer, bool>>>()))
    //                 .ReturnsAsync(0); // Simula um cliente que nunca comprou antes

    //    var customerService = new CustomerService(dbContextMock.Object);

    //    // Act
    //    var result = await customerService.CanPurchase(1, 150);

    //    // Assert
    //    Assert.False(result);
    //}

    //[Fact]
    //public async Task CanPurchase_FirstTimeCustomerWithValidPurchaseValue_ReturnsTrue()
    //{
    //    // Arrange
    //    var dbContextMock = new Mock<TestDbContext>();
    //    dbContextMock.Setup(c => c.Customers.CountAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Customer, bool>>>()))
    //                 .ReturnsAsync(0); // Simula um cliente que nunca comprou antes

    //    var customerService = new CustomerService(dbContextMock.Object);

    //    // Act
    //    var result = await customerService.CanPurchase(1, 50);

    //    // Assert
    //    Assert.True(result);
    //}

    // Adicione outros testes conforme necessário
}
