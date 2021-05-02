using Xunit;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Crusts;

namespace PizzaBox.Testing.Tests
{
  public class StoreTests
  {
    [Fact]
    public void Test_ChicagoStore()
    {
      //arrange
      var sut = new FamilyPizzaStore();

      //act
      var actual = sut.Name;

      //assert
      Assert.True(actual == "ChicagoStore");
    }


    [Fact]
    public void Test_NewYorkStore()
    {
      //arrange
      var sut = new ExpressPizzaStore();

      //act

      //assert
      Assert.True(sut.Name.Equals("NewYorkStore"));
    }

    [Fact]
    public void Test_newOrder()
    {
      var store = new ExpressPizzaStore();
      var sut = store.newOrder(new Domain.Models.Orders.Customer(), new Domain.Models.Orders.Order());
      Assert.True(sut);
    }

    [Fact]
    public void Test_newOrderTime()
    {
      var store = new ExpressPizzaStore();
      store.newOrder(new Domain.Models.Orders.Customer(), new Domain.Models.Orders.Order());
      var sut = store.newOrder(new Domain.Models.Orders.Customer(), new Domain.Models.Orders.Order());
      Assert.False(sut);
    }

    [Fact]
    public void Test_hasPizza()
    {
      var pizza = new CheesePizza();
      pizza.addCrust(new MediumCrust());
      var store = new ExpressPizzaStore();
      var order = new Domain.Models.Orders.Order();
      store.newOrder(new Domain.Models.Orders.Customer(), order);
      store.addPizza(order, pizza);
      Assert.True(order.pizzas.Contains(pizza));
    }

    [Fact]
    public void Test_hasPizzaPrice()
    {
      var pizza = new CheesePizza();
      pizza.addCrust(new MediumCrust());
      var store = new ExpressPizzaStore();
      var order = new Domain.Models.Orders.Order();
      store.newOrder(new Domain.Models.Orders.Customer(), order);
      store.addPizza(order, pizza);
      Assert.True(order.price == pizza.Price);
    }

    [Fact]
    public void Test_notHavePizzaPrice()
    {
      var pizza = new CheesePizza();
      pizza.addCrust(new MediumCrust());
      var store = new ExpressPizzaStore();
      var order = new Domain.Models.Orders.Order();
      store.newOrder(new Domain.Models.Orders.Customer(), order);
      store.addPizza(order, pizza);
      store.removePizza(order, pizza);
      Assert.False(order.pizzas.Contains(pizza));
    }
  }
}