using Xunit;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Testing.Tests.UnitTests
{
  public class PizzaTests
  {
    /// Test to see if a cheese pizza calls itself that.
    [Fact]
    public void Test_CheesePizzaName()
    {
      //  a) head: arrange
      var sut = new CheesePizza();

      //  b) body: act
      string actual = sut.Name;

      //  c) foot: assert
      Assert.True(actual.Equals("cheese"));
    }

    /// Test to see if a custom pizza calls itself that.
    [Fact]
    public void Test_CustomPizzaName()
    {
      //  a) head: arrange
      var sut = new CustomPizza();

      //  b) body: act
      string actual = sut.Name;

      //  c) foot: assert
      Assert.True(actual.Equals("custom"));
    }

    /// Test to see if a meat pizza calls itself that.
    [Fact]
    public void Test_MeatPizzaName()
    {
      //  a) head: arrange
      var sut = new MeatPizza();

      //  b) body: act
      string actual = sut.Name;

      //  c) foot: assert
      Assert.True(sut.Name.Equals("meat"));
    }


    /// Test to see if a vegetable pizza calls itself that.
    [Fact]
    public void Test_VegetablePizzaName()
    {
      //  a) head: arrange
      var sut = new VegetablePizza();

      //  b) body: act
      string actual = sut.Name;

      //  c) foot: assert
      Assert.True(actual.Equals("vegtable"));
    }


    /// Test to see if a pepperoni pizza calls itself that.
    [Fact]
    public void Test_PepperoniPizzaName()
    {
      //  a) head: arrange
      var sut = new PepperoniPizza();

      //  b) body: act
      string actual = sut.Name;

      //  c) foot: assert
      Assert.True(actual.Equals("pepperoni"));
    }




  }
}