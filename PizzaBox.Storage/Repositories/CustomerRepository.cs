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
  public class CustomerRepository : IRepository<Customer>
  {
    public List<Customer> Customers { get; set; } //<...>

    private readonly PizzaBoxContext _context;


    // a parameterless construcor is required.
    public CustomerRepository() : base() { }
    public CustomerRepository(PizzaBoxContext context) { _context = context; }

    /// [II]. BODY: Use CRUD
    /// 1. Create
    public bool Insert(Customer customer)
    {
      //  a) head
      bool didSucceed = false;

      //  b) body
      try
      {
        _context.Customers.Add(customer);
        didSucceed = true;
      }
      catch (Exception e) { e.ToString(); }
      //$"There was an issue with adding pizza customer {customer}";

      //  c) foot
      return didSucceed;
    }

    /// 2. Read
    public IEnumerable<Customer> Select(Func<Customer, bool> filter)
    {
      return _context.Customers.Where(filter);
    }

    /// 3. Update
    public Customer Update(Customer customer)
    {
      //  a) head


      //  b) body


      //  c)
      return customer;
    }// /'Update'

    /// 4. Delete
    public bool Delete(Customer customer)
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

    public List<Customer> ToList() { return Customers; }

    public void Save() { _context.SaveChanges(); }

  }// /cla 'CustomerRepository'
}// /ns '..Repositories'
 // EoF