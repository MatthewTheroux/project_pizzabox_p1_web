// [I]. HEAD
//  A] Libraries
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PizzaBox.Client.Web.Models;
using PizzaBox.Storage;
using PizzaBox.Storage.Repositories;

/// UX Controllers
namespace PizzaBox.Client.Web.Controllers
{
  // the Route Handler
  [Route("[controller]")]
  /// This will get a user to ___.
  public class HomeController : Controller
  {
    //  B] Fields and Properties
    /// Track APizza's 'UnitOfWork'.  Make only one per session, (i.example.example, user).
    private readonly UnitOfWork _unitOfWork;

    private readonly ILogger<HomeController> _logger;

    public string Title { get; set; }


    //  C] Populate fields via dependency injection through the constructor(s).
    public HomeController(UnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    // Enable the logging mechanism.
    public HomeController(ILogger<HomeController> logger) { _logger = logger; }

    public HomeController(UnitOfWork unitOfWork, ILogger<HomeController> logger)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
    }// /cxtr --detailed


    /// Show the About Us page.
    //[ViewData]
    public IActionResult About()
    {
      Title = "About Us";
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    /// 
    [HttpGet]
    public IActionResult Index()
    {
      OrderViewModel orderViewModel = new OrderViewModel();

      orderViewModel.PopulatePizzaComponentChoices(_unitOfWork);

      return View("order", orderViewModel);
    }// /ax 'Index'

    public IActionResult Index(string message)
    {
      ViewBag.Message("There was an Error thrown in Index.");
      return View();
    }

    /// In case of ...stuff,
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      ViewBag.Message("There was an Error. It was sent to the ErrorView.");
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }// /ax 'Error'

  }// /cla 'HomeController'
}// /ns '..Web.Controllers'
 // EoF