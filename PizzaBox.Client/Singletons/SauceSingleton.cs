using System.Collections.Generic;
using PizzaBox.Domain.Models.Sauces;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class SauceSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static SauceSingleton _instance;
    private const string _path = @"data/sauces.xml";
    private readonly PizzaBoxContext _context;

    public long StoreEntityId;

    public List<ASauce> Sauces { get; set; }
    public static SauceSingleton Instance(PizzaBoxContext context)
    {
        if (_instance == null)
        {
          _instance = new SauceSingleton(context);
        }

        return _instance;
    }

    /// <summary>
    /// 
    /// </summary>
    private SauceSingleton(PizzaBoxContext context)
    {
      _context = context;
     // _context.Sauces.AddRange(_fileRepository.ReadFromFile<List<ASauce>>(_path));

    //Sauces = _context.Sauces.ToList();
   /* if(Sauces == null){
      var m = new Marinara();
      var a = new Alfredo();
      var b = new Bbq();
     _context.Add(m);
     _context.Add(a);
     _context.Add(b);
     _context.SaveChanges();

    }*/
    Sauces = _context.Sauces.ToList();
    }
  }
}
