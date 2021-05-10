// [I]. HEAD
//  A] Libraries
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

///
namespace PizzaBox.Domain.Models.Pizzas
{
  /// a pizza topped with all of the cheeses
  public class CheesePizza : APizza
  {
    //  B] Fields and Properties


    // [II]. BODY
    ///
    public CheesePizza()
    {
      //  a) head
      Name = "Cheese Pizza";

      //  b)  body
      // Cheese pizza needs a smooth crust, by default.
      Crust = new PizzaCrust(PizzaCrust.Choice.BUBBLY_ITALIAN);

      AddTopping(new Components.Toppings.PizzaToppingCheese(Components.Toppings.PizzaToppingCheese.Choice.CHEDDAR));
      AddTopping(new Components.Toppings.PizzaToppingCheese(Components.Toppings.PizzaToppingCheese.Choice.MOZZ_PROV_MIX));
      AddTopping(new Components.Toppings.PizzaToppingCheese(Components.Toppings.PizzaToppingCheese.Choice.GORGONZOLA));

      //  c) foot  =created
    }
  }
}// /ns
 // EoF