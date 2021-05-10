using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Components.Toppings
{
  public abstract class APizzaTopping : AComponent
  {
    public static readonly Price BASE_PRICE = new Price(.50M);

    /// the pizza this topping is a part of
    public APizza Pizza { get; set; } = null;


    // [III]. FOOT
    /// Default constructor for a Topping if none can be found.
    public override string ToString() { return "topping"; }
  }// /cla
}// /ns
 // EoF