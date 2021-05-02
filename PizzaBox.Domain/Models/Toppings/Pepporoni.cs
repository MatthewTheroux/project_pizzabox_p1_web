using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Toppings
{
  public class Pepporoni : APizzaTopping
  {
    public Pepporoni()
    {
      name = "Pepperoni";
      veget = false;
      vegan = false;
      price = 0.99;
    }
  }
}