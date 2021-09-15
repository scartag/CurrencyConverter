using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Lib.DTO
{
    public class RateDto
    {
        public string CurrencyFrom { get; }

        public string CurrencyTo { get; }

        public decimal Amount { get;}

        public RateDto(string currencyFrom, string currencyTo, decimal amount)
        {
            CurrencyFrom = currencyFrom;
            CurrencyTo = currencyTo;
            Amount = amount;
        }
    }
}
