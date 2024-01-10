using Application.Interface.FacadPattern;
using Common;
using EndPoint.Areas.PdfManagerArea.Models;
using EndPoint.Areas.PdfManagerArea.Models.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Areas.PdfManagerArea.Controllers
{
    [Area("PdfManagerArea")]
    public class OtherContextController : Controller
    {
        // google recaptch for old email
        // secret  6Ld3n1MfAAAAAGzT9vR6AEa_xL_VA5COy-eynEpR
        // site key 6Ld3n1MfAAAAAMTUJrJr-3ia1jQI0qW1pDo4u2Y5 
        private readonly IViewContextFacad _ViewContextFacad;
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        private readonly IHostEnvironment _Environment;
        public OtherContextController(IViewContextFacad viewContextFacad, IFeaturesDetailsFacad featuresDetails, IHostEnvironment environment)
        {
            _ViewContextFacad = viewContextFacad;
            _FeaturesDetails = featuresDetails;
            _Environment = environment;
        }
        public async Task<IActionResult> SnAccount()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(await _ViewContextFacad.ReturnAllSocialNetworks.Execute());
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> HomeContext()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(await _ViewContextFacad.ReturnHomeContextService.ExecuteAsync());
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> TermsOfUseContext()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_ViewContextFacad.ReturnTermsOfUseService.Execute());
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> PrivacyPolicyContext()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_ViewContextFacad.ReturnPrivacyPolicyService.Execute());
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> RemovedReportedBugs(string Filter, int PageIndex)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_ViewContextFacad.ReturnReportBugsService.ReturnAllRemovedItems(new Application.Services.Query.ViewContext.ReturnReportBugs.RequestReturnReprteBugsDto
                {
                    Filter = Formating.FixFilterFormat(Filter),
                    PageIndex = PageIndex,
                    PageSize = 10,
                }));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> ReportedBugs(string Filter, int PageIndex)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_ViewContextFacad.ReturnReportBugsService.ReturnAll(new Application.Services.Query.ViewContext.ReturnReportBugs.RequestReturnReprteBugsDto
                {
                    Filter = Formating.FixFilterFormat(Filter),
                    PageIndex = PageIndex,
                    PageSize = 10,
                }));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> WhyChooseUsContext(int Type)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Type = Type;
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(await _ViewContextFacad.ReturnWhyChooseUsService.ExecuteAsync());
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> ThreeStepHelp(string Filter, int PageIndex)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(await _ViewContextFacad.ReturnTreeStepHelpService.ReturnAllAsync(new Application.Services.Query.ViewContext.ReturnTreeStepHelp.RequestReturnTreeStepHelpListDto
                {
                    Filter = Formating.FixFilterFormat(Filter),
                    PageIndex = PageIndex,
                    PageSize = 12,
                }));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> EditStepsHelpContext(long Id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                var result = await _ViewContextFacad.ReturnTreeStepHelpService.ExecuteAsync(Id);
                if (result.Success)
                    return View(result);
                else
                    return RedirectToAction("NotFound", "AreaError");
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> AboutUsContext()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_ViewContextFacad.ReturnTermsOfUseService.ReturnAboutUs());
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> DmcaContext()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_ViewContextFacad.ReturnTermsOfUseService.ReturnDmca());
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> EditHelpVideo(long Id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                var result = await _ViewContextFacad.ReturnTreeStepHelpService.ExecuteAsync(Id);
                if (result.Success)
                {
                    return View(result);
                }
                else
                    return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/AreaError/NotFound");
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAccounts(RequsetUpdateSocialNetworkViewModel requset)
        {
            return Json(_ViewContextFacad.UpdateSocialNetworksService.Execute(new Application.Services.Command.ViewContext.UpdateSocialNetworks.RequestUpdateSocialNetworksDto
            {
                Id = requset.Id,
                Reddit = requset.Reddit,
                Pinterest = requset.Pinterest,
                Medium = requset.Medium,
                Okru = requset.Okru,
                Tumblr = requset.Tumblr,
                VK = requset.VK,
                Facebook = requset.Facebook,
                Twitter = requset.Twitter,
            }));

        }
        [HttpPost]
        public async Task<IActionResult> UpdateHomeContext(RequestUpdateHomeContextViewModel request)
        {
            return Json(_ViewContextFacad.UpdateHomeContextService.Execute(new Application.Services.Command.ViewContext.UpdateHomeContext.RequestUpdateHomeContextDto
            {
                Id = request.Id,
                MainServicesH2Text = request.MainServicesH2Text,
                MainServicesPText = request.MainServicesPText,
                ServicesInfoH1Text = request.ServicesInfoH1Text,
                ServicesInfoPText = request.ServicesInfoPText,
                TopTitleText = request.TopTitleText
            }));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTermsOfUse(RequestUpdateTermsOfUseViewModel request)
        {
            return Json(_ViewContextFacad.UpdateTermsOfUseService.Execute(new Application.Services.Command.ViewContext.UpdateTermsOfUse.RequestUpdateTermsOfUseDto
            {
                Id = request.Id,
                Text = request.Text,
            }));
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePrivacyPolicy(RequestUpdateTermsOfUseViewModel request)
        {
            return Json(_ViewContextFacad.UpdatePrivacyPolicyService.Execute(new Application.Services.Command.ViewContext.UpdatePrivacyPolicy.RequestUpdatePrivacyPolicyDto
            {
                Id = request.Id,
                Text = request.Text,
            }));
        }
        [HttpPost]
        public async Task<IActionResult> ChangeItemState(long Id, bool State)
        { 
            return Json(_ViewContextFacad.ChangeReportedBugStateService.Execute(Id, State));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWhyChooseUsContext(RequestUpdateWhyChooseUsViewModel request)
        {
            #region Validation
            try
            {
                WhyChooseUsValidation validation = new WhyChooseUsValidation();
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
            }
            catch
            { return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" }); }
            #endregion
            if (request.Type > 0)
            {
                return Json(_ViewContextFacad.UpdateWhyChooseUsService.Execute(new Application.Services.Command.ViewContext.UpdateWhyChooseUs.RequestUpdateWhyChooseUsDto
                {
                    Id = request.Id,
                    Text = request.Text,
                    Title = request.Title,
                    Type = request.Type
                }));
            }
            return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateThreeStepHelpContext(RequestUpdateTreeHelpStepViewModel request)
        {
            #region Validation
            try
            {
                UpdateTreeHelpStepValidation validation = new UpdateTreeHelpStepValidation();
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
            }
            catch
            { return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" }); }
            #endregion
            return Json(_ViewContextFacad.UpdateTreeStepHelpService.Execute(new Application.Services.Command.ViewContext.UpdateTreeStepHelp.RequestUpdateTreeStepHelpDto
            {
                Id = request.Id,
                Step1 = request.Step1,
                Step2 = request.Step2,
                Step3 = request.Step3,
            }));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAboutUsContext(UpdateAboutUsViewModel request)
        {
            #region Validation
            try
            {
                UpdateAboutUsValidation validation = new UpdateAboutUsValidation();
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
            }
            catch
            { return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" }); }
            #endregion
            return Json(_ViewContextFacad.UpdateTermsOfUseService.UpdateAboutUs(new Application.Services.Command.ViewContext.UpdateTermsOfUse.RequestUpdateTermsOfUseDto
            {
                Id = request.Id,
                Text = request.Text
            }));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDmcaContext(UpdateAboutUsViewModel request)
        {
            #region Validation
            try
            {
                UpdateAboutUsValidation validation = new UpdateAboutUsValidation();
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
            }
            catch
            { return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" }); }
            #endregion
            return Json(_ViewContextFacad.UpdateTermsOfUseService.UpdateDmca(new Application.Services.Command.ViewContext.UpdateTermsOfUse.RequestUpdateTermsOfUseDto
            {
                Id = request.Id,
                Text = request.Text
            }));
        }
        [HttpPost]
        [RequestSizeLimit(209715200)]// 200 mb limit
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<IActionResult> UpdateHelpVideo(UpdateHelpVideoViewModel request)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (request.File != null && request.File.Length > 0 && request.Id > 0)
                {
                    if (!Formating.FileFormatingValidation(request.File.FileName, Formating.VideosFormat))
                        return Json(new ResultMessage { Success = false, Message = $"Video in {Path.GetExtension(request.File.FileName).ToLower()} format is not acceptable, You can see the list of allowed formats from the upload page" });
                    var Feature = await _ViewContextFacad.ReturnTreeStepHelpService.ExecuteAsync(request.Id);
                    if (Feature.Success)
                    {
                        string VideoName = $"Help-VID_{Feature.Enything.Service}{Path.GetExtension(request.File.FileName).ToLower()}";
                        //if(Feature.Enything.VideoName != null) { AppliedMethodes.DeleteFile($"{_Environment.ContentRootPath}\\{GetPath.GetHelpVideoPath()}\\{Feature.Enything.VideoName}"); }
                        try
                        {
                            using (FileStream output = System.IO.File.Create($"{_Environment.ContentRootPath}\\{GetPath.GetHelpVideoPath()}\\{VideoName}"))
                                await request.File.CopyToAsync(output);
                            return Json(_ViewContextFacad.UpdateHelpVideoService.Execute(new Application.Services.Command.ViewContext.UpdateHelpVideo.RequestUpdateHelpVideoDto
                            {
                                Id = request.Id,
                                VideoName = VideoName
                            }));
                        }
                        catch
                        {
                            return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
                        }
                    }
                    return Json(new ResultMessage { Success = false, Message = "The service was not found" });
                }
                return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
            }
            return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHomeImage(IFormFile Image, long Id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (Image != null && Id > 0)
                {
                    string[] ValidFormats = new string[] { ".webp", ".png" };
                    if (Formating.FileFormatsValidation(Image.FileName, ValidFormats))
                        return Json(new ResultMessage { Success = false, Message = "Just .webp,.png File Format Valid" });
                    string path;
                    if (Id == 1)
                        path = $"{GetPath.GetHomeImages()}\\{GetPath.HomeTopImage}";
                    else
                        path = $"{GetPath.GetHomeImages()}\\{GetPath.HomeDownImage}";
                    try
                    {
                        using (FileStream output = System.IO.File.Create(path))
                            await Image.CopyToAsync(output);
                        return Json(new ResultMessage { Success = true, Message = "Image Successfully Updated" });
                    }
                    catch { return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" }); }
                }
                return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
            }
            return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
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
