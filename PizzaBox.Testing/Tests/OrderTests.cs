using Xunit;
using PizzaBox.Domain.Models.Orders;

namespace PizzaBox.Testing.Tests
{
    public class OrderTests
    {
        
        
        [Fact]
        public void Test_Order()
        {
            //arrange
            var sut = new Order();

            //act

            //assert
            Assert.False(sut.pizzas.Equals(null));
        }
    }
}