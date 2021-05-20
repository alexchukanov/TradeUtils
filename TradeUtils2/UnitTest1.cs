using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TradeUtils;

namespace TradeUtils2
{
    [TestClass]
    public class CurrencyConverterTests
    {

        private static CurrencyConverter CreateConverter(params ISymbol[] symbols)
        {
            return new CurrencyConverter(symbols);
        }


        [TestMethod]
        // public void ReturnsSameVolumeForSameCurrency(decimal volume, Currency currency)
        public void ReturnsSameVolumeForSameCurrency()
        {
            decimal volume = 1;
            Currency currency = Currency.Eur;

            var converter = CreateConverter();

            var convertedVolume = converter.Convert(volume, currency, currency);

            Assert.AreEqual(volume, convertedVolume);
        }

        [TestMethod]
        // public void ReturnsSameVolumeForSameCurrency(decimal volume, Currency currency)
        public void ReturnsUsdVolumeToEurCurrency()
        {
            decimal volumeFrom = 10;
            decimal volumeTo = 12;
            decimal rate = 1.2m;

            Currency currencyFrom = Currency.Usd;
            Currency currencyTo = Currency.Eur;

            var st = new SymbolTest();
            st.BaseCurrency = currencyFrom;
            st.SecondaryCurrency = currencyTo;
            st.Rate = rate;

            ISymbol[] symbols = { st };

            var converter = CreateConverter(st);

            var convertedVolume = converter.Convert(volumeFrom, currencyFrom, currencyTo);

            Assert.AreEqual(volumeTo, convertedVolume);
        }
    }

    public class SymbolTest : ISymbol
    {
        public Currency BaseCurrency { get; set; }

		public Currency SecondaryCurrency { get; set; }
        		
		public decimal Rate { get; set; }
	}
}
