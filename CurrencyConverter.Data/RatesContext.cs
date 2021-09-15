using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CurrencyConverter.Data
{
    public partial class RatesContext : DbContext
    {
        public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }

        public RatesContext(DbContextOptions<RatesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ExchangeRate>(entity =>
            {
                entity.ToTable("ExchangeRate");

                entity.Property(e => e.CurrencyFrom)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyTo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
