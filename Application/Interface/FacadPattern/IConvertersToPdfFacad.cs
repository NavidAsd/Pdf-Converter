using Application.Services.ConvertToPdf.ExcelToPdf;
using Application.Services.ConvertToPdf.HtmlToPdf;
using Application.Services.ConvertToPdf.ImagesToPdf;
using Application.Services.ConvertToPdf.PptToPdf;
using Application.Services.ConvertToPdf.WordToPdf;

namespace Application.Interface.FacadPattern
{
    public interface IConvertersToPdfFacad
    {
        IPptToPdfService PptToPdfService { get; }
        IWordToPdfService WordToPdfService { get; }
        IExcelToPdfService ExcelToPdfService { get; }
        IImagesToPdfService  ImagesToPdfService { get; }
        IHtmlToPdfService HtmlToPdfService { get; }
    }
}
