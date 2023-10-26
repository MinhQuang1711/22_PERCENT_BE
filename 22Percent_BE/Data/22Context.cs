using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Entities.Invoices.SubInvoices;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data
{
    public class _22Context :DbContext
    {
        public _22Context(DbContextOptions options) : base(options){ }


        public DbSet<User> Users { get; set; }  
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<SaleInvoices> SaleInvoices { get; set; }
        public DbSet<DetailProduct> DetailProducts { get; set; }
        public DbSet<ImportInvoices> ImportInvoices { get; set; }
        public DbSet<PaymentInvoices> PaymentInvoices { get; set; }
        public DbSet<DetailSaleInvoice> DetailSaleInvoices { get; set; }      
        public DbSet<DetailImportInvoice> DetailImportInvoices { get; set; }


        /*
            // Config project to db using connect string 
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            const string connectionString = "Server=localhost;User ID=root;Password=Tlua35016;Database=22Percent";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        /*
           // Create relationship for entites
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Config primary key

            modelBuilder.Entity<User>().HasKey(e=> e.Id);
            modelBuilder.Entity<Product>().HasKey(e=> e.Id);
            modelBuilder.Entity<Ingredient>().HasKey(e=> e.Id);
            modelBuilder.Entity<SaleInvoices>().HasKey(e => e.Id);
            modelBuilder.Entity<DetailProduct>().HasKey(e => e.Id);          
            modelBuilder.Entity<ImportInvoices>().HasKey(e=> e.Id);
            modelBuilder.Entity<PaymentInvoices>().HasKey(e=> e.Id);
            modelBuilder.Entity<DetailSaleInvoice>().HasKey(e => e.Id);
            modelBuilder.Entity<DetailImportInvoice>().HasKey(e => e.Id);


            /*
                Config relationship many to many for Product and Ingredient using DetailProduct
            */

            modelBuilder.Entity<DetailProduct>()
                .HasOne(dp=> dp.Ingredient)
                .WithMany(e=> e.DetailProducts)
                .HasForeignKey(e=> e.IngredientID)
                .IsRequired();

            modelBuilder.Entity<DetailProduct>()
                .HasOne(e => e.Product)
                .WithMany(e => e.DetailProducts)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();


            /*
                Config relationship many to many for SaleInvoice and Product using DtailSaleInvoice    
            */
            modelBuilder.Entity<DetailSaleInvoice>()
                .HasOne(e=> e.product)
                .WithMany(e=> e.DetailSaleInvoices)
                .HasForeignKey(e=> e.productId)
                .IsRequired(); 

            modelBuilder.Entity<DetailSaleInvoice>()
                .HasOne(e=> e.saleInvoices)
                .WithMany(e=> e.detailSaleInvoices)
                .HasForeignKey(e=> e.saleInvoiceId)
                .IsRequired();


            /*
                Config relationship many to many for ImportInvoice and Ingredient using DetailImportInvoice    
            */

            modelBuilder.Entity<DetailImportInvoice>()
                .HasOne(e=> e.importInvoices)
                .WithMany(e=> e.detailImportInvoices)
                .HasForeignKey(e=> e.importInvoiceId)
                .IsRequired();

            modelBuilder.Entity<DetailImportInvoice>()
                .HasOne(e => e.ingredient)
                .WithMany(e => e.DetailImportInvoices)
                .HasForeignKey(e => e.ingredientId)
                .IsRequired();
        }




    }
}
