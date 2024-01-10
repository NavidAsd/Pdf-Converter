using Application.Interface.FacadPattern;
using Application.Services.Command.AddInpuFile;
using Application.Services.Organizers.RotatePdf;
using Application.Services.Query.ReturnFeatureDetails;
using Common;
using EndPoint.Models;
using EndPoint.Models.MultiClasses;
using EndPoint.Models.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EndPoint.Controllers
{
    public class OrganizeController : Controller
    {
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        private readonly IAncillaryServicesFacad _AncillaryServices;
        private readonly IOrganizersLogFacad _OrganizersLog;
        private readonly IOrganizersFacad _Organizers;
        private readonly IViewContextFacad _ViewFacad;
        public OrganizeController(IFeaturesDetailsFacad features, IAncillaryServicesFacad ancillary, IOrganizersLogFacad organizerslog,
            IOrganizersFacad organizers, IViewContextFacad view)
        {
            _FeaturesDetails = features;
            _AncillaryServices = ancillary;
            _OrganizersLog = organizerslog;
            _Organizers = organizers;
            _ViewFacad = view;
        }

        [Route("tst-pg")]
        public async Task<IActionResult> tstpg()
        {
            var FetureDetails = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.Organizers.MergePdf });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.Organizers.MergePdf);
            ViewBag.ThreeStepHelp = await _ViewFacad.ReturnTreeStepHelpService.FindWithServiceAsync(Domain.Entities.Features.Organizers.MergePdf);
            ViewBag.FAQ = await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.Organizers.MergePdf, GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }



        [Route("merge-pdf")]
        public async Task<IActionResult> MergPdf()
        {
            var FetureDetails = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.Organizers.MergePdf });
            ViewBag.Comments =await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.Organizers.MergePdf);
            ViewBag.ThreeStepHelp =await _ViewFacad.ReturnTreeStepHelpService.FindWithServiceAsync(Domain.Entities.Features.Organizers.MergePdf);
            ViewBag.FAQ =await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.Organizers.MergePdf,GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("rotate-pdf")]
        public async Task<IActionResult> RotatePdf()
        {
            var FetureDetails = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.Organizers.RotatePdf });
            ViewBag.Comments = await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.Organizers.RotatePdf);
            ViewBag.ThreeStepHelp = await _ViewFacad.ReturnTreeStepHelpService.FindWithServiceAsync(Domain.Entities.Features.Organizers.RotatePdf);
            ViewBag.FAQ =await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.Organizers.RotatePdf,GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }
        [Route("delete-pdf-pages")]
        public async Task<IActionResult> DeletePdfPages()
        {
            var FetureDetails = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = Domain.Entities.Features.Organizers.DeletePdfPages });
            ViewBag.Comments =await _FeaturesDetails.ReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(GetPath.GetCommentCount(), Domain.Entities.Features.Organizers.DeletePdfPages);
            ViewBag.ThreeStepHelp = await _ViewFacad.ReturnTreeStepHelpService.FindWithServiceAsync(Domain.Entities.Features.Organizers.DeletePdfPages);
            ViewBag.FAQ =await _ViewFacad.ReturnFrequentlyQuestionService.ReturnAllAsync(Domain.Entities.Features.Organizers.DeletePdfPages,GetPath.GetFAQCount()); //FAQ
            if (FetureDetails.Success)
                return View(FetureDetails);
            else
                return RedirectToAction("PageNotFound", "Error");
        }


        [HttpPost]
        [RequestSizeLimit(73400320)] // 70 MB in bytes
        [RequestFormLimits(MultipartBodyLengthLimit = 73400320)]
        public async Task<IActionResult> MergPdfUpload(List<IFormFile> file, string Recaptcha)
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
                    string[] FilesNames = new string[System.Convert.ToInt32(file.Count)];


                    foreach (var item in file)
                    {
                        if (Formating.FileFormatValidation(item.FileName, ".pdf")) //Format Validation
                            return Json(new ResultMessage { Success = false, Message = "File Format Incorrect" });
                    }
                    try
                    {
                        for (int i = 0; i < file.Count; i++)
                        {
                            if (file[i].Length > 0)
                            {
                                FilesNames[i] = Formating.ReturnInputFileName(file[i].FileName);
                                FileName = FilesNames[i];
                                using (FileStream output = System.IO.File.Create($"{FilePath}\\{FileName}"))
                                    await file[i].CopyToAsync(output);

                                SaveInputFileData(FileName, file[i].Length, userip); //Save Input File Details
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
                        var mergResult = await _Organizers.MergPdfService.ExecuteAsync(new Application.Services.Organizers.MergPdfs.RequestMergPdfsDto
                        {
                            OutputPath = GetPath.GetOutputPath(),
                            InputFileNames = FilesNames,
                            InputFilePath = FilePath,
                            UserIp = userip
                        });
                        if (mergResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.Organizers.MergePdf);
                            // Save Action Log 
                            var savelog = _OrganizersLog.AddNewOrganizeLogService.Execute(new Application.Services.Command.ServicesLog.AddNewOrganizeLog.RequestAddNewOrganizeLogDto
                            {
                                FileInputName = null,
                                FileOutName = mergResult.Enything.OutFileName,
                                UserIp = userip,
                                FileInputSize = "0",
                                Type = Domain.Entities.Features.Organizers.MergePdf,
                            });
                            return Json(savelog);
                        }
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
                        foreach (var item in FilesNames)
                        {
                            AppliedMethodes.DeleteFile($"{FilePath}\\{item}");
                            _FeaturesDetails.UpdateInputFileService.UpdateFileDeletedFromFileName(new Application.Services.Command.UpdateInputFileDetail.RequestUpdateInputListFilesDto
                            {
                                FileName = item,
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
        [RequestSizeLimit(73400320)]
        [RequestFormLimits(MultipartBodyLengthLimit = 73400320)]
        public async Task<IActionResult> RotatePdfUpload(UploadFileViewModel request, Rotation DegreeRotation)
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
                        using (FileStream output = System.IO.File.Create(@FullPath))
                            await request.file.CopyToAsync(output);

                        SaveInputFileData(FileName, request.file.Length, userip); //Save Input File Details
                        var Result = await _Organizers.RotatePdfService.ExecuteAsync(new Application.Services.Organizers.RotatePdf.RequestRotatePdfDto
                        {
                            InputFileName = FileName,
                            InputFilePath = FilePath,
                            OutputPath = GetPath.GetOutputPath(),
                            UserIp = userip,
                            DegreeRotation = DegreeRotation
                        });
                        if (Result.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.Organizers.RotatePdf);
                            // Save Action Log 
                            var savelog = _OrganizersLog.AddNewOrganizeLogService.Execute(new Application.Services.Command.ServicesLog.AddNewOrganizeLog.RequestAddNewOrganizeLogDto
                            {
                                FileInputName = FileName,
                                FileOutName = Result.Enything.FileName,
                                UserIp = userip,
                                FileInputSize = request.file.Length.ToString(),
                                Type = Domain.Entities.Features.Organizers.RotatePdf,

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
        public async Task<IActionResult> GetPdfPagesUpload(UploadFileViewModel request)
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

                        var FileId = SaveInputFileData(FileName, request.file.Length, userip).Result; //Save Input File Details
                        var PdfPageCount = _Organizers.DeletePdfPagesService.ReturnPdfPages(new Application.Services.Organizers.DeletePdfPages.RequestReturnPdfPagesDto
                        {
                            InputFileFullPath = FullPath,
                            Id = FileId.Enything.Id
                        });
                        return Json(PdfPageCount);
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
        public async Task<IActionResult> DeletePdfPages(DeletePdfPagesViewModel request)
        {
            if (request.Pages.Length > 0)
            {
                var captcha = await _AncillaryServices.GoogleRecaptchaService.Responsewithstring(request.Recaptcha);
                if (captcha.Success)
                {
                    var FileExist = _FeaturesDetails.ReturnInputFileDetailsService.Execute(request._Id);
                    if (FileExist.Success)
                    {
                        string FilePath = $"{GetPath.GetInputPath()}\\{FileExist.Enything.UserIp}";
                        var ProcessResult = await _Organizers.DeletePdfPagesService.ExecuteAsync(new Application.Services.Organizers.DeletePdfPages.RequestDeletePdfPageDto
                        {
                            DeletePages = request.Pages,
                            InputFileName = FileExist.Enything.FileName,
                            UserIp = FileExist.Enything.UserIp,
                            InputFilePath = FilePath,
                            OutputPath = GetPath.GetOutputPath(),
                        });
                        if (ProcessResult.Success)
                        {
                            _FeaturesDetails.UpdateFeatureDetailsService.PlusCountUse(Domain.Entities.Features.Organizers.DeletePdfPages);
                            // Save Action Log 
                            var savelog = _OrganizersLog.AddNewOrganizeLogService.Execute(new Application.Services.Command.ServicesLog.AddNewOrganizeLog.RequestAddNewOrganizeLogDto
                            {
                                FileInputName = FileExist.Enything.FileName,
                                FileOutName = ProcessResult.Enything.OutFileName,
                                UserIp = FileExist.Enything.UserIp,
                                FileInputSize = FileExist.Enything.FileSize,
                                Type = Domain.Entities.Features.Organizers.DeletePdfPages,

                            });
                            DeleteInputFile($"{FilePath}\\{FileExist.Enything.FileName}", savelog.Enything.Id); //+ Save Action
                            return Json(savelog);
                        }
                        return Json(ProcessResult);
                    }
                    return Json(FileExist);
                }
                return Json(captcha);
            }
            return Json(new ResultMessage { Success = false, Message = "You must select at least one page to delete" });
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
                var ReturnFile = _OrganizersLog.ReturnOrganizedFileLogService.Execute(new Application.Services.Query.ReturnOrganizedFileLog.RequestReturnOrganizedFileLogDto
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
                var service = await _FeaturesDetails.ReturnFeatureDetailsService.ExecuteAsync(new RequestReturnFeatureDetailsDto { ServiceType = request.Service });
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
            return (await _FeaturesDetails.AddInputFileService.ExecuteAsync(new Application.Services.Command.AddInpuFile.RequestAddInputFileDto
            {
                FileName = FileName,
                FileSize = FileSize.ToString(),
                UserIp = UserIp
            }));
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
