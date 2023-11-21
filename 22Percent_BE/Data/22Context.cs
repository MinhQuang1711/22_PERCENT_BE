using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Entities.Invoices.SubInvoices;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data
{
    public class _22Context :DbContext
    {
        public _22Context(DbContextOptions options) : base(options){ }

        public DbSet<User> Users { get; set; }  
        public DbSet<Report> Reports { get; set; }  
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<SaleInvoices> SaleInvoices { get; set; }
        public DbSet<DetailProduct> DetailProducts { get; set; }
        public DbSet<ImportInvoices> ImportInvoices { get; set; }
        public DbSet<PaymentInvoices> PaymentInvoices { get; set; }
        public DbSet<DetailIngredient> DetailIngredients { get; set; }
        public DbSet<DetailSaleInvoice> DetailSaleInvoices { get; set; }      
        public DbSet<DetailImportInvoice> DetailImportInvoices { get; set; }


        /*
            // Config project to db using connect string 
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            const string connectionString = "Server=localhost;User ID=root;Password=Tlua35016;Database=23Percent";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        /*
           // Create relationship for entites
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Config primary key
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<Report>().HasKey(e => e.Id);
            modelBuilder.Entity<Product>().HasKey(e=> e.Id); 
            modelBuilder.Entity<Ingredient>().HasKey(e=> e.Id);
            modelBuilder.Entity<SaleInvoices>().HasKey(e => e.Id);
            modelBuilder.Entity<DetailProduct>().HasKey(e => e.Id);          
            modelBuilder.Entity<ImportInvoices>().HasKey(e=> e.Id);
            modelBuilder.Entity<PaymentInvoices>().HasKey(e=> e.Id);
            modelBuilder.Entity<DetailIngredient>().HasKey(e => e.Id);
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
                .HasOne(e=> e.Product)
                .WithMany(e=> e.DetailSaleInvoices)
                .HasForeignKey(e=> e.ProductId)
                .IsRequired(); 

            modelBuilder.Entity<DetailSaleInvoice>()
                .HasOne(e=> e.SaleInvoices)
                .WithMany(e=> e.DetailSaleInvoices)
                .HasForeignKey(e=> e.SaleInvoiceId)
                .IsRequired();


            /*
                Config relationship many to many for ImportInvoice and Ingredient using DetailImportInvoice    
            */

            modelBuilder.Entity<DetailImportInvoice>()
                .HasOne(e=> e.ImportInvoices)
                .WithMany(e=> e.DetailImportInvoices)
                .HasForeignKey(e=> e.ImportInvoiceId)
                .IsRequired();

            modelBuilder.Entity<DetailImportInvoice>()
                .HasOne(e => e.Ingredient)
                .WithMany(e => e.DetailImportInvoices)
                .HasForeignKey(e => e.IngredientId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(e=> e.Products)
                .WithOne(e=> e.User)
                .HasForeignKey(e=> e.CreateUser)
                .IsRequired();
            modelBuilder.Entity<User>()
              .HasMany(e => e.Ingredients)
              .WithOne(e => e.User)
              .HasForeignKey(e => e.CreateUser)
              .IsRequired();
            modelBuilder.Entity<User>()
                .HasMany(e => e.SaleInvoices)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.CreateUser)
                .IsRequired(); 
            modelBuilder.Entity<User>()
                .HasMany(e => e.ImportInvoices)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.CreateUser)
                .IsRequired();
            modelBuilder.Entity<User>()
                .HasMany(e => e.PaymentInvoices)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.CreateUser)
                .IsRequired();
            modelBuilder.Entity<User>()
                .HasMany(e => e.Reports)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.CreateUser)
                .IsRequired();

            /*
                Config realtionship 1 - 1 between Ingredient with DetailIngredient
             */
            modelBuilder.Entity<Ingredient>()
                .HasOne(e => e.DetailIngredient)
                .WithOne(e => e.Ingredient)
                .HasForeignKey<DetailIngredient>(e => e.IngredientId)
                .IsRequired();



        }




    }
}
