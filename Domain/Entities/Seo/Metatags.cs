using Domain.Entities.Commons;

namespace Domain.Entities.Seo
{
    public class Metatags : BaseEntity
    {
        public string PageName { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Author { set; get; }
        public string Other { set; get; }
    }
}
