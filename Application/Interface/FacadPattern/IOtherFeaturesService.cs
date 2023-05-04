using Application.Services.Other.ExtractImages;

namespace Application.Interface.FacadPattern
{
    public interface IOtherFeaturesService
    {
        IExtractPdfImagesService ExtractPdfImagesService { get; }
    }
}
