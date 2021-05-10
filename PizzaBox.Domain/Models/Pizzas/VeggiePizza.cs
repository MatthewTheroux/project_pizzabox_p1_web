// [I]. HEAD
//  A] Libraries
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

///
namespace PizzaBox.Domain.Models.Pizzas
{
  /// a pizza topped with all of the veggies
  public class VegetablePizza : APizza
  {
    //  B] Fields and Properties

    // [II]. BODY
    ///
    public VegetablePizza()
    {
      //  a) head
      Name = "Vegtable Pizza";

      //  b)  body
      // Veggie pizza should have a crispy thin crust, by default.
      Crust = new PizzaCrust(PizzaCrust.Choice.NY_THIN);

      // Dump all of the veggie toppings on it.
      AddTopping(new PizzaToppingVegetable(PizzaToppingVegetable.Choice.MUSHROOM));
      AddTopping(new PizzaToppingVegetable(PizzaToppingVegetable.Choice.GREEN_BELL_PEPPER));
      AddTopping(new PizzaToppingVegetable(PizzaToppingVegetable.Choice.ONION));
      AddTopping(new PizzaToppingVegetable(PizzaToppingVegetable.Choice.BANANA_PEPPER));
      AddTopping(new PizzaToppingVegetable(PizzaToppingVegetable.Choice.DICED_TOMATO)); //≈veg

      //  c) foot  =created
    }
  }// /cla 'VegtablePizza'
}// /ns '..Models.Pizzas'
 // EoF