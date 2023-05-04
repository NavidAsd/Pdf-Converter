using Common;
using System.IO;
using Application.Interface.FacadPattern;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System;
using EndPoint.Areas.PdfManagerArea.Models;
using EndPoint.Areas.PdfManagerArea.Models.Validation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace EndPoint.Areas.PdfManagerArea.Controllers
{
    [Area("PdfManagerArea")]
    public class AdminController : Controller
    {
        private readonly IAdminFacad _AdminFacad;
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        public AdminController(IAdminFacad adminFacad, IFeaturesDetailsFacad featuresDetails)
        {
            _AdminFacad = adminFacad;
            _FeaturesDetails = featuresDetails;
        }
        public IActionResult Index(string Filter, int PageIndex)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var currentadmin = _AdminFacad.ReturnAdminDetailsService.Execute(long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
                if (currentadmin.Enything.RemoveAdmin == true)
                {
                    var user = _AdminFacad.ReturnAdminDetailsService.ReturnAll(new Application.Services.Query.Admin.ReturnAdminDetails.RequestReturnAllAdminDetailsDto
                    {
                        Filter = Formating.FixFilterFormat(Filter),
                        PageIndex = PageIndex,
                        PageSize = 10,
                        CurrentAdminId = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    });
                    if (user.Success)
                    {
                        ViewBag.Data = LayoutData();
                        ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                        return View(user);
                    }
                    return View(new ResultMessage<Application.Services.Query.Admin.ReturnAdminDetails.ResultReturnAllAdminDetailsDto>
                    {
                        Success = false,
                        Enything = null,
                        Message = user.Message
                    });
                }
                return Redirect($"{ GetPath.GetDomainHttps()}/PdfManagerArea/AreaError/NotFound");
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");

        }
        public IActionResult Removed(string Filter, int PageIndex)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = _AdminFacad.ReturnAdminDetailsService.ReturnAllRemoved(new Application.Services.Query.Admin.ReturnAdminDetails.RequestReturnAllAdminDetailsDto
                {
                    Filter = Formating.FixFilterFormat(Filter),
                    PageIndex = PageIndex,
                    PageSize = 10,
                    CurrentAdminId = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                });
                if (user.Success)
                {
                    ViewBag.Data = LayoutData();
                    ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                    return View(user);
                }
                return View(new ResultMessage<Application.Services.Query.Admin.ReturnAdminDetails.ResultReturnAllAdminDetailsDto>
                {
                    Success = false,
                    Enything = null,
                    Message = user.Message
                });
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");

        }
        public IActionResult Create()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View();
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }

        [HttpPost]
        public IActionResult UpdateAddPermition(long Id, bool State)
        {
            return Json(_AdminFacad.UpdateAdminService.ChangeAdminAddPermition(new Application.Services.Command.Admin.UpdateAdmin.UpdateAdminDto
            {
                CurrentAdminId = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                Id = Id,
                State = State,
            }));
        }
        [HttpPost]
        public IActionResult UpdateRemovePermition(long Id, bool State)
        {
            return Json(_AdminFacad.UpdateAdminService.ChangeAdminRemovePermition(new Application.Services.Command.Admin.UpdateAdmin.UpdateAdminDto
            {
                CurrentAdminId = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                Id = Id,
                State = State,
            }));
        }
        [HttpPost]
        public IActionResult RemoveAdmin(long Id)
        {
            return Json(_AdminFacad.UpdateAdminService.ChangeAdminState(new Application.Services.Command.Admin.UpdateAdmin.UpdateAdminDto
            {
                CurrentAdminId = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                Id = Id,
                State = true,
            }));
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewAdmin(CreateNewAdminViewModel request)
        {
            #region Validation
            try
            {
                CreateNewAdminValidation validation = new CreateNewAdminValidation();
                ValidationResult Result = validation.Validate(request);
                if (!Result.IsValid)
                {
                    foreach (ValidationFailure failure in Result.Errors)
                    {
                        return Json(new ResultMessage
                        {
                            Success = false,
                            Message = failure.ErrorMessage,
                        });
                    }
                }
                if (request.Password != request.RePassword)
                {
                    return Json(new ResultMessage
                    {
                        Success = false,
                        Message = "The password is inconsistent with its repetition"
                    });
                }
            }
            catch
            {
                return Json(new ResultMessage
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again"
                });
            }
            #endregion
            var result = _AdminFacad.AddNewAdminService.Execute(new Application.Services.Command.Admin.AddNewAdmin.RequestAddNewAdminDto
            {
                CurrnetAdminId = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                AccountImage = GetPath.GetDefaultAdminImageName(),
                AddAdmin = request.AddAdmin,
                RemoveAdmin = request.RemoveAdmin,
                Email = request.Email,
                Name = request.FullName,
                Password = request.Password,  

            });
            if (result.Success)
            {
                string ImagePath = $"wwwroot\\{GetPath.GetAdminImagePath()}\\{result.Enything.Id}";
                if (!Directory.Exists(ImagePath))
                    Directory.CreateDirectory(ImagePath);
                AppliedMethodes.CopyFile($"wwwroot\\{GetPath.GetDefaultAdminImage()}\\{GetPath.GetDefaultAdminImageName()}", $"{ImagePath}\\{GetPath.GetDefaultAdminImageName()}");
            }
                return Json(result);
        }
        private Models.Admin LayoutData()
        {
            Models.Admin data = new Models.Admin()
            {
                Email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value,
                FullName = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Name).Value,
                Id = Convert.ToInt64(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                AccountImage = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.StreetAddress).Value,
                ImagePath = GetPath.GetAdminImagePath(),

            };
            return data;
        }
    }
}
