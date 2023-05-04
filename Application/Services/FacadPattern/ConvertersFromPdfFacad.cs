using Application.Interface.FacadPattern;
using Application.Services.ConvertFormPdf.PdfToBmp;
using Application.Services.ConvertFormPdf.PdfToExcel;
using Application.Services.ConvertFormPdf.PdfToGif;
using Application.Services.ConvertFormPdf.PdfToJpg;
using Application.Services.ConvertFormPdf.PdfToPdfA;
using Application.Services.ConvertFormPdf.PdfToPng;
using Application.Services.ConvertFormPdf.PdfToPower;
using Application.Services.ConvertFormPdf.PdfToTiff;
using Application.Services.ConvertFormPdf.PdfToWord;

namespace Application.Services.FacadPattern
{
    public class ConvertersFromPdfFacad : IConvertersFromPdfFacad
    {
        public ConvertersFromPdfFacad() { }

        private IPdfToPngService _pdfTOpng;
        public IPdfToPngService PdfToPngService
        {
            get
            {
                return _pdfTOpng = _pdfTOpng ?? new PdfToPngService();
            }
        }
        private IPdfToBmpService _pdfTObmp;
        public IPdfToBmpService PdfToBmpService
        {
            get
            {
                return _pdfTObmp = _pdfTObmp ?? new PdfToBmpService();
            }
        }
        private IPdfToGifService _pdfTOgif;
        public IPdfToGifService PdfToGifService
        {
            get
            {
                return _pdfTOgif = _pdfTOgif ?? new PdfToGifService();
            }
        }
        private IPdfToTiffService _pdfTottif;
        public IPdfToTiffService PdfToTiffService
        {
            get
            {
                return _pdfTottif = _pdfTottif ?? new PdfToTiffService();
            }
        }
        private IPdfToExcelService _pdfTOexcel;
        public IPdfToExcelService PdfToExcelService
        {
            get
            {
                return _pdfTOexcel = _pdfTOexcel ?? new PdfToExcelService();
            }
        }
        private IPdfToWordService _pdfTOword;
        public IPdfToWordService PdfToWordService
        {
            get
            {
                return _pdfTOword = _pdfTOword ?? new PdfToWordService();
            }
        }
        private IPdfToPdfAService _pdfTOpdfa;
        public IPdfToPdfAService PdfToPdfAService
        {
            get
            {
                return _pdfTOpdfa = _pdfTOpdfa ?? new PdfToPdfAService();
            }
        }
        private IPdfToPowerPointService _pdfTOppt;
        public IPdfToPowerPointService PdfToPowerPointService
        {
            get
            {
                return _pdfTOppt = _pdfTOppt ?? new PdfToPowerPointService();
            }
        }

        private IPdfToJpgService _pdfTOjpg;
        public IPdfToJpgService PdfToJpgService
        {
            get
            {
                return _pdfTOjpg = _pdfTOjpg ?? new PdfToJpgService();
            }
        }
    }
}
