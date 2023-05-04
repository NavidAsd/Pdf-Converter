﻿using Application.Interface;
using Common;
using System.ComponentModel;
using System.Drawing.Text;
using System.IO;
using System.Linq;

namespace Application.Services.Query.ReturnServiceImage
{
    public interface IReturnServiceImage
    {
        ResultMessage<ReturnServiceImageDto> ReturnServiceImage(int Service);
        ResultMessage<ReturnHomeImagesDto> ReturnHomeImages();
    }

    public class ReturnServiceImageDto
    {
        public string Image { set; get; }
        public string ImageTitle { set; get; }
        public string ImageAlt { set; get; }

    }
    public class ReturnHomeImagesDto
    {
        public string TopImage { set; get; }
        public string DownImage { set; get; }
    }
    public class ReturnServiceImage : IReturnServiceImage
    {
        private readonly IPdfConverterContext _Context;
        public ReturnServiceImage(IPdfConverterContext context)
        {
            _Context = context;
        }

        ResultMessage<ReturnServiceImageDto> IReturnServiceImage.ReturnServiceImage(int Service)
        {
            
            try
            {
                var ServiceResult = _Context.FeaturesDetails.Where(p => p.Service == Service).FirstOrDefault();               
                AppliedMethodes.CreateDirectory(GetPath.GetServiceImages());
                if (ServiceResult != null)
                {
                    var initialData = $"pdfconverter-{ServiceResult.Name}{ServiceResult.ImageFormat}";
                    string path = $"{GetPath.GetServiceImages()}\\{initialData}";
                    if (File.Exists(path.Replace("/", "\\")))
                        return new ResultMessage<ReturnServiceImageDto>
                        {
                            Success = true,
                            Enything = new ReturnServiceImageDto
                            {
                                Image = initialData,
                                ImageAlt=ServiceResult.ImageAlt,
                                ImageTitle=ServiceResult.ImageTitle,
                            },
                        };
                    return new ResultMessage<ReturnServiceImageDto>
                    {
                        Success = false,
                        Message = "Image Not Found"
                    };
                }
                return new ResultMessage<ReturnServiceImageDto>
                {
                    Success = false,
                    Message = "Image Not Found"
                };
            }
            catch
            {
                return new ResultMessage<ReturnServiceImageDto>
                {
                    Success = false,
                    Message = "Image Not Found"
                };
            }
        }
        ResultMessage<ReturnHomeImagesDto> IReturnServiceImage.ReturnHomeImages()
        {
            AppliedMethodes.CreateDirectory(GetPath.GetHomeImages());
            bool image1 = File.Exists($"{GetPath.GetHomeImages()}\\{GetPath.HomeTopImage}");
            bool image2 = File.Exists($"{GetPath.GetHomeImages()}\\{GetPath.HomeDownImage}");
            return new ResultMessage<ReturnHomeImagesDto>
            {
                Success = true,
                Enything = new ReturnHomeImagesDto
                {
                    TopImage = image1 != false ? GetPath.HomeTopImage : null,
                    DownImage = image2 != false ? GetPath.HomeDownImage : null,
                },
            };
        }
    }
}