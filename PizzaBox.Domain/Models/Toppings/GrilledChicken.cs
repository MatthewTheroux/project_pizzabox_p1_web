using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Toppings
{
  public class GrilledChicken : APizzaTopping
  {
    public GrilledChicken()
    {
      name = "GrilledChicken";
      veget = false;
      vegan = false;
      price = 1.50;
    }
  }
}