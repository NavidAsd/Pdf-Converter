using Application.Services.Organizers.DeletePdfPages;
using Application.Services.Organizers.MergPdfs;
using Application.Services.Organizers.RotatePdf;
using Application.Services.Query.ReturnOrganizedFileLog;

namespace Application.Interface.FacadPattern
{
    public class OrganizersFacad : IOrganizersFacad
    {
        public OrganizersFacad() { }

        private IMergPdfService _mergPdf;
        public IMergPdfService MergPdfService
        {
            get
            {
                return _mergPdf = _mergPdf ?? new MergPdfService();
            }
        }
        private IDeletePdfPagesService _deletePDfPages;
        public IDeletePdfPagesService DeletePdfPagesService
        {
            get
            {
                return _deletePDfPages = _deletePDfPages ?? new DeletePdfPagesService();
            }
        }
        private IRotatePdfService _rotatePdf;
        public IRotatePdfService RotatePdfService
        {
            get
            {
                return _rotatePdf = _rotatePdf ?? new RotatePdfService();
            }
        }
    }
}
