using Application.Interface;
using Common;

namespace Application.Services.Command.ViewContext.UpdateTermsOfUse
{
    public interface IUpdateTermsOfUseService
    {
        ResultMessage Execute(RequestUpdateTermsOfUseDto request);
        ResultMessage UpdateAboutUs(RequestUpdateTermsOfUseDto request);
        ResultMessage UpdateDmca(RequestUpdateTermsOfUseDto request);
    }
    public class RequestUpdateTermsOfUseDto
    {
        public long Id { set; get; }
        public string Text { set; get; }
    }
    public class UpdateTermsOfUseService : IUpdateTermsOfUseService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateTermsOfUseService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateTermsOfUseService.Execute(RequestUpdateTermsOfUseDto request)
        {
            try
            {
                var result = _Context.TermsOfUses.Find(request.Id);
                if (result != null)
                {
                    result.Text = request.Text;
                    result.LastUpdate = System.DateTime.Now;
                    _Context.SaveChanges();
                    return new ResultMessage
                    {
                        Success = true,
                        Message = "Context SuccessFully Updated"
                    };
                }
                Domain.Entities.OtherContext.TermsOfUse footerContext = new Domain.Entities.OtherContext.TermsOfUse
                {
                    Text = request.Text,
                    IsRemoved = false,
                    InsertTime = System.DateTime.Now,
                };
                _Context.TermsOfUses.Add(footerContext);
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
                    Message = "Something Worng Please Try Again"
                };
            }
        }
        ResultMessage IUpdateTermsOfUseService.UpdateAboutUs(RequestUpdateTermsOfUseDto request)
        {
            try
            {
                var result = _Context.TermsOfUses.Find(request.Id);
                if (result != null)
                {
                    result.AboutUs = request.Text;
                    result.LastUpdate = System.DateTime.Now;
                    _Context.SaveChanges();
                    return new ResultMessage
                    {
                        Success = true,
                        Message = "Context SuccessFully Updated"
                    };
                }
                Domain.Entities.OtherContext.TermsOfUse footerContext = new Domain.Entities.OtherContext.TermsOfUse
                {
                    Text = request.Text,
                    IsRemoved = false,
                    InsertTime = System.DateTime.Now,
                };
                _Context.TermsOfUses.Add(footerContext);
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
                    Message = "Something Worng Please Try Again"
                };
            }
        }
        ResultMessage IUpdateTermsOfUseService.UpdateDmca(RequestUpdateTermsOfUseDto request)
        {
            try
            {
                var result = _Context.TermsOfUses.Find(request.Id);
                if (result != null)
                {
                    result.Dmca = request.Text;
                    result.LastUpdate = System.DateTime.Now;
                    _Context.SaveChanges();
                    return new ResultMessage
                    {
                        Success = true,
                        Message = "Context SuccessFully Updated"
                    };
                }
                Domain.Entities.OtherContext.TermsOfUse footerContext = new Domain.Entities.OtherContext.TermsOfUse
                {
                    Text = request.Text,
                    IsRemoved = false,
                    InsertTime = System.DateTime.Now,
                };
                _Context.TermsOfUses.Add(footerContext);
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
                    Message = "Something Worng Please Try Again"
                };
            }
        }
    }
}
