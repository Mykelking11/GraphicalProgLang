/// <summary>
/// Represents an interface for a random number generator.
/// </summary>
public interface IRandomNumberGenerator
{
    /// <summary>
    /// Generates a random integer within the specified range.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random number to generate.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number to generate.</param>
    /// <returns>A random integer within the specified range.</returns>
    int Next(int minValue, int maxValue);
}
