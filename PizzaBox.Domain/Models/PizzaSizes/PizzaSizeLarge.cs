
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Crusts
{
  public class PizzaSizeLarge : APizzaSize
  {
    public PizzaSizeLarge()
    {
      Name = "Large";
      Size = 14;
      //Price = 9.99;
    }

  }
}