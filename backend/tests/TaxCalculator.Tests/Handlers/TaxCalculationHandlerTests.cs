using NUnit.Framework;
using TaxCalculator.Application.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.Commands;
using TaxCalculator.Application.DTO;
using TaxCalculator.Domain.Interfaces;
using TaxCalculator.Domain.Models;
using Moq;

namespace TaxCalculator.Application.Handlers.Tests
{
    [TestFixture()]
    public class TaxCalculationHandlerTests
    {
        private Mock<ITaxBandRepository> _taxBandRepoMock;
        private TaxCalculationHandler _taxCalculationHandler;

        [SetUp]
        public void Setup()
        {
            _taxBandRepoMock = new Mock<ITaxBandRepository>();
            _taxCalculationHandler = new TaxCalculationHandler(_taxBandRepoMock.Object);

            var taxBands = new List<TaxBand>
        {
            new TaxBand("Tax Band A", 0, 5000,  0),
            new TaxBand("Tax Band B",5000, 20000, 20),
            new TaxBand( "Tax Band C", 20000, null, 40 ),
        };

            _taxBandRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(taxBands);
        }
        [Test]
        [TestCase(10000, 1000)]
        [TestCase(40000, 11000)]
        public async Task Handle_GivenSalary_ComputesCorrectValues(int salary, int expectedAnnualTax)
        {
            var expectedNetAnnualSalary = salary - expectedAnnualTax;
            var expectedNetMonthlySalary = Math.Round((decimal)expectedNetAnnualSalary / 12, 2);
            var expectedMonthlyTax = Math.Round((decimal)expectedAnnualTax / 12, 2);

            var command = new TaxCalculationCommand { Salary = salary };
            var result = await _taxCalculationHandler.Handle(command, CancellationToken.None);

            Assert.That(result.GrossAnnualSalary, Is.EqualTo(salary));
            Assert.That(result.AnnualTaxPaid, Is.EqualTo(expectedAnnualTax));
            Assert.That(result.NetAnnualSalary, Is.EqualTo(expectedNetAnnualSalary));
            Assert.That(result.NetMonthlySalary, Is.EqualTo(expectedNetMonthlySalary));
            Assert.That(result.MonthlyTaxPaid, Is.EqualTo(expectedMonthlyTax));
        }
    }
}