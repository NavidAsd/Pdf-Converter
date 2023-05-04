using Application.Services.ConvertFormPdf.PdfToBmp;
using Application.Services.ConvertFormPdf.PdfToExcel;
using Application.Services.ConvertFormPdf.PdfToGif;
using Application.Services.ConvertFormPdf.PdfToJpg;
using Application.Services.ConvertFormPdf.PdfToPdfA;
using Application.Services.ConvertFormPdf.PdfToPng;
using Application.Services.ConvertFormPdf.PdfToPower;
using Application.Services.ConvertFormPdf.PdfToTiff;
using Application.Services.ConvertFormPdf.PdfToWord;

namespace Application.Interface.FacadPattern
{
    public interface IConvertersFromPdfFacad
    {
        IPdfToJpgService PdfToJpgService { get; }
        IPdfToPngService PdfToPngService { get; }
        IPdfToBmpService PdfToBmpService { get; }
        IPdfToGifService PdfToGifService { get; }
        IPdfToTiffService PdfToTiffService { get; }
        IPdfToExcelService PdfToExcelService { get; }
        IPdfToWordService PdfToWordService { get; }
        IPdfToPdfAService PdfToPdfAService { get; }
        IPdfToPowerPointService PdfToPowerPointService { get; }
    }
}
