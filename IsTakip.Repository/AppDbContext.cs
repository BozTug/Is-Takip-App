using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Classes.SupplierClass;
using IsTakip.Core.Classes.UserClasses;
using IsTakip.Core.Classes.WareHouseClasses;
using Microsoft.EntityFrameworkCore;
using System.Reflection;



namespace IsTakip.Repository
{

    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Business> Businesses { get; set; }

        public DbSet<Jobfile> Jobfiles { get; set; }

        public DbSet<ProductionLead> ProductionLeads { get; set; }



        public DbSet<Agenda> Agendas { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerClass> CustomerClasses { get; set; }

        public DbSet<CustomerRepresentative> customerRepresentatives { get; set; }



        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Core.Classes.UserClasses.User> Users { get; set; }

        public DbSet<MailParameters> MailParameters { get; set; }



        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<WareHouseInventory> wareHouseInventories { get; set; }

        public DbSet<WareHouseShelf> wareHouseShelves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }



    }
}
