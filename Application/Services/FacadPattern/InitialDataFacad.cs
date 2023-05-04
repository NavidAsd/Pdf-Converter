using Application.Interface;
using Application.Interface.FacadPattern;
using Application.Services.Command.InitialData.AddInitialAdditionalHelp;
using Application.Services.Command.InitialData.AddInitialFeatures;
using Application.Services.Command.InitialData.AddInitialMetatagPagesData;
using Application.Services.Command.InitialData.AddInitialThreeStepHelp;
using Microsoft.Extensions.Hosting;

namespace Application.Services.FacadPattern
{
    public class InitialDataFacad : IInitialDataFacad
    {
        private readonly IPdfConverterContext _Context;
        public readonly IHostingEnvironment _Hosting;
        public InitialDataFacad(IPdfConverterContext context, IHostingEnvironment hosting)
        {
            _Context = context;
            _Hosting = hosting;
        }

        private IAddInitialFeaturesService _addInitialFeatures;
        public IAddInitialFeaturesService AddInitialFeaturesService
        {
            get
            {
                return _addInitialFeatures = _addInitialFeatures ?? new AddInitialFeaturesService(_Context);
            }
        }
        private IAddInitialThreeStepHelpService _addInitialThreeHelp;
        public IAddInitialThreeStepHelpService AddInitialThreeStepHelpService
        {
            get
            {
                return _addInitialThreeHelp = _addInitialThreeHelp ?? new AddInitialThreeStepHelpService(_Context);
            }
        }
        private IAddInitialMetatagPagesService _addinitialMetaPages;
        public IAddInitialMetatagPagesService AddInitialMetatagPagesService
        {
            get
            {
                return _addinitialMetaPages = _addinitialMetaPages ?? new AddInitialMetatagpagesService(_Context, _Hosting);
            }
        }
        private IAddInitialAdditionalHelpService _addinitialhelp;
        public IAddInitialAdditionalHelpService AddInitialAdditionalHelpService
        {
            get
            {
                return _addinitialhelp = _addinitialhelp ?? new AddInitialAdditionalHelpService(_Context);
            }
        }

    }
}
