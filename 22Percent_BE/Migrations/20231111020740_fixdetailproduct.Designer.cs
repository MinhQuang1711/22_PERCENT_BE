﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _22Percent_BE.Data;

#nullable disable

namespace _22Percent_BE.Migrations
{
    [DbContext(typeof(_22Context))]
    [Migration("20231111020740_fixdetailproduct")]
    partial class fixdetailproduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("_22Percent_BE.Data.Entities.DetailImportInvoice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("importInvoiceId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ingredientId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("price")
                        .HasColumnType("double");

                    b.Property<double>("weight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("importInvoiceId");

                    b.HasIndex("ingredientId");

                    b.ToTable("DetailImportInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.DetailProduct", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<string>("IngredientID")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("IngredientID");

                    b.HasIndex("ProductId");

                    b.ToTable("DetailProducts");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.DetailSaleInvoice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("productId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("saleInvoiceId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("productId");

                    b.HasIndex("saleInvoiceId");

                    b.ToTable("DetailSaleInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Ingredient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<double>("ImportPrice")
                        .HasColumnType("double");

                    b.Property<double>("Loss")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("NetWeight")
                        .HasColumnType("double");

                    b.Property<double>("RealWeight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.ImportInvoices", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("createUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("total")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("ImportInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.PaymentInvoices", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("createUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("descriptions")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("total")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("PaymentInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.SaleInvoices", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("createUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("discount")
                        .HasColumnType("double");

                    b.Property<double>("quantity")
                        .HasColumnType("double");

                    b.Property<double>("total")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("SaleInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<double>("Profit")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("createUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.DetailImportInvoice", b =>
                {
                    b.HasOne("_22Percent_BE.Data.Entities.Invoices.SubInvoices.ImportInvoices", "importInvoices")
                        .WithMany("detailImportInvoices")
                        .HasForeignKey("importInvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_22Percent_BE.Data.Entities.Ingredient", "ingredient")
                        .WithMany("DetailImportInvoices")
                        .HasForeignKey("ingredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("importInvoices");

                    b.Navigation("ingredient");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.DetailProduct", b =>
                {
                    b.HasOne("_22Percent_BE.Data.Entities.Ingredient", "Ingredient")
                        .WithMany("DetailProducts")
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_22Percent_BE.Data.Entities.Product", "Product")
                        .WithMany("DetailProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.DetailSaleInvoice", b =>
                {
                    b.HasOne("_22Percent_BE.Data.Entities.Product", "product")
                        .WithMany("DetailSaleInvoices")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_22Percent_BE.Data.Entities.Invoices.SubInvoices.SaleInvoices", "saleInvoices")
                        .WithMany("detailSaleInvoices")
                        .HasForeignKey("saleInvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("saleInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Ingredient", b =>
                {
                    b.Navigation("DetailImportInvoices");

                    b.Navigation("DetailProducts");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.ImportInvoices", b =>
                {
                    b.Navigation("detailImportInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.SaleInvoices", b =>
                {
                    b.Navigation("detailSaleInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Product", b =>
                {
                    b.Navigation("DetailProducts");

                    b.Navigation("DetailSaleInvoices");
                });
#pragma warning restore 612, 618
        }
    }
}
