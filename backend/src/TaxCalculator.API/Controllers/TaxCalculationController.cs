using MediatR;

using Microsoft.AspNetCore.Mvc;

using TaxCalculator.Application.Commands;
using TaxCalculator.Application.DTO;

namespace TaxCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaxCalculationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Calculate the taxes based on annual salary
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaxCalculationDTO))]
        public async Task<ActionResult> TaxCalculateAsync(TaxCalculationCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
