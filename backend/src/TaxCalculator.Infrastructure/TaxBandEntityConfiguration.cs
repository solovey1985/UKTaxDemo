using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Domain.Models;

namespace TaxCalculator.Infrastructure
{
    public class TaxBandConfiguration : IEntityTypeConfiguration<TaxBand>
    {
        public void Configure(EntityTypeBuilder<TaxBand> builder)
        {
            builder.HasKey(tb => tb.LowerLimit); // Setting LowerLimit as Primary Key
            builder.Property(tb => tb.Name).IsRequired();
            builder.Property(tb => tb.TaxRate).IsRequired();
        }
    }
}
