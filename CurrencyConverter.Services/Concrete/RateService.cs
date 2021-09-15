using CurrencyConverter.Data;
using CurrencyConverter.Lib.DTO;
using CurrencyConverter.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.Services.Concrete
{
    public class RateService : IRateService
    {
        private readonly RatesContext ctx;
        public RateService(RatesContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<ConversionDto> ConvertAmountByRate(RateDto dto)
        {
            if (dto.CurrencyFrom == dto.CurrencyTo)
            {
                return new ConversionDto(DateTime.Today, dto.Amount, 1m);
            }

            var rateItem = await ctx.ExchangeRates
               .Where(x => (x.CurrencyFrom == dto.CurrencyFrom && x.CurrencyTo == dto.CurrencyTo) || 
               (x.CurrencyFrom == dto.CurrencyTo && x.CurrencyTo == dto.CurrencyFrom))
               .OrderByDescending(p => p.RateDate)
               .FirstOrDefaultAsync();

            var converted = 0m;
            var rate = 0m;
            if (rateItem.CurrencyFrom == dto.CurrencyFrom)
            {
                rate = rateItem.Rate;
                converted = rate * dto.Amount;
            }
            else
            {
                rate = (1 / rateItem.Rate);
                converted = rate * dto.Amount;
            }

            var resultDto = new ConversionDto(rateItem.RateDate, converted, rate);

            return resultDto;
        }

        public async Task<bool> RateExists(RateDto dto)
        {
            if (dto.CurrencyFrom == dto.CurrencyTo)
            {
                return await ctx.ExchangeRates.AnyAsync(p => p.CurrencyFrom == dto.CurrencyFrom || p.CurrencyTo == dto.CurrencyFrom);
            }

            var result = await ctx.ExchangeRates
                .AnyAsync(x => (x.CurrencyFrom == dto.CurrencyFrom && x.CurrencyTo == dto.CurrencyTo) || (x.CurrencyFrom == dto.CurrencyTo && x.CurrencyTo == dto.CurrencyFrom));

            return result;
        }
    }
}
