﻿// <auto-generated />
using System;
using Infraestructure.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230117181647_AddCompanyTableAndProductUniqueConstraint")]
    partial class AddCompanyTableAndProductUniqueConstraint
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mattel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hasbro"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgeRestriction")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgeRestriction = 6,
                            CompanyId = 1,
                            Description = "MaxSteel vs Elementor",
                            ImageURL = "https://www.cinepremiere.com.mx/wp-content/uploads/2020/04/Max-Steel-ranking-.jpg",
                            Name = "MaxSteel",
                            Price = 205.85m
                        },
                        new
                        {
                            Id = 2,
                            AgeRestriction = 10,
                            CompanyId = 2,
                            Description = "Nonopoly Marvel",
                            ImageURL = "https://phantom-elmundo.unidadeditorial.es/8faa10a4f45cce9370d6f3d9d3632ea9/crop/0x213/1198x1009/resize/640/assets/multimedia/imagenes/2020/04/16/15870484935240.jpg",
                            Name = "Monopoly",
                            Price = 498.00m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
