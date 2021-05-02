using System.Collections.Generic;
using System;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Orders;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class CustomerSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static CustomerSingleton _instance;
    private const string _path = @"data/customers.xml";
    private readonly PizzaBoxContext _context;

    public List<Customer> Customers { get; set; }
    public static CustomerSingleton Instance(PizzaBoxContext context)
    {
        if (_instance == null)
        {
          _instance = new CustomerSingleton(context);
        }

        return _instance;
    }

    /// <summary>
    /// 
    /// </summary>
    private CustomerSingleton(PizzaBoxContext context)
    {
     _context = context;
    
    //Customers = _context.Customers.ToList();
    /*if(Customers == null)
    {
      Console.WriteLine("3rd");
     var c = new Customer();
      c.name = "John Doe";
      var c1 = new Customer();
      c1.name = "Jane Doe";
      _context.Add(c);
      _context.Add(c1);
      _context.SaveChanges();
      Console.WriteLine("2nd");
    }*/
    Customers = _context.Customers.ToList();

    }
  }
}
