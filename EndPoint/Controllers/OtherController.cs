using Microsoft.AspNetCore.Mvc;
using Common;
using EndPoint.Models.MultiClasses;
using Microsoft.AspNetCore.Localization;
using Application.Interface.FacadPattern;
using Application.Services.Query.ReturnFeatureDetails;
using EndPoint.Models;
using EndPoint.Models.Validation;
using FluentValidation.Results;
using System.Threading.Tasks;
using System.IO;
using Application.Services.Command.AddInpuFile;
using Microsoft.Extensions.Hosting;

namespace EndPoint.Controllers
{
    public class OtherController : Controller
    {
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        private readonly IAncillaryServicesFacad _AncillaryServices;
        private readonly IOtherFeaturesLogService _OtherFeaturesLog;
        private readonly IOtherFeaturesService _OtherFoutures;
        private readonly IViewContextFacad _ViewFacad;
        private readonly IHostEnvironment _Environment;

        public OtherController(IFeaturesDetailsFacad features, IAncillaryServicesFacad ancillary, IOtherFeaturesLogService otherFeaturesLog
            , IOtherFeaturesService otherfoutures, IViewContextFacad view, IHostEnvironment environment)
        {
            _FeaturesDetails = features;
            _AncillaryServices = ancillary;
            _OtherFeaturesLog = otherFeaturesLog;
            _OtherFoutures = otherfoutures;
            _ViewFacad = view;
            _Environment = environment;
        }
        [Route("extract-pdf-images")]
        public async Task<IActionResult> ExtractPdfImages()
        {
            var FetureDetails = _FeaturesDetails.ReturnFeatureDetailsService.Excute(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.OtherFeatures.ExtractImagesFromPdf });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.OtherFeatures.ExtractImagesFromPdf);
            ViewBag.ThreeStepHelp = _ViewFacad.ReturnTreeStepHelpService.FindWithService(Domain.Entities.Features.OtherFeatures.ExtractImagesFromPdf);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.OtherFeatures.ExtractImagesFromPdf,GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }

        [Route("read-pdf")]
        public async Task<IActionResult> ReadPdf()  
        {
            var FetureDetails = _FeaturesDetails.ReturnFeatureDetailsService.Excute(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.OtherFeatures.PdfReader });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.OtherFeatures.PdfReader);
            ViewBag.ThreeStepHelp = _ViewFacad.ReturnTreeStepHelpService.FindWithService(Domain.Entities.Features.OtherFeatures.PdfReader);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.OtherFeatures.PdfReader,GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        
        [HttpPost]
        [RequestSizeLimit(73400320)]
        [RequestFormLimits(MultipartBodyLengthLimit = 73400320)]
        public async Task<IActionResult> ExtractPdfImagesUpload(UploadFileViewModel request)
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
                        var ExtractResult = await _OtherFoutures.ExtractPdfImagesService.ExecuteAsync(new Application.Services.Other.ExtractImages.RequestExtractPdfImagesDto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutputPath = GetPath.GetOutputPath(),
                            UserIp = userip,
                        });
                        if (ExtractResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.OtherFeatures.ExtractImagesFromPdf);
                            // Save Action Log 
                            var savelog = _OtherFeaturesLog.AddNewOtherFeaturesLogService.Execute(new Application.Services.Command.ServicesLog.AddOtherFeaturesLog.RequestAddNewOtherFeaturesLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = ExtractResult.Enything.FileName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.OtherFeatures.ExtractImagesFromPdf,

                            });
                            DeleteInputFile(FullPath, savelog.Enything.Id); //+ Save Action
                            return Json(savelog);
                        }
                        // for prevent overuploading
                        return Json(new ResultMessage<RepOutFileViewModel> { Success = false, Message = "Something Wrong Please Try Again", Enything = new RepOutFileViewModel { FileName = FileName, UserIp = userip } });
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
        public async Task<IActionResult> ReadPdfUpload(UploadFileViewModel request)
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
                    string FileName = Formating.ReturnFileNameWithoutModified(FilesFormat.pdf, "ReadPdf");
                    string FullPath = $"{FilePath}\\{FileName}";
                    #endregion
                    AppliedMethodes.CreateDirectory(FilePath);
                    try
                    {
                        using (FileStream output = System.IO.File.Create(FullPath))
                            await request.file.CopyToAsync(output);

                        SaveInputFileData(FileName, request.file.Length, userip); //Save Input File Details
                        _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.OtherFeatures.ExtractImagesFromPdf);
                        // Save Action Log 
                        var savelog = _OtherFeaturesLog.AddNewOtherFeaturesLogService.Execute(new Application.Services.Command.ServicesLog.AddOtherFeaturesLog.RequestAddNewOtherFeaturesLogDto
                        {
                            FileInputName = FileName,
                            FileOutName = FileName,
                            UserIp = userip,
                            FileInputSize = request.file.Length.ToString(),
                            Type = Domain.Entities.Features.OtherFeatures.PdfReader,

                        });
                        string OutPath = $"{_Environment.ContentRootPath}\\{GetPath.GetReadPdfPath()}\\{userip}";
                        AppliedMethodes.CreateDirectory(OutPath);
                        AppliedMethodes.CopyFile(FullPath, $"{OutPath}\\{FileName}");//Copy File To outFilesPath
                        DeleteInputFile(FullPath, savelog.Enything.Id);
                        if (savelog.Success)
                        {
                            return Json(new ResultMessage<ReturnPdfDetailsForOpen>
                            {
                                Success = true,
                                Enything = new ReturnPdfDetailsForOpen
                                {
                                    Id = savelog.Enything.Id,
                                    FileSize = request.file.Length.ToString()
                                }
                            });
                        }
                        return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
                    }
                    catch { return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" }); }
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
                    Message = "Something Wrong Please Try Again"
                });
            }
            #endregion

            if (!string.IsNullOrWhiteSpace(request.OutFileName) && System.Convert.ToInt64(request.FId) > 0)
            {
                request.OutFileName = AppliedMethodes.FixRequestFormat(request.OutFileName);
                //Check file exist
                var ReturnFile = _OtherFeaturesLog.ReturnOtherFileLogService.Execute(new Application.Services.Query.ReturnOtherFileLog.RequestReturnOtherFileLogDto
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
                Message = "Something Wrong Please Try Again"
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


        private async Task<ResultMessage<ResultAddInputFileDto>> SaveInputFileData(string FileName, long FileSize, string UserIp)
        {
            return await _FeaturesDetails.AddInputFileService.ExecuteAsync(new Application.Services.Command.AddInpuFile.RequestAddInputFileDto
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