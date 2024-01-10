using Application.Interface;
using Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Command.AddNewBolgPost
{
    public interface IAddNewBlogPostService
    {
        Task<ResultMessage> AddPost(RequestAddNewBlogPostDto request);
    }
    public class RequestAddNewBlogPostDto
    {
        public Domain.Entities.Blog.BlogPosts Post { get; set; }
    }
    public class AddNewBlogPostService : IAddNewBlogPostService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewBlogPostService(IPdfConverterContext context)
        {
            _Context = context;
        }
        async Task<ResultMessage> IAddNewBlogPostService.AddPost(RequestAddNewBlogPostDto request)
        {
            var uniquePost = _Context.BlogPosts.Where(p => p.ServiceId.Equals(request.Post.ServiceId)
            && p.Url.Equals(request.Post.Url)).FirstOrDefault();
            try
            {
                if (uniquePost != null)
                {
                    uniquePost.Url = request.Post.Url;
                    uniquePost.ServiceName = request.Post.ServiceName;
                    uniquePost.Content = request.Post.Content;
                    uniquePost.Title = request.Post.Title;
                    uniquePost.ImgUrl = request.Post.ImgUrl;
                    uniquePost.IsRemoved = false;
                    uniquePost.LastUpdate = DateTime.Now;
                }
                else
                {
                    await _Context.BlogPosts.AddAsync(request.Post);
                }
                await _Context.SaveChangesAsync();
                return new ResultMessage { Success = true };
            }
            catch
            {
                return new ResultMessage() { Success = false, Message = "Something Worng" };
            }
        }
    }
}
