
using Domain.Entities.Commons;

namespace Domain.Entities.OtherContext
{
    public class TreeHelpSteps : BaseEntity
    {
        public int ServiceType { set; get; }
        public string Service { set; get; }
        public string Step1 { set; get; }
        public string Step2 { set; get; }
        public string Step3 { set; get; }
        public string VideoName { set; get; }
    }
}
