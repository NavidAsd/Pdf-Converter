using Application.Interface.FacadPattern;
using Application.Services.Other.ExtractImages;

namespace Application.Services.FacadPattern
{
    public class OtherFeaturesService : IOtherFeaturesService
    {
        public OtherFeaturesService() { }

        private IExtractPdfImagesService _extractPdfImages;
        public IExtractPdfImagesService  ExtractPdfImagesService
        {
            get
            {
                return _extractPdfImages = _extractPdfImages ?? new ExtractPdfImagesService();
            }
        }
    }
}
