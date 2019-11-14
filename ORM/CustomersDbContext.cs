using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ORM
{
    public class CustomersDbContext : DbContext
    {

        public CustomersDbContext() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=Customers;Integrated Security=True")
        {

        }

        public CustomersDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CustomersDbContext, ORM.Migrations.Configuration>());
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .Ignore(x => x.OrdersCount);


            modelBuilder.Entity<Customer>()
                .ToTable("Customers")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Customer>()
                .HasOptional(x => x.Profile)
                .WithRequired(x => x.Customer);

            modelBuilder.Entity<Customer>()
                .HasMany(x => x.Orders)
                .WithRequired(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);
            
            modelBuilder.Entity<Profile>()
                .ToTable("Profiles")
                .HasKey(x => x.CustomerId);

            modelBuilder.Entity<Order>()
                .ToTable("Orders")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.OrderLines)
                .WithRequired(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<OrderLine>()
                .ToTable("OrderLines")
                .HasKey(x => x.Id);

            modelBuilder.Entity<OrderDetail>()
                .HasRequired(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);
        }

    }
}
