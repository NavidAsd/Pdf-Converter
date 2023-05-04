namespace EndPoint.Areas.PdfManagerArea.Models
{
    public class UpdateAdditionalViewModel
    {
        public long Id { set; get; }
        public string Title { set; get; }

        public string ServiceDescription { set; get; }
        public string HelpContext { set; get; }
    }
    public class UpdateOnePartAdditionalViewModel
    {
        public long Id { set; get; }
        public int Type { set; get; }// 1 =left; 2 =center; 3 =right; 
        public string BlockTitle { set; get; }
        public string Text { set; get; }

    }
}
