using System.Collections.Generic;

using PizzaBox.Domain.Models.Orders;

///
namespace PizzaBox.Domain.Abstracts
{
  public abstract class AStore : AnEntity
  {

    public string Name { get; set; }
    public List<Order> Orders = new List<Order>();

    public abstract void PlaceAnOrder();

    public AStore() { EntityName = "(a store"; }
  }
}