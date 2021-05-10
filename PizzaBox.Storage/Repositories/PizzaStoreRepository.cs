// [I]. HEAD
//  A] Libraries
using System;
using System.Collections.Generic;
using System.Linq;

using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Abstracts;

///
namespace PizzaBox.Storage.Repositories
{
  ///
  public class PizzaStoreRepository : IRepository<APizzaStore>
  {
    public List<APizzaStore> Stores { get; set; }

    private readonly PizzaBoxContext _context;


    // a parameterless construcor is required.
    public PizzaStoreRepository() : base() { }
    public PizzaStoreRepository(PizzaBoxContext context) { _context = context; }

    /// [II]. BODY: Use CRUD
    /// 1. Create
    public bool Insert(APizzaStore store)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body
      try
      {
        _context.Stores.Add(store);
        didSucceed = true;
      }
      catch (Exception e) { e.ToString(); }
      //$"There was an issue with adding pizza store {store}";

      //  c) foot
      return didSucceed;
    }

    /// 2. Read
    public IEnumerable<APizzaStore> Select(Func<APizzaStore, bool> filter)
    {
      return _context.Stores.Where(filter);
    }

    /// 3. Update
    public APizzaStore Update(APizzaStore store)
    {
      //  a) head


      //  b) body


      //  c)
      return store;
    }// /'Update'

    /// 4. Delete
    public bool Delete(APizzaStore store)
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

    public List<APizzaStore> ToList() { return Stores; }

    public void Save() { _context.SaveChanges(); }

  }// /cla 'OrderRepository'
}// /ns '..Repositories'
 // EoF