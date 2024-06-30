using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolioManagement.Data.Context
{
    public class DataBaseContextApplication : DbContext
    {
        public DataBaseContextApplication(DbContextOptions<DataBaseContextApplication> options)
            : base(options)
        {
        }

        public DbSet<FundoImobiliario> FundosImobiliarios { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investimento>()
                        .HasOne(i => i.FundoImobiliario)
                        .WithOne(f => f.Investimento)
                        .HasForeignKey<Investimento>(i => i.FundoImobiliarioId)
                        .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}