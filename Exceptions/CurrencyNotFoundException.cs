using System;

namespace FxTest.Exceptions
{
    [Serializable]
    public class CurrencyNotFoundException : Exception
    {
        public CurrencyNotFoundException()
        {
        }

        public CurrencyNotFoundException(string message)
            : base(message)
        {
        }

        public CurrencyNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
