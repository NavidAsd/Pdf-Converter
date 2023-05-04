using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Application.Services.Command.QuartzServices.RemoveOutFiles
{
    public interface IRemoveOutFilesService
    {
        ResultMessage DeleteAllFiles(int Days);
        ResultMessage DeleteQrImages(int Days);
    }
    public class RemoveOutFilesService : IRemoveOutFilesService
    {
        private readonly IPdfConverterContext _Context;
        private readonly IHostEnvironment _Environment;
        public RemoveOutFilesService(IPdfConverterContext context,IHostEnvironment environment)
        {
            _Context = context;
            _Environment = environment;
        }
        ResultMessage IRemoveOutFilesService.DeleteAllFiles(int Days)
        {
            var expireTime = DateTime.Now.AddDays(-Days);
            try
            {
                var ConvertedFiles = _Context.ConverterLogs.IgnoreQueryFilters().Where(p => p.InsertTime < expireTime).ToList();
                if (ConvertedFiles.Count > 0)
                {
                    foreach (var item in ConvertedFiles)
                        AppliedMethodes.DeleteFile($"{GetPath.GetOutputPath()}\\{item.UserIp}\\{item.FileOutName}");
                }
            }
            catch { }
            try
            {
                var OptimizersFiles = _Context.OptimizersLogs.IgnoreQueryFilters().Where(p => p.InsertTime < expireTime).ToList();
                if (OptimizersFiles.Count > 0)
                {
                    foreach (var item in OptimizersFiles)
                        AppliedMethodes.DeleteFile($"{GetPath.GetOutputPath()}\\{item.UserIp}\\{item.FileOutName}");
                }
            }
            catch { }
            try
            {
                var OrganizersFiles = _Context.OrganizersLogs.IgnoreQueryFilters().Where(p => p.InsertTime < expireTime).ToList();
                if (OrganizersFiles.Count > 0)
                {
                    foreach (var item in OrganizersFiles)
                        AppliedMethodes.DeleteFile($"{GetPath.GetOutputPath()}\\{item.UserIp}\\{item.FileOutName}");
                }
            }
            catch { }
            try
            {
                var SecurityFiles = _Context.SecurityLogs.IgnoreQueryFilters().Where(p => p.InsertTime < expireTime).ToList();
                if (SecurityFiles.Count > 0)
                {
                    foreach (var item in SecurityFiles)
                        AppliedMethodes.DeleteFile($"{GetPath.GetOutputPath()}\\{item.UserIp}\\{item.FileOutName}");
                }
            }
            catch { }
            try
            {
                var OtherFeaturesFiles = _Context.OtherFeaturesLogs.IgnoreQueryFilters().Where(p => p.InsertTime < expireTime).ToList();
                if (OtherFeaturesFiles.Count > 0)
                {
                    foreach (var item in OtherFeaturesFiles)
                    {
                        if (item.Type != Domain.Entities.Features.OtherFeatures.PdfReader)
                            AppliedMethodes.DeleteFile($"{GetPath.GetOutputPath()}\\{item.UserIp}\\{item.FileOutName}");
                        else
                            AppliedMethodes.DeleteFile($"{_Environment.ContentRootPath}\\{GetPath.GetReadPdfPath()}\\{item.UserIp}\\{item.FileOutName}");
                    }
                }
            }
            catch { }

            return new ResultMessage { Success = true };
        }
        ResultMessage IRemoveOutFilesService.DeleteQrImages(int Days)
        {
            var expireTime = DateTime.Now.AddDays(-Days);
            try
            {
                var ConvertedFiles = _Context.ConverterLogs.IgnoreQueryFilters().Where(p => p.InsertTime < expireTime).ToList();
                if (ConvertedFiles.Count > 0)
                {
                    foreach (var item in ConvertedFiles)
                        AppliedMethodes.DeleteFile($"{_Environment.ContentRootPath}\\{GetPath.GetQrImagesPath()}\\{item.UserIp}\\{item.QRImage}");
                }
            }
            catch { }
            try
            {
                var OptimizersFiles = _Context.OptimizersLogs.IgnoreQueryFilters().Where(p => p.InsertTime < expireTime).ToList();
                if (OptimizersFiles.Count > 0)
                {
                    foreach (var item in OptimizersFiles)
                        AppliedMethodes.DeleteFile($"{_Environment.ContentRootPath}\\{GetPath.GetQrImagesPath()}\\{item.UserIp}\\{item.QRImage}");
                }
            }
            catch { }
            try
            {
                var OrganizersFiles = _Context.OrganizersLogs.IgnoreQueryFilters().Where(p => p.InsertTime < expireTime).ToList();
                if (OrganizersFiles.Count > 0)
                {
                    foreach (var item in OrganizersFiles)
                        AppliedMethodes.DeleteFile($"{_Environment.ContentRootPath}\\{GetPath.GetQrImagesPath()}\\{item.UserIp}\\{item.QRImage}");
                }
            }
            catch { }
            try
            {
                var SecurityFiles = _Context.SecurityLogs.IgnoreQueryFilters().Where(p => p.InsertTime < expireTime).ToList();
                if (SecurityFiles.Count > 0)
                {
                    foreach (var item in SecurityFiles)
                        AppliedMethodes.DeleteFile($"{_Environment.ContentRootPath}\\{GetPath.GetQrImagesPath()}\\{item.UserIp}\\{item.QRImage}");
                }
            }
            catch { }
            try
            {
                var OtherFeaturesFiles = _Context.OtherFeaturesLogs.IgnoreQueryFilters().Where(p => p.InsertTime < expireTime).ToList();
                if (OtherFeaturesFiles.Count > 0)
                {
                    foreach (var item in OtherFeaturesFiles)
                            AppliedMethodes.DeleteFile($"{_Environment.ContentRootPath}\\{GetPath.GetQrImagesPath()}\\{item.UserIp}\\{item.QRImage}");
                }
            }
            catch { }

            return new ResultMessage { Success = true };
        }
    }
}
