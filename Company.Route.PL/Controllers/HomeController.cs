using Company.Route.PL.Models;
using Company.Route.PL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace Company.Route.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScopedService scope1;
        private readonly IScopedService scope2;
        private readonly ITransientService transient1;
        private readonly ITransientService transient2;
        private readonly ISingletonService singleton1;
        private readonly ISingletonService singleton2;

        public HomeController(ILogger<HomeController> logger)
            //,IScopedService scope1
            //,IScopedService scope2
            //,ITransientService transient1
            //,ITransientService transient2
            //,ISingletonService singleton1
            //,ISingletonService singleton2)
        {
            _logger = logger;
            //this.scope1 = scope1;
            //this.scope2 = scope2;
            //this.transient1 = transient1;
            //this.transient2 = transient2;
            //this.singleton1 = singleton1;
            //this.singleton2 = singleton2;
        }

        //public string TestLifeTime() // to test life time of services I have
        //{
        //   StringBuilder builder = new StringBuilder();
        //    builder.Append($"scope1 :: {scope1.GetGuid}\n");
        //    builder.Append($"scope2 :: {scope2.GetGuid}\n");

        //    builder.Append($"transient1 :: {transient1.GetGuid}\n");
        //    builder.Append($"transient2 :: {transient2.GetGuid}\n");

        //    builder.Append($"singleton1 :: {singleton1.GetGuid}\n");
        //    builder.Append($"singleton2 :: {singleton2.GetGuid}\n");


        //    return builder.ToString();
        //}

        public IActionResult Index()
        {
            return View();
        }

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
}
