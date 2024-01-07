using System;

/// <summary>
/// Represents a random number generator using the System.Random class.
/// </summary>
public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _random = new Random();

    /// <summary>
    /// Generates a random integer within the specified range.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random number to generate.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number to generate.</param>
    /// <returns>A random integer within the specified range.</returns>
    public int Next(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }
}
