using CurrencyConverter.Lib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Services.Contract
{
    public interface IRateService
    {
        Task<bool> RateExists(RateDto dto);

        Task<ConversionDto> ConvertAmountByRate(RateDto dto);
    }
}
