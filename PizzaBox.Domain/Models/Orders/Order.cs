using System;
using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models.Orders
{
  public class Order : AnEntity
  {
    public double price { get; set; }
    public List<APizza> pizzas;
    public Customer customer;
    public AStore store;
    public DateTime time { get; }


    public Order()
    {
      time = DateTime.Now;
      price = 0.0;
      pizzas = new List<APizza>();
    }
  }
}