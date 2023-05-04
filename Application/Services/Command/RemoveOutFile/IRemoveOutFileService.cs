using Application.Interface;
using Common;
using Domain.Entities.Logs;
using System.Linq;

namespace Application.Services.Command.RemoveOutFile
{
    public interface IRemoveOutFileService
    {
        //ResultMessage RemoveWithId(RequestRemoveOutFileDto request);
        ResultMessage NormalRemove(RequestRemoveOutFileDto request);
    }
    public class RequestRemoveOutFileDto
    {
        public long Id { set; get; }
        public string OutFileName { set; get; }
        public AllServicesLog LogService { set; get; }
    }
    public class RemoveOutFileService : IRemoveOutFileService
    {
        private readonly IPdfConverterContext _Context;
        public RemoveOutFileService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IRemoveOutFileService.NormalRemove(RequestRemoveOutFileDto request)
        {
            var userip = RemoveLog(request);
            if (userip == null)
                return new ResultMessage { Success = false, Message = "Link not found may have been deleted" };
            AppliedMethodes.DeleteFile($"{GetPath.GetOutputPath()}\\{userip}\\{request.OutFileName}");
            return new ResultMessage { Success = true, Message = "Your Link Successfully Removed" };
        }
        private string RemoveLog(RequestRemoveOutFileDto request)
        {
            string result = "";
            if (request.LogService == AllServicesLog.ConverterLog)
            {
                var log = _Context.ConverterLogs.Where(p => p.IsRemoved == false && p.Id == request.Id && p.FileOutName == request.OutFileName).FirstOrDefault();
                if (log != null)
                {
                    log.IsRemoved = true;
                    log.RemoveTime = System.DateTime.Now;
                    result = log.UserIp;
                }
                else result = null;
            }
            else if (request.LogService == AllServicesLog.OptimizersLog)
            {
                var log = _Context.OptimizersLogs.Where(p => p.IsRemoved == false && p.Id == request.Id && p.FileOutName == request.OutFileName).FirstOrDefault();
                if (log != null)
                {
                    log.IsRemoved = true;
                    log.RemoveTime = System.DateTime.Now;
                    result = log.UserIp;
                }
                else result = null;
            }
            else if (request.LogService == AllServicesLog.OrganizersLog)
            {
                var log = _Context.OrganizersLogs.Where(p => p.IsRemoved == false && p.Id == request.Id && p.FileOutName == request.OutFileName).FirstOrDefault();
                if (log != null)
                {
                    log.IsRemoved = true;
                    log.RemoveTime = System.DateTime.Now;
                    result = log.UserIp;
                }
                else result = null;

            }
            else if (request.LogService == AllServicesLog.OtherFeaturesLog)
            {
                var log = _Context.OtherFeaturesLogs.Where(p => p.IsRemoved == false && p.Id == request.Id && p.FileOutName == request.OutFileName).FirstOrDefault();
                if (log != null)
                {
                    log.IsRemoved = true;
                    log.RemoveTime = System.DateTime.Now;
                    result = log.UserIp;
                }
                else result = null;

            }
            else if (request.LogService == AllServicesLog.SecurityLog)
            {
                var log = _Context.SecurityLogs.Where(p => p.IsRemoved == false && p.Id == request.Id && p.FileOutName == request.OutFileName).FirstOrDefault();
                if (log != null)
                {
                    log.IsRemoved = true;
                    log.RemoveTime = System.DateTime.Now;
                    result = log.UserIp;
                }
                else result = null;

            }
            else { result = null; }
            try
            {
                _Context.SaveChanges();
            }
            catch { }
            return result;
        }
    }
}
