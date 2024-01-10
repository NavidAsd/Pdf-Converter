using Application.Interface.FacadPattern;
using Application.Services.Query.ReturnConvertedFileLog;
using Application.Services.Query.ReturnFeatureDetails;
using Common;
using EndPoint.Models;
using EndPoint.Models.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EndPoint.Controllers
{
    public class ConvertToPdfController : Controller
    {
        private readonly IConvertersToPdfFacad _Converter;
        private readonly IConvertLogFacad _ConvertLog;
        private readonly IAncillaryServicesFacad _AncillaryServices;
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        private readonly IViewContextFacad _ViewFacad;
        public ConvertToPdfController(IConvertersToPdfFacad converter, IConvertLogFacad convertLog, IAncillaryServicesFacad ancillaryServices,
            IFeaturesDetailsFacad featuresDetails, IViewContextFacad view)
        {
            _Converter = converter;
            _ConvertLog = convertLog;
            _AncillaryServices = ancillaryServices;
            _FeaturesDetails = featuresDetails;
            _ViewFacad = view;
        }

        [Route("ppt-to-pdf")]
        public async Task<IActionResult> PptToPdf()
        {
            var FetureDetails = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.ConverterToPdf.PptToPdf });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.ConverterToPdf.PptToPdf);
            ViewBag.ThreeStepHelp = await _ViewFacad.ReturnTreeStepHelpService.FindWithServiceAsync(Domain.Entities.Features.ConverterToPdf.PptToPdf);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.ConverterToPdf.PptToPdf, GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("word-to-pdf")]
        public async Task<IActionResult> WordToPdf()
        {
            var FetureDetails = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.ConverterToPdf.DocToPdf });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.ConverterToPdf.DocToPdf);
            ViewBag.ThreeStepHelp = await _ViewFacad.ReturnTreeStepHelpService.FindWithServiceAsync(Domain.Entities.Features.ConverterToPdf.DocToPdf);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.ConverterToPdf.DocToPdf, GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("excel-to-pdf")]
        public async Task<IActionResult> ExcelToPdf()
        {
            var FetureDetails = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.ConverterToPdf.ExcelToPdf });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.ConverterToPdf.ExcelToPdf);
            ViewBag.ThreeStepHelp = await _ViewFacad.ReturnTreeStepHelpService.FindWithServiceAsync(Domain.Entities.Features.ConverterToPdf.ExcelToPdf);
            ViewBag.Images = await _ViewFacad.ReturnServiceImage.ReturnServiceImageAsync(Domain.Entities.Features.ConverterToPdf.ExcelToPdf);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.ConverterToPdf.ExcelToPdf, GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("images-to-pdf")]
        public async Task<IActionResult> ImagesToPdf()
        {
            var FetureDetails = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.ConverterToPdf.ImagesToPdf });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.ConverterToPdf.ImagesToPdf);
            ViewBag.ThreeStepHelp = await _ViewFacad.ReturnTreeStepHelpService.FindWithServiceAsync(Domain.Entities.Features.ConverterToPdf.ImagesToPdf);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.ConverterToPdf.ImagesToPdf, GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("html-to-pdf")]
        public async Task<IActionResult> HtmlToPdf()
        {
            var FetureDetails = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.ConverterToPdf.HtmlToPdf });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.ConverterToPdf.HtmlToPdf);
            ViewBag.ThreeStepHelp = await _ViewFacad.ReturnTreeStepHelpService.FindWithServiceAsync(Domain.Entities.Features.ConverterToPdf.HtmlToPdf);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.ConverterToPdf.HtmlToPdf, GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("html-css-to-pdf")]
        public async Task<IActionResult> HtmlCssToPdf()
        {
            var FetureDetails = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.ConverterToPdf.HtmlToPdf });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.ConverterToPdf.HtmlToPdf);
            ViewBag.ThreeStepHelp = await _ViewFacad.ReturnTreeStepHelpService.FindWithServiceAsync(Domain.Entities.Features.ConverterToPdf.HtmlToPdf);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.ConverterToPdf.HtmlToPdf, GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }

        [HttpPost]
        [RequestSizeLimit(73400320)] // 70 MB in bytes
        [RequestFormLimits(MultipartBodyLengthLimit = 73400320)]
        public async Task<IActionResult> PptToPdfUpload(UploadFileViewModel request)
        {
            if (request.file.Length > 0 && request.file != null)
            {
                var captcha = await _AncillaryServices.GoogleRecaptchaService.Responsewithstring(request.Recaptcha);
                if (captcha.Success)
                {
                    //File Format Validation
                    if (Formating.FileFormatValidation(request.file.FileName, ".ppt") && Formating.FileFormatValidation(request.file.FileName, ".pptx"))
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
                        var convertResult = await _Converter.PptToPdfService.ExecuteAsync(new Application.Services.ConvertToPdf.PptToPdf.RequestPptToPdfDto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutputPath = GetPath.GetOutputPath(),
                            UserIp = userip
                        });
                        if (convertResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.ConverterToPdf.PptToPdf);
                            // Save Action Log 
                            var savelog = _ConvertLog.AddNewConvertLogService.Execute(new Application.Services.Command.ServicesLog.AddNewConvertLog.RequestAddNewConvertLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = convertResult.Enything.OutFile,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.ConverterToPdf.PptToPdf,

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
        public async Task<IActionResult> WordToPdfUpload(UploadFileViewModel request)
        {
            if (request.file.Length > 0 && request.file != null)
            {
                var captcha = await _AncillaryServices.GoogleRecaptchaService.Responsewithstring(request.Recaptcha);
                if (captcha.Success)
                {
                    //File Format Validation
                    if (Formating.FileFormatValidation(request.file.FileName, ".docx") && Formating.FileFormatValidation(request.file.FileName, ".rtf"))
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
                        var convertResult = await _Converter.WordToPdfService.ExecuteAsync(new Application.Services.ConvertToPdf.WordToPdf.RequestWordToPdfDto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutputPath = GetPath.GetOutputPath(),
                            UserIp = userip
                        });
                        if (convertResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.ConverterToPdf.DocToPdf);
                            // Save Action Log 
                            var savelog = _ConvertLog.AddNewConvertLogService.Execute(new Application.Services.Command.ServicesLog.AddNewConvertLog.RequestAddNewConvertLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = convertResult.Enything.PdfName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.ConverterToPdf.DocToPdf,

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
        public async Task<IActionResult> ExcelToPdfUpload(UploadFileViewModel request)
        {
            if (request.file.Length > 0 && request.file != null)
            {
                var captcha = await _AncillaryServices.GoogleRecaptchaService.Responsewithstring(request.Recaptcha);
                if (captcha.Success)
                {
                    //File Format Validation
                    if (Formating.FileFormatValidation(request.file.FileName, ".xlsx") && Formating.FileFormatValidation(request.file.FileName, ".xls"))
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
                        var convertResult = await _Converter.ExcelToPdfService.ExecuteAsync(new Application.Services.ConvertToPdf.ExcelToPdf.RequestExcelToPdfDto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutputPath = GetPath.GetOutputPath(),
                            UserIp = userip
                        });
                        if (convertResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.ConverterToPdf.ExcelToPdf);
                            // Save Action Log 
                            var savelog = _ConvertLog.AddNewConvertLogService.Execute(new Application.Services.Command.ServicesLog.AddNewConvertLog.RequestAddNewConvertLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = convertResult.Enything.PdfName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.ConverterToPdf.ExcelToPdf,

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
        public async Task<IActionResult> ImageToPdfUpload(List<IFormFile> file, string Recaptcha)
        {
            if (file.Count > 0)
            {
                var captcha = await _AncillaryServices.GoogleRecaptchaService.Responsewithstring(Recaptcha);
                if (captcha.Success)
                {
                    var userip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    string FilePath = $"{GetPath.GetInputPath()}\\{userip}";
                    string FileName = "";
                    AppliedMethodes.CreateDirectory(FilePath);

                    List<Application.Services.ConvertToPdf.ImagesToPdf.InputImages> Images = new List<Application.Services.ConvertToPdf.ImagesToPdf.InputImages>();

                    foreach (var item in file)
                    {
                        if (Formating.ImageFileFormatValidation(item.FileName)) //Format Validation
                            return Json(new ResultMessage { Success = false, Message = "File Format Incorrect" });
                    }
                    try
                    {
                        foreach (var item in file)
                        {
                            if (item.Length > 0)
                            {
                                FileName = Formating.ReturnInputFileName(item.FileName);
                                Application.Services.ConvertToPdf.ImagesToPdf.InputImages localimages = new Application.Services.ConvertToPdf.ImagesToPdf.InputImages
                                {
                                    InputFileName = FileName,
                                    InputFilePath = FilePath,
                                };

                                //write files
                                using (FileStream output = System.IO.File.Create($"{FilePath}\\{FileName}"))
                                    await item.CopyToAsync(output);

                                SaveInputFileData(FileName, item.Length, userip); //Save Input File Details
                                Images.Add(localimages);
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

                    try
                    {
                        //Start Converting Proccess
                        var convertResult = _Converter.ImagesToPdfService.Execute(new Application.Services.ConvertToPdf.ImagesToPdf.RequestJpgToPdfDto
                        {
                            Images = Images,
                            OutputPath = GetPath.GetOutputPath(),
                            UserIp = userip,
                        });
                        if (convertResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.ConverterToPdf.ImagesToPdf);
                            // Save Action Log 
                            var savelog = _ConvertLog.AddNewConvertLogService.Execute(new Application.Services.Command.ServicesLog.AddNewConvertLog.RequestAddNewConvertLogDto
                            {
                                FileInputName = null,
                                FileOutName = convertResult.Enything.PdfName,
                                UserIp = userip,
                                FileInputSize = "0",
                                Type = Domain.Entities.Features.ConverterToPdf.ImagesToPdf,
                            });
                            return Json(savelog);
                        }
                        // for prevent overuploading | not working
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
                    finally
                    {//Delete InputFiles + Save Action
                        foreach (var item in Images)
                        {
                            AppliedMethodes.DeleteFile($"{item.InputFilePath}\\{item.InputFileName}");
                            _FeaturesDetails.UpdateInputFileService.UpdateFileDeletedFromFileName(new Application.Services.Command.UpdateInputFileDetail.RequestUpdateInputListFilesDto
                            {
                                FileName = item.InputFileName,
                                UserIp = userip,
                                FileDeleted = true,
                            });
                        }
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
        public async Task<IActionResult> HtmlToPdfUpload(HtmlToPdfViewModel request)
        {
            #region Validation
            if (!AppliedMethodes.UrlValidation(request.Url))
            {
                return Json(new ResultMessage { Success = false, Message = "The given URL is invalid. Please check to see if it is written correctly" });
            }
            #endregion
            try
            {
                var captcha = await _AncillaryServices.GoogleRecaptchaService.Responsewithstring(request.Recaptcha);
                if (captcha.Success)
                {
                    var userip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    var convertResult = await _Converter.HtmlToPdfService.ExecuteAsync(new Application.Services.ConvertToPdf.HtmlToPdf.RequestHtmlToPdfDto
                    {
                        InputUrl = request.Url,
                        OutputPath = GetPath.GetOutputPath(),
                        UserIp = userip
                    });
                    if (convertResult.Success)
                    {
                        // Save Action Log 
                        return Json(_ConvertLog.AddNewConvertLogService.Execute(new Application.Services.Command.ServicesLog.AddNewConvertLog.RequestAddNewConvertLogDto
                        {
                            FileInputName = request.Url,
                            FileOutName = convertResult.Enything.PdfName,
                            UserIp = userip,
                            FileInputSize = "0",
                            Type = Domain.Entities.Features.ConverterToPdf.HtmlToPdf,
                        }));
                    }
                    return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
                }
                return Json(captcha);
            }
            catch
            {
                return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> HtmlCssToPdfUpload(HtmlToPdfViewModel request)
        {
            #region Validation
            if (!AppliedMethodes.UrlValidation(request.Url))
            {
                return Json(new ResultMessage { Success = false, Message = "The given URL is invalid. Please check to see if it is written correctly" });
            }
            #endregion
            try
            {
                var captcha = await _AncillaryServices.GoogleRecaptchaService.Responsewithstring(request.Recaptcha);
                if (captcha.Success)
                {
                    var userip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    var convertResult = await _Converter.HtmlToPdfService.ConvertWithCssAsync(new Application.Services.ConvertToPdf.HtmlToPdf.RequestHtmlToPdfDto
                    {
                        InputUrl = request.Url,
                        OutputPath = GetPath.GetOutputPath(),
                        UserIp = userip
                    });
                    if (convertResult.Success)
                    {
                        // Save Action Log 
                        return Json(_ConvertLog.AddNewConvertLogService.Execute(new Application.Services.Command.ServicesLog.AddNewConvertLog.RequestAddNewConvertLogDto
                        {
                            FileInputName = request.Url,
                            FileOutName = convertResult.Enything.PdfName,
                            UserIp = userip,
                            FileInputSize = "0",
                            Type = Domain.Entities.Features.ConverterToPdf.HtmlToPdf,
                        }));
                    }
                    return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
                }
                return Json(captcha);
            }
            catch
            {
                return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
            }
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
                var service = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = request.Service });
                if (service.Success)
                {
                    var commnet = _FeaturesDetails.AddNewUserCommentService.ExecuteAsync(new Application.Services.Command.AddNewUserComment.RequestAddNewUserCommentDto
                    {
                        UserEmail = request.UserEmail,
                        UserName = request.UserName,
                        Message = request.Message,
                        Service = request.Service,
                        Rate = request.Rate
                    }).Result;
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

        private void SaveInputFileData(string FileName, long FileSize, string UserIp)
        {
            _FeaturesDetails.AddInputFileService.ExecuteAsync(new Application.Services.Command.AddInpuFile.RequestAddInputFileDto
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
