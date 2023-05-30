using Application.Interface.FacadPattern;
using Application.Services.Query.ReturnFeatureDetails;
using Common;
using EndPoint.Models;
using EndPoint.Models.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace EndPoint.Controllers
{
    public class SecurityController : Controller
    {
        private readonly string ControllerName = "Security";
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        private readonly IAncillaryServicesFacad _AncillaryServices;
        private readonly ISecurityLogFacad _SecurityLog;
        private readonly ISecurityFacad _Security;
        private readonly IViewContextFacad _ViewFacad;
        public SecurityController(IFeaturesDetailsFacad features, IAncillaryServicesFacad ancillary, ISecurityLogFacad securitylog,
            ISecurityFacad security, IViewContextFacad view)
        {
            _FeaturesDetails = features;
            _AncillaryServices = ancillary;
            _SecurityLog = securitylog;
            _Security = security;
            _ViewFacad = view;
        }
        [Route("unlock-pdf")]
        public async Task<IActionResult> UnlockPdf()
        {
            var FetureDetails = _FeaturesDetails.ReturnFeatureDetailsService.Excute(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.Security.UnlockPdf });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.Security.UnlockPdf);
            ViewBag.ThreeStepHelp = _ViewFacad.ReturnTreeStepHelpService.FindWithService(Domain.Entities.Features.Security.UnlockPdf);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.Security.UnlockPdf, GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("protect-pdf")]
        public async Task<IActionResult> ProtectPdf()
        {
            var FetureDetails = _FeaturesDetails.ReturnFeatureDetailsService.Excute(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.Security.ProtectPdf });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.Security.ProtectPdf);
            ViewBag.ThreeStepHelp = _ViewFacad.ReturnTreeStepHelpService.FindWithService(Domain.Entities.Features.Security.ProtectPdf);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.Security.ProtectPdf, GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("remove-pdf-protection")]
        public async Task<IActionResult> RemovePdfProtection()
        {
            var FetureDetails = _FeaturesDetails.ReturnFeatureDetailsService.Excute(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.Security.RemvePdfProtection });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.Security.RemvePdfProtection);
            ViewBag.ThreeStepHelp = _ViewFacad.ReturnTreeStepHelpService.FindWithService(Domain.Entities.Features.Security.RemvePdfProtection);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.Security.RemvePdfProtection, GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }

        [HttpPost]
        [RequestSizeLimit(73400320)] // 70 MB in bytes
        [RequestFormLimits(MultipartBodyLengthLimit = 73400320)]
        public async Task<IActionResult> UnlockPdfUpload(UploadFileViewModel request)
        {
            if (request.file.Length > 0 && request.file != null)
            {
                var captcha = await _AncillaryServices.GoogleRecaptchaService.Responsewithstring(request.Recaptcha);
                if (captcha.Success)
                {
                    //File Format Validation
                    if (Formating.FileFormatValidation(request.file.FileName, ".pdf"))
                        return Json(new ResultMessage { Success = false, Message = "File Format Incorrect" });
                    #region Variables
                    var userip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    string FilePath = $"{GetPath.GetInputPath()}\\{userip}";
                    string FileName = Formating.ReturnInputFileName(request.file.FileName);
                    string FullPath = $"{FilePath}\\{FileName}";
                    #endregion
                    AppliedMethodes.CreateDirectory(FilePath);
                    try
                    {
                        using (FileStream output = System.IO.File.Create(FullPath))
                            await request.file.CopyToAsync(output);

                        SaveInputFileData(FileName, request.file.Length, userip); //Save Input File Details
                        var UnlockResult = await _Security.UnlockPdfService.ExecuteAsync(new Application.Services.Security.UnlockPdf.RequestUnlockPdfDto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutputPath = GetPath.GetOutputPath(),
                            UserIp = userip,

                        });
                        if (UnlockResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.Security.UnlockPdf);
                            // Save Action Log 
                            var savelog = _SecurityLog.AddNewSecurityLogService.Execute(new Application.Services.Command.ServicesLog.AddNewSecurityLog.RequestAddNewSecurityLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = UnlockResult.Enything.FileName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.Security.UnlockPdf,

                            });
                            DeleteInputFile(FullPath, savelog.Enything.Id); //+ Save Action
                            if (savelog.Success)
                            {
                                return Json(new ResultMessage<Application.Services.Security.UnlockPdf.ResultUnlockPdfForView>
                                {
                                    Success = savelog.Success,
                                    Message = savelog.Message,
                                    Enything = new Application.Services.Security.UnlockPdf.ResultUnlockPdfForView
                                    {
                                        Id = savelog.Enything.Id,
                                        OutFileName = savelog.Enything.OutFileName,
                                        ProcessTime = UnlockResult.Enything.ProcessTime,
                                        PassFounded = UnlockResult.Enything.Password
                                    },
                                });
                            }
                            return Json(savelog);
                        }
                        return Json(UnlockResult);
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
                return Json(captcha);

            }
            return Json(new ResultMessage
            {
                Success = false,
                Message = "The uploaded file may be corrupted!"
            });
        }

        [HttpPost]
        [RequestSizeLimit(73400320)]
        [RequestFormLimits(MultipartBodyLengthLimit = 73400320)]
        public async Task<IActionResult> ProtectPdfUpload(UploadSecurityFileViewModel request)
        {
            if (request.file.Length > 0 && request.file != null)
            {
                #region Validation
                try
                {
                    UploadSecurityFileValidation validation = new UploadSecurityFileValidation();
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
                        return Json(new ResultMessage { Success = false, Message = "The password is different from repeating it" });
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
                    //File Format Validation
                    if (Formating.FileFormatValidation(request.file.FileName, ".pdf"))
                        return Json(new ResultMessage { Success = false, Message = "File Format Incorrect" });
                    #region Variables
                    var userip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    string FilePath = $"{GetPath.GetInputPath()}\\{userip}";
                    string FileName = Formating.ReturnInputFileName(request.file.FileName);
                    string FullPath = $"{FilePath}\\{FileName}";
                    #endregion
                    AppliedMethodes.CreateDirectory(FilePath);
                    try
                    {
                        using (FileStream output = System.IO.File.Create(FullPath))
                            await request.file.CopyToAsync(output);

                        SaveInputFileData(FileName, request.file.Length, userip); //Save Input File Details
                        var Result = await _Security.ProtectionPdfService.ExecuteAsync(new Application.Services.Security.ProtectedPdf.RequestProtectionPdfDto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutPutPath = GetPath.GetOutputPath(),
                            UserIp = userip,
                            Password = request.Password
                        });
                        if (Result.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.Security.ProtectPdf);
                            // Save Action Log 
                            var savelog = _SecurityLog.AddNewSecurityLogService.Execute(new Application.Services.Command.ServicesLog.AddNewSecurityLog.RequestAddNewSecurityLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = Result.Enything.FileName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.Security.ProtectPdf,

                            });
                            DeleteInputFile(FullPath, savelog.Enything.Id); //+ Save Action
                            return Json(savelog);
                        }
                        return Json(Result);
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
                return Json(captcha);

            }
            return Json(new ResultMessage
            {
                Success = false,
                Message = "The uploaded file may be corrupted!"
            });
        }

        [HttpPost]
        [RequestSizeLimit(73400320)]
        [RequestFormLimits(MultipartBodyLengthLimit = 73400320)]
        public async Task<IActionResult> RemovePdfProtectionUpload(UploadSecurityFileViewModel request)
        {
            if (request.file.Length > 0 && request.file != null)
            {
                request.RePassword = "000";//for prevent validation error
                #region Validation
                try
                {
                    UploadSecurityFileValidation validation = new UploadSecurityFileValidation();
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
                    //File Format Validation
                    if (Formating.FileFormatValidation(request.file.FileName, ".pdf"))
                        return Json(new ResultMessage { Success = false, Message = "File Format Incorrect" });
                    #region Variables
                    var userip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    string FilePath = $"{GetPath.GetInputPath()}\\{userip}";
                    string FileName = Formating.ReturnInputFileName(request.file.FileName);
                    string FullPath = $"{FilePath}\\{FileName}";
                    #endregion
                    AppliedMethodes.CreateDirectory(FilePath);
                    try
                    {
                        using (FileStream output = System.IO.File.Create(FullPath))
                            await request.file.CopyToAsync(output);

                        SaveInputFileData(FileName, request.file.Length, userip); //Save Input File Details
                        var UnlockResult = await _Security.RemovePdfProtectionService.ExecuteAsync(new Application.Services.Security.RemovePdfProtection.RequestRemovePdfProtectionDto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutPutPath = GetPath.GetOutputPath(),
                            UserIp = userip,
                            Password = request.Password
                        });
                        if (UnlockResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.Security.RemvePdfProtection);
                            // Save Action Log 
                            var savelog = _SecurityLog.AddNewSecurityLogService.Execute(new Application.Services.Command.ServicesLog.AddNewSecurityLog.RequestAddNewSecurityLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = UnlockResult.Enything.FileName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.Security.RemvePdfProtection,

                            });
                            DeleteInputFile(FullPath, savelog.Enything.Id); //+ Save Action
                            return Json(savelog);
                        }
                        return Json(UnlockResult);
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
                return Json(captcha);

            }
            return Json(new ResultMessage
            {
                Success = false,
                Message = "The uploaded file may be corrupted!"
            });
        }

        [HttpPost]
        public async Task<IActionResult> SendFileToEmail(SendFileToEmailViewModel request)
        {
            #region Validaton
            try
            {
                SendFileToEmailValidation validation = new SendFileToEmailValidation();
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
                    Message = "Something Wrong Pleas Try Again"
                });
            }
            #endregion

            if (!string.IsNullOrWhiteSpace(request.OutFileName) && System.Convert.ToInt64(request.FId) > 0)
            {
                request.OutFileName = AppliedMethodes.FixRequestFormat(request.OutFileName);
                //Check file exist
                var ReturnFile = _SecurityLog.ReturnSecurityFileLogService.Execute(new Application.Services.Query.ReturnSecurityFileLog.RequestReturnSecurityFileLogDto
                {
                    Id = System.Convert.ToInt64(request.FId),
                    OutFileName = request.OutFileName
                });
                if (ReturnFile.Success)
                {
                    //save email
                    return Json(await _FeaturesDetails.AddNewEmailFileSenderService.ExecuteAsync(new Application.Services.Command.AddNewEmailFileSender.RequestAddNewEmailFileSenderDto
                    {
                        FileName = request.OutFileName,
                        UserEmail = request.UserEmail,
                        UserIp = ReturnFile.Enything.UserIp
                    }));
                }
                return Json(ReturnFile);
            }
            return Json(new ResultMessage
            {
                Success = false,
                Message = "Something Wrong Pleas Try Again"
            });

        }

        [HttpPost]
        public async Task<IActionResult> UserMessage(NewUserMessageViewModel request)
        {
            #region Validation
            try
            {
                NewUserMessageValidation validation = new NewUserMessageValidation();
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
                var service = _FeaturesDetails.ReturnFeatureDetailsService.Excute(new RequestReturnFeatureDetailsDto { ServiceType = request.Service });
                if (service.Success)
                {
                    var commnet = await _FeaturesDetails.AddNewUserCommentService.ExecuteAsync(new Application.Services.Command.AddNewUserComment.RequestAddNewUserCommentDto
                    {
                        UserEmail = request.UserEmail,
                        UserName = request.UserName,
                        Message = request.Message,
                        Service = request.Service,
                        Rate = request.Rate
                    });
                    if (commnet.Success)
                    {
                        _FeaturesDetails.UpdateFeatureDetailsService.UpdateAvgRate(new Application.Services.Command.UpdateFeatureDetails.RequestUpdateFeatureDetailsDto
                        {
                            ServiceType = request.Service,
                            AvgRate = commnet.Enything.AvgRate
                        });
                    }
                    return Json(commnet);
                }
                return Json(service);
            }
            return Json(captcha);
        }

        private async void SaveInputFileData(string FileName, long FileSize, string UserIp)
        {
            await _FeaturesDetails.AddInputFileService.ExecuteAsync(new Application.Services.Command.AddInpuFile.RequestAddInputFileDto
            {
                FileName = FileName,
                FileSize = FileSize.ToString(),
                UserIp = UserIp
            });
        }
        private void DeleteInputFile(string FileFullPath, long Id)
        {
            AppliedMethodes.DeleteFile(FileFullPath);
            _FeaturesDetails.UpdateInputFileService.UpdateFileDeleted(new Application.Services.Command.UpdateInputFileDetail.RequestUpdateInputFileDto
            {
                FileDeleted = true,
                Id = Id
            });

        }


    }
}
