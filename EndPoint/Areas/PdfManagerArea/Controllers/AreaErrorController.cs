using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Areas.PdfManagerArea.Controllers
{
    public class AreaErrorController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
