using Application.Services.Optimizers.ComperssionPdf;

namespace Application.Interface.FacadPattern
{
    public interface IOptimizersFacad
    {
        IComperssingPdfService ComperssingPdfService { get; }
    }
}
