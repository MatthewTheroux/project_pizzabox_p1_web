// [I]. HEAD
//  A] Libraries
using System.Collections.Generic;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

///
namespace PizzaBox.Domain.Models.Pizzas
{
  /// a pizza topped with double pepperoni
  public class PepperoniPizza : APizza
  {
    //  B] Fields and Properties


    // [II]. BODY
    ///
    public PepperoniPizza()
    {
      //  a) head
      Name = "Pepperoni Pizza";

      //  b)  body
      // Pepperoni pizza needs a thin-'n-crispy crust, by default.
      Crust = new PizzaCrust(PizzaCrust.Choice.NY_THIN);
      //Sauce = new PizzaSauce(PizzaSauce.Choice.SMOOTH_MARINARA);

      // Add it, twice.
      AddTopping(new PizzaToppingMeat(PizzaToppingMeat.Choice.PEPPERONI));
      AddTopping(new PizzaToppingMeat(PizzaToppingMeat.Choice.PEPPERONI));

      //  c) foot  =created
    }
  }// /cla 'PepperoniPizza'
}// /ns '..Pizzas'
 // EoF