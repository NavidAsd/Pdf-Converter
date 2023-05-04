using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common;
using System.IO;
using System.Threading.Tasks;
using Application.Interface.FacadPattern;
using Microsoft.AspNetCore.Localization;
using EndPoint.Models.MultiClasses;
using EndPoint.Models;
using Application.Services.Query.ReturnFeatureDetails;
using EndPoint.Models.Validation;
using FluentValidation.Results;
using Application.Services.Query.ReturnConvertedFileLog;
using Application.UseServices;

namespace EndPoint.Controllers
{//adobe api key:     e00d1fde6bc74aeb9494c62871ad22ed
    public class ConvertFromPdfController : Controller
    {
        private readonly IConvertersFromPdfFacad _Converter;
        private readonly IConvertLogFacad _ConvertLog;
        private readonly IAncillaryServicesFacad _AncillaryServices;
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        private readonly IViewContextFacad _ViewFacad;
        public ConvertFromPdfController(IConvertersFromPdfFacad converter, IConvertLogFacad convertlog, IAncillaryServicesFacad ancillaryservices,
            IFeaturesDetailsFacad featuresdetails, IViewContextFacad view)
        {
            _Converter = converter;
            _ConvertLog = convertlog;
            _AncillaryServices = ancillaryservices;
            _FeaturesDetails = featuresdetails;
            _ViewFacad = view;
        }
        [Route("pdf-to-ppt/")]
        public IActionResult PdfToPpt()
        {
            var FetureDetails = _FeaturesDetails.ReturnFeatureDetailsService.Excute(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.ConvertFromPdf.PdfToPpt });
            ViewBag.Comments = _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnets(GetPath.GetCommentCount(), Domain.Entities.Features.ConvertFromPdf.PdfToPpt);
            ViewBag.ThreeStepHelp = _ViewFacad.ReturnTreeStepHelpService.FindWithService(Domain.Entities.Features.ConvertFromPdf.PdfToPpt);
            ViewBag.FAQ = _ViewFacad.ReturnFrequentlyQuestionService.ReturnAll(Domain.Entities.Features.ConvertFromPdf.PdfToPpt,GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("pdf-to-images/")]
        public IActionResult PdfToImages()
        {
            var FetureDetails = _FeaturesDetails.ReturnFeatureDetailsService.Excute(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.ConvertFromPdf.PdfToJpg });
            ViewBag.Comments = _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnets(GetPath.GetCommentCount(), Domain.Entities.Features.ConvertFromPdf.PdfToJpg);
            ViewBag.ThreeStepHelp = _ViewFacad.ReturnTreeStepHelpService.FindWithService(Domain.Entities.Features.ConvertFromPdf.PdfToJpg);
            ViewBag.FAQ = _ViewFacad.ReturnFrequentlyQuestionService.ReturnAll(Domain.Entities.Features.ConvertFromPdf.PdfToJpg,GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("pdf-to-word")]
        public IActionResult PdfToWord()
        {
            var FetureDetails = _FeaturesDetails.ReturnFeatureDetailsService.Excute(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.ConvertFromPdf.PdfToDoc });
            ViewBag.Comments = _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnets(GetPath.GetCommentCount(), Domain.Entities.Features.ConvertFromPdf.PdfToDoc);
            ViewBag.ThreeStepHelp = _ViewFacad.ReturnTreeStepHelpService.FindWithService(Domain.Entities.Features.ConvertFromPdf.PdfToDoc);
            ViewBag.Images = _ViewFacad.ReturnServiceImage.ReturnServiceImage(Domain.Entities.Features.ConvertFromPdf.PdfToDoc);
            ViewBag.FAQ = _ViewFacad.ReturnFrequentlyQuestionService.ReturnAll(Domain.Entities.Features.ConvertFromPdf.PdfToDoc,GetPath.GetFAQCount()); //FAQ
           if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("pdf-to-pdfa")]
        public IActionResult PdfToPdfA()
        {
            var FetureDetails = _FeaturesDetails.ReturnFeatureDetailsService.Excute(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.ConvertFromPdf.PdfToPdfA });
            ViewBag.Comments = _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnets(GetPath.GetCommentCount(), Domain.Entities.Features.ConvertFromPdf.PdfToPdfA);
            ViewBag.ThreeStepHelp = _ViewFacad.ReturnTreeStepHelpService.FindWithService(Domain.Entities.Features.ConvertFromPdf.PdfToPdfA);
            ViewBag.FAQ = _ViewFacad.ReturnFrequentlyQuestionService.ReturnAll(Domain.Entities.Features.ConvertFromPdf.PdfToPdfA,GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }

