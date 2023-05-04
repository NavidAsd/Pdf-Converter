using Application.Interface;
using Common;

namespace Application.Services.Command.ViewContext.UpdateWhyChooseUs
{
    public interface IUpdateWhyChooseUsService
    {
        ResultMessage Execute(RequestUpdateWhyChooseUsDto request);
    }
    public class RequestUpdateWhyChooseUsDto
    {
        public long Id { set; get; }
        public int Type { set; get; }
        public string Title { set; get; }
        public string Text { set; get; }

    }
    public class UpdateWhyChooseUsService : IUpdateWhyChooseUsService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateWhyChooseUsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateWhyChooseUsService.Execute(RequestUpdateWhyChooseUsDto request)
        {
            try
            {
                var result = _Context.WhyChooseUs.Find(request.Id);
                if (result != null)
                {
                    if (request.Type == 1)
                    {
                        result.Text1 = request.Text;
                        result.Title1 = request.Title;
                    }
                    else if(request.Type == 2)
                    {
                        result.Text2 = request.Text;
                        result.Title2 = request.Title;
                    }
                    else
                    {
                        result.Text3 = request.Text;
                        result.Title3 = request.Title;
                    }
                    result.LastUpdate = System.DateTime.Now;
                    _Context.SaveChanges();
                    return new ResultMessage
                    {
                        Success = true,
                        Message = "Context SuccessFully Updated"
                    };
                }
                Domain.Entities.OtherContext.WhyChooseUs chooseUs = new Domain.Entities.OtherContext.WhyChooseUs()
                {
                    LastUpdate = System.DateTime.Now,
                };
                if (request.Type == 1)
                {
                    chooseUs.Text1 = request.Text;
                    chooseUs.Title1 = request.Title;
                }
                else if (request.Type == 2)
                {
                    chooseUs.Text2 = request.Text;
                    chooseUs.Title2 = request.Title;
                }
                else
                {
                    chooseUs.Text3 = request.Text;
                    chooseUs.Title3 = request.Title;
                }
                _Context.WhyChooseUs.Add(chooseUs);
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Context SuccessFully Updated"
                };
            }
            catch
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again"
                };
            }
        }
    }
}
