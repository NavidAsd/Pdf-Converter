using Domain.Entities.Commons;

namespace Domain.Entities.OtherContext
{
    public class AdditionalHelp : BaseEntity
    {
        public string Title { set; get; }
        public string BlockTitleleft { set; get; }
        public string BlockTitlecenter { set; get; }
        public string BlockTitleright { set; get; }
        public string Textleft { set; get; }
        public string Textcenter { set; get; }
        public string Textright { set; get; }
        public int ServiceType { set; get; }
        public string Service { set; get; }

        public string ServiceDescription { set; get; }
        public string HelpContext { set; get; }
    }
}
