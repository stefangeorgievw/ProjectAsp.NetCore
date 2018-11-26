﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Web.Data;

namespace Project.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181126151506_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Project.Models.Account", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("CompanyProfileId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Project.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyProfileId");

                    b.Property<string>("JobId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProfileId");

                    b.HasIndex("JobId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Project.Models.CompanyProfile", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Rating");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.ToTable("CompaniesProfiles");
                });

            modelBuilder.Entity("Project.Models.Contract", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("CompanyProfileId");

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<string>("JobId");

                    b.Property<string>("UserId");

                    b.Property<string>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CompanyProfileId");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Project.Models.Job", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<decimal>("MaximumPrice");

                    b.Property<DateTime?>("StartDate");

                    b.Property<int>("Status");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Project.Models.UserProfile", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Project.Models.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Project.Models.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project.Models.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Project.Models.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Models.Category", b =>
                {
                    b.HasOne("Project.Models.CompanyProfile")
                        .WithMany("Categories")
                        .HasForeignKey("CompanyProfileId");

                    b.HasOne("Project.Models.Job")
                        .WithMany("Categories")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("Project.Models.CompanyProfile", b =>
                {
                    b.HasOne("Project.Models.Account", "Account")
                        .WithOne("CompanyProfile")
                        .HasForeignKey("Project.Models.CompanyProfile", "AccountId");
                });

            modelBuilder.Entity("Project.Models.Contract", b =>
                {
                    b.HasOne("Project.Models.Account", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Project.Models.CompanyProfile")
                        .WithMany("Contracts")
                        .HasForeignKey("CompanyProfileId");

                    b.HasOne("Project.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId");

                    b.HasOne("Project.Models.Account", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Project.Models.UserProfile")
                        .WithMany("Contracts")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("Project.Models.Job", b =>
                {
                    b.HasOne("Project.Models.CompanyProfile", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Project.Models.UserProfile", "User")
                        .WithMany("Jobs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Project.Models.UserProfile", b =>
                {
                    b.HasOne("Project.Models.Account", "Account")
                        .WithOne("UserProfile")
                        .HasForeignKey("Project.Models.UserProfile", "AccountId");
                });
#pragma warning restore 612, 618
        }
    }
}
