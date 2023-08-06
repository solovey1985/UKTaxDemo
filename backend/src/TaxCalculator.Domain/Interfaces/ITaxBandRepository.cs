using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaxCalculator.Domain.Models;

namespace TaxCalculator.Domain.Interfaces
{
    public interface ITaxBandRepository
    {
        Task<IEnumerable<TaxBand>> GetAllAsync();
    }
}
