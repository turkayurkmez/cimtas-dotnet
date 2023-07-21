using DILifeTime.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DILifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingletonGuid singletonGuid;
        private readonly IScopedGuid scopedGuid;
        private readonly ITransientGuid transientGuid;
        private readonly GuidService guidService;

        public HomeController(ILogger<HomeController> logger, ISingletonGuid singletonGuid, IScopedGuid scopedGuid, ITransientGuid transientGuid, GuidService guidService)
        {
            _logger = logger;
            this.singletonGuid = singletonGuid;
            this.scopedGuid = scopedGuid;
            this.transientGuid = transientGuid;
            this.guidService = guidService;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = singletonGuid.Guid.ToString();
            ViewBag.Scoped = scopedGuid.Guid.ToString();
            ViewBag.Transient = transientGuid.Guid.ToString();


            ViewBag.ServiceSingleton = guidService.Singleton.Guid.ToString();
            ViewBag.ServiceTransient = guidService.Transient.Guid.ToString();
            ViewBag.ServiceScoped = guidService.ScopedGuid.Guid.ToString();



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