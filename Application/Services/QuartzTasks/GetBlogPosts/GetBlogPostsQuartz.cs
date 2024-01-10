using Application.Interface.FacadPattern;
using Quartz;
using System.Threading.Tasks;

namespace Application.Services.QuartzTasks.GetBlogPosts
{
    [DisallowConcurrentExecution]
    public class GetBlogPostsQuartz : IJob
    {
        private readonly IViewContextFacad _ViewFacad;
        public GetBlogPostsQuartz(IViewContextFacad viewFacad)
        {
            _ViewFacad = viewFacad;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var Categories = new Domain.Entities.Features.AllCategories().ReturnAll();
            foreach (var category in Categories)
            {
                var posts = _ViewFacad.ReturnBlogPostsService.ExecuteAsync(Common.GetPath.GetBlogPostCount(), category.Value, 0).Result;
                if (posts.Success)
                {
                    foreach (var item in posts.Enything.Posts)
                    {
                        _ViewFacad.AddNewBlogPostService.AddPost(new Command.AddNewBolgPost.RequestAddNewBlogPostDto
                        {
                            Post = new Domain.Entities.Blog.BlogPosts
                            {
                                Content = item.Content,
                                Title = item.Title,
                                Url = item.Link,
                                ImgUrl = item.TitleImage,
                                ServiceId = category.Value,
                                ServiceName = category.Key,
                            },
                        });
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
