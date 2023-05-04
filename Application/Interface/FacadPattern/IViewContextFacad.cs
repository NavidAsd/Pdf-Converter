using Application.Services.Blog.ReturnBlogPostsData;
using Application.Services.Command.ViewContext.AddNewFrequntlyQuestion;
using Application.Services.Command.ViewContext.AddNewReportBug;
using Application.Services.Command.ViewContext.ChangeReportState;
using Application.Services.Command.ViewContext.UpdateAdditionalHelp;
using Application.Services.Command.ViewContext.UpdateFrequentlyQuestion;
using Application.Services.Command.ViewContext.UpdateHelpVideo;
using Application.Services.Command.ViewContext.UpdateHomeContext;
using Application.Services.Command.ViewContext.UpdatePrivacyPolicy;
using Application.Services.Command.ViewContext.UpdateSocialNetworks;
using Application.Services.Command.ViewContext.UpdateTermsOfUse;
using Application.Services.Command.ViewContext.UpdateTreeStepHelp;
using Application.Services.Command.ViewContext.UpdateWhyChooseUs;
using Application.Services.Query.ReturnServiceImage;
using Application.Services.Query.ViewContext.ReturnAdditionalHelps;
using Application.Services.Query.ViewContext.ReturnFrequentlyQuestion;
using Application.Services.Query.ViewContext.ReturnHomeContext;
using Application.Services.Query.ViewContext.ReturnPrivacyPolicy;
using Application.Services.Query.ViewContext.ReturnReportBugs;
using Application.Services.Query.ViewContext.ReturnSocialNetworks;
using Application.Services.Query.ViewContext.ReturnTermsOfUse;
using Application.Services.Query.ViewContext.ReturnTreeStepHelp;
using Application.Services.Query.ViewContext.ReturnWhyChooseUs;

namespace Application.Interface.FacadPattern
{
    public interface IViewContextFacad
    {
        IReturnAllSocialNetworksService ReturnAllSocialNetworks { get; }
        IUpdateSocialNetworksService UpdateSocialNetworksService { get; }
        IReturnHomeContextService ReturnHomeContextService { get; }
        IUpdateHomeContextService UpdateHomeContextService { get; }
        IReturnTermsOfUseService  ReturnTermsOfUseService { get; }
        IUpdateTermsOfUseService UpdateTermsOfUseService { get; }
        IReturnPrivacyPolicyService ReturnPrivacyPolicyService { get; }
        IUpdatePrivacyPolicyService  UpdatePrivacyPolicyService { get; }
        IReturnReportBugsService  ReturnReportBugsService { get; }
        IAddNewReportBugService AddNewReportBugService { get; }
        IChangeReportedBugStateService ChangeReportedBugStateService { get; }
        IReturnWhyChooseUsService ReturnWhyChooseUsService { get; }
        IUpdateWhyChooseUsService UpdateWhyChooseUsService { get; }
        IReturnTreeStepHelpService ReturnTreeStepHelpService { get; }
        IUpdateTreeStepHelpService UpdateTreeStepHelpService { get; }
        IReturnBlogPostsService ReturnBlogPostsService { get; }
        IReturnFrequentlyQuestionService ReturnFrequentlyQuestionService { get; }
        IAddNewFrequentlyQuestionService  AddNewFrequentlyQuestionService { get; }
        IUpdateFrequentlyQuestionService UpdateFrequentlyQuestionService { get; }
        IUpdateHelpVideoService UpdateHelpVideoService { get; }
        IReturnServiceImage ReturnServiceImage { get; }
        IReturnAdditionalHelpService ReturnAdditionalHelpService { get; }
        IUpdateAdditionalHelpService UpdateAdditionalHelpService { get; }
    }
}
