// [I]. HEAD
//  A] Libraries
using System;
using System.Collections.Generic;
using System.Linq;

using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models.Components;

using PizzaBox.Storage;

///
namespace PizzaBox.Storage.Repositories
{
  ///
  public class PizzaSizeRepository : IRepository<PizzaSize>
  {
    public List<PizzaSize> Sizes { get; set; }

    private readonly PizzaBoxContext _context;


    // a parameterless construcor is required.
    public PizzaSizeRepository() : base() { }
    public PizzaSizeRepository(PizzaBoxContext context) { _context = context; }

    /// [II]. BODY: Use CRUD
    /// 1. Create
    public bool Insert(PizzaSize size)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body
      try
      {
        _context.Sizes.Add(size);
        didSucceed = true;
      }
      catch (Exception e) { e.ToString(); }
      //$"There was an issue with adding pizza size {size}";

      //  c) foot
      return didSucceed;
    }

    /// 2. Read
    public IEnumerable<PizzaSize> Select(Func<PizzaSize, bool> filter)
    {
      return _context.Sizes.Where(filter);
    }

    /// 3. Update
    public PizzaSize Update(PizzaSize size)
    {
      //  a) head


      //  b) body


      //  c)
      return size;
    }// /'Update'

    /// 4. Delete
    public bool Delete(PizzaSize size)
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

    public List<PizzaSize> ToList() { return Sizes; }

    public void Save() { _context.SaveChanges(); }

  }// /cla 'SizeRepository'
}// /ns '..Repositories'
 // EoF