        [HttpPost]
        [RequestSizeLimit(73400320)] // 70 MB in bytes
        [RequestFormLimits(MultipartBodyLengthLimit = 73400320)]
        public async Task<IActionResult> PdfToPptUpload(UploadFileViewModel request)
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
                                                                                  //Start Converting Proccess
                        var convertResult = await _Converter.PdfToPowerPointService.ExecuteAsync(new Application.Services.ConvertFormPdf.PdfToPower.RequestPdfToPowerPointDto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutputPath = GetPath.GetOutputPath(),
                            UserIp = userip
                        });
                        if (convertResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.ConvertFromPdf.PdfToPpt);
                            // Save Action Log 
                            var savelog = _ConvertLog.AddNewConvertLogService.Execute(new Application.Services.Command.ServicesLog.AddNewConvertLog.RequestAddNewConvertLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = convertResult.Enything.PPTName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.ConvertFromPdf.PdfToPpt,

                            });
                            DeleteInputFile(FullPath, savelog.Enything.Id); //+ Save Action
                            return Json(savelog);
                        }
                        return Json(convertResult);
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
        public async Task<IActionResult> PdfToImageUpload(UploadFileViewModel request)
        {
            if (request.file.Length > 0 && request.file != null && request.Service > 0)
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
                                                                                  //Start Converting Proccess
                        UseConvertToImages UseService = new UseConvertToImages();
                        var convertResult = UseService.PdfToImages(new RequestUseConvertToImagesServiceDto
                        {
                            PdfFullPath = FullPath,
                            ImagesPath = GetPath.GetOutputPath(),
                            UserIp = userip,
                            ServiceType = request.Service,
                        }, _Converter);
                        if (convertResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(request.Service);
                            // Save Action Log 
                            var savelog = _ConvertLog.AddNewConvertLogService.Execute(new Application.Services.Command.ServicesLog.AddNewConvertLog.RequestAddNewConvertLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = convertResult.Enything.ImageName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = request.Service,
                            });
                            DeleteInputFile(FullPath, savelog.Enything.Id); //+ Save Action
                            return Json(savelog);
                        }
                        return Json(convertResult);
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
        public async Task<IActionResult> PdfToWordUpload(UploadFileViewModel request)
        {
            if (request.file.Length > 0 && request.file != null && request.Service >= 0 && request.Service < 2)
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
                                                                                  //Start Converting Proccess
                        var convertResult = await _Converter.PdfToWordService.ExecuteAsync(new Application.Services.ConvertFormPdf.PdfToWord.RequestPdfToWordDto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutputPath = GetPath.GetOutputPath(),
                            UserIp = userip,
                            DocFormat = (SautinSoft.PdfFocus.CWordOptions.eWordDocument)request.Service
                        });
                        if (convertResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.ConvertFromPdf.PdfToDoc);
                            // Save Action Log 
                            var savelog = _ConvertLog.AddNewConvertLogService.Execute(new Application.Services.Command.ServicesLog.AddNewConvertLog.RequestAddNewConvertLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = convertResult.Enything.DocName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.ConvertFromPdf.PdfToDoc,

                            });
                            DeleteInputFile(FullPath, savelog.Enything.Id); //+ Save Action
                            return Json(savelog);
                        }
                        return Json(convertResult);
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
        public async Task<IActionResult> PdfTPdfAUpload(UploadFileViewModel request)
        {
            if (request.file.Length > 0 && request.file != null && request.Type > 0)
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
                                                                                  //Start Converting Proccess
                        var convertResult = _Converter.PdfToPdfAService.Execute(new Application.Services.ConvertFormPdf.PdfToPdfA.RequestPdfToPdfADto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutputPath = GetPath.GetOutputPath(),
                            UserIp = userip,
                            PdfAType = request.Type
                        });
                        if (convertResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.ConvertFromPdf.PdfToPdfA);
                            // Save Action Log 
                            var savelog = _ConvertLog.AddNewConvertLogService.Execute(new Application.Services.Command.ServicesLog.AddNewConvertLog.RequestAddNewConvertLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = convertResult.Enything.DocName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.ConvertFromPdf.PdfToPdfA,
                            });
                            DeleteInputFile(FullPath, savelog.Enything.Id); //+ Save Action
                            return Json(savelog);
                        }
                        return Json(convertResult);
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
                var ReturnFile = _ConvertLog.ReturnConvertedFileLogService.Execute(new RequestReturnConvertedFileLogDto
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


        /* private ResultMessage<ResultReturnCheckFileLogDto> CheckFileExist(long Id, string OutFileName, Domain.Entities.Logs.AllServicesLog ServiceType)
         {
             switch (ServiceType)
             {
                 case Domain.Entities.Logs.AllServicesLog.ConverterLog:
                     return _ConvertLog.ReturnConvertedFileLogService.Execute(new RequestReturnConvertedFileLogDto
                     {
                         Id = Id,
                         OutFileName = OutFileName
                     });
                 case Domain.Entities.Logs.AllServicesLog.OptimizersLog:
                     return null;
                 case Domain.Entities.Logs.AllServicesLog.OrganizersLog:
                     return null;
                 case Domain.Entities.Logs.AllServicesLog.SecurityLog:
                     return null;
                 case Domain.Entities.Logs.AllServicesLog.OtherFeaturesLog:
                     return null;
                 default: return null;
             }
         }*/

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