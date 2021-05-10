using Xunit;
using PizzaBox.Domain.Models.Orders;

namespace PizzaBox.Testing.Tests.UnitTests
{
  public class OrderTests
  {


    [Fact]
    public void Test_NullOrder()
    {
      //  a) head: arrange
      var sut = new Order();

      //  b) body: act

      //  c) foot: assert
      Assert.False(sut.pizzas.Equals(null));
    }


  }// /cla 'TestOrders'
}// /ns '..UnitTests
 // EoF