using Application.Interface.FacadPattern;
using Common;
using EndPoint.Areas.PdfManagerArea.Models;
using EndPoint.Areas.PdfManagerArea.Models.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Areas.PdfManagerArea.Controllers
{
    [Area("PdfManagerArea")]
    public class SeoController : Controller
    {
        private readonly ISeoFacad _SeoFacad;
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        public SeoController(ISeoFacad seoFacad, IFeaturesDetailsFacad featuresFacad)
        {
            _SeoFacad = seoFacad;
            _FeaturesDetails = featuresFacad;
        }
        public IActionResult Metatags(string Filter, int PageIndex)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_SeoFacad.ReturnMetatagsService.ReturnAllTags(new Application.Services.Query.Seo.ReturnMetatags.RequestReturnMetatagsDto
                {
                    Filter = Filter,
                    PageIndex = PageIndex,
                    PageSize = 15
                }));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public IActionResult EditMetatag(long Id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                var result = _SeoFacad.ReturnMetatagsService.ReturnTag(Id);
                if (result.Success)
                    return View(result);
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/AreaError/NotFound");
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public IActionResult AddMetaForAll()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                return View(_SeoFacad.ReturnMetatagsService.ReturnTagWithPageName("All"));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public IActionResult MetatagKeywords(string Filter, int PageIndex, long MetaId)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                ViewBag.MetaId = MetaId;
                return View(_SeoFacad.ReturnMetatagKeywordsService.ReturnForAdmin(new Application.Services.Query.Seo.ReturnMetatagKeywords.RequestReturnMetatagKeywordsDto
                {
                    Filter = Filter,
                    PageIndex = PageIndex,
                    PageSize = 15,
                    MetaId = MetaId,
                }));
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }
        public IActionResult CreateKeyword(long MetaId)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Data = LayoutData();
                ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                var result = _SeoFacad.ReturnMetatagsService.ReturnTag(MetaId);
                if (result.Success)
                {
                    ViewBag.MetaId = MetaId;
                    ViewBag.PageName = result.Enything.PageName;
                    return View();
                }
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/AreaError/NotFound");
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
        }

        [HttpPost]
        public IActionResult ChangeTagState(long Id, bool State)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Json(_SeoFacad.UpdateMetatagService.ChangeRemovedState(new Application.Services.Command.Seo.UpdateMetatags.RequetsChangeRemovedStateDto
                {
                    Id = Id,
                    State = State
                }));
            }
            return Json(new ResultMessage { Success = false, Message = "Authentication not performed" });

        }
        [HttpPost]
        public async Task<IActionResult> EditMetatagData(RequestEditMetatagViewModel request)
        {
            #region Validation
            try
            {
                EdtiMetatagValidation validation = new EdtiMetatagValidation();
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
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Json(_SeoFacad.UpdateMetatagService.UpdateTags(new Application.Services.Command.Seo.UpdateMetatags.RequestUpdateMetatagDto
                {
                    Id = request.Id,
                    Title = request.Title,
                    Author = request.Author,
                    Description = request.Description,
                    Other = request.Other,

                }));
            }
            return Json(new ResultMessage { Success = false, Message = "Authentication not performed" });
        }
        [HttpPost]
        public IActionResult RemoveKeyword(long Id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Json(_SeoFacad.UpdateMetatagKeywordService.ChangeRemoveState(new Application.Services.Command.Seo.UpdateMetatagKeyword.RequestChangeRemoveStateKeywordDto
                {
                    Id = Id,
                }));
            }
            return Json(new ResultMessage { Success = false, Message = "Authentication not performed" });

        }
        [HttpPost]
        public IActionResult UpdateKeyWord(RequestUpdateMetatagKeywordViewModel request)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                #region Validation
                try
                {
                    UpdateMetatagKeywordValidation validation = new UpdateMetatagKeywordValidation();
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

                return Json(_SeoFacad.UpdateMetatagKeywordService.UpdateKey(new Application.Services.Command.Seo.UpdateMetatagKeyword.RequestUpdateKeywordDto
                {
                    Id = request.Id,
                    Key = request.Keyword
                }));
            }
            return Json(new ResultMessage { Success = false, Message = "Authentication not performed" });

        }
        [HttpPost]
        public IActionResult AddNewKeys(List<KeywordsViewModel> request, long MetaId)
        {
            if (request.Count > 0 && MetaId > 0)
            {
                Application.Services.Command.Seo.AddNewMetatagKeywords.RequestAddNewKeywordsDto key;
                List<Application.Services.Command.Seo.AddNewMetatagKeywords.RequestAddNewKeywordsDto> keys = new List<Application.Services.Command.Seo.AddNewMetatagKeywords.RequestAddNewKeywordsDto>();
                foreach (var item in request)
                {
                    if (!string.IsNullOrWhiteSpace(item.Key))
                    {
                        key = new Application.Services.Command.Seo.AddNewMetatagKeywords.RequestAddNewKeywordsDto();
                        key.Keyword = item.Key;
                        key.MetaId = MetaId;
                        keys.Add(key);
                    }
                }
                return Json(_SeoFacad.AddNewKeywordsService.Execute(keys));
            }
            return Json(new ResultMessage { Success = false, Message = "Please add at least one field to the table" });
        }
        [HttpPost]
        public async Task<IActionResult> AddTagsForAll(AddMetatagForAllViewModel request)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var result = await _SeoFacad.AddNewKeywordsService.AddNewMetatagsForAllPages(request.Tags);
                return Json(result);
            }
            return Json(new ResultMessage { Success = false, Message = "Authentication not performed" });
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
