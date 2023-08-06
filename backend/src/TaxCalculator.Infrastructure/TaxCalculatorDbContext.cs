using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TaxCalculator.Domain.Models;

namespace TaxCalculator.Infrastructure
{
    public class TaxCalculatorDbContext: DbContext
    {
        public DbSet<TaxBand> TaxBands { get; set; }
        public TaxCalculatorDbContext(DbContextOptions<TaxCalculatorDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaxBandConfiguration());
        }
    }
}
