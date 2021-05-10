// [I]. HEAD
//  A] Libraries
using System;
using System.Collections.Generic;
using System.Linq;

using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

///
namespace PizzaBox.Storage.Repositories
{
  ///
  public class PizzaOrderRepository : IRepository<PizzaOrder>
  {
    public List<PizzaOrder> Orders { get; set; }

    private readonly PizzaBoxContext _context;


    // parameterless construcor is required.
    public PizzaOrderRepository() : base() { }
    public PizzaOrderRepository(PizzaBoxContext context) { _context = context; }

    /// [II]. BODY: Use CRUD
    /// 1. Create
    public bool Insert(PizzaOrder order)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body
      try
      {
        _context.Orders.Add(order);
        didSucceed = true;
      }
      catch (Exception e) { }

      //  c) foot
      return didSucceed;
    }

    /// 2. Read
    public IEnumerable<PizzaOrder> Select(Func<PizzaOrder, bool> filter)
    {
      return _context.Orders.Where(filter);
    }

    /// 3. Update
    public PizzaOrder Update(PizzaOrder order)
    {
      //  a) head

      //  b) body


      //  c)
      return new PizzaOrder();//<!>
    }// /'Update'

    /// 4. Delete
    public bool Delete(PizzaOrder order)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body


      //  c)
      didSucceed = true;
      return didSucceed;
    }

    // [III]. FOOT
    ///
    public override string ToString()
    {
      return "";//<!>
    }

    public List<PizzaOrder> ToList() { return Orders; }

    public void Save() { _context.SaveChanges(); }

  }// /cla 'OrderRepository'
}// /ns '..Repositories'
 // EoF