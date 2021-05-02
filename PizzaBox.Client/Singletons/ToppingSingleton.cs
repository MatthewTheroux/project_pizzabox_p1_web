using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Models.Toppings;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class ToppingSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static ToppingSingleton _instance;
    private const string _path = @"data/toppings.xml";
    private readonly PizzaBoxContext _context;

    public List<APizzaTopping> toppings { get; set; }
    public static ToppingSingleton Instance(PizzaBoxContext context)
    {

      if (_instance == null)
      {
        _instance = new ToppingSingleton(context);
      }

      return _instance;
    }

    /// <summary>
    /// 
    /// </summary>
    private ToppingSingleton(PizzaBoxContext context)
    {
      _context = context;
      // _context.Pizzas.AddRange(_fileRepository.ReadFromFile<List<APizza>>(_path));
      //      var cp = new CustomPizza();

      //toppings = _context.Toppings.ToList();

      /* if(toppings == null){
       var bb = new BlackBeans();
       var c = new Chedder();
       var fe = new FriedEgg();
       var gc = new GrilledChicken();
       var p = new Parmesan();
       var pp = new Pepporoni();
       var pa = new Pineapple();
       var s = new Sausage();
       var sh = new Spinach();
       var t = new Tomato();
       var j = new Jalapeno();
       var m = new Mozzerella();
      _context.Add(j);
      _context.Add(bb);
      _context.Add(c);
      _context.Add(fe);
      _context.Add(gc);
      _context.Add(p);
      _context.Add(pp);
      _context.Add(pa);
      _context.Add(s);
      _context.Add(sh);
      _context.Add(t);
      _context.Add(m);
      _context.SaveChanges();
       }*/
      toppings = _context.Toppings.ToList();
    }
  }
}
