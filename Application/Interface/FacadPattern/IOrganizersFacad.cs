using Application.Services.Organizers.DeletePdfPages;
using Application.Services.Organizers.MergPdfs;
using Application.Services.Organizers.RotatePdf;

namespace Application.Interface.FacadPattern
{
    public interface IOrganizersFacad
    {
        IMergPdfService MergPdfService { get; }
        IDeletePdfPagesService DeletePdfPagesService { get; }
        IRotatePdfService RotatePdfService { get; } 
    }
}
