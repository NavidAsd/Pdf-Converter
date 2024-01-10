using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Query.ViewContext.ReturnTreeStepHelp
{
    public interface IReturnTreeStepHelpService
    {
        Task<ResultMessage<ResultReturnTreeStepHelpListDto>> ReturnAllAsync(RequestReturnTreeStepHelpListDto request);
        Task<ResultMessage<ResultReturnTreeStepHelpDto>> ExecuteAsync(long Id);
        Task<ResultMessage<ResultReturnTreeStepHelpDto>> FindWithServiceAsync(int ServiceType);
    }
    public class ResultReturnTreeStepHelpDto
    {
        public long Id { set; get; }
        public int ServiceType { set; get; }
        public string Service { set; get; }
        public string Step1 { set; get; }
        public string Step2 { set; get; }
        public string Step3 { set; get; }
        public string VideoName { set; get; }
        public System.DateTime? LastUpdate { set; get; }
    }
    public class ResultReturnTreeStepHelpListDto
    {
        public int TotalRow { set; get; }
        public int PageIndex { set; get; }
        public int Pagesize { set; get; }
        public string Filter { set; get; }

        public List<ResultReturnTreeStepHelpDto> TreeStepHelp { set; get; }
    }
    public class RequestReturnTreeStepHelpListDto
    {
        public string Filter { set; get; }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
    }
    public class ReturnTreeStepHelpService : IReturnTreeStepHelpService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnTreeStepHelpService(IPdfConverterContext context)
        {
            _Context = context;
        }
        async Task<ResultMessage<ResultReturnTreeStepHelpDto>> IReturnTreeStepHelpService.ExecuteAsync(long Id)
        {
            var result =await _Context.TreeHelpSteps.FindAsync(Id);
            if (result != null)
            {
                return new ResultMessage<ResultReturnTreeStepHelpDto>
                {
                    Success = true,
                    Enything = new ResultReturnTreeStepHelpDto
                    {
                        Id = result.Id,
                        Service = result.Service,
                        ServiceType = result.ServiceType,
                        Step1 = result.Step1,
                        Step2 = result.Step2,
                        Step3 = result.Step3,
                        VideoName = result.VideoName,
                    }
                };
            }
            else
            {
                return new ResultMessage<ResultReturnTreeStepHelpDto>
                {
                    Success = false,
                    Message = "Not Found"
                };
            }
        }
        async Task<ResultMessage<ResultReturnTreeStepHelpDto>> IReturnTreeStepHelpService.FindWithServiceAsync(int ServiceType)
        {
            var result = await _Context.TreeHelpSteps.Where(p => p.ServiceType == ServiceType).FirstOrDefaultAsync();
            if (result != null)
            {
                return new ResultMessage<ResultReturnTreeStepHelpDto>
                {
                    Success = true,
                    Enything = new ResultReturnTreeStepHelpDto
                    {
                        Id = result.Id,
                        Service = result.Service,
                        ServiceType = result.ServiceType,
                        Step1 = result.Step1,
                        Step2 = result.Step2,
                        Step3 = result.Step3,
                        VideoName = result.VideoName,
                    }
                };
            }
            else
            {
                return new ResultMessage<ResultReturnTreeStepHelpDto>
                {
                    Success = false,
                    Message = "Not Found"
                };
            }
        }

        async Task<ResultMessage<ResultReturnTreeStepHelpListDto>> IReturnTreeStepHelpService.ReturnAllAsync(RequestReturnTreeStepHelpListDto request)
        {
            int totalrow = 0;
            var Comments = _Context.TreeHelpSteps.Where(p => p.IsRemoved == false).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Filter))
                Comments = Comments.Where(p => p.Service.Contains(request.Filter)).AsQueryable();
            var Services = _Context.FeaturesDetails.IgnoreQueryFilters().ToList();

            var result = Comments.ToPaged(request.PageIndex, request.PageSize, out totalrow);

            if (result != null)
            {
                return new ResultMessage<ResultReturnTreeStepHelpListDto>
                {
                    Success = true,
                    Enything = new ResultReturnTreeStepHelpListDto
                    {
                        Filter = request.Filter,
                        PageIndex = request.PageIndex,
                        Pagesize = request.PageSize,
                        TotalRow = totalrow,
                        TreeStepHelp = result.Select(p => new ResultReturnTreeStepHelpDto
                        {
                            Id = p.Id,
                            Service = p.Service,
                            ServiceType = p.ServiceType,
                            Step1 = p.Step1,
                            Step2 = p.Step2,
                            Step3 = p.Step3,
                            VideoName = p.VideoName,
                            LastUpdate = p.LastUpdate
                        }).ToList()
                    }
                };
            }
            return new ResultMessage<ResultReturnTreeStepHelpListDto>
            {
                Success = false,
                Message = "No HelpContext Found"
            };
        }
    }
}
