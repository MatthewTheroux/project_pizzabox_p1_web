using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repositories;
using PizzaBox.Storing;
using PizzaBox.Domain.Models.Stores;
using System.IO;

///
namespace PizzaBox.Client.Singletons
{
  ///
  public class StoreSingleton
  {
    private const string __path = @"data/store.xml";
    private readonly FileRepository _fileRepository = new FileRepository();
    private static StoreSingleton _instance;
    private readonly PizzaBoxContext _context;
    public List<AStore> Stores { get; set; }
    public static StoreSingleton Instance(PizzaBoxContext context)
    {

      if (_instance == null)
      {
        _instance = new StoreSingleton(context);
      }
      return _instance;

    }

    ///
    private StoreSingleton(PizzaBoxContext context)
    {
      _context = context;
      Stores = _context.Stores.ToList();
      if (Stores == null)
      {
        var s = new FamilyPizzaStore();
        var n = new ExpressPizzaStore();
        _context.Add(s);
        _context.Add(n);

      }
      //Stores = _context.Stores.ToList();
    }



  }
}