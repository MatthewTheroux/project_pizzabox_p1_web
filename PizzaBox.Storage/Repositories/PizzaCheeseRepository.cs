// [I]. HEAD
//  A] Libraries
using System;
using System.Collections.Generic;
using System.Linq;

using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models.Components.Toppings;

///
namespace PizzaBox.Storage.Repositories
{
  ///
  public class PizzaCheeseRepository : IRepository<PizzaToppingCheese>
  {
    public List<PizzaToppingCheese> Cheeses { get; set; }

    private readonly PizzaBoxContext _context;


    // a parameterless construcor is required.
    public PizzaCheeseRepository() : base() { }
    public PizzaCheeseRepository(PizzaBoxContext context) { _context = context; }

    /// [II]. BODY: Use CRUD
    /// 1. Create
    public bool Insert(PizzaToppingCheese cheese)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body
      try
      {
        _context.Cheeses.Add(cheese);
        didSucceed = true;
      }
      catch (Exception e) { e.ToString(); }
      //$"There was an issue with adding pizza cheese {cheese}";

      //  c) foot
      return didSucceed;
    }

    /// 2. Read
    public IEnumerable<PizzaToppingCheese> Select(Func<PizzaToppingCheese, bool> filter)
    {
      return _context.Cheeses.Where(filter);
    }

    /// 3. Update
    public PizzaToppingCheese Update(PizzaToppingCheese cheese)
    {
      //  a) head


      //  b) body


      //  c)
      return cheese;
    }// /'Update'

    /// 4. Delete
    public bool Delete(PizzaToppingCheese cheese)
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

    public List<PizzaToppingCheese> ToList() { return Cheeses; }

    public void Save() { _context.SaveChanges(); }

  }// /cla 'CheeseRepository'
}// /ns '..Repositories'
 // EoF