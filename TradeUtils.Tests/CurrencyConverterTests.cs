using NUnit.Framework;

namespace TradeUtils.Tests
{
    [TestFixture]
    public class CurrencyConverterTests
    {
        private static CurrencyConverter CreateConverter(params ISymbol[] symbols)
        {
            return new CurrencyConverter(symbols);
        }

        [TestCase(1, Currency.Eur)]
        [TestCase(2, Currency.Chf)]
        public void ReturnsSameVolumeForSameCurrency(decimal volume, Currency currency)
        {
            var converter = CreateConverter();

            var convertedVolume = converter.Convert(volume, currency, currency);

            Assert.AreEqual(volume, convertedVolume);
        }
    }
}