namespace FxTest
{
    public interface IConverter
    {
        decimal? Convert(string main, string money, decimal amount);
    }
}
