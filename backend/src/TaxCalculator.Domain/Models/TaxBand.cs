using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Domain.Models
{
    public class TaxBand
    {
        public int LowerLimit { get; private set; }
        public string Name { get; private set; }
        public int? UpperLimit { get; private set; }
        public int TaxRate { get; private set; }

        public TaxBand(string name, int lowerLimit, int? upperLimit, int taxRate)
        {
            Name = name;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
            TaxRate = taxRate;
        }

        /// <summary>
        /// Calculate tax based on band limits.
        /// </summary>
        /// <param name="salary">Taxable salary.</param>
        /// <returns>The tax value based on the band limits.</returns>
        public decimal CalculateTax(decimal salary)
        {
           return salary * (TaxRate / 100m);
        }
    }
}
