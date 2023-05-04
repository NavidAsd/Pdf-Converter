using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Query.ViewContext.ReturnWhyChooseUs
{
    public interface IReturnWhyChooseUsService
    {
        ResultMessage<ResultReturnWhyChooseUsDto> Execute();
    }
    public class ResultReturnWhyChooseUsDto
    {
        public long Id { set; get; }
        public string Title1 { set; get; }
        public string Title2 { set; get; }
        public string Title3 { set; get; }
        public string Text1 { set; get; }
        public string Text2 { set; get; }
        public string Text3 { set; get; }
        public System.DateTime LastUpdate { set; get; }
    }
    public class ReturnWhyChooseUsService : IReturnWhyChooseUsService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnWhyChooseUsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnWhyChooseUsDto> IReturnWhyChooseUsService.Execute()
        {
            try
            {

                var result = _Context.WhyChooseUs.FirstOrDefault();
                if (result != null)
                {
                    return new ResultMessage<ResultReturnWhyChooseUsDto>
                    {
                        Success = true,
                        Enything = new ResultReturnWhyChooseUsDto
                        {
                            Id = result.Id,
                            Text1 = result.Text1,
                            Text2 = result.Text2,
                            Text3 = result.Text3,
                            Title1 = result.Title1,
                            Title2 = result.Title2,
                            Title3 = result.Title3,
                            LastUpdate = result.LastUpdate,
                        }
                    };
                }
                return new ResultMessage<ResultReturnWhyChooseUsDto>
                {
                    Success = true,
                    Enything = new ResultReturnWhyChooseUsDto
                    {
                        Id = 0,
                        Text1 = null,
                        Text2 = null,
                        Text3 = null,
                        Title1 = null,
                        Title2 = null,
                        Title3 = null,
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultReturnWhyChooseUsDto>
                {
                    Success = false,
                    Message = "No Data Found"
                };
            }
        }
    }
}
