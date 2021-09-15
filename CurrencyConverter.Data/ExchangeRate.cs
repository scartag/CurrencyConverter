using System;
using System.Collections.Generic;

namespace CurrencyConverter.Data
{
    public partial class ExchangeRate
    {
        public int Id { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public decimal Rate { get; set; }
        public DateTime RateDate { get; set; }
    }
}
