using Microsoft.VisualStudio.TestTools.UnitTesting;
using FxTest;
using FxTest.Exceptions;

namespace FxTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReturnValidObject()
        {
            Processor processor = new Processor(new RateDefinition());

            var result = processor.ValidateAndArrange("Exchange eur/ddk 1");
            Assert.IsInstanceOfType(result, typeof(Fx));
        }

        [TestMethod]
        public void ShouldParseCommaSeparatedAmount()
        {
            Processor processor = new Processor(new RateDefinition());

            var result = processor.ValidateAndArrange("Exchange eur/ddk 1,56");
            Assert.IsInstanceOfType(result, typeof(Fx));
        }

        [TestMethod]
        public void ShouldReturnReversedPair()
        {
            Processor processor = new Processor(new RateDefinition());

            var result = processor.ValidateAndArrange("Exchange ddk/eur 1.56");
            Assert.IsInstanceOfType(result, typeof(Fx));
        }

        [TestMethod]
        public void ShouldReturnSamePair()
        {
            Processor processor = new Processor(new RateDefinition());

            var result = processor.ValidateAndArrange("Exchange ddk/ddk 2.5");
            Assert.IsInstanceOfType(result, typeof(Fx));
            Assert.AreEqual(2.5m, result.Amount);
        }

        [TestMethod]
        public void ShouldThrowInvalidInputException()
        {
            Processor processor = new Processor(new RateDefinition());
            Assert.ThrowsException<InvalidInputException>(() => processor.ValidateAndArrange("Exchange fdg-rrr 2.5"));
        }

        [TestMethod]
        public void ShouldThrowCurrencyNotFoundException()
        {
            Processor processor = new Processor(new RateDefinition());
            Assert.ThrowsException<CurrencyNotFoundException>(() => processor.Convert(new Fx { MainISO = "sdg", MoneyISO = "rrr", Amount = 0 }));
        }
    }
}
