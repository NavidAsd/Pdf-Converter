using Domain.Entities.Commons;

namespace Domain.Entities.Blog
{
    public class BlogPosts : BaseEntity
    {
        public string Title { set; get; }
        public string Content { set; get; }
        public string Url { set; get; }
        public string ImgUrl { set; get; }
        public int ServiceId { set; get; }
        public string ServiceName { set; get; }
    }
}
