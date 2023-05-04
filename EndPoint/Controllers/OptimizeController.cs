using Application.Interface.FacadPattern;
using Application.Services.Optimizers.ComperssionPdf;
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
    public class OptimizeController : Controller
    {
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        private readonly IAncillaryServicesFacad _AncillaryServices;
        private readonly IOptimizersLogFacad _OptimizeLog;
        private readonly IOptimizersFacad _Optimize;
        private readonly IViewContextFacad _ViewFacad;
        public OptimizeController(IFeaturesDetailsFacad features, IAncillaryServicesFacad ancillary, IOptimizersLogFacad optimizelog,
            IOptimizersFacad optimize, IViewContextFacad view)
        {
            _FeaturesDetails = features;
            _AncillaryServices = ancillary;
            _OptimizeLog = optimizelog;
            _Optimize = optimize;
            _ViewFacad = view;
        }
        [Route("compress-pdf")]
        public IActionResult CompressPdf()
        {
            var FetureDetails = _FeaturesDetails.ReturnFeatureDetailsService.Excute(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.Optimizers.CompressPdf });
            ViewBag.Comments = _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnets(GetPath.GetCommentCount(), Domain.Entities.Features.Optimizers.CompressPdf);
            ViewBag.ThreeStepHelp = _ViewFacad.ReturnTreeStepHelpService.FindWithService(Domain.Entities.Features.Optimizers.CompressPdf);
            ViewBag.FAQ = _ViewFacad.ReturnFrequentlyQuestionService.ReturnAll(Domain.Entities.Features.Optimizers.CompressPdf,GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }

        [HttpPost]
        [RequestSizeLimit(73400320)]
        [RequestFormLimits(MultipartBodyLengthLimit = 73400320)]
        public async Task<IActionResult> CompressPdfUpoad(UploadFileViewModel request)
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
                        var CompressResult = await _Optimize.ComperssingPdfService.ExecuteAsync(new Application.Services.Optimizers.ComperssionPdf.RequestComperssingPdfDto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutputPath = GetPath.GetOutputPath(),
                            UserIp = userip,
                        });
                        if (CompressResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.OtherFeatures.ExtractImagesFromPdf);
                            // Save Action Log 
                            var savelog = _OptimizeLog.AddNewOptimizeLogService.Execute(new Application.Services.Command.ServicesLog.AddNewOptimizeLog.RequestAddNewOptimizeLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = CompressResult.Enything.OutFileName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.OtherFeatures.ExtractImagesFromPdf,

                            });
                            DeleteInputFile(FullPath, savelog.Enything.Id); //+ Save Action
                            if (!savelog.Success)
                            {
                                return Json(new ResultMessage<ReturnDataForController>
                                {
                                    Success = savelog.Success,
                                    Message = savelog.Message
                                });
                            }
                            return Json(new ResultMessage<ReturnDataForController>
                            {
                                Success = savelog.Success,
                                Message = savelog.Message,
                                Enything = new ReturnDataForController
                                {
                                    InputFileSize = Formating.SizeSuffix(request.file.Length),
                                    OutFileSize = Formating.SizeSuffix(CompressResult.Enything.OutFileSize),
                                    OutFileName = savelog.Enything.OutFileName,
                                    Id = savelog.Enything.Id,
                                }
                            });

                        }
                        return Json(CompressResult);
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
                    Message = "Something Wrong Please Try Again"
                });
            }
            #endregion

            if (!string.IsNullOrWhiteSpace(request.OutFileName) && System.Convert.ToInt64(request.FId) > 0)
            {
                request.OutFileName = AppliedMethodes.FixRequestFormat(request.OutFileName);
                //Check file exist
                var ReturnFile = _OptimizeLog.ReturnOptimizedFileLogService.Execute(new Application.Services.Query.ReturnOptimizedFileLog.RequestReturnOptimizedFileLogDto
                {
                    Id = System.Convert.ToInt64(request.FId),
                    OutFileName = request.OutFileName
                });
                if (ReturnFile.Success)
                {
                    //save email
                    return Json( await _FeaturesDetails.AddNewEmailFileSenderService.ExecuteAsync(new Application.Services.Command.AddNewEmailFileSender.RequestAddNewEmailFileSenderDto
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
