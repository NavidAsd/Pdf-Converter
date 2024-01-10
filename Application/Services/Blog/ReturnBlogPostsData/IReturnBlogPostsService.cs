using Common;
using Domain.Entities.Blog;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Blog.ReturnBlogPostsData
{
    public interface IReturnBlogPostsService
    {
        Task<ResultMessage<ResultReturnBlogPostsDto>> ExecuteAsync(int? LimitCount, int? Category,int? after);
    }
    public class ResultReturnBlogPostsDto
    {
        public List<BlogEntities> Posts { set; get; }
    }
    public class ReturnBlogPostsService : IReturnBlogPostsService
    {
        async Task<ResultMessage<ResultReturnBlogPostsDto>> IReturnBlogPostsService.ExecuteAsync(int? LimitCount, int? Category,int? after)
        {
            try
            {
                string Url = GetPath.GetBlogUrl();
                if (Category != null)
                    Url += $"?categories={Category}";
                if (LimitCount > 10 || LimitCount == null)
                {
                    var ResponseList = new List<InternalServiceResponse>();
                    int page = 1;
                    Url += Category != null ? $"&&page={page}" : $"?page={page}";
                    while (true)
                    {
                        page += 1;
                        var Rsp = await AppliedMethodes.RequestSender(Url, false);
                        if (Rsp.StatusCode == (int)System.Net.HttpStatusCode.OK)
                            ResponseList.Add(Rsp);
                        else
                            break;
                        Url = Url.Replace($"page={page - 1}", $"page={page}");
                    }
                    if (ResponseList.Count > 0)
                    {
                        List<BlogEntities> result = new List<BlogEntities>();
                        foreach (var item in ResponseList)
                        {
                            dynamic JsonResult = JsonConvert.DeserializeObject(item.ResponseContent);
                            //int count = LimitCount != null && LimitCount <= JsonResult.Count ? LimitCount : JsonResult.Count;
                            for (int i = 0; i < JsonResult.Count; i++)
                            {
                                if (result.Count >= LimitCount && LimitCount != null)
                                    break;
                                if(after > 0 ) 
                                {
                                    if(i > after)
                                    {
                                        Domain.Entities.Blog.BlogEntities Blog = new BlogEntities();
                                        Blog.Id = JsonResult[i].id;
                                        Blog.InsertDate = JsonResult[i].date;
                                        Blog.Status = JsonResult[i].status;
                                        Blog.Link = JsonResult[i].link;
                                        Blog.Type = JsonResult[i].type;
                                        Blog.Title = JsonResult[i].title.rendered;
                                        try
                                        {
                                            Blog.TitleImage = JsonResult[i].better_featured_image.source_url;
                                        }
                                        catch { try { Blog.TitleImage = JsonResult[i].featured_media_src_url; } catch { Blog.TitleImage = null; } }
                                        Blog.Content = JsonResult[i].content.rendered;
                                        result.Add(Blog);

                                    }
                                }
                                else
                                {
                                    Domain.Entities.Blog.BlogEntities Blog = new BlogEntities();
                                    Blog.Id = JsonResult[i].id;
                                    Blog.InsertDate = JsonResult[i].date;
                                    Blog.Status = JsonResult[i].status;
                                    Blog.Link = JsonResult[i].link;
                                    Blog.Type = JsonResult[i].type;
                                    Blog.Title = JsonResult[i].title.rendered;
                                    try
                                    {
                                        Blog.TitleImage = JsonResult[i].better_featured_image.source_url;
                                    }
                                    catch { try { Blog.TitleImage = JsonResult[i].featured_media_src_url; } catch { Blog.TitleImage = null; } }
                                    Blog.Content = JsonResult[i].content.rendered;
                                    result.Add(Blog);

                                }
                            }
                            if (result.Count >= LimitCount && LimitCount != null)
                                break;
                        }
                        return new ResultMessage<ResultReturnBlogPostsDto>
                        {
                            Success = true,
                            Enything = new ResultReturnBlogPostsDto
                            {
                                Posts = result
                            },
                        };
                    }
                }

                var Response = await AppliedMethodes.RequestSender(Url, false);
                if (Response.StatusCode == (int)System.Net.HttpStatusCode.OK)
                {
                    dynamic JsonResult = JsonConvert.DeserializeObject(Response.ResponseContent);

                    List<BlogEntities> result = new List<BlogEntities>();

                    int count = LimitCount != null && LimitCount <= JsonResult.Count ? LimitCount : JsonResult.Count;

                    for (int i = 0; i < count; i++)
                    {
                        Domain.Entities.Blog.BlogEntities Blog = new BlogEntities();
                        Blog.Id = JsonResult[i].id;
                        Blog.InsertDate = JsonResult[i].date;
                        Blog.Status = JsonResult[i].status;
                        Blog.Link = JsonResult[i].link;
                        Blog.Type = JsonResult[i].type;
                        Blog.Title = JsonResult[i].title.rendered;
                        try
                        {
                            Blog.TitleImage = JsonResult[i].better_featured_image.source_url;
                        }
                        catch { try { Blog.TitleImage = JsonResult[i].featured_media_src_url; } catch { Blog.TitleImage = null; } }
                        Blog.Content = JsonResult[i].content.rendered;
                        result.Add(Blog);
                    }
                    return new ResultMessage<ResultReturnBlogPostsDto>
                    {
                        Success = true,
                        Enything = new ResultReturnBlogPostsDto
                        {
                            Posts = result
                        },
                    };
                }
                return new ResultMessage<ResultReturnBlogPostsDto>
                {
                    Success = false,
                    Message = "Error on Load Data"
                };
            }
            catch
            {
                return new ResultMessage<ResultReturnBlogPostsDto>
                {
                    Success = false,
                    Message = "Error on Load Data"
                };
            }
        }
    }
}
