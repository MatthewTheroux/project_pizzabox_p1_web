using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Toppings
{
  public class Tomato : APizzaTopping
  {
    public Tomato()
    {
      name = "Tomato";
      veget = true;
      vegan = true;
      price = 0.50;
    }
  }
}