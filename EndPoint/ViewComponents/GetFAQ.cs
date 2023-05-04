using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EndPoint.ViewComponents
{
    public class GetFAQ : ViewComponent
    {
        public GetFAQ(){}
        public IViewComponentResult Invoke(Common.ResultMessage<List<Application.Services.Query.ViewContext.ReturnFrequentlyQuestion.FrequentlyQuestions>> FAQ)
        {
            return View("GetFAQ",FAQ);
        }
    }
}
