using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Changelang (string culture,string Cl,string Ac)
        {
            try
            {
                Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = System.DateTimeOffset.UtcNow.AddMonths(1) });
            }
            catch
            { }
            return RedirectToAction(Ac, Cl);
        }
    }
}
