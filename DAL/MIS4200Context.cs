using System;
using System.Collections.Generic;
using System.Data.Entity; // this is needed to access the models
using System.Linq;
using System.Web;
using SBurkeMIS4200.Models; // this needed to access the DbContext object

namespace SBurkeMIS4200.DAL
{
    public class MIS4200Context : DbContext // inherits from DbContext
    {
        public MIS4200Context() : base("name=DefaultConnection")
        {
            // add the set initializer statement here
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MIS4200Context, SBurkeMIS4200.Migrations.MISContext.Configuration>("DefaultConnection"));
        }

        // this method is a "constructor" and is called when a new context is created
        // the base attribute says which connection string to use
        
        // include each object here. the value inside <> is the name of the class,
        // the value outside should generally be the plural of the class name
        // and is the name used to reference the entity in code

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        // sd2 assignment

        public DbSet<Car> Cars { get; set; }
        public DbSet<Salesperson> Salespeople { get; set; }

        public DbSet<CustomerCar> CustomerCars { get; set; }

        // add this method - it will be used later
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}