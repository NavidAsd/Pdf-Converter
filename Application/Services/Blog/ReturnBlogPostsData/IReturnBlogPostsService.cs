using Common;
using Domain.Entities.Blog;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Dropbox.Api.Sharing.ListFileMembersIndividualResult;

namespace Application.Services.Blog.ReturnBlogPostsData
{
    public interface IReturnBlogPostsService
    {
        ResultMessage<ResultReturnBlogPostsDto> Execute(int? LimitCount, int? Category,int? after);
    }
    public class ResultReturnBlogPostsDto
    {
        public List<BlogEntities> Posts { set; get; }
    }
    public class ReturnBlogPostsService : IReturnBlogPostsService
    {
        ResultMessage<ResultReturnBlogPostsDto> IReturnBlogPostsService.Execute(int? LimitCount, int? Category,int? after)
        {
            try
            {
                string Url = GetPath.GetBlogUrl();
                if (Category != null)
                    Url += $"?categories={Category}";
                if (LimitCount > 10 || LimitCount == null)
                {
                    var ResponseList = new List<Task<InternalServiceResponse>>();
                    int page = 1;
                    Url += Category != null ? $"&&page={page}" : $"?page={page}";
                    while (true)
                    {
                        page += 1;
                        var Rsp = AppliedMethodes.RequestSender(Url, false);
                        if (Rsp.Result.StatusCode == (int)System.Net.HttpStatusCode.OK)
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
                            dynamic JsonResult = JsonConvert.DeserializeObject(item.Result.ResponseContent);
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

                var Response = AppliedMethodes.RequestSender(Url, false);
                if (Response.Result.StatusCode == (int)System.Net.HttpStatusCode.OK)
                {
                    dynamic JsonResult = JsonConvert.DeserializeObject(Response.Result.ResponseContent);

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
