using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Query.ViewContext.ReturnTreeStepHelp
{
    public interface IReturnTreeStepHelpService
    {
        ResultMessage<ResultReturnTreeStepHelpListDto> ReturnAll(RequestReturnTreeStepHelpListDto request);
        ResultMessage<ResultReturnTreeStepHelpDto> Execute(long Id);
        ResultMessage<ResultReturnTreeStepHelpDto> FindWithService(int ServiceType);
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
        ResultMessage<ResultReturnTreeStepHelpDto> IReturnTreeStepHelpService.Execute(long Id)
        {
            var result = _Context.TreeHelpSteps.Find(Id);
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
        ResultMessage<ResultReturnTreeStepHelpDto> IReturnTreeStepHelpService.FindWithService(int ServiceType)
        {
            var result = _Context.TreeHelpSteps.Where(p => p.ServiceType == ServiceType).FirstOrDefault();
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

        ResultMessage<ResultReturnTreeStepHelpListDto> IReturnTreeStepHelpService.ReturnAll(RequestReturnTreeStepHelpListDto request)
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
