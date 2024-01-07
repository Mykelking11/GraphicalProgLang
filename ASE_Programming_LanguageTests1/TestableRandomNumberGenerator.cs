public class TestableRandomNumberGenerator : IRandomNumberGenerator
{
    private int _fixedValue;

    public TestableRandomNumberGenerator(int fixedValue)
    {
        _fixedValue = fixedValue;
    }

    public int Next(int minValue, int maxValue)
    {
        // Always returns the fixed value regardless of the min and max parameters
        return _fixedValue;
    }
}
