using Application.Interface;
using Common;
using System.Linq;

namespace Application.Services.Query.ReturnInputFileDetails
{
    public interface IReturnInputFileDetailsService
    {
        ResultMessage<ResutlReturnInputFileDetailsDto> Execute(long Id);
        ResultMessage<ResutlReturnInputFileDetailsDto> ReturnWithLen(RequestReturnInputFileDetails request);
    }
    public class RequestReturnInputFileDetails
    {
        public long Id { set; get; }
        public string FileLength { set; get; }
    }
    public class ResutlReturnInputFileDetailsDto
    {
        public string FileName { set; get; }
        public string UserIp { set; get; }
        public string FileSize { set; get; }
    }
    public class ReturnInputFileDetailsService : IReturnInputFileDetailsService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnInputFileDetailsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResutlReturnInputFileDetailsDto> IReturnInputFileDetailsService.Execute(long Id)
        {
            var result = _Context.InputFiles.Where(p => p.IsRemoved == false && p.FileDeleted == false && p.Id == Id).FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResutlReturnInputFileDetailsDto>
                {
                    Success = true,
                    Enything = new ResutlReturnInputFileDetailsDto
                    {
                        FileName = result.FileName,
                        UserIp = result.UserIp,
                        FileSize=result.FIleSize
                    },
                };
            }
            return new ResultMessage<ResutlReturnInputFileDetailsDto>
            {
                Success=false,
                Enything=null,
                Message= "The file you uploaded may have been deleted. Please upload again"
            };
        }
        ResultMessage<ResutlReturnInputFileDetailsDto> IReturnInputFileDetailsService.ReturnWithLen(RequestReturnInputFileDetails request)
        {
            var result = _Context.InputFiles.Where(p => p.IsRemoved == false && p.FileDeleted == false && p.Id == request.Id && p.FIleSize == request.FileLength).FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResutlReturnInputFileDetailsDto>
                {
                    Success = true,
                    Enything = new ResutlReturnInputFileDetailsDto
                    {
                        FileName = result.FileName,
                        UserIp = result.UserIp,
                        FileSize=result.FIleSize
                    },
                };
            }
            return new ResultMessage<ResutlReturnInputFileDetailsDto>
            {
                Success=false,
                Enything=null,
                Message= "The file you uploaded may have been deleted. Please upload again"
            };
        }
    }
}

