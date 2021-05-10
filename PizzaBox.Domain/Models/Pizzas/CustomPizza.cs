// [I]. HEAD
//  A] Libraries
using System;
using System.Collections.Generic;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

///
namespace PizzaBox.Domain.Models.Pizzas
{
  /// a pizza topped with all of the meats
  public class CustomPizza : APizza
  {
    //  B] Fields and Properties


    // [II]. BODY
    ///
    public CustomPizza()
    {
      //  a) head
      Name = "Custom Pizza";

      //  b)  body
      // Factory();

      //  c) foot  =created
    }

    // private void Factory()
    // {
    //   AddSize();
    //   AddCrust();
    //   AddSauce();
    //   AddCheese();


    // }

    // private void AddSize()
    // {

    // }
  }
}// /ns
 // EoF