using Application.Interface;
using Common;
using System.Linq;

namespace Application.Services.Command.Seo.UpdateMetatags
{
    public interface IUpdateMetatagService
    {
        ResultMessage UpdateTags(RequestUpdateMetatagDto request);
        ResultMessage ChangeRemovedState(RequetsChangeRemovedStateDto request);
    }
    public class RequetsChangeRemovedStateDto
    {
        public long Id { set; get; }
        public bool State { set; get; }
    }
    public class RequestUpdateMetatagDto
    {
        public long Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Author { set; get; }
        public string Other { set; get; }

    }
    public class UpdateMetatagService : IUpdateMetatagService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateMetatagService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateMetatagService.UpdateTags(RequestUpdateMetatagDto request)
        {
            var result = _Context.Metatags.Find(request.Id);
            if (result != null)
            {
                result.Title = request.Title;
                result.Description = request.Description;
                result.Author = request.Author;
                result.Other = request.Other;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Metatags Successfully updated"
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Item Not Found"
            };
        }
        ResultMessage IUpdateMetatagService.ChangeRemovedState(RequetsChangeRemovedStateDto request)
        {
            var result = _Context.Metatags.Find(request.Id);
            if (result != null)
            {
                result.IsRemoved = request.State;
                result.RemoveTime = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Item Successfully Status Changed"
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Item Not Found"
            };
        }

    }
}
