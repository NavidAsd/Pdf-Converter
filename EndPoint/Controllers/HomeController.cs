using Application.Interface.FacadPattern;
using Common;
using EndPoint.Models;
using EndPoint.Models.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> Index()
        {
            ViewBag.HomeContext = await _ViewFacad.ReturnHomeContextService.ExecuteAsync();
            ViewBag.WhyChooseUsContext = await _ViewFacad.ReturnWhyChooseUsService.ExecuteAsync();
            ViewBag.BlogPosts = await _ViewFacad.ReturnBlogPostsFromDbService.GetPostsAsync(GetPath.GetBlogPostCountHome(), null, true);
            ViewBag.BlogPostsSlide = await _ViewFacad.ReturnBlogPostsFromDbService.GetPostsAsync(GetPath.GetBlogPostCountHomeSlide(), null, false);
            ViewBag.Images = await _ViewFacad.ReturnServiceImage.ReturnHomeImagesAsync();
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(null, null);
            return View(await _Features.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), null));
        }
        [Route("report-bug")]
        public async Task<IActionResult> ReportBug()
        {
            return View();
        }
        [Route("privacy")]
        public async Task<IActionResult> Privacy()
        {
            return View(_ViewFacad.ReturnPrivacyPolicyService.Execute());
        }
        [Route("terms-of-use")]
        public async Task<IActionResult> TermsOfUse()
        {
            return View(_ViewFacad.ReturnTermsOfUseService.Execute());
        }
        [Route("about-us")]
        public async Task<IActionResult> AboutUs()
        {
            return View(_ViewFacad.ReturnTermsOfUseService.ReturnAboutUs());
        }
        [Route("contact-us")]
        public async Task<IActionResult> ContactUs()
        {
            return View();
        }
        [Route("dmca")]
        public async Task<IActionResult> Dmca()
        {
            return View(_ViewFacad.ReturnTermsOfUseService.ReturnDmca());
        }
        [Route("questions")]
        public async Task<IActionResult> Questions()
        {
            return View(await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(null, null));
        }
        [Route("services")]
        public async Task<IActionResult> Services()
        {
            return View();
        }
        [HttpPost]
        [Route("accept")]
        public async Task<IActionResult> Accept()
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
