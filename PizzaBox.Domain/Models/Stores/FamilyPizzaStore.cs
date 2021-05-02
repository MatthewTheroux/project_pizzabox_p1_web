using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Orders;

namespace PizzaBox.Domain.Models.Stores
{
  public class FamilyPizzaStore : APizzaStore
  {
    public FamilyPizzaStore()
    {
      Name = "FamilyPizzaStore";
      EntityName = "FamilyPizzaStore";
    }

  }

}