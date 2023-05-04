using Application.Interface;
using System;
using System.Linq;

namespace Application.Services.Command.QuartzServices.RemoveAllFilesLog
{
    public interface IRemoveFilesLogService
    {
        bool DeleteAllLogs(int Days);
    }
    public class RemoveFilesLogService : IRemoveFilesLogService
    {
        private readonly IPdfConverterContext _Context;
        public RemoveFilesLogService(IPdfConverterContext context)
        {
            _Context = context;
        }
        bool IRemoveFilesLogService.DeleteAllLogs(int Days)
        {
            var expireTime = DateTime.Now.AddDays(-Days);

            try
            {
                var ConverterLogs = _Context.ConverterLogs.Where(p => p.IsRemoved == false && p.InsertTime < expireTime).ToList();
                if (ConverterLogs.Count > 0)
                {
                    foreach (var item in ConverterLogs)
                    {
                        item.IsRemoved = true;
                        item.RemoveTime = DateTime.Now;
                    }
                    _Context.SaveChanges();
                }
            }
            catch {}

            try
            {
                var OptimizerLogs = _Context.OptimizersLogs.Where(p => p.IsRemoved == false && p.InsertTime < expireTime).ToList();
                if (OptimizerLogs.Count > 0)
                {
                    foreach (var item in OptimizerLogs)
                    {
                        item.IsRemoved = true;
                        item.RemoveTime = DateTime.Now;
                    }
                    _Context.SaveChanges();
                }
            }
            catch {  }

            try
            {
                var OrganizerLogs = _Context.OrganizersLogs.Where(p => p.IsRemoved == false && p.InsertTime < expireTime).ToList();
                if (OrganizerLogs.Count > 0)
                {
                    foreach (var item in OrganizerLogs)
                    {
                        item.IsRemoved = true;
                        item.RemoveTime = DateTime.Now;
                    }
                    _Context.SaveChanges();
                }
            }
            catch {  }

            try
            {
                var SecurityLogs = _Context.SecurityLogs.Where(p => p.IsRemoved == false && p.InsertTime < expireTime).ToList();
                if (SecurityLogs.Count > 0)
                {
                    foreach (var item in SecurityLogs)
                    {
                        item.IsRemoved = true;
                        item.RemoveTime = DateTime.Now;
                    }
                    _Context.SaveChanges();
                }
            }
            catch {  }

            try
            {
                var OtherFeatureLogs = _Context.OtherFeaturesLogs.Where(p => p.IsRemoved == false && p.InsertTime < expireTime).ToList();
                if (OtherFeatureLogs.Count > 0)
                {
                    foreach (var item in OtherFeatureLogs)
                    {
                        item.IsRemoved = true;
                        item.RemoveTime = DateTime.Now;
                    }
                    _Context.SaveChanges();
                }
            }
            catch {  }
            return true;
        }
    }
}
