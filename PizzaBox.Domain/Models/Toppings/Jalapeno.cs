using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Toppings
{
  public class Jalapeno : APizzaTopping
  {
    public Jalapeno()
    {
      name = "Jalapeno";
      veget = true;
      vegan = true;
      price = 0.50;
    }
  }
}