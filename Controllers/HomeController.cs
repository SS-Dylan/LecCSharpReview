using LecCSharpReview.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LecCSharpReview.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    #region return Content
    /// <summary>
    /// return Content returns a raw string instead of a view.
    /// </summary>
    /// <returns></returns>
    public IActionResult HelloWorld()
    {
        return Content("Hello, World!");
    }

    /// <summary>
    /// Uses URL .../home/hello/{name}
    /// Works this way due to route in Program.cs
    /// {Controller}/{action}/{id}
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IActionResult Hello(string? id)
    {
        var name = "World";
        if(id != null)
        {
            name = id;
        }
        return Content($"Hello, {name}!");
    }
    #endregion

    #region Enums
    /// <summary>
    /// *Enums are value types*
    /// Enums use int by default to store values in memory.
    /// </summary>
    enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };

    /// <summary>
    /// This enum was overrided to use a byte to store value instead of an int.
    /// </summary>
    enum Months : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };

    public IActionResult EnumDemo()
    {
        Days today = Days.Wednesday;
        int dayNumber = (int)today; //The (int) is the type class, it is needed for this line to work.
        string model = $"{today} is day #{dayNumber} ";

        foreach(string item in Enum.GetNames(typeof(Months)))
        //Enum.GetNames(typeof(Months)) converts the enum to a string.
        {
            model += item + " ";
        }
        return Content(model);
    }
    #endregion

    #region Classes
    /// <summary>
    /// Initializes a new Employee object with the name Jeff,
    /// then uses the talk method in the Employee model.
    /// </summary>
    /// <returns></returns>
    public IActionResult ClassDemo()
    {
        //Uses base Employee model
        Employee e = new()
        {
            Name = "Dylan"
        };

        //Uses inhereted Manager model, new Manager must be specified unlike employee
        Employee m = new Manager
        {
            Name = "Savanna"
        };

        string model = e.Talk();
        model += "\n";
        model += m.Talk();
        return Content(model);
    }
    #endregion

    #region Interfaces
    public IActionResult InterfaceDemo()
    {
        IGetArea r = new Rectangle
        {
            Length = 20,
            Width = 10
        };

        return Content($"The area of the rectangle is {r.GetArea()}");
    }
    #endregion

    #region Anonymous
    public IActionResult AnonymousDemo()
    {
        //Creating an object without newing anything. Called an *ANONYMOUS OBJECT*
        var o = new { Amount = 100, Message = "Hello" };

        //Takes the object passed to it and creates a Json version of it, then returns it.
        return Json(o);
    }
    #endregion

    #region LINQ
    public IActionResult LINQDemo()
    {
        var products = new[] //Creates new array
        {
            new {id = 1, Color="Red", Price=1.3m},
            new {id = 2, Color="Blue", Price=2.35m},
            new {id = 3, Color="Pink", Price=0.89m}
        };

        //A way of writing SQL in C#
        var productQ = 
            from prod in products
            select new {prod.Color, prod.Price};

        var model = "";
        foreach(var p in productQ)
        {
            model += $"Color={p.Color}, Price={p.Price}\n";
        }

        return Content(model);
    }
    #endregion

    #region Lambda
    public IActionResult LambdaDemo()
    {
        var products = new[] //Creates new array
        {
            new {id = 1, Color="Red", Price=1.3m},
            new {id = 2, Color="Blue", Price=2.35m},
            new {id = 3, Color="Pink", Price=0.89m}
        };

        string model = "";
        var product = products.FirstOrDefault(p => p.id == 2); //Lambda expression. input => returns
        if(product != null)
        {
            model = $"Color={product.Color}, Price={product.Price}\n";
        }
        return Content(model);
    }
    #endregion

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
