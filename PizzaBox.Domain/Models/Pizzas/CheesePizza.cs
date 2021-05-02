using System;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Abstracts.PizzaComponents;
using PizzaBox.Domain.Abstracts.PizzaComponents.PizzaToppings;

using PizzaBox.Domain.Models.Toppings;


namespace PizzaBox.Domain.Models.Pizzas
{
  public class CheesePizza : APizza
  {

    public CheesePizza()
    {

      Name = "Cheese Pizza";
      addTopping(new APizzaTopping[] { new Mozzerella() });

    }
  }
}