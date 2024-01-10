using Domain.Entities.Blog;
using Domain.Entities.Details;
using Domain.Entities.Files;
using Domain.Entities.Logs;
using Domain.Entities.OtherContext;
using Domain.Entities.Seo;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPdfConverterContext
    {
        DbSet<ConverterLog> ConverterLogs { get; set; }
        DbSet<OtherFeaturesLog> OtherFeaturesLogs { get; set; }
        DbSet<FeaturesDetails> FeaturesDetails { get; set; }
        DbSet<OptimizersLog> OptimizersLogs { get; set; }
        DbSet<OrganizersLog> OrganizersLogs { get; set; }
        DbSet<SecurityLog> SecurityLogs { get; set; }
        DbSet<Admin> Admins { get; set; }
        DbSet<InputFiles> InputFiles { get; set; }
        DbSet<EmailSenderFiles> EmailSenderFiles { get; set; }
        DbSet<UserComments> UserComments { get; set; }
        DbSet<SocialNetworks> SocialNetworks { get; set; }
        DbSet<HomePageContext> HomePageContexts { get; set; }
        DbSet<TermsOfUse> TermsOfUses { get; set; }
        DbSet<PrivacyAndPolicy> PrivacyAndPolicies { get; set; }
        DbSet<ReportBug> ReportBugs { get; set; }
        DbSet<TreeHelpSteps> TreeHelpSteps { get; set; }
        DbSet<WhyChooseUs> WhyChooseUs { get; set; }
        DbSet<FrequentlyQuestions> FrequentlyQuestions { get; set; }
        DbSet<Metatags> Metatags { get; set; }
        DbSet<Keywords> Keywords { get; set; }
        DbSet<AdditionalHelp> AdditionalHelps { get; set; }
        DbSet<UserMessages> UserMessages { get; set; }
        DbSet<BlogPosts> BlogPosts { get; set; }


        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
