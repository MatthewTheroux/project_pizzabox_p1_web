// [I]. HEAD
//  A] Libraries
using System.Collections.Generic;
using System.Text;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

using PizzaBox.Storage;
using PizzaBox.Storage.Repositories;

/// data base interactions
namespace PizzaBox.Storage
{
  /// contains ALL repositories
  public class UnitOfWork
  {
    //  B] Properties
    private readonly PizzaBoxContext _context;

    public PizzaSizeRepository Sizes { get; }
    public PizzaCrustRepository Crusts { get; }
    public PizzaSauceRepository Sauces { get; }
    public PizzaCheeseRepository Cheeses { get; }
    public PizzaToppingsRepository Toppings { get; }
    public PizzaSpiceRepository Spices { get; }

    public PizzaStoreRepository Stores { get; }
    public CustomerRepository Customers { get; }
    public PizzaOrderRepository Orders { get; }

    //  C] 
    public UnitOfWork(PizzaBoxContext context)
    {
      _context = context;

      Sizes = new PizzaSizeRepository(_context);
      Crusts = new PizzaCrustRepository(_context);
      Sauces = new PizzaSauceRepository(_context);
      Cheeses = new PizzaCheeseRepository(_context);
      Toppings = new PizzaToppingsRepository(_context);
      Spices = new PizzaSpiceRepository(_context);

      Stores = new PizzaStoreRepository(_context);
      Customers = new CustomerRepository(_context);
      Orders = new PizzaOrderRepository(_context);
    }// /cxtr

    /// [III]. FOOT
    public override string ToString()
    {
      StringBuilder uowStringBuilder = new StringBuilder();

      uowStringBuilder.Append("sizes: ");
      foreach (PizzaSize size in Sizes.ToList()) { uowStringBuilder.Append($"{size}, "); }
      uowStringBuilder.AppendLine();

      uowStringBuilder.Append("crusts: ");
      foreach (PizzaCrust crust in Crusts.ToList()) { uowStringBuilder.Append($"{crust}, "); }
      uowStringBuilder.AppendLine();

      uowStringBuilder.Append("sauces: ");
      foreach (PizzaSauce sauce in Sauces.ToList()) { uowStringBuilder.Append($"{sauce}, "); }
      uowStringBuilder.AppendLine();

      uowStringBuilder.Append("cheeses: ");
      foreach (PizzaToppingCheese cheese in Cheeses.ToList()) { uowStringBuilder.Append($"{cheese}, "); }
      uowStringBuilder.AppendLine();

      uowStringBuilder.Append("toppings: ");
      foreach (APizzaTopping topping in Toppings.ToList()) { uowStringBuilder.Append($"{topping}, "); }
      uowStringBuilder.AppendLine();

      uowStringBuilder.Append("spices: ");
      foreach (PizzaSpice spice in Spices.ToList()) { uowStringBuilder.Append($"{spice}, "); }
      uowStringBuilder.AppendLine();

      uowStringBuilder.Append("stores: ");
      foreach (APizzaStore store in Stores.ToList()) { uowStringBuilder.Append($"{store}, "); }
      uowStringBuilder.AppendLine();

      uowStringBuilder.Append("Customers: ");
      foreach (Customer customer in Customers.ToList()) { uowStringBuilder.Append($"{customer}, "); }
      uowStringBuilder.AppendLine();

      uowStringBuilder.Append("Orders: ");
      foreach (PizzaOrder order in Orders.ToList()) { uowStringBuilder.Append($"{order}, "); }
      uowStringBuilder.AppendLine();

      return uowStringBuilder.ToString();
    }// /'ToString'

    public void Save() { _context.SaveChanges(); }

  }// /cla  UoW
}// /ns '..Storage'
 // [EoF]