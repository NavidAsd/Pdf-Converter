using Application.Interface;
using Common;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Command.AddInpuFile
{
    public interface IAddInputFileService
    {
        Task<ResultMessage<ResultAddInputFileDto>> ExecuteAsync(RequestAddInputFileDto request);
    }
    public class ResultAddInputFileDto
    {
        public long Id { set; get; }
    }
    public class RequestAddInputFileDto
    {
        public string FileName { set; get; }
        public string FileSize { set; get; }
        public string UserIp { set; get; }
        public bool FileDeleted { set; get; }
    }
    public class ReturnPdfDetailsForOpen
    {
        public long Id { set; get; }
        public string FileSize { set; get; }
    }
    public class AddInputFileService : IAddInputFileService
    {
        private readonly IPdfConverterContext _Context;
        public AddInputFileService(IPdfConverterContext context)
        {
            _Context = context;
        }
        async Task<ResultMessage<ResultAddInputFileDto>> IAddInputFileService.ExecuteAsync(RequestAddInputFileDto request)
        {
            try
            {
                Domain.Entities.Files.InputFiles File = new Domain.Entities.Files.InputFiles()
                {
                    FileName = request.FileName,
                    FIleSize = request.FileSize,
                    UserIp = request.UserIp,
                    InsertTime = System.DateTime.Now,
                    IsRemoved = false,
                    FileDeleted = false
                };
                await _Context.InputFiles.AddAsync(File);
                _Context.SaveChanges();
                var result = _Context.InputFiles.Where(p => p.IsRemoved == false && p.FileDeleted == false && p.FileName == request.FileName && p.UserIp == request.UserIp).FirstOrDefault();
                return new ResultMessage<ResultAddInputFileDto>
                {
                    Success = true,
                    Enything = new ResultAddInputFileDto { Id = result.Id }
                };
            }
            catch
            {
                return new ResultMessage<ResultAddInputFileDto>
                {
                    Success = false,
                };
            }
        }
    }
}
