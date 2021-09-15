using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Lib.Models
{
    public class RateRequest
    {
        [Required]
        public string CurrencyFrom { get; set; }

        [Required]
        public string CurrencyTo { get; set; }

        [Range(double.Epsilon, double.MaxValue)]
        [Required]
        public decimal Amount { get; set; }
    }
}
