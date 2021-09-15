using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Lib.Models
{
    public class RateResponse
    {
        public DateTime RateDate { get; set; }

        public decimal ConversionAmount { get; }

        public decimal Rate { get; set; }

        public RateResponse(DateTime rateDate, decimal conversionAmount, decimal rate)
        {
            RateDate = rateDate;
            ConversionAmount = conversionAmount;
            Rate = rate;
        }
    }
}
