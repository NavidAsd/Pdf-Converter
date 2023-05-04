using Application.Interface.FacadPattern;
using Application.UseServices;
using Common;
using Domain.Entities.Logs;
using EndPoint.Models.DownloadPart;
using EndPoint.Models.MultiClasses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EndPoint.Controllers
{
    public class DownloaderController : Controller
    {
        private readonly IConvertLogFacad _ConvertLog;
        private readonly IOptimizersLogFacad _OptimizersLog;
        private readonly IOrganizersLogFacad _OrganizersLog;
        private readonly ISecurityLogFacad _SecurityLog;
        private readonly IOtherFeaturesLogService _OtherFeaturesLog;
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        private readonly IAncillaryServicesFacad _Ancillary;
        private readonly IHostingEnvironment _Environment;
        public DownloaderController(IConvertLogFacad convertLog, IOptimizersLogFacad optimizers, IOrganizersLogFacad organizers
            , ISecurityLogFacad securityLog, IOtherFeaturesLogService otherFeaturesLog, IFeaturesDetailsFacad features,
            IAncillaryServicesFacad ancillary,IHostingEnvironment environment)
        {
            _ConvertLog = convertLog;
            _OptimizersLog = optimizers;
            _OrganizersLog = organizers;
            _SecurityLog = securityLog;
            _OtherFeaturesLog = otherFeaturesLog;
            _FeaturesDetails = features;
            _Ancillary = ancillary;
            _Environment = environment;
        }
        [Route("open-pdf")]
        public async Task<IActionResult> OpenPdf(string Id, string Length)
        {

            if (!string.IsNullOrWhiteSpace(Id) && !string.IsNullOrWhiteSpace(Length))
            {
                var ReturnFile = _OtherFeaturesLog.ReturnOtherFileLogService.ReturnWithLen(new Application.Services.Query.ReturnOtherFileLog.RequestReturnFileWithLenDto
                {
                    Id = System.Convert.ToInt64(Id),
                    FileLength = Length
                });

                if (ReturnFile.Success)
                {
                    ViewBag.FileFullPath = $"{GetPath.GetReadPdfPath().Replace("wwwroot", "")}\\{ReturnFile.Enything.UserIp}\\{ReturnFile.Enything.OutFileName}";
                    return View();
                }
                return RedirectToAction("PageNotFound", "Error");
            }
            return RedirectToAction("PageNotFound", "Error");
        }
        [Route("download-link")]
        public async Task<IActionResult> DownloadLink(DownloadFileViewModel request)
        {
            UseReturnFeaturesLog ReturnLogs = new UseReturnFeaturesLog();
            var ReturnFile = ReturnLogs.ReturnSerivceLog(new RequestReturnFeaturesFileLogDto
            {
                Id = System.Convert.ToInt64(request.Id),
                LogService = request.LogService,
                OutFileName = request.OutFileName
            }, _ConvertLog, _OptimizersLog, _OrganizersLog, _SecurityLog, _OtherFeaturesLog);
            if (ReturnFile.Success)
            {
                string FullUrl = $"{GetPath.GetDomain()}/Downloader/DownloadFile?OutFileName={request.OutFileName}&Id={request.Id}&LogService={request.LogService}";

                if (ReturnFile.Enything.ShortLink == null)
                    ViewBag.ShortUrl = ReturnShortLink(FullUrl, System.Convert.ToInt64(request.Id), request.LogService);
                else
                    ViewBag.ShortUrl = ReturnFile.Enything.ShortLink;

                if (ReturnFile.Enything.QrImage == null)
                    ViewBag.QrImage = $"{GetPath.GetQrImagesPath()}\\{ReturnFile.Enything.UserIp}\\{ReturnQrImage(FullUrl, ReturnFile.Enything.UserIp, System.Convert.ToInt64(request.Id), request.LogService)}";
                else
                    ViewBag.QrImage = $"{GetPath.GetQrImagesPath()}\\{ReturnFile.Enything.UserIp}\\{ReturnFile.Enything.QrImage}";

                ViewBag.FullUrl = FullUrl;
                ViewBag.FileName = ReturnFile.Enything.OutFileName;
                ViewBag.Service = request.LogService;
                ViewBag.Id = request.Id;
                return View();
            }
            return RedirectToAction("PageNotFound", "Error");
        }
        public async Task<IActionResult> DownloadFile(DownloadFileViewModel request)
        {
            UseReturnFeaturesLog ReturnLogs = new UseReturnFeaturesLog();
            var ReturnFile = ReturnLogs.ReturnSerivceLog(new RequestReturnFeaturesFileLogDto
            {
                Id = System.Convert.ToInt64(request.Id),
                LogService = request.LogService,
                OutFileName = request.OutFileName
            }, _ConvertLog, _OptimizersLog, _OrganizersLog, _SecurityLog, _OtherFeaturesLog);
            if (ReturnFile.Success)
            {
                try
                {
                    string path = $"{GetPath.GetOutputPath()}\\{ReturnFile.Enything.UserIp}\\{ReturnFile.Enything.OutFileName}";
                    path = path.Replace("/", "\\");
                    var memory = new MemoryStream();
                    using (var stream = new FileStream(@path, FileMode.Open))
                    {
                        await stream.CopyToAsync(memory);
                    }
                    memory.Position = 0;
                    return File(memory, MimeTypes.FallbackMimeType, @ReturnFile.Enything.OutFileName);
                }
                catch (Exception ex)
                {
                    using (var tw = new System.IO.StreamWriter(GetPath.GetOutputPath() + "//Error.txt", true))
                    {
                        tw.WriteLine(ex.Message);
                    }
                }
            }
            return RedirectToAction("PageNotFound", "Error");
        }

        public async Task<IActionResult> DeleteLink(DownloadFileViewModel request)
        {
            UseReturnFeaturesLog ReturnLogs = new UseReturnFeaturesLog();
            var ReturnFile = ReturnLogs.ReturnSerivceLog(new RequestReturnFeaturesFileLogDto
            {
                Id = System.Convert.ToInt64(request.Id),
                LogService = request.LogService,
                OutFileName = request.OutFileName
            }, _ConvertLog, _OptimizersLog, _OrganizersLog, _SecurityLog, _OtherFeaturesLog);
            if (ReturnFile.Success)
            {
                return Json(_FeaturesDetails.RemoveOutFileService.NormalRemove(new Application.Services.Command.RemoveOutFile.RequestRemoveOutFileDto
                {
                    Id = System.Convert.ToInt64(request.Id),
                    LogService = request.LogService,
                    OutFileName = request.OutFileName
                }));
            }
            return RedirectToAction("PageNotFound", "Error");
        }

        private string ReturnShortLink(string FullUrl, long Id, AllServicesLog LogService)
        {
            string ShortUrl = AppliedMethodes.LinkShorter(FullUrl).Result;
            if (ShortUrl != null)
            {
                UseUpdateShortLink UseService = new UseUpdateShortLink();
                UseService.Use(new RequestUpdateFileLogShortLinkDto
                {
                    Id = Id,
                    ShortLink = ShortUrl,
                    LogService = LogService
                }, _FeaturesDetails);
            }
            return ShortUrl;
        }
        private string ReturnQrImage(string FullUrl,string UserIp,long Id,AllServicesLog LogService)
        {
            var Qr = _Ancillary.GenerateQrCodeService.CreateNewCode(new Application.Services.QRCode.RequestGenerateQrCodeDto
            {
                QrImagePath =  $"{_Environment.ContentRootPath}//{GetPath.GetQrImagesPath()}",
                UserIp = UserIp,
                Url = FullUrl,
            });
            if (Qr.Success)
            {
                UseUpdateQrImage UseService = new UseUpdateQrImage();
                UseService.Use(new RequestUpdateQrImageDto
                {
                    Id = Id,
                    QrImageName = Qr.Enything.QrImageName,
                    LogService = LogService
                }, _FeaturesDetails);
                return Qr.Enything.QrImageName;
            }
            return null;
        }
    }
}
