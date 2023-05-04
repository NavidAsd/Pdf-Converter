using Common;
using EndPoint.Models.MultiClasses;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    public class ErrorController : Controller
    {
        [Route("not-found")]
        public IActionResult NotFound()
        {
            return View();
        }
        [Route("page-not-found")]
        public IActionResult PageNotFound()
        {
            return View();
        }

    }
}
