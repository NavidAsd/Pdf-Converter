using Application.Interface;
using Common;
using Domain.Entities.Blog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Query.Blog
{
    public interface IReturnBlogPostsFromDbService
    {
        Task<ResultMessage<ReturnBlogPostsFromDbDto>> GetPostsAsync(int? LimitCount, int? Category, bool DefaultSort);
    }
    public class ReturnBlogPostsFromDbDto
    {
        public List<BlogEntities> Posts { set; get; }
    }
    public class ReturnBlogPostsFromDbService : IReturnBlogPostsFromDbService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnBlogPostsFromDbService(IPdfConverterContext context) { _Context = context; }
        async Task<ResultMessage<ReturnBlogPostsFromDbDto>> IReturnBlogPostsFromDbService.GetPostsAsync(int? LimitCount, int? Category, bool DefaultSort)
        {
            var posts = _Context.BlogPosts.Where(p => p.IsRemoved == false).AsQueryable();
            if (Category > 0)
                posts = posts.Where(p => p.ServiceId.Equals(Category)).AsQueryable();
            if (LimitCount > 0)
                posts = posts.Take((int)LimitCount).AsQueryable();
            if (DefaultSort)
                posts = posts.OrderByDescending(p => p.InsertTime).AsQueryable();
            else
                posts = posts.OrderBy(p => p.InsertTime).AsQueryable();
            if (posts == null)
            {
                return new ResultMessage<ReturnBlogPostsFromDbDto>
                {
                    Success = false,
                    Message = "no item found"
                };
            }
            return new ResultMessage<ReturnBlogPostsFromDbDto>
            {
                Success = true,
                Enything = new ReturnBlogPostsFromDbDto
                {
                    Posts = posts.Select(o => new BlogEntities
                    {
                        Link = o.Url,
                        Content = o.Content,
                        Title = o.Title,
                        TitleImage = o.ImgUrl,
                        Type = o.ServiceName,
                        Id = o.Id,
                    }).ToList(),
                }
            };
        }
    }
}
