using Application.Interface;
using Common;
using System.Linq;

namespace Application.Services.Command.UpdateInputFileDetail
{
    public interface IUpdateInputFileService
    {
        ResultMessage UpdateFileDeleted(RequestUpdateInputFileDto request);
        ResultMessage UpdateFileDeletedFromFileName(RequestUpdateInputListFilesDto request);
    }
    public class RequestUpdateInputFileDto
    {
        public long Id { set; get; }
        public bool FileDeleted { set; get; }
    }
    public class RequestUpdateInputListFilesDto
    {
        public string FileName { set; get; }
        public string UserIp { set; get; }
        public bool FileDeleted { set; get; }
    }
    public class UpdateInputFileService : IUpdateInputFileService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateInputFileService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateInputFileService.UpdateFileDeletedFromFileName(RequestUpdateInputListFilesDto request)
        {
            var result = _Context.InputFiles.Where(p => p.FileName == request.FileName && p.UserIp == request.UserIp).FirstOrDefault();
            if (result != null)
            {
                if (result.FileDeleted != request.FileDeleted)
                {
                    result.FileDeleted = request.FileDeleted;
                    _Context.SaveChanges();
                }
                return new ResultMessage { Success = true };
            }
            return new ResultMessage { Success = false };
        }
        ResultMessage IUpdateInputFileService.UpdateFileDeleted(RequestUpdateInputFileDto request)
        {
            var result = _Context.InputFiles.Find(request.Id);
            if (result != null)
            {
                if (result.FileDeleted != request.FileDeleted)
                {
                    result.FileDeleted = request.FileDeleted;
                    _Context.SaveChanges();
                }
                return new ResultMessage { Success = true };
            }
            return new ResultMessage { Success = false };
        }
    }
}
