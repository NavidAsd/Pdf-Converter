using Application.Interface.FacadPattern;
using Microsoft.AspNetCore.Mvc;
using Common;
using System;
using System.Linq;
using System.Security.Claims;
using EndPoint.Areas.PdfManagerArea.Models;
using EndPoint.Areas.PdfManagerArea.Models.Validation;
using FluentValidation.Results;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EndPoint.Areas.PdfManagerArea.Controllers
{
    [Area("PdfManagerArea")]
    public class ServicesController : Controller
    {
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        private readonly IViewContextFacad _ViewContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ServicesController(IFeaturesDetailsFacad featuresdetails, IViewContextFacad viewContext, IHostingEnvironment environment)
        {
            _FeaturesDetails = featuresdetails;
            _ViewContext = viewContext;
            _hostingEnvironment = environment;
        }
        public IActionResult Index(string? Filter)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_FeaturesDetails.GetAllFeaturesDetailsService.Execute(Formating.FixFilterFormat(Filter)));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");

        }
        public IActionResult Edit(int Service)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (Service > 0)
                {
                    ViewBag.Data = LayoutData();
                    ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                    return View(_FeaturesDetails.ReturnFeatureDetailsService.ReturnForAdmin(new Application.Services.Query.ReturnFeatureDetails.RequestReturnFeatureDetailsDto { ServiceType = Service }));
                }
                else
                    return RedirectToAction("NotFound", "Error");
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");

        }

        public IActionResult AdditionalHelp()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_ViewContext.ReturnAdditionalHelpService.ReturnAllForAdmin());
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> EditBlock(long Id, int Type)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                ViewBag.Type = Type;
                if (Type > 0 && Type < 4)
                    return View(await _ViewContext.ReturnAdditionalHelpService.ReturnWithIdAsync(Id));
                else
                    return RedirectToAction("NotFound", "Error");
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> EditAdditionalHelp(long Id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(await _ViewContext.ReturnAdditionalHelpService.ReturnWithIdAsync(Id));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        [HttpPost]
        public IActionResult UpdateBasicAdditionalHelp(UpdateAdditionalViewModel request)
        {
            #region Validation
            try
            {
                UpdateBasicAdditionalHelpValidation validation = new UpdateBasicAdditionalHelpValidation();
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
            return Json(_ViewContext.UpdateAdditionalHelpService.UpdateBasic(new Application.Services.Command.ViewContext.UpdateAdditionalHelp.RequestUpdateAdditionalHelpDto
            {
                Id = request.Id,
                Title = request.Title,
                HelpContext = request.HelpContext,
                ServiceDescription = request.ServiceDescription,
            }));
        }
        [HttpPost]
        public IActionResult UpdateOneBlockAdditionalHelp(UpdateOnePartAdditionalViewModel request)
        {
            #region Validation
            try
            {
                UpdateOnePartAdditionalHelpValidation validation = new UpdateOnePartAdditionalHelpValidation();
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
            return Json(_ViewContext.UpdateAdditionalHelpService.UpdateOnePart(new Application.Services.Command.ViewContext.UpdateAdditionalHelp.RequestUpdateOnePartAdditionalHelpDto
            {
                BlockTitle = request.BlockTitle,
                Id = request.Id,
                Text = request.Text,
                Type = request.Type
            }));
        }
        [HttpPost]
        public IActionResult ChangeStatusAdditional(long Id, bool State)
        {
            return Json(_ViewContext.UpdateAdditionalHelpService.ChangeState(Id, State));
        }
        [HttpPost]
        public IActionResult ChangeState(int Service, bool State)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (Service > 0)
                {
                    return Json(_FeaturesDetails.ChangeFeatureStateService.Execute(new Application.Services.Command.ChangeServiceState.RequestChangeFeatureStateDto
                    {
                        Service = Service,
                        State = State
                    }));
                }
                return Json(new ResultMessage { Success = false, Message = "Something Worng Please Try Again" });
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }

        [HttpPost]
        public IActionResult EditDetails(EditServiceDetailsViewModel request)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                /*try
                {
                    EditServiceDetailsValidation validation = new EditServiceDetailsValidation();
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
                    } */
                try
                {
                    return Json(_FeaturesDetails.EditFeatureDetailsService.Execute(new Application.Services.Command.EditServiceDetails.RequestEditFeatureDetailsDto
                    {
                        Service = request.Service,
                        HelpContext = request.HelpContext,
                        Description = request.Description,
                        FirstParagraph = request.FirstParagraph,
                        SecendParagraph = request.SecendParagraph,
                    }));
                }
                catch { return Json(new ResultMessage { Success = false, Message = "Something Worng Please Try Again" }); }
                /*}
                catch { return Json(new ResultMessage { Success = false, Message = "Something Worng Please Try Again" }); }*/
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateImage(IFormFile Image, ServiceUpdateImageDetails ImageDetails)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string[] ValidFormats = new string[] { ".webp", ".png" };
                if (Image != null && !string.IsNullOrWhiteSpace(ImageDetails.Name))
                {
                    if (Formating.FileFormatsValidation(Image.FileName, ValidFormats))
                        return Json(new ResultMessage { Success = false, Message = "Just .webp,.png File Format Valid" });
                    string path = $"{GetPath.GetServiceImages()}\\pdfconverter-{ImageDetails.Name}{Path.GetExtension(Image.FileName).ToLower()}";
                    try
                    {
                        using (FileStream output = System.IO.File.Create(path))
                            await Image.CopyToAsync(output);
                        DeleteOldServiceImage($"{GetPath.GetServiceImages()}\\pdfconverter-{ImageDetails.Name}", Path.GetExtension(Image.FileName).ToLower());
                        var Result = _FeaturesDetails.UpdateFeatureDetailsService.UpdateImageFormat(new Application.Services.Command.UpdateFeatureDetails.RequestUpdateServiceImageDetailsDto
                        {
                            ServiceName = ImageDetails.Name,
                            ImageAlt = ImageDetails.Alt,
                            ImageTitle = ImageDetails.Title,
                            ImageFormat = Path.GetExtension(Image.FileName).ToLower(),
                        });
                        if (Result.Success)
                            return Json(new ResultMessage { Success = true, Message = "Image Successfully Updated" });
                        return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
                    }
                    catch { return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" }); }
                }
                return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
            }
            return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public async Task<IActionResult> DownloadSchema(long? Service, Common.Schema.SchemaType Type)
        {
            try
            {
                long LService = Service == null ? 0 : (long)Service;
                string FileName = null;
                if (Common.Schema.SchemaType.Faq == Type)
                    FileName = $"{Formating.StandardFaqSchemaFileName}{Service}.json";
                else if (Common.Schema.SchemaType.HowTo == Type)
                    FileName = $"{Formating.StandardHowToSchemaFileName}{Service}.json";
                string path = _hostingEnvironment.ContentRootPath;
                if (Type == Common.Schema.SchemaType.Faq)
                    path += $"\\{GetPath.GetSchemaFaqJsonPath()}\\{FileName}";
                else if (Type == Common.Schema.SchemaType.HowTo)
                    path += $"\\{GetPath.GetSchemaHowToJsonPath()}\\{FileName}";
                path = path.Replace("/", "\\");
                var memory = new MemoryStream();
                using (var stream = new FileStream(@path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, MimeTypes.FallbackMimeType, FileName);
            }
            catch (Exception ex)
            {
                return Json(new ResultMessage
                {
                    Success = false,
                    Message = "File Not Found"
                });
            }
        }

        private void DeleteOldServiceImage(string FullPath, string ImageFormat)
        {
            if (ImageFormat == ".webp")
                AppliedMethodes.DeleteFile(FullPath + ".png");
            else if (ImageFormat == ".png")
                AppliedMethodes.DeleteFile(FullPath + ".webp");
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
