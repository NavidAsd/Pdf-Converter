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
    [Migration("20220402054208__ConvertLog")]
    partial class _ConvertLog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Arabic_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    
                    b.Property<string>("QRImage")
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
#pragma warning restore 612, 618
        }
    }
}