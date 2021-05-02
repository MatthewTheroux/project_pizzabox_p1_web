using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static PizzaSingleton _instance;
    private const string _path = @"data/pizzas.xml";
    private readonly PizzaBoxContext _context;

    public List<APizza> pizzas { get; set; }
    public static PizzaSingleton Instance(PizzaBoxContext context)
    {
        if (_instance == null)
        {
          _instance = new PizzaSingleton(context);
        }

        return _instance;
    }

    /// <summary>
    /// 
    /// </summary>
    private PizzaSingleton(PizzaBoxContext context)
    {
     // _context.Pizzas.AddRange(_fileRepository.ReadFromFile<List<APizza>>(_path));
     _context = context;
    
    
     //pizzas = _context.Pizzas.ToList();
     /*if(pizzas == null){
      var cp = new CheesePizza();
      var csp = new CustomPizza();
      var ml = new MeatloversPizza();
      _context.Add(cp);
      _context.Add(ml);
      _context.Add(csp);
      _context.SaveChanges();

      
    }*/
    pizzas = _context.Pizzas.ToList();
    }
  }
}
