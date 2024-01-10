using Application.Interface;
using Application.Interface.FacadPattern;
using Application.Services.Blog.ReturnBlogPostsData;
using Application.Services.Command.AddNewBolgPost;
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
using Application.Services.Query.Blog;
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
using Microsoft.Extensions.Configuration;

namespace Application.Services.FacadPattern
{
    public class ViewContextFacad : IViewContextFacad
    {
        private readonly IPdfConverterContext _Context;
        private readonly IConfiguration _Config;
        public ViewContextFacad(IPdfConverterContext context,IConfiguration config)
        {
            _Context = context;
            _Config = config;
        }
        private IReturnAllSocialNetworksService _returnAllSocialNetworks;
        public IReturnAllSocialNetworksService ReturnAllSocialNetworks
        {
            get
            {
                return _returnAllSocialNetworks = _returnAllSocialNetworks ?? new ReturnAllSocialNetworksService(_Context);
            }
        }
        private IUpdateSocialNetworksService _updateSocialNetworks;
        public IUpdateSocialNetworksService UpdateSocialNetworksService
        {
            get
            {
                return _updateSocialNetworks = _updateSocialNetworks ?? new UpdateSocialNetworksService(_Context);
            }
        }
        private IReturnHomeContextService _returnHomeContext;
        public IReturnHomeContextService ReturnHomeContextService
        {
            get
            {
                return _returnHomeContext = _returnHomeContext ?? new ReturnHomeContextService(_Context);
            }
        }
        private IUpdateHomeContextService _updateHomePageContext;
        public IUpdateHomeContextService UpdateHomeContextService
        {
            get
            {
                return _updateHomePageContext = _updateHomePageContext ?? new UpdateHomeContextService(_Context);
            }
        }
        private IReturnTermsOfUseService _returnTermsOfUse;
        public IReturnTermsOfUseService ReturnTermsOfUseService
        {
            get
            {
                return _returnTermsOfUse = _returnTermsOfUse ?? new ReturnTermsOfUseService(_Context);
            }
        }
        private IUpdateTermsOfUseService _updateTermsOfUse;
        public IUpdateTermsOfUseService UpdateTermsOfUseService
        {
            get
            {
                return _updateTermsOfUse = _updateTermsOfUse ?? new UpdateTermsOfUseService(_Context);
            }
        }
        private IReturnPrivacyPolicyService _returnPrivacyPolicy;
        public IReturnPrivacyPolicyService ReturnPrivacyPolicyService
        {
            get
            {
                return _returnPrivacyPolicy = _returnPrivacyPolicy ?? new ReturnPrivacyPolicyService(_Context);
            }
        }
        private IUpdatePrivacyPolicyService _updatePrivacyPolicy;
        public IUpdatePrivacyPolicyService UpdatePrivacyPolicyService
        {
            get
            {
                return _updatePrivacyPolicy = _updatePrivacyPolicy ?? new UpdatePrivacyPolicyService(_Context);
            }
        }
        private IReturnReportBugsService _returnReportBugs;
        public IReturnReportBugsService ReturnReportBugsService
        {
            get
            {
                return _returnReportBugs = _returnReportBugs ?? new ReturnReportBugsService(_Context);
            }
        }
        private IAddNewReportBugService _addNewReportBug;
        public IAddNewReportBugService AddNewReportBugService
        {
            get
            {
                return _addNewReportBug = _addNewReportBug ?? new AddNewReportBugService(_Context);
            }
        }
        private IChangeReportedBugStateService _changeReportedBugsState;
        public IChangeReportedBugStateService ChangeReportedBugStateService
        {
            get
            {
                return _changeReportedBugsState = _changeReportedBugsState ?? new ChangeReportedBugStateService(_Context);
            }
        }
        private IReturnWhyChooseUsService _whyChooseUs;
        public IReturnWhyChooseUsService ReturnWhyChooseUsService
        {
            get
            {
                return _whyChooseUs = _whyChooseUs ?? new ReturnWhyChooseUsService(_Context);
            }
        }
        private IUpdateWhyChooseUsService _updateWhyChooseUs;
        public IUpdateWhyChooseUsService UpdateWhyChooseUsService
        {
            get
            {
                return _updateWhyChooseUs = _updateWhyChooseUs ?? new UpdateWhyChooseUsService(_Context);
            }
        }
        private IReturnTreeStepHelpService _returnTreeStepHelp;
        public IReturnTreeStepHelpService ReturnTreeStepHelpService
        {
            get
            {
                return _returnTreeStepHelp = _returnTreeStepHelp ?? new ReturnTreeStepHelpService(_Context);
            }
        }
        private IUpdateTreeStepHelpService _updateTreeStepHelp;
        public IUpdateTreeStepHelpService UpdateTreeStepHelpService
        {
            get
            {
                return _updateTreeStepHelp = _updateTreeStepHelp ?? new UpdateTreeStepHelpService(_Context);
            }
        }
        private IReturnBlogPostsService _returnBlogPosts;
        public IReturnBlogPostsService ReturnBlogPostsService
        {
            get
            {
                return _returnBlogPosts = _returnBlogPosts ?? new ReturnBlogPostsService();
            }
        }
        private IReturnFrequentlyQuestionService _returnFrequentlyQuestion;
        public IReturnFrequentlyQuestionService ReturnFrequentlyQuestionService
        {
            get
            {
                return _returnFrequentlyQuestion = _returnFrequentlyQuestion ?? new ReturnFrequentlyQuestionService(_Context);
            }
        }
        private IAddNewFrequentlyQuestionService _addNewFrequentlyQuestion;
        public IAddNewFrequentlyQuestionService AddNewFrequentlyQuestionService
        {
            get
            {
                return _addNewFrequentlyQuestion = _addNewFrequentlyQuestion ?? new AddNewFrequentlyQuestionService(_Context,_Config);
            }
        }
        private IUpdateFrequentlyQuestionService _updateFrequentlyQuestion;
        public IUpdateFrequentlyQuestionService UpdateFrequentlyQuestionService
        {
            get
            {
                return _updateFrequentlyQuestion = _updateFrequentlyQuestion ?? new UpdateFrequentlyQuestionService(_Context);
            }
        }
        private IUpdateHelpVideoService _updateHelpVideo;
        public IUpdateHelpVideoService UpdateHelpVideoService
        {
            get
            {
                return _updateHelpVideo = _updateHelpVideo ?? new UpdateHelpVideoService(_Context);
            }
        }
        private IReturnServiceImage _returnServiceImage;
        public IReturnServiceImage ReturnServiceImage
        {
            get
            {
                return _returnServiceImage = _returnServiceImage ?? new ReturnServiceImage(_Context);
            }
        }
        private IReturnAdditionalHelpService _returnAdditionalHelp;
        public IReturnAdditionalHelpService ReturnAdditionalHelpService
        {
            get
            {
                return _returnAdditionalHelp = _returnAdditionalHelp ?? new ReturnAdditionalHelpService(_Context);
            }
        }
        private IUpdateAdditionalHelpService _updateAdditionalHelp;
        public IUpdateAdditionalHelpService UpdateAdditionalHelpService
        {
            get
            {
                return _updateAdditionalHelp = _updateAdditionalHelp ?? new UpdateAdditionalHelpService(_Context);
            }
        }
        private IAddNewBlogPostService _addNewBlogPost;
        public IAddNewBlogPostService AddNewBlogPostService
        {
            get
            {
                return _addNewBlogPost = _addNewBlogPost ?? new AddNewBlogPostService(_Context);
            }
        }
        private IReturnBlogPostsFromDbService _returnBlogPostsFromDb;
        public IReturnBlogPostsFromDbService ReturnBlogPostsFromDbService
        {
            get
            {
                return _returnBlogPostsFromDb = _returnBlogPostsFromDb ?? new ReturnBlogPostsFromDbService(_Context);
            }
        }
    }
}
