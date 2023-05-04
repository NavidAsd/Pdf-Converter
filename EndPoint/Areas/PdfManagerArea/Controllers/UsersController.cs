using Application.Interface.FacadPattern;
using Common;
using Common.Schema;
using EndPoint.Areas.PdfManagerArea.Models;
using EndPoint.Areas.PdfManagerArea.Models.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Areas.PdfManagerArea.Controllers
{
    [Area("PdfManagerArea")]
    public class UsersController : Controller
    {
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        private readonly IViewContextFacad _ViewContext;
        private readonly IConfiguration _Configuration;

        public UsersController(IFeaturesDetailsFacad features, IViewContextFacad View, IConfiguration configuration)
        {
            _FeaturesDetails = features;
            _ViewContext = View;
            _Configuration = configuration;
        }
        public IActionResult Comments(string Filter, int PageIndex)
        {
            if (!string.IsNullOrWhiteSpace(Filter))
                Filter = Formating.FixFileNameFormat(Filter);

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_FeaturesDetails.ReturnUsersCommnetsService.ReturnAllAcceptedCommnetsForAdmin(new Application.Services.Query.ReturnUsersCommnets.RequestReturnUsersCommentsDto
                {
                    Filter = Filter,
                    PageIndex = PageIndex,
                    PageSize = 25
                }));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public IActionResult UserMessages(string Filter, int PageIndex)
        {
            if (!string.IsNullOrWhiteSpace(Filter))
                Filter = Formating.FixFileNameFormat(Filter);

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_FeaturesDetails.ReturnUserMessagesService.ReturnAll(new Application.Services.Query.ReturnUserMessages.RequestReturnUserMessagesDto
                {
                    Filter = Filter,
                    PageIndex = PageIndex,
                    PageSize = 20,
                }).Result);
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public IActionResult UnAcceptedComments(string Filter, int PageIndex)
        {
            if (!string.IsNullOrWhiteSpace(Filter))
                Filter = Formating.FixFileNameFormat(Filter);

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_FeaturesDetails.ReturnUsersCommnetsService.ReturnAllUnAcceptedCommnetsForAdmin(new Application.Services.Query.ReturnUsersCommnets.RequestReturnUsersCommentsDto
                {
                    Filter = Filter,
                    PageIndex = PageIndex,
                    PageSize = 25
                }));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public IActionResult RemovedComments(string Filter, int PageIndex)
        {
            if (!string.IsNullOrWhiteSpace(Filter))
                Filter = Formating.FixFileNameFormat(Filter);

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_FeaturesDetails.ReturnUsersCommnetsService.ReturnAllDeletedCommnetsForAdmin(new Application.Services.Query.ReturnUsersCommnets.RequestReturnUsersCommentsDto
                {
                    Filter = Filter,
                    PageIndex = PageIndex,
                    PageSize = 25
                }));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public IActionResult FrequentlyQuestions(string Filter, int PageIndex, long? Service)
        {
            if (!string.IsNullOrWhiteSpace(Filter))
                Filter = Formating.FixFileNameFormat(Filter);

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.Service = Service;
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_ViewContext.ReturnFrequentlyQuestionService.ReturnAllForAdmin(new Application.Services.Query.ViewContext.ReturnFrequentlyQuestion.RequestReturnFrequentlyQuestionDto
                {
                    PageSize = 10,
                    PageIndex = PageIndex,
                    Filter = Filter,
                    Service = Service,
                }));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public IActionResult EditFrequentlyQuestion(long Id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                var result = _ViewContext.ReturnFrequentlyQuestionService.FindQuestion(Id);
                if (result.Success)
                    return View(result);
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/AreaError/NotFound");
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public IActionResult Create(long? Service)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                if (Service == null || Service <= 0)
                {
                    ViewBag.Service = null;
                    return View();
                }
                ViewBag.Service = Service;
                ViewBag.Faq = false;
                ViewBag.HowTo = false;
                ViewBag.Video = false;
                if (SchemaAppliedMethodes.CheckSchemaFileExist(Service, SchemaType.Faq))
                    ViewBag.Faq = true;
                if (SchemaAppliedMethodes.CheckSchemaFileExist(Service, SchemaType.HowTo))
                    ViewBag.HowTo = true;
                if (SchemaAppliedMethodes.CheckSchemaFileExist(Service, SchemaType.Video))
                    ViewBag.Video = true;

                var serviceexist = _FeaturesDetails.ReturnFeatureDetailsService.ReturnForAdmin(new Application.Services.Query.ReturnFeatureDetails.RequestReturnFeatureDetailsDto
                {
                    ServiceType = Convert.ToInt32(Service),
                });
                if (serviceexist.Success)
                {
                    ViewBag.ServiceName = serviceexist.Enything.Name;
                    return View();
                }
                ViewBag.Service = null;
                return RedirectToAction("NotFound", "AreaError");
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }

        [HttpPost]
        public IActionResult ChangeRemoveState(string Id, bool State)
        {
            return Json(_FeaturesDetails.ChangeUserCommentStateService.ChangeRemoveState(new Application.Services.Command.ChangeUserCommentState.RequestChangeUserCommentStateDto
            {
                Id = Convert.ToInt64(Id),
                State = State
            }));
        }
        [HttpPost]
        public IActionResult ChangeMessagesState(string Id, bool State)
        {
            return Json(_FeaturesDetails.ChangeUserCommentStateService.ChangeUserMessageState(new Application.Services.Command.ChangeUserCommentState.RequestChangeUserCommentStateDto
            {
                Id = Convert.ToInt64(Id),
                State = State
            }));
        }
        [HttpPost]
        public IActionResult ChangeAccepted(string Id, bool State)
        {
            return Json(_FeaturesDetails.ChangeUserCommentStateService.ChangeAcceptState(new Application.Services.Command.ChangeUserCommentState.RequestChangeUserCommentStateDto
            {
                Id = Convert.ToInt64(Id),
                State = State
            }));
        }
        [HttpPost]
        public IActionResult ChangeQuestionState(string Id, bool State)
        {
            return Json(_ViewContext.UpdateFrequentlyQuestionService.ChangeRemoveState(Convert.ToInt64(Id), State));
        }
        [HttpPost]
        public IActionResult AddNewQuestion(AddNewFrequentlyQuestionViewModel request)
        {
            #region Validation
            try
            {
                AddNewFrequentlyQuestionValidation validation = new AddNewFrequentlyQuestionValidation();
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

            if (request.Service != null && request.Service > 0)
            {
                var service = _FeaturesDetails.ReturnFeatureDetailsService.ReturnForAdmin(new Application.Services.Query.ReturnFeatureDetails.RequestReturnFeatureDetailsDto
                {
                    ServiceType = Convert.ToInt32(request.Service),
                });
                if (service.Success)
                {
                    return Json(_ViewContext.AddNewFrequentlyQuestionService.Execut(new Application.Services.Command.ViewContext.AddNewFrequntlyQuestion.RequestAddNewFrequntlyQuestionDto
                    {
                        Question = request.Question,
                        Answer = request.Answer,
                        Service = request.Service,
                    }));
                }
            }
            return Json(_ViewContext.AddNewFrequentlyQuestionService.Execut(new Application.Services.Command.ViewContext.AddNewFrequntlyQuestion.RequestAddNewFrequntlyQuestionDto
            {
                Question = request.Question,
                Answer = request.Answer,
                Service = null,
            }));

        }
        [HttpPost]
        public IActionResult DeleteSchema(AddNewFrequesntlyQuestionFromFileViewModel request)
        {
            if (request.Service == null)
                request.Service = 0;
            if (HttpContext.User.Identity.IsAuthenticated && request.Service >= 0)
            {
                var result = SchemaAppliedMethodes.GenerateJsonFileFullPath(request.Service, request.Type, Environment.CurrentDirectory.ToString());
                AppliedMethodes.DeleteFile(result.FilePath + "\\" + result.FileName);
                return Json(new ResultMessage { Success = true, Message = "Json File Deleted" });
            }
            return Json(new ResultMessage { Success = true, Message = "Something Worng Tryagain later" });
        }
        [HttpPost]
        [RequestSizeLimit(73400320)]
        [RequestFormLimits(MultipartBodyLengthLimit = 73400320)]
        public async Task<IActionResult> AddNewQuestionFromFile(AddNewFrequesntlyQuestionFromFileViewModel request)
        {
            if (request.File.Length > 0 && request.File != null && request.Type >= 0)
            {
                //File Format Validation
                if (Formating.FileFormatValidation(request.File.FileName, ".json"))
                    return Json(new ResultMessage { Success = false, Message = "File Format Invalid" });
                var GenerateResult = SchemaAppliedMethodes.GenerateJsonFileFullPath(request.Service, request.Type, Environment.CurrentDirectory);
                string FullPath = GenerateResult.FilePath + "\\" + GenerateResult.FileName;
                AppliedMethodes.CreateDirectory(GenerateResult.FilePath);
                try
                {
                    using (FileStream output = System.IO.File.Create(FullPath))
                        await request.File.CopyToAsync(output);
                    if (request.Type == Common.Schema.SchemaType.Faq)
                    {
                        var result = await _ViewContext.AddNewFrequentlyQuestionService.AddWithJsonFile(new Application.Services.Command.ViewContext.AddNewFrequntlyQuestion.RequestAddNewFrequentlyQuestionUsingJsonFileDto
                        {
                            FileName = GenerateResult.FileName,
                            FilePath = GenerateResult.FilePath,
                            Service = request.Service,
                        });
                        return Json(result);
                    }
                    Common.Schema.GetItemsListFromSchema fromSchema = new Common.Schema.GetItemsListFromSchema(FullPath);
                    try
                    {
                        var Fresult = fromSchema.CheckSchema(request.Type);
                        if (Fresult)
                            return Json(new ResultMessage { Success = true, Message = "The json file has been successfully uploaded" });
                        else
                        {
                            AppliedMethodes.DeleteFile(FullPath);
                            return Json(new ResultMessage { Success = false, Message = $"The selected file type must be of [{request.Type.ToString()}] type" });
                        }
                    }
                    catch
                    {
                        return Json(new ResultMessage { Success = true, Message = "The json file has been successfully uploaded" });
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
            }
            return Json(new ResultMessage
            {
                Success = false,
                Message = "The uploaded file may be corrupted!"
            });
        }

        [HttpPost]
        public IActionResult UpdateQuestion(AddNewFrequentlyQuestionViewModel request)
        {
            #region Validation
            try
            {
                AddNewFrequentlyQuestionValidation validation = new AddNewFrequentlyQuestionValidation();
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
            return Json(_ViewContext.UpdateFrequentlyQuestionService.UpdateData(new Application.Services.Command.ViewContext.UpdateFrequentlyQuestion.RequestUpdateFrequentlyQuestionDto
            {
                Question = request.Question,
                Answer = request.Answer,
                Id = request.Id,
            }));
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
