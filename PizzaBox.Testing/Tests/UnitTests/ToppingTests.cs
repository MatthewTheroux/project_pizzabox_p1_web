// [I]. HEAD
//  A] Libraries
using Xunit;

using PizzaBox.Domain.Models.Components.Toppings;

namespace PizzaBox.Testing.Tests.UnitTests
{
  public class ToppingTests
  {
    [Fact]
    public void Test_Mozzerella()
    {
      //  a) head: arrange
      var sut = new PizzaToppingCheese("moZzeRelLa");

      //  b) body: act
      var actual = sut.ToString();

      //  c) foot: assert
      Assert.True(actual == "MOZZERELLA");
    }


    [Fact]
    public void Test_Mushroom()
    {
      //  a) head: arrange
      var sut = new PizzaToppingVegetable(1);

      //  b) body: act
      string actual = "MUSHROOM";

      //  c) foot: assert
      Assert.True(actual.Equals(sut.ToString()));
    }


    [Fact]
    public void Test_Sausage()
    {
      //  a) arrange
      var sut = new PizzaToppingMeat("Sausage");

      //act

      //assert
      Assert.True(sut.EntityName.Equals("Sausage"));
    }

    [Fact]
    public void Test_Broccoli()
    {
      //  a) head: arrange
      var sut = new PizzaToppingVegetable(PizzaToppingVegetable.Choice.BROCCOLI);

      //  b) body: act
      string actual = "BROCCOLI";

      //  c) foot: assert
      Assert.True(sut.ToString().Equals(actual));
    }

    [Fact]
    public void Test_Pineapple()
    {
      //  a) head: arrange
      var sut = new PizzaToppingFruit("Pineapple");

      //  b) body: act

      //  c) foot: assert
      Assert.True(sut.EntityName.Equals("Pineapple"));
    }
  }// /'ToppingTests'
}// /ns '..UnitTests'
 // EoF