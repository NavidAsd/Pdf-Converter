using Application.Services.Optimizers.ComperssionPdf;

namespace Application.Interface.FacadPattern
{
    public class OptimizersFacad : IOptimizersFacad
    {
        public OptimizersFacad() { }


        private IComperssingPdfService _compressPdf;
        public IComperssingPdfService ComperssingPdfService
        {
            get
            {
                return _compressPdf = _compressPdf ?? new ComperssingPdfService();
            }
        }
    }
}
