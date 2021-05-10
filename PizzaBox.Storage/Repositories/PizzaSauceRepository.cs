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
  public class PizzaSauceRepository : IRepository<PizzaSauce>
  {
    public List<PizzaSauce> Sauces { get; set; }

    private readonly PizzaBoxContext _context;


    // a parameterless construcor is required.
    public PizzaSauceRepository() : base() { }
    public PizzaSauceRepository(PizzaBoxContext context) { _context = context; }

    /// [II]. BODY: Use CRUD
    /// 1. Create
    public bool Insert(PizzaSauce sauce)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body
      try
      {
        _context.Sauces.Add(sauce);
        didSucceed = true;
      }
      catch (Exception e) { e.ToString(); }
      //$"There was an issue with adding pizza sauce {sauce}";

      //  c) foot
      return didSucceed;
    }

    /// 2. Read
    public IEnumerable<PizzaSauce> Select(Func<PizzaSauce, bool> filter)
    {
      return _context.Sauces.Where(filter);
    }

    /// 3. Update
    public PizzaSauce Update(PizzaSauce sauce)
    {
      //  a) head


      //  b) body


      //  c)
      return sauce;
    }// /'Update'

    /// 4. Delete
    public bool Delete(PizzaSauce sauce)
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

    public List<PizzaSauce> ToList() { return Sauces; }

    public void Save() { _context.SaveChanges(); }

  }// /cla 'SauceRepository'
}// /ns '..Repositories'
 // EoF