using System;
using Application.Interface;
using System.Linq;

namespace Application.Services.Command.QuartzServices.RemoveInputFiles
{
    public interface IRemoveInputFilesService
    {
        bool RemoveInputFiles(int Hour);
        bool RemoveInputFilesDetail(int Day);
    }
    public class RemoveInputFilesService : IRemoveInputFilesService
    {
        private readonly IPdfConverterContext _Context;
        public RemoveInputFilesService(IPdfConverterContext context)
        {
            _Context = context;
        }
        bool IRemoveInputFilesService.RemoveInputFiles(int Hour)
        {
            var Files = _Context.InputFiles.Where(p => p.IsRemoved == false && p.FileDeleted == false && p.InsertTime < DateTime.Now.AddHours(-Hour)).ToList();
            if (Files.Count > 0)
            {
                foreach (var File in Files)
                {
                    try
                    {
                        System.IO.File.Delete($"{Common.GetPath.GetOutputPath()}\\{File.UserIp}\\{File.FileName}");
                        var result = _Context.InputFiles.Find(File.Id);
                        result.FileDeleted = true;
                        _Context.SaveChanges();
                    }
                    catch { }
                }
            }
            return true;
        }
        bool IRemoveInputFilesService.RemoveInputFilesDetail(int Day)
        {
            try
            {
                var LogFiles = _Context.InputFiles.Where(p => p.FileDeleted == true && p.InsertTime < DateTime.Now.AddDays(-Day)).ToList();
                if (LogFiles.Count > 0)
                {
                    foreach (var item in LogFiles)
                    {
                        try
                        {
                            _Context.InputFiles.Remove(item);
                        }
                        catch { }
                    }
                    _Context.SaveChanges();
                }
                return true;
            }
            catch { return false; }
        }
    }
}
