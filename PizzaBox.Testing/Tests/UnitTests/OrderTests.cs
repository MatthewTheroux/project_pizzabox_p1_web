using Xunit;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Testing.Tests.UnitTests
{
  public class OrderTests
  {


    [Fact]
    public void Test_NotNullOrder()
    {
      //  a) head: arrange
      var sut = new PizzaOrder();

      //  b) body: act

      //  c) foot: assert
      Assert.False(sut.Pizzas.Equals(null));
    }

    [Fact]
    public void Test_1PizzaOrder()
    {
      //  a) head: arrange
      var sut = new PizzaOrder();
      sut.AddPizza(new PepperoniPizza());

      //  b) body: act
      var actual = new PepperoniPizza();

      //  c)
    }


  }// /cla 'TestOrders'
}// /ns '..UnitTests
 // EoF