namespace EndPoint.Models
{
    public class GetViewContextViewModel
    {
        public Application.UseServices.ReturnViewContext Context { set; get; }
        public Common.ResultMessage<Application.Services.Query.ViewContext.ReturnTotalUseAvg.ResultReturnTotalUseAvgDto> TotalConvert { set; get; }
    }
}
