﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeTable.Logging.DBContext;

#nullable disable

namespace TimeTable.Migrations.EFLogger
{
    [DbContext(typeof(EFLoggerContext))]
    [Migration("20220207234547_LogDB")]
    partial class LogDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TimeTable.Logging.DBContext.LogElement", b =>
                {
                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdditionalMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryName", "Date");

                    b.HasIndex("RequestId");

                    b.ToTable("LogElements");
                });

            modelBuilder.Entity("TimeTable.Logging.DBContext.RequestElement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Request")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Response")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RequestElements");
                });

            modelBuilder.Entity("TimeTable.Logging.DBContext.LogElement", b =>
                {
                    b.HasOne("TimeTable.Logging.DBContext.RequestElement", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");

                    b.Navigation("Request");
                });
#pragma warning restore 612, 618
        }
    }
}