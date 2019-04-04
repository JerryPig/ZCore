using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZDomain.Model;

namespace EntityFramework.Core
{
    public class ZCoreContext : DbContext
    {
        private static bool _created = false;
        public ZCoreContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        public ZCoreContext(DbContextOptions options) : base(options)
        {

        }

        public static string ConnnectString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source= C:\Users\Administrator\source\repos\ZCore.DB");
            }
        }

        public DbSet<Supplier> SysSupplier { get; set; }

        public DbSet<SupplierType> SupplierType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Supplier>(m =>
            {
                m.HasKey(e => e.Id);

                m.Property(e => e.SupplierName)
                .HasMaxLength(50);

                m.Property(e => e.ShortName)
                .HasMaxLength(50);

                m.Property(e => e.Remark)
                .HasMaxLength(255);

                m.Property(e => e.Province)
                .HasMaxLength(50);

                m.Property(e => e.City)
                .HasMaxLength(50);

                m.Property(e => e.Address)
                .HasMaxLength(50);

                m.Property(e => e.Status);
            });

            modelBuilder.Entity<SupplierType>(m =>
            {

                m.HasKey(e => e.Id);

                m.Property(e => e.TypeCode)
                .HasMaxLength(50);

                m.Property(e => e.TypeName)
                .HasMaxLength(50);


            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
