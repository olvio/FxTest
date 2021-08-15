using System.Linq;
using The_Morpher;
using FxTest.Exceptions;
using System.Text.RegularExpressions;


namespace FxTest
{
    public class Processor
    {
        private IConverter _converter;
        public Processor(IConverter converter)
        {
            _converter = converter;
        }
        private decimal amount;
        public Fx ValidateAndArrange(string input)
        {
            ECLP eCLP = new ECLP(input);
            CommandResult result = eCLP.Parse();

            if (result.Args.Count < 3)
            {
                throw new InvalidInputException($"The input must consist of at least 3 space separeated values. Input: {input}");
            }

            string command = result.Args.First().ToString();
            if (command.ToLower() != "exchange")
            {
                throw new InvalidInputException($"The only currently supported command is 'Exchange'. Input: {command}");
            }

            string convertable = result.Args.Skip(2).First().ToString();
            if (!decimal.TryParse(convertable.Replace(",","."), out  amount))
            {
                throw new InvalidInputException($"The input could not be converted to decimal. Input: {convertable}");
            } 
            
            string currencies = result.Args.Skip(1).First().ToString();
            var expression = new Regex(@"^[a-zA-Z]{3}/[a-zA-Z]{3}$");
            if (!expression.IsMatch(currencies))
            {
                throw new InvalidInputException($"The currency pair must be in XXX/YYY format. Input: {currencies}");
            }

            var pair = currencies.Split('/');
            var fx = new Fx {  Amount = amount, MainISO = pair[0].ToUpper(), MoneyISO = pair[1].ToUpper() };

            return fx;
        }

        public decimal Convert(Fx input)
        {
            if (input.MainISO.Equals(input.MoneyISO))
            {
                return input.Amount;
            }
           var result = _converter.Convert(input.MainISO, input.MoneyISO, input.Amount);

            if (result ==  null)
            {
                throw new CurrencyNotFoundException($"The currency pair not found. Input: {input.MainISO}/{input.MoneyISO}");
            }
           return (decimal)result;
        }
    }
}
