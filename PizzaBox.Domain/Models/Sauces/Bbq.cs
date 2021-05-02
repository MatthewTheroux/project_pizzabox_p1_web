using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Sauces
{
  public class Bbq : ASauce
  {
    public Bbq()
    {
      name = "BBQ";
      veget = false;
      vegan = false;
      price = 2.50;
    }
  }
}