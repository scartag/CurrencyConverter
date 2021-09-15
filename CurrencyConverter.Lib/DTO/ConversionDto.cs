using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Lib.DTO
{
    public class ConversionDto
    {
        public DateTime RateDate { get; }

        public decimal Rate { get; set; }

        public decimal ConversionAmount { get; }

        public ConversionDto(DateTime rateDate, decimal conversionAmount, decimal rate)
        {
            RateDate = rateDate;
            ConversionAmount = conversionAmount;
            Rate = rate;
        }
    }
}
