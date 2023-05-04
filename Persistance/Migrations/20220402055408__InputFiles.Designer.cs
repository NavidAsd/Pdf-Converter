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
    [Migration("20220402055408__InputFiles")]
    partial class _InputFiles
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

                    b.Property<long>("Rate")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<int>("Service")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FeaturesDetails");
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

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

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

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

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

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

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

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

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

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("date");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SecurityLogs");
                });

            modelBuilder.Entity("Domain.Entities.Users.Admin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountImage")
                        .HasColumnType("nvarchar(max)");

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
