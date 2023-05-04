using Application.Interface.FacadPattern;
using Application.Services.ConvertToPdf.ExcelToPdf;
using Application.Services.ConvertToPdf.HtmlToPdf;
using Application.Services.ConvertToPdf.ImagesToPdf;
using Application.Services.ConvertToPdf.PptToPdf;
using Application.Services.ConvertToPdf.WordToPdf;

namespace Application.Services.FacadPattern
{
    public class ConvertersToPdfFacad : IConvertersToPdfFacad
    {
        public ConvertersToPdfFacad()
        { }

        private IPptToPdfService _pptToPdf;
        public IPptToPdfService PptToPdfService
        {
            get
            {
                return _pptToPdf = _pptToPdf ?? new PptToPdfService();
            }
        }
        private IWordToPdfService _wordToPdf;
        public IWordToPdfService WordToPdfService
        {
            get
            {
                return _wordToPdf = _wordToPdf ?? new WordToPdfService();
            }
        }
        private IExcelToPdfService _excelToPdf;
        public IExcelToPdfService ExcelToPdfService
        {
            get
            {
                return _excelToPdf = _excelToPdf ?? new ExcelToPdfService();
            }
        }
        private IImagesToPdfService _imagesToPdf;
        public IImagesToPdfService ImagesToPdfService
        {
            get
            {
                return _imagesToPdf = _imagesToPdf ?? new ImagesToPdfService();
            }
        }
        private IHtmlToPdfService _htmlToPdf;
        public IHtmlToPdfService HtmlToPdfService
        {
            get
            {
                return _htmlToPdf = _htmlToPdf ?? new HtmlToPdfService();
            }
        }
    }
}
