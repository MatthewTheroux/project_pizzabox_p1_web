using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models.Orders
{
  public class Customer : AnEntity
  {
    public List<Order> orders;
    public string name { get; set; }

    public Customer()
    {
      orders = new List<Order>();
    }

  }
}
