﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _22Percent_BE.Data;

#nullable disable

namespace _22Percent_BE.Migrations
{
    [DbContext(typeof(_22Context))]
    partial class _22ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("_22Percent_BE.Data.Entities.DetailImportInvoice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ImportInvoiceId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IngredientId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ImportInvoiceId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DetailImportInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.DetailIngredient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IngredientId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("ToalCost")
                        .HasColumnType("double");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId")
                        .IsUnique();

                    b.ToTable("DetailIngredients");
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

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SaleInvoiceId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleInvoiceId");

                    b.ToTable("DetailSaleInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Ingredient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

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

                    b.HasIndex("CreateUser");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.ImportInvoices", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Total")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CreateUser");

                    b.ToTable("ImportInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.PaymentInvoices", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Total")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CreateUser");

                    b.ToTable("PaymentInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.SaleInvoices", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Discount")
                        .HasColumnType("double");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CreateUser");

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
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<double>("Profit")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CreateUser");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Report", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("FinalProfit")
                        .HasColumnType("double");

                    b.Property<DateTime>("FromTime")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("MaterialCost")
                        .HasColumnType("double");

                    b.Property<double>("OtherCost")
                        .HasColumnType("double");

                    b.Property<double>("Revenue")
                        .HasColumnType("double");

                    b.Property<double>("SaleProfit")
                        .HasColumnType("double");

                    b.Property<DateTime>("ToTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CreateUser");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.DetailImportInvoice", b =>
                {
                    b.HasOne("_22Percent_BE.Data.Entities.Invoices.SubInvoices.ImportInvoices", "ImportInvoices")
                        .WithMany("DetailImportInvoices")
                        .HasForeignKey("ImportInvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_22Percent_BE.Data.Entities.Ingredient", "Ingredient")
                        .WithMany("DetailImportInvoices")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImportInvoices");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.DetailIngredient", b =>
                {
                    b.HasOne("_22Percent_BE.Data.Entities.Ingredient", "Ingredient")
                        .WithOne("DetailIngredient")
                        .HasForeignKey("_22Percent_BE.Data.Entities.DetailIngredient", "IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");
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
                    b.HasOne("_22Percent_BE.Data.Entities.Product", "Product")
                        .WithMany("DetailSaleInvoices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_22Percent_BE.Data.Entities.Invoices.SubInvoices.SaleInvoices", "SaleInvoices")
                        .WithMany("DetailSaleInvoices")
                        .HasForeignKey("SaleInvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SaleInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Ingredient", b =>
                {
                    b.HasOne("_22Percent_BE.Data.Entities.User", "User")
                        .WithMany("Ingredients")
                        .HasForeignKey("CreateUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.ImportInvoices", b =>
                {
                    b.HasOne("_22Percent_BE.Data.Entities.User", "User")
                        .WithMany("ImportInvoices")
                        .HasForeignKey("CreateUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.PaymentInvoices", b =>
                {
                    b.HasOne("_22Percent_BE.Data.Entities.User", "User")
                        .WithMany("PaymentInvoices")
                        .HasForeignKey("CreateUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.SaleInvoices", b =>
                {
                    b.HasOne("_22Percent_BE.Data.Entities.User", "User")
                        .WithMany("SaleInvoices")
                        .HasForeignKey("CreateUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Product", b =>
                {
                    b.HasOne("_22Percent_BE.Data.Entities.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("CreateUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Report", b =>
                {
                    b.HasOne("_22Percent_BE.Data.Entities.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("CreateUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Ingredient", b =>
                {
                    b.Navigation("DetailImportInvoices");

                    b.Navigation("DetailIngredient")
                        .IsRequired();

                    b.Navigation("DetailProducts");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.ImportInvoices", b =>
                {
                    b.Navigation("DetailImportInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Invoices.SubInvoices.SaleInvoices", b =>
                {
                    b.Navigation("DetailSaleInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.Product", b =>
                {
                    b.Navigation("DetailProducts");

                    b.Navigation("DetailSaleInvoices");
                });

            modelBuilder.Entity("_22Percent_BE.Data.Entities.User", b =>
                {
                    b.Navigation("ImportInvoices");

                    b.Navigation("Ingredients");

                    b.Navigation("PaymentInvoices");

                    b.Navigation("Products");

                    b.Navigation("Reports");

                    b.Navigation("SaleInvoices");
                });
#pragma warning restore 612, 618
        }
    }
}
