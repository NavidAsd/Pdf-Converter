using Application.Interface.FacadPattern;
using Common;
using EndPoint.Models;
using EndPoint.Models.Validation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EndPoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeaturesDetailsFacad _Features;
        private readonly IViewContextFacad _ViewFacad;
        private readonly IAncillaryServicesFacad _AncillaryServices;
        private readonly IInitialDataFacad _iniiii;
        public HomeController(IInitialDataFacad niiii, IFeaturesDetailsFacad features, IViewContextFacad viewFacad, IAncillaryServicesFacad ancillary)
        {
            _Features = features;
            _ViewFacad = viewFacad;
            _AncillaryServices = ancillary;
            _iniiii = niiii;
        }

        [Route("")]
        public IActionResult Index()
        {
            ViewBag.HomeContext = _ViewFacad.ReturnHomeContextService.Execute();
            ViewBag.WhyChooseUsContext = _ViewFacad.ReturnWhyChooseUsService.Execute();
            ViewBag.BlogPosts = _ViewFacad.ReturnBlogPostsService.Execute(GetPath.GetBlogPostCountHome(), null,0);
            ViewBag.BlogPostsSlide = _ViewFacad.ReturnBlogPostsService.Execute(GetPath.GetBlogPostCountHomeSlide(), null, GetPath.GetBlogPostCountHome());
            ViewBag.Images = _ViewFacad.ReturnServiceImage.ReturnHomeImages();
            ViewBag.FAQ = _ViewFacad.ReturnFrequentlyQuestionService.ReturnAll(null, null);
            return View(_Features.ReturnUsersCommnetsService.ReturnAllTopRatingCommnets(GetPath.GetCommentCount(), null));
        }
        [Route("report-bug")]
        public IActionResult ReportBug()
        {
            return View();
        }
        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View(_ViewFacad.ReturnPrivacyPolicyService.Execute());
        }
        [Route("terms-of-use")]
        public IActionResult TermsOfUse()
        {
            return View(_ViewFacad.ReturnTermsOfUseService.Execute());
        }
        [Route("about-us")]
        public IActionResult AboutUs()
        {
            return View(_ViewFacad.ReturnTermsOfUseService.ReturnAboutUs());
        }
        [Route("contact-us")]
        public IActionResult ContactUs()
        {
            return View();
        }
        [Route("dmca")]
        public IActionResult Dmca()
        {
            return View(_ViewFacad.ReturnTermsOfUseService.ReturnDmca());
        }
        [Route("questions")]
        public IActionResult Questions()
        {
            return View(_ViewFacad.ReturnFrequentlyQuestionService.ReturnAll(null, null));
        }
        [Route("services")]
        public IActionResult Services()
        {
            return View();
        }
        [HttpPost]
        [Route("accept")]
        public IActionResult Accept()
        {
            var option = new CookieOptions();
            option.Expires = new System.DateTimeOffset(2038, 1, 1, 0, 0, 0, TimeSpan.FromHours(0));
            if (Request.Cookies[Common.GetPath.GetCookieKey()] == null)
                Response.Cookies.Append(GetPath.GetCookieKey(), "CookieAccepted", option);
            return Json(new ResultMessage { Success = true });
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserMessage(AddNewUserMessageViewModel request)
        {
            #region Validation
            try
            {
                AddNewUserMessageValidation validation = new AddNewUserMessageValidation();
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
            {
                return Json(new ResultMessage
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again"
                });
            }
            #endregion
            var captcha = await _AncillaryServices.GoogleRecaptchaService.Responsewithstring(request.Recaptcha);
            if (captcha.Success)
            {
                return Json(await _Features.AddNewUserMessageService.Execute(new Application.Services.Command.AddNewUserMessage.AddNewUserMessageDto
                {
                    Email = request.Email,
                    Message = request.Message,
                }));
            }
            return Json(captcha);

    }

    [HttpPost]
        public async Task<IActionResult> SaveReportedBug(AddRepoteBugViewModel request)
        {
            #region Validation
            try
            {
                AddReporteBugValidation validation = new AddReporteBugValidation();
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
                if (!AppliedMethodes.UrlValidation(request.Url) && !request.Url.Contains(GetPath.GetDomain()))
                {
                    return Json(new ResultMessage
                    {
                        Success = false,
                        Message = "Please enter a valid url that is relevant to our domain"
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
            var captcha = await _AncillaryServices.GoogleRecaptchaService.Responsewithstring(request.Recaptcha);
            if (captcha.Success)
            {
                return Json(_ViewFacad.AddNewReportBugService.Execute(new Application.Services.Command.ViewContext.AddNewReportBug.RequestAddNewReportBugDto
                {
                    Email = request.Email,
                    Description = request.Problem,
                    Url = request.Url
                }));
            }
            return Json(captcha);
        }
    }
}
