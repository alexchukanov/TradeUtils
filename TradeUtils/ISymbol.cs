namespace TradeUtils
{
    public interface ISymbol
    {
        Currency BaseCurrency { get; }
        Currency SecondaryCurrency { get; }
        decimal Rate { get; }
    }
}