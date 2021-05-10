// [I]. HEAD
//  A] Libraries
using System;
using System.Collections.Generic;
using System.Linq;

using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models.Components;

///
namespace PizzaBox.Storage.Repositories
{
  ///
  public class PizzaCrustRepository : IRepository<PizzaCrust>
  {
    public List<PizzaCrust> Crusts { get; set; }

    private readonly PizzaBoxContext _context;


    // a parameterless construcor is required.
    public PizzaCrustRepository() : base() { }
    public PizzaCrustRepository(PizzaBoxContext context) { _context = context; }

    /// [II]. BODY: Use CRUD
    /// 1. Create
    public bool Insert(PizzaCrust crust)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body
      try
      {
        _context.Crusts.Add(crust);
        didSucceed = true;
      }
      catch (Exception e) { e.ToString(); }
      //$"There was an issue with adding pizza crust {crust}";

      //  c) foot
      return didSucceed;
    }

    /// 2. Read
    public IEnumerable<PizzaCrust> Select(Func<PizzaCrust, bool> filter)
    {
      return _context.Crusts.Where(filter);
    }

    /// 3. Update
    public PizzaCrust Update(PizzaCrust crust)
    {
      //  a) head


      //  b) body


      //  c)
      return crust;
    }// /'Update'

    /// 4. Delete
    public bool Delete(PizzaCrust crust)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body


      //  c)
      //didSucceed = true;
      return didSucceed;
    }

    // [III]. FOOT
    ///
    public override string ToString()
    {
      return "";//<!>
    }

    public List<PizzaCrust> ToList() { return Crusts; }

    public void Save() { _context.SaveChanges(); }

  }// /cla 'CrustRepository'
}// /ns '..Repositories'
 // EoF