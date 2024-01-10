using Microsoft.EntityFrameworkCore;
using Application.Interface;
using Domain.Entities.Logs;
using Domain.Entities.Users;
using Domain.Entities.Details;
using Domain.Entities.Files;
using Domain.Entities.Features;
using Domain.Entities.OtherContext;
using Domain.Entities.Seo;
using Domain.Entities.Blog;
#nullable disable

namespace Persistance.Context
{
    public partial class PdfConverterContext : DbContext, IPdfConverterContext

    {
        private readonly string Connection = @"Data Source=DESKTOP-KE0BSMH; Initial Catalog=PdfConverter_test; Integrated Security=True; User Id=sa;Password=pdfconverter00654Q";
        //private readonly string Connection = @"Data Source=.; Initial Catalog=PdfConverter_test; Trusted_Connection=True;";
        public PdfConverterContext()
        {
        }


        public PdfConverterContext(DbContextOptions<PdfConverterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConverterLog> ConverterLogs { get; set; }
        public virtual DbSet<OtherFeaturesLog> OtherFeaturesLogs { get; set; }
        public virtual DbSet<FeaturesDetails> FeaturesDetails { get; set; }
        public virtual DbSet<OptimizersLog> OptimizersLogs { get; set; }
        public virtual DbSet<OrganizersLog> OrganizersLogs { get; set; }
        public virtual DbSet<SecurityLog> SecurityLogs { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<InputFiles> InputFiles { get; set; }
        public virtual DbSet<EmailSenderFiles> EmailSenderFiles { get; set; }
        public virtual DbSet<UserComments> UserComments { get; set; }
        public virtual DbSet<SocialNetworks> SocialNetworks { get; set; }
        public virtual DbSet<HomePageContext> HomePageContexts { get; set; }
        public virtual DbSet<TermsOfUse> TermsOfUses { get; set; }
        public virtual DbSet<PrivacyAndPolicy> PrivacyAndPolicies { get; set; }
        public virtual DbSet<ReportBug> ReportBugs { get; set; }
        public virtual DbSet<TreeHelpSteps> TreeHelpSteps { get; set; }
        public virtual DbSet<WhyChooseUs> WhyChooseUs { get; set; }
        public virtual DbSet<FrequentlyQuestions> FrequentlyQuestions { get; set; }
        public virtual DbSet<Metatags> Metatags { get; set; }
        public virtual DbSet<Keywords> Keywords { get; set; }
        public virtual DbSet<AdditionalHelp> AdditionalHelps { get; set; }
        public virtual DbSet<UserMessages> UserMessages { get; set; }
        public virtual DbSet<BlogPosts> BlogPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyQueryFilter(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            OnModelCreatingPartial(modelBuilder);

        }
        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConverterLog>().HasQueryFilter(p => p.IsRemoved == false);
            modelBuilder.Entity<OtherFeaturesLog>().HasQueryFilter(p => p.IsRemoved == false);
            modelBuilder.Entity<FeaturesDetails>().HasQueryFilter(p => p.IsRemoved == false);
            modelBuilder.Entity<OptimizersLog>().HasQueryFilter(p => p.IsRemoved == false);
            modelBuilder.Entity<OrganizersLog>().HasQueryFilter(p => p.IsRemoved == false);
            modelBuilder.Entity<SecurityLog>().HasQueryFilter(p => p.IsRemoved == false);
            modelBuilder.Entity<Admin>().HasQueryFilter(p => p.IsRemoved == false);
            modelBuilder.Entity<EmailSenderFiles>().HasQueryFilter(p => p.IsRemoved == false);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
