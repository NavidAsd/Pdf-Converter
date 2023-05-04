using Common;
using Domain.Entities.Features;
using Application.Interface.FacadPattern;

namespace Application.UseServices
{
    public class UseConvertToImages
    {
        public ResultMessage<ReturnPdfToImagesDto> PdfToImages(RequestUseConvertToImagesServiceDto request, IConvertersFromPdfFacad _ConvertFromPdf)
        {
            if (request.ServiceType > 0)
            {
                if (request.ServiceType == ConvertFromPdf.PdfToJpg)
                {
                    return _ConvertFromPdf.PdfToJpgService.Execute(new Services.ConvertFormPdf.PdfToJpg.RequestPdfToJpgDto
                    {
                        InputPath = request.PdfFullPath,
                        OutputPath = request.ImagesPath,
                        UserIp = request.UserIp
                    });
                }
                else if (request.ServiceType == ConvertFromPdf.PdfToPng)
                {
                    return _ConvertFromPdf.PdfToPngService.Execute(new Services.ConvertFormPdf.PdfToPng.RequestPdfToPngDto
                    {
                        InputPath = request.PdfFullPath,
                        OutputPath = request.ImagesPath,
                        UserIp = request.UserIp
                    });
                }
                else if (request.ServiceType == ConvertFromPdf.PdfToBmp)
                {
                    return _ConvertFromPdf.PdfToBmpService.Execute(new Services.ConvertFormPdf.PdfToBmp.RequestPdfToBmpDto
                    {
                        InputPath = request.PdfFullPath,
                        OutputPath = request.ImagesPath,
                        UserIp = request.UserIp
                    });
                }
                else if (request.ServiceType == ConvertFromPdf.PdfToTiff)
                {
                    return _ConvertFromPdf.PdfToTiffService.Execute(new Services.ConvertFormPdf.PdfToTiff.RequestPdfToTiffDto
                    {
                        InputPath = request.PdfFullPath,
                        OutputPath = request.ImagesPath,
                        UserIp = request.UserIp
                    });
                }
                else if (request.ServiceType == ConvertFromPdf.PdfToGif)
                {
                    return _ConvertFromPdf.PdfToGifService.Execute(new Services.ConvertFormPdf.PdfToGif.RequestPdfToGifDto
                    {
                        InputPath = request.PdfFullPath,
                        OutputPath = request.ImagesPath,
                        UserIp = request.UserIp
                    });
                }
                else
                {
                    return new ResultMessage<ReturnPdfToImagesDto>
                    {
                        Success = false,
                        Enything = null,
                        Message = "Something Wrong Please Try Again"
                    };
                }
            }
            else
            {
                return new ResultMessage<ReturnPdfToImagesDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Please Try Again"
                };
            }
        }


    }
    public class RequestUseConvertToImagesServiceDto
    {
        public string ImagesPath { set; get; }
        public string PdfFullPath { set; get; }
        public string UserIp { set; get; }
        public int ServiceType { set; get; }
    }
    public class ReturnPdfToImagesDto
    {
        public string ImageName { set; get; }
        public string ImagePath { set; get; }
    }
}
