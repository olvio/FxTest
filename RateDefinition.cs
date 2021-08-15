using System.Collections.Generic;
using System.Linq;

namespace FxTest
{
    public class RateDefinition : IConverter
    {
        public RateDefinition()
        {
            ExchangeRates.Add(new Fx {  MainISO = "EUR", MoneyISO = "DDK", Amount = 743.94m/100 });
            ExchangeRates.Add(new Fx { MainISO = "USD", MoneyISO = "DDK", Amount = 663.11m/100 });
            ExchangeRates.Add(new Fx { MainISO = "GBP", MoneyISO = "DDK", Amount = 852.85m /100 });
            ExchangeRates.Add(new Fx { MainISO = "SEK", MoneyISO = "DDK", Amount = 76.10m/100 });
            ExchangeRates.Add(new Fx { MainISO = "CHF", MoneyISO = "DDK", Amount = 683.58m/100 });
            ExchangeRates.Add(new Fx { MainISO = "JPY", MoneyISO = "DDK", Amount = 5.9740m/100 });
        }

        List<Fx> ExchangeRates { get; set; } = new List<Fx>();

        public decimal? Convert(string main, string money, decimal amount)
        {
            var rate = ExchangeRates.Where(r => (r.MainISO == main && r.MoneyISO == money) || (r.MoneyISO == main && r.MainISO == money)).FirstOrDefault();

            if (rate !=null)
            {
                if (rate.MainISO.Equals(main))
                {
                    return rate.Amount/amount;
                }
                else
                {
                    return amount/rate.Amount;                   
                }
            }
            return null;
        }
    }
}
