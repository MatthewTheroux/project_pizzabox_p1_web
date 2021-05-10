// [I]. HEAD
//  A] Libraries
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PizzaBox.Client.Web.Models;
using PizzaBox.Storage;

/// UX Controllers
namespace PizzaBox.Client.Web.Controllers
{
  // the Route Handler
  //[Route(“/[order]/[controller] /[action]”)] 
  [Route("[controller]")]
  /// This will get a user to ___.
  public class HomeController : Controller
  {
    //  B] Fields and Properties
    /// Track APizza's 'UnitOfWork'.  Make more than one so that users don't share it.
    private readonly UnitOfWork _unitOfWork;

    private readonly ILogger<HomeController> _logger; //<?>


    public HomeController(UnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    // Enable the logging mechanism.
    public HomeController(ILogger<HomeController> logger) { _logger = logger; }

    public HomeController(UnitOfWork unitOfWork, ILogger<HomeController> logger)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
    }// /cxtr


    ///
    [HttpGet]
    public IActionResult Privacy() { return View(); } //<?>

    /// 
    [HttpGet]
    public IActionResult Index()
    {
      var order = new OrderViewModel();

      order.Populate(_unitOfWork);

      return View("order", order);
    }


    /// In case of ...stuff,
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

  }// /cla 'HomeController'
}// /ns '..Web.Controllers'
// EoF
