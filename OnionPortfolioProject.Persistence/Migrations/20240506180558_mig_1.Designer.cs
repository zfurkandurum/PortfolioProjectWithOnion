﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioProjectOnion.Persistence.Context;

#nullable disable

namespace OnionProtfolioProject.Persistence.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20240506180558_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArticleCategory", b =>
                {
                    b.Property<int>("ArticlesId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ArticlesId", "CategoriesCategoryId");

                    b.HasIndex("CategoriesCategoryId");

                    b.ToTable("ArticleCategory");
                });

            modelBuilder.Entity("OnionPortfolioProject.Domain.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("OnionPortfolioProject.Domain.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OnionPortfolioProject.Domain.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WhoAmIId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WhoAmIId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("OnionPortfolioProject.Domain.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IconPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WhoAmIId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WhoAmIId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("OnionPortfolioProject.Domain.WhoAmI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CvPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WhoAmIs");
                });

            modelBuilder.Entity("ArticleCategory", b =>
                {
                    b.HasOne("OnionPortfolioProject.Domain.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnionPortfolioProject.Domain.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnionPortfolioProject.Domain.Link", b =>
                {
                    b.HasOne("OnionPortfolioProject.Domain.WhoAmI", null)
                        .WithMany("Links")
                        .HasForeignKey("WhoAmIId");
                });

            modelBuilder.Entity("OnionPortfolioProject.Domain.Skill", b =>
                {
                    b.HasOne("OnionPortfolioProject.Domain.WhoAmI", null)
                        .WithMany("Skills")
                        .HasForeignKey("WhoAmIId");
                });

            modelBuilder.Entity("OnionPortfolioProject.Domain.WhoAmI", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}