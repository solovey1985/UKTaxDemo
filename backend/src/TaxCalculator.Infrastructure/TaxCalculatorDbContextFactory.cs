using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaxCalculator.Infrastructure
{
    public class TaxCalculatorDbContextFactory: IDesignTimeDbContextFactory<TaxCalculatorDbContext>
    {
        public TaxCalculatorDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaxCalculatorDbContext>();
            
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=YourDatabase;User Id=sa;Password=1qaz@WSX;TrustServerCertificate=True");
            
            return new TaxCalculatorDbContext(optionsBuilder.Options);
        }
    }
}
