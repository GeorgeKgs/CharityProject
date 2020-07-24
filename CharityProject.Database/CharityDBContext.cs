using CharityProject.Entities.DomainClasses;
using CharityProject.Entities.EshopEntities;
using CharityProject.Entities.SignatureClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Database
{
    public class CharityDBContext : DbContext, IDisposable
    {

        public CharityDBContext() : base("name=DBConnection")
        {

        }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }       
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Signature> Signatures { get; set; }


        //---------------------------FLUENT API CONFIGURATION-------------------------------------//
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Donation>()
                        .HasRequired<Partner>(d => d.Partner)
                        .WithMany(p => p.Donations);

            modelBuilder.Entity<Donation>()
                        .HasRequired<Plan>(d => d.Plan)
                        .WithMany(p => p.Donations);
        
        }

        public System.Data.Entity.DbSet<CharityProject.Entities.ViewModels.IndexVm> IndexVms { get; set; }

        public System.Data.Entity.DbSet<CharityProject.Entities.CartEntities.ProductVm> ProductVms { get; set; }

        public System.Data.Entity.DbSet<CharityProject.Entities.CartEntities.Cart> Carts { get; set; }
    }
}
