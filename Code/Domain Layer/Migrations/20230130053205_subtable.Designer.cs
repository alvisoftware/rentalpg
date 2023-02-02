﻿// <auto-generated />
using System;
using Domain_Layer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DomainLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230130053205_subtable")]
    partial class subtable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain_Layer.Models.Owners", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("altcontact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("deleteddate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("owners");
                });

            modelBuilder.Entity("DomainLayer.Models.AssignedProperty", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("deleteddate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("enddate")
                        .HasColumnType("datetime2");

                    b.Property<long>("propertyid")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("startdate")
                        .HasColumnType("datetime2");

                    b.Property<long>("tenantid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("assignedproperties");
                });

            modelBuilder.Entity("DomainLayer.Models.PropertyInfo", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("area")
                        .HasColumnType("float");

                    b.Property<DateTime>("availabledate")
                        .HasColumnType("datetime2");

                    b.Property<int>("balcony")
                        .HasColumnType("int");

                    b.Property<int>("bathroom")
                        .HasColumnType("int");

                    b.Property<int>("bedroom")
                        .HasColumnType("int");

                    b.Property<int>("cityid")
                        .HasColumnType("int");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("createdby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("deleteddate")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isapprove")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ownerid")
                        .HasColumnType("bigint");

                    b.Property<int>("propertytypeid")
                        .HasColumnType("int");

                    b.Property<string>("seourl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("specification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stateid")
                        .HasColumnType("int");

                    b.Property<int>("transtpetype")
                        .HasColumnType("int");

                    b.Property<string>("zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("propertyInfos");
                });

            modelBuilder.Entity("DomainLayer.Models.Queries", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("deleteddate")
                        .HasColumnType("datetime2");

                    b.Property<long>("propertyid")
                        .HasColumnType("bigint");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("tenantid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("queries");
                });

            modelBuilder.Entity("DomainLayer.Models.Subtable", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("deleteddate")
                        .HasColumnType("datetime2");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("messageid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("senderid")
                        .HasColumnType("bigint");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("subtables");
                });

            modelBuilder.Entity("DomainLayer.Models.Tenant", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("deleteddate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firsttname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lasttname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tenants");
                });
#pragma warning restore 612, 618
        }
    }
}
