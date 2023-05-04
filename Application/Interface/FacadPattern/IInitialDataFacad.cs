using Application.Services.Command.InitialData.AddInitialAdditionalHelp;
using Application.Services.Command.InitialData.AddInitialFeatures;
using Application.Services.Command.InitialData.AddInitialMetatagPagesData;
using Application.Services.Command.InitialData.AddInitialThreeStepHelp;

namespace Application.Interface.FacadPattern
{
    public interface IInitialDataFacad
    {
        IAddInitialFeaturesService AddInitialFeaturesService { get; }
        IAddInitialThreeStepHelpService AddInitialThreeStepHelpService { get; }
        IAddInitialMetatagPagesService AddInitialMetatagPagesService { get; }
        IAddInitialAdditionalHelpService AddInitialAdditionalHelpService { get; }
    }
}
