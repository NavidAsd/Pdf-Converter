
using Domain.Entities.Commons;

namespace Domain.Entities.Details
{
    public class FeaturesDetails : BaseEntity
    {
        public int Service { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string HelpContext { set; get; }
        public double Rate { set; get; }
        public long CountUse { set; get; }
        public string ContextStep1 { set; get; }
        public string ContextStep2 { set; get; }
        public string ContextStep3 { set; get; }
        public string Paragraph1 { set; get; }
        public string Paragraph2 { set; get; }
        //Image Details\\
        public string? ImageFormat { set; get; }
        public string? ImageAlt { set; get; }
        public string? ImageTitle { set; get; }

    }
}
