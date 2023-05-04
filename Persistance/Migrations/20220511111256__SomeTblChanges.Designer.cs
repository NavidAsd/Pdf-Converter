﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance.Context;

namespace Persistance.Migrations
{
    [DbContext(typeof(PdfConverterContext))]
    [Migration("20220511111256__SomeTblChanges")]
    partial class _SomeTblChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Arabic_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Details.FeaturesDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContextStep1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContextStep2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContextStep3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CountUse")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelpContext")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<int>("Service")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FeaturesDetails");
                });

            modelBuilder.Entity("Domain.Entities.Details.UserComments", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<int>("Service")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserComments");
                });

            modelBuilder.Entity("Domain.Entities.Files.EmailSenderFiles", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<int>("TryToSend")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailSenderFiles");
                });

            modelBuilder.Entity("Domain.Entities.Files.InputFiles", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FIleSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FileDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InputFiles");
                });

            modelBuilder.Entity("Domain.Entities.Logs.ConverterLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileInputName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileInputSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileOutName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("QRImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("ShortLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConverterLogs");
                });

            modelBuilder.Entity("Domain.Entities.Logs.OptimizersLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileInputName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileInputSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileOutName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("QRImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("ShortLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OptimizersLogs");
                });

            modelBuilder.Entity("Domain.Entities.Logs.OrganizersLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileInputName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileInputSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileOutName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("QRImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("ShortLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrganizersLogs");
                });

            modelBuilder.Entity("Domain.Entities.Logs.OtherFeaturesLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileInputName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileInputSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileOutName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("QRImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("ShortLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OtherFeaturesLogs");
                });

            modelBuilder.Entity("Domain.Entities.Logs.SecurityLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileInputName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileInputSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileOutName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("QRImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("ShortLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SecurityLogs");
                });

            modelBuilder.Entity("Domain.Entities.OtherContext.FrequentlyQuestions", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FrequentlyQuestions");
                });

            modelBuilder.Entity("Domain.Entities.OtherContext.HomePageContext", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MainServicesH2Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainServicesPText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServicesInfoH1Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServicesInfoPText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopTitleText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HomePageContexts");
                });

            modelBuilder.Entity("Domain.Entities.OtherContext.PrivacyAndPolicy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrivacyAndPolicies");
                });

            modelBuilder.Entity("Domain.Entities.OtherContext.ReportBug", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("ProblemStatement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReportBugs");
                });

            modelBuilder.Entity("Domain.Entities.OtherContext.SocialNetworks", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("Telegram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Youtube")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SocialNetworks");
                });

            modelBuilder.Entity("Domain.Entities.OtherContext.TermsOfUse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutUs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dmca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TermsOfUses");
                });

            modelBuilder.Entity("Domain.Entities.OtherContext.TreeHelpSteps", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<string>("Service")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceType")
                        .HasColumnType("int");

                    b.Property<string>("Step1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Step2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Step3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TreeHelpSteps");
                });

            modelBuilder.Entity("Domain.Entities.OtherContext.WhyChooseUs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WhyChooseUs");
                });

            modelBuilder.Entity("Domain.Entities.Users.Admin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AddAdmin")
                        .HasColumnType("bit");

                    b.Property<long?>("Code")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CodeExpiration")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("date");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RemoveAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<bool>("Used")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });
#pragma warning restore 612, 618
        }
    }
}
