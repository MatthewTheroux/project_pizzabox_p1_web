using Xunit;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

/// Test model units within the Domain
namespace PizzaBox.Testing.Tests.UnitTests
{
  public class StoreTests
  {
    /// Test to see if a Family Pizza Store calls itself that.
    [Fact]
    public void Test_FamilyPizzaStoreName()
    {
      //  a) head: arrange
      var sut = new FamilyPizzaStore();

      //  b) body: act
      string actual = sut.EntityName;

      //  c) foot: assert
      Assert.True(actual.Equals("FamilyPizzaStore"));
    }

    /// Test to see if an Express Pizza Store calls itself that.
    [Fact]
    public void Test_ExpressPizzaStoreName()
    {
      //  a)  head: arrange
      var sut = new ExpressPizzaStore();

      //  b)  body: act
      string actual = sut.EntityName;

      //  c) foot: assert
      Assert.True(actual.Equals("ExpressPizzaStore"));
    }

    ///
    /*[Fact]
    public void Test_ExpressPizzaStore_HasPizza()
    {
      ExpressPizzaStore store = new ExpressPizzaStore();
      CheesePizza pizza = new CheesePizza();
      var order = new Domain.Models.Orders.Order();
      store.newOrder(new Domain.Models.Orders.Customer(), order);
      store.addPizza(order, pizza);
      Assert.True(order.pizzas.Contains(pizza));
    }*/

    /// Test to see if cheese pizza has a price.
    [Fact]
    public void Test_DoesCheesePizzaHavePrice()
    {
      CheesePizza pizza = new CheesePizza();

      Assert.True(pizza.Order.TotalPrice == pizza.Price);
    }

    /*
        ///
        [Fact]
        public void Test_DoesPizzaNotHavePrice()
        {
          var pizza = new CheesePizza();
          var store = new ExpressPizzaStore();
          var order = new Domain.Models.Orders.Order();
          store.newOrder(new Domain.Models.Orders.Customer(), order);
          store.addPizza(order, pizza);
          store.removePizza(order, pizza);
          Assert.False(order.pizzas.Contains(pizza));
        }
        */
  }// /cla 'StoreTests'
}// /ns '..UnitTests'
 // EoF