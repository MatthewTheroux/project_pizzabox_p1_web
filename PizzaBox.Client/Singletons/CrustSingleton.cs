using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Crusts;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class CrustSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static CrustSingleton _instance;
    private const string _path = @"data/crusts.xml";
    private readonly PizzaBoxContext _context;

    public List<ASize> Crusts { get; set; }
    public static CrustSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new CrustSingleton(context);
      }

      return _instance;
    }

    /// <summary>
    /// 
    /// </summary>
    private CrustSingleton(PizzaBoxContext context)
    {
      _context = context;

      //Crusts = _context.Crusts.ToList();
      /*if(Crusts == null)
      {

       var m = new MediumCrust();
       var s = new SmallCrust();
       var l = new LargeCrust();
       var x = new XLargeCrust();
       _context.Add(m);
       _context.Add(s);
       _context.Add(l);
       _context.Add(x);
       _context.SaveChanges();
      }*/
      Crusts = _context.Crusts.ToList();
      //    _context.Add(cp);
      //      _context.SaveChanges();

      //      Pizzas = _context.Pizzas.ToList();
    }
  }
}
