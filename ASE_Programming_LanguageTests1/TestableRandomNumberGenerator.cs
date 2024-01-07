/// <summary>
/// A testable implementation of the IRandomNumberGenerator interface.
/// </summary>
public class TestableRandomNumberGenerator : IRandomNumberGenerator
{
    private int _fixedValue;

    /// <summary>
    /// Initializes a new instance of the TestableRandomNumberGenerator class with a fixed value.
    /// </summary>
    /// <param name="fixedValue">The fixed value to be returned by the Next method.</param>
    public TestableRandomNumberGenerator(int fixedValue)
    {
        _fixedValue = fixedValue;
    }

    /// <summary>
    /// Generates a random integer within the specified range (always returns the fixed value).
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random number to generate.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number to generate.</param>
    /// <returns>The fixed value specified during initialization.</returns>
    public int Next(int minValue, int maxValue)
    {
        // Always returns the fixed value regardless of the min and max parameters
        return _fixedValue;
    }
}
