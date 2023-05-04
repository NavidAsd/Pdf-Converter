using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System;
using Common;
using Microsoft.AspNetCore.Authentication;
using Application.Interface.FacadPattern;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EndPoint.Areas.PdfManagerArea.Controllers
{
    [Area("PdfManagerArea")]
    public class HomeController : Controller
    {
        private readonly IFeaturesDetailsFacad _Features;
        public HomeController(IFeaturesDetailsFacad features)
        {
            _Features = features;
        }
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                try
                {
                    Models.Admin data = new Models.Admin()
                    {
                        Email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value,
                        FullName = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Name).Value,
                        Id = Convert.ToInt64(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                        AccountImage = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.StreetAddress).Value,
                        ImagePath = GetPath.GetAdminImagePath(),

                    };
                    ViewBag.Data = data;
                    ViewBag.CommentCount = _Features.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                }
                catch { return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login"); }
                return View();
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
    }
}
