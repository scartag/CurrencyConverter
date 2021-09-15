using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Data
{
    public class RateDbInitializer
    {
        private readonly ILogger<RateDbInitializer> _logger;
        private readonly RatesContext _ctx;
        public RateDbInitializer(ILogger<RateDbInitializer> logger, RatesContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }


        public async Task SeedAsync()
        {
            if (!_ctx.ExchangeRates.Any())
            {
				await AddRates();
			}
           
        }

        public async Task AddRates()
        {
			var codes = new List<string> { "USD", "EUR", "GBP", "AUD", "CAD", "NZD", "NGN" };


			var list = new List<ExchangeRate>();
			var random = new Random();

			for (int i = 0; i < 5; i++)
			{
				foreach (var code in codes)
				{
					var subs = codes.Where(x => x != code).ToList();


					foreach (var sub in subs)
					{
						var currentDate = DateTime.Today.AddDays(-i);
						var temp = list.FirstOrDefault(x => x.CurrencyTo == code && x.CurrencyFrom == sub && x.RateDate == currentDate);
						if (temp == null)
						{
							temp = new ExchangeRate { CurrencyFrom = code, CurrencyTo = sub, Rate = (decimal)random.NextDouble(), RateDate = currentDate };
							list.Add(temp);
						}


					}
				}
			}

			await _ctx.ExchangeRates.AddRangeAsync(list);

			await _ctx.SaveChangesAsync();
		}
    }
}
