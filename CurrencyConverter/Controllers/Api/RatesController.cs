using CurrencyConverter.Lib.DTO;
using CurrencyConverter.Lib.Models;
using CurrencyConverter.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {

        private readonly IRateService rateService;

        public RatesController(IRateService _rateService)
        {
            rateService = _rateService;
        }

        /// <summary>
        /// Get a rate convertion
        /// </summary>
        /// <remarks>
        /// Example of the request
        ///     POST /api/v1/rates/
        /// </remarks>
        /// <returns>A single rate conversion</returns>
        /// <param name="request"></param>
        /// <response code="200">Returns a single rate conversion</response>
        /// <response code="404">Exchange rate was not found</response>
        /// <response code="400">Invalid query parameters</response>
        [HttpPost]
        [Route("", Name = nameof(GetRate))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRate(RateRequest request)
        {

            if (ModelState.IsValid)
            {
                var dto = Map(request);

                if (await rateService.RateExists(dto))
                {
                    var rate = await rateService.ConvertAmountByRate(dto);
                    var response = Map(rate);

                    return Ok(response);
                }

                return NotFound("The specified currency symbols were not found.");
            }

            return BadRequest("Invalid parameters were provided");
        }

        private RateResponse Map(ConversionDto dto) => new RateResponse(dto.RateDate, dto.ConversionAmount, dto.Rate);

        private RateDto Map(RateRequest request) => new RateDto(currencyFrom: request.CurrencyFrom, currencyTo: request.CurrencyTo, amount: request.Amount);
    }
}
