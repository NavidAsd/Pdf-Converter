
using Microsoft.AspNetCore.Http;

namespace EndPoint.Areas.PdfManagerArea.Models
{
    public class AddNewFrequentlyQuestionViewModel
    {
        public long Id { set; get; }
        public string Question { set; get; }
        public string Answer { set; get; }
        public long? Service { set; get; }

    }
    public class AddNewFrequesntlyQuestionFromFileViewModel
    {
        public IFormFile File { set; get; }
        public long? Service { set; get; }
        public Common.Schema.SchemaType Type { set; get; }
    }
}
