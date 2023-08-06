using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TaxCalculator.Domain.Interfaces;
using TaxCalculator.Domain.Models;

namespace TaxCalculator.Infrastructure.Repositories
{
    public class TaxBandRepository : ITaxBandRepository
    {
        private readonly TaxCalculatorDbContext _dbContext;

        public TaxBandRepository(TaxCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaxBand>> GetAllAsync()
        {
            return await _dbContext.TaxBands.ToListAsync();
        }
    }
}
