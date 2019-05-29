﻿// <auto-generated />
using System;
using BTSuggestions.DataAccessHandlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BTSuggestions.Web.Migrations
{
    [DbContext(typeof(BTSuggestionContext))]
    [Migration("20190529233504_init3")]
    partial class init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BTSuggestions.Core.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(1500);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("PainPointId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PainPointId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BTSuggestions.Core.Entities.PainPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Annotation")
                        .HasMaxLength(1500);

                    b.Property<string>("CompanyContact");

                    b.Property<string>("CompanyLocation");

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("IndustryType");

                    b.Property<int>("PriorityLevel");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(1500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("Type");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PainPoints");
                });

            modelBuilder.Entity("BTSuggestions.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Privilege");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BTSuggestions.Core.Entities.Comment", b =>
                {
                    b.HasOne("BTSuggestions.Core.Entities.PainPoint", "PainPoint")
                        .WithMany()
                        .HasForeignKey("PainPointId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BTSuggestions.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BTSuggestions.Core.Entities.PainPoint", b =>
                {
                    b.HasOne("BTSuggestions.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
