using System;
using System.Collections.Generic;

namespace TradeUtils
{
    public class CurrencyConverter
    {  
        Dictionary<string, decimal> rateTable = new Dictionary<string, decimal>(); 
                
        public CurrencyConverter(IEnumerable<ISymbol> symbols)
        {
            foreach (var sym in symbols)
            {
                string valKey = $"{sym.BaseCurrency}-{sym.SecondaryCurrency}";
                rateTable.Add(valKey, sym.Rate);
            }
        }

        public decimal Convert(decimal volume, Currency currencyFrom, Currency currencyTo)
        {
            decimal result = 0;

            if (currencyFrom == currencyTo)
            {
                result = volume;
            }
            else
            {
                string symbol = $"{currencyFrom.ToString()}-{currencyTo.ToString()}";
                result = rateTable[symbol] * volume;
            }
            return result;
        }
    }
}