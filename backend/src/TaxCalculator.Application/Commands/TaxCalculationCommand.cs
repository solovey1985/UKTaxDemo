using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TaxCalculator.Application.DTO;

namespace TaxCalculator.Application.Commands
{
    public class TaxCalculationCommand: IRequest<TaxCalculationDTO>
    {
        public int Salary { get; set; }
    }
}
