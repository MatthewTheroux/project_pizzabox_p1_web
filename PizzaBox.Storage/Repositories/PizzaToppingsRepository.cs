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
  public class PizzaToppingsRepository : IRepository<APizzaTopping>
  {
    public List<APizzaTopping> Toppings { get; set; }

    private readonly PizzaBoxContext _context;


    // a parameterless construcor is required.
    public PizzaToppingsRepository() : base() { }
    public PizzaToppingsRepository(PizzaBoxContext context) { _context = context; }

    /// [II]. BODY: Use CRUD
    /// 1. Create
    public bool Insert(APizzaTopping topping)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body
      try
      {
        _context.Toppings.Add(topping);
        didSucceed = true;
      }
      catch (Exception e) { e.ToString(); }
      //$"There was an issue with adding pizza topping {topping}";

      //  c) foot
      return didSucceed;
    }// /'Insert'

    /// 2. Read
    public IEnumerable<APizzaTopping> Select(Func<APizzaTopping, bool> filter)
    {
      return _context.Toppings.Where(filter);
    }

    /// 3. Update
    public APizzaTopping Update(APizzaTopping topping)
    {
      //  a) head


      //  b) body


      //  c)
      return topping;
    }// /'Update'

    /// 4. Delete
    public bool Delete(APizzaTopping topping)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body


      //  c)
      //didSucceed = true;
      return didSucceed;
    }// /'Delete'

    // [III]. FOOT
    ///
    public override string ToString()
    {
      return "";//<!>
    }

    public List<APizzaTopping> ToList() { return Toppings; }

    public void Save() { _context.SaveChanges(); }

  }// /cla 'CrustRepository'
}// /ns '..Repositories'
 // EoF