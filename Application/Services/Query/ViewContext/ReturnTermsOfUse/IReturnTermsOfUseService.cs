using Application.Interface;
using Common;
using System.Linq;

namespace Application.Services.Query.ViewContext.ReturnTermsOfUse
{
    public interface IReturnTermsOfUseService
    {
        ResultMessage<ResultReturnTermsOfUseDto> Execute();
        ResultMessage<ResultReturnTermsOfUseDto> ReturnAboutUs();
        ResultMessage<ResultReturnTermsOfUseDto> ReturnDmca();
    }
    public class ResultReturnTermsOfUseDto
    {
        public long Id { set; get; }
        public string Text { set; get; }
        public System.DateTime? LastUpdate { set; get; }
    }
    public class ReturnTermsOfUseService : IReturnTermsOfUseService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnTermsOfUseService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnTermsOfUseDto> IReturnTermsOfUseService.Execute()
        {
            var result = _Context.TermsOfUses.FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResultReturnTermsOfUseDto>
                {
                    Success = true,
                    Enything = new ResultReturnTermsOfUseDto
                    {
                        Id = result.Id,
                        Text = result.Text,
                        LastUpdate = result.LastUpdate,
                    }
                };
            }
            return new ResultMessage<ResultReturnTermsOfUseDto>
            {
                Success = false,
                Enything = new ResultReturnTermsOfUseDto
                {
                    Text = null,
                    Id = 0,
                },
                Message = "Nothing Found"
            };
        }
        ResultMessage<ResultReturnTermsOfUseDto> IReturnTermsOfUseService.ReturnAboutUs()
        {
            var result = _Context.TermsOfUses.FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResultReturnTermsOfUseDto>
                {
                    Success = true,
                    Enything = new ResultReturnTermsOfUseDto
                    {
                        Id = result.Id,
                        Text = result.AboutUs,
                        LastUpdate = result.LastUpdate,
                    }
                };
            }
            return new ResultMessage<ResultReturnTermsOfUseDto>
            {
                Success = false,
                Enything = new ResultReturnTermsOfUseDto
                {
                    Text = null,
                    Id = 0,
                },
                Message = "Nothing Found"
            };
        }
        ResultMessage<ResultReturnTermsOfUseDto> IReturnTermsOfUseService.ReturnDmca()
        {
            var result = _Context.TermsOfUses.FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResultReturnTermsOfUseDto>
                {
                    Success = true,
                    Enything = new ResultReturnTermsOfUseDto
                    {
                        Id = result.Id,
                        Text = result.Dmca,
                        LastUpdate = result.LastUpdate,
                    }
                };
            }
            return new ResultMessage<ResultReturnTermsOfUseDto>
            {
                Success = false,
                Enything = new ResultReturnTermsOfUseDto
                {
                    Text = null,
                    Id = 0,
                },
                Message = "Nothing Found"
            };
        }
    }
}
