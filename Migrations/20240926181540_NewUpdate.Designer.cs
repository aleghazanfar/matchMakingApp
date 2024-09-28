﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RishtaWebApp.Data;

#nullable disable

namespace RishtaWebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240926181540_NewUpdate")]
    partial class NewUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RishtaWebApp.Models.LookUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LookUps");
                });

            modelBuilder.Entity("RishtaWebApp.Models.MemberDetail", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BodyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("BrSisMarried")
                        .HasColumnType("int");

                    b.Property<int>("Brothers")
                        .HasColumnType("int");

                    b.Property<int>("CasteId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ComplexId")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DependsSibling")
                        .HasColumnType("int");

                    b.Property<string>("FatherOccupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuturePlans")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HomeDistricts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<int>("Income")
                        .HasColumnType("int");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KidsDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaritalStatusId")
                        .HasColumnType("int");

                    b.Property<int>("MonthlyIncome")
                        .HasColumnType("int");

                    b.Property<int>("MotherLanguageId")
                        .HasColumnType("int");

                    b.Property<string>("MotherOccupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.Property<string>("NatureOfJob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherProperties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parantage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QualificationId")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReqCasteId")
                        .HasColumnType("int");

                    b.Property<int>("ReqHeight")
                        .HasColumnType("int");

                    b.Property<int>("ReqMaritalStatusId")
                        .HasColumnType("int");

                    b.Property<int>("ReqNationalityId")
                        .HasColumnType("int");

                    b.Property<int>("ReqQualificationId")
                        .HasColumnType("int");

                    b.Property<int>("ReqSectId")
                        .HasColumnType("int");

                    b.Property<string>("Residence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectId")
                        .HasColumnType("int");

                    b.Property<int>("Sisters")
                        .HasColumnType("int");

                    b.Property<string>("SubCaste")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MemberDetails");
                });

            modelBuilder.Entity("RishtaWebApp.Models.PersonOrg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonOrgType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PersonOrgs");
                });
#pragma warning restore 612, 618
        }
    }
}
