﻿using cakefactory.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cakefactory.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Personalization> Personalizations { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DocumentType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Personalization>().HasIndex(x => x.PersoName).IsUnique();
            modelBuilder.Entity<ProductType>().HasIndex(x => x.Description).IsUnique();
        }
    }
}
