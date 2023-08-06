using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TaxCalculator.Application.Commands;
using TaxCalculator.Application.DTO;
using TaxCalculator.Domain.Interfaces;
using TaxCalculator.Domain.Models;

namespace TaxCalculator.Application.Handlers
{
    public class TaxCalculationHandler : IRequestHandler<TaxCalculationCommand, TaxCalculationDTO>
    {
        private readonly ITaxBandRepository _taxBandsRepository;
        public TaxCalculationHandler(ITaxBandRepository? taxBandRepository)
        {
            _taxBandsRepository = taxBandRepository ?? throw new ArgumentNullException(nameof(taxBandRepository));
        }

        public async Task<TaxCalculationDTO> Handle(TaxCalculationCommand request, CancellationToken cancellationToken)
        {
            var taxBands = (await _taxBandsRepository.GetAllAsync()).OrderBy(tb => tb.LowerLimit);
            decimal salaryLeft = request.Salary;
            decimal totalTax = 0;

            foreach (var band in taxBands)
            {
                if (salaryLeft <= 0)
                {
                    break;
                }

                // Here, assuming the tax band's upper limit can be null
                decimal bandMax = band.UpperLimit ?? salaryLeft;
                decimal bandMin = band.LowerLimit;
                // Consider only the part of salary that falls into the band's range
                if (salaryLeft <= bandMax)
                {
                    bandMax = salaryLeft;
                    bandMin = 0;
                }

                var currnetTax = band.CalculateTax(bandMax - bandMin);
                totalTax += currnetTax;
                salaryLeft -= (bandMax - bandMin);
            }

            return new TaxCalculationDTO()
            {
                AnnualTaxPaid = totalTax,
                GrossAnnualSalary = request.Salary,
                NetAnnualSalary = request.Salary - totalTax,
                GrossMonthlySalary = Math.Round( (decimal)request.Salary / 12, 2),
                NetMonthlySalary = Math.Round((request.Salary - totalTax) / 12,2),
                MonthlyTaxPaid = Math.Round(totalTax / 12, 2)
            };
        }
    }
}
