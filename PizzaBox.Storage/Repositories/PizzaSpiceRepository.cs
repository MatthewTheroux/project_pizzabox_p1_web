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
  public class PizzaSpiceRepository : IRepository<PizzaSpice>
  {
    public List<PizzaSpice> Spices { get; set; } //<...>

    private readonly PizzaBoxContext _context;


    // a parameterless construcor is required.
    public PizzaSpiceRepository() : base() { }
    public PizzaSpiceRepository(PizzaBoxContext context) { _context = context; }

    /// [II]. BODY: Use CRUD
    /// 1. Create
    public bool Insert(PizzaSpice spice)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body
      try
      {
        _context.Spices.Add(spice);
        didSucceed = true;
      }
      catch (Exception e) { e.ToString(); }
      //$"There was an issue with adding pizza spice {spice}";

      //  c) foot
      return didSucceed;
    }// /'Insert'

    /// 2. Read
    public IEnumerable<PizzaSpice> Select(Func<PizzaSpice, bool> filter)
    {
      return _context.Spices.Where(filter);
    }

    /// 3. Update
    public PizzaSpice Update(PizzaSpice spice)
    {
      //  a) head


      //  b) body


      //  c)
      return spice;
    }// /'Update'

    /// 4. Delete
    public bool Delete(PizzaSpice spice)
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

    public List<PizzaSpice> ToList() { return Spices; }

    public void Save() { _context.SaveChanges(); }

  }// /cla 'SpiceRepository'
}// /ns '..Repositories'
 // EoF