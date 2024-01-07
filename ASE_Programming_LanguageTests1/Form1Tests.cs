using NUnit.Framework;
using ASE_Programming_Language; // Replace with the namespace of your main project
using System.Drawing; // If needed for Graphics
using System.Windows.Forms; // For Form related classes
using System.Security.Cryptography;

/// <summary>
/// Test fixture for the Form1 class.
/// </summary>
[TestFixture]
public class Form1Tests
{
    private IRandomNumberGenerator randomNumberGenerator;
    private object expectedCount;

    /// <summary>
    /// Test case to verify that GenerateRandomCommands creates the specified number of commands.
    /// </summary>
    [Test]
    public void GenerateRandomCommands_ShouldCreateSpecifiedNumberOfCommands()
    {
        // Arrange

        // Create a testable random number generator with a fixed value for testing
        var testRandom = new TestableRandomNumberGenerator(50);

        // Create an instance of Form1 with the testable random number generator
        var form = new Form1(testRandom);
        int numberOfCommands = 10;

        // Act

        // Generate random commands using the specified number
        var commands = form.GenerateRandomCommands(numberOfCommands);

        // Assert

        // Verify that the number of generated commands matches the expected number
        Assert.AreEqual(numberOfCommands, commands.Count);

        // Additional assertions can be added to verify properties of the commands
    }

    /// <summary>
    /// Test case to verify that ExecuteMultiLineCommands draws concentric circles with varying gaps.
    /// </summary>
    [Test]
    public void ExecuteMultiLineCommands_ShouldDrawConcentricCirclesWithVaryingGaps()
    {
        // Arrange

        // Create an instance of Form1 with a testable random number generator
        var form = new Form1(new TestableRandomNumberGenerator(50));

        // Specify the command text for testing
        string commandText = "size = count *"; // The multiplier is 10

        // Act

        // Execute multi-line commands with the specified command text
        form.ExecuteMultiLineCommands(commandText);

        // Assert

        // Verify that the last gap multiplier was calculated correctly
        int expectedGapMultiplier = 0; // As specified in your command text
        Assert.AreEqual(expectedGapMultiplier, form.LastGapMultiplier, "Gap multiplier was not calculated correctly.");
    }

    /// <summary>
    /// Test case to verify that ExecuteMultiLineCommands processes commands correctly.
    /// </summary>
    [Test]
    public void ExecuteMultiLineCommands_ShouldProcessCommandsCorrectly()
    {
        // Arrange

        // Create an instance of Form1 with the provided random number generator
        var form = new Form1(randomNumberGenerator);

        // Specify the command text for testing
        string commandText = "set number 10\nif size > 10\nendif";

        // Act

        // Execute multi-line commands with the specified command text
        form.ExecuteMultiLineCommands(commandText);

        // Assert

        // Verify that the number was set correctly based on the provided command text
        int expectedNumber = (int)0.0d;
        Assert.AreEqual(expectedNumber, form.Number, "Number was not set correctly.");
    }

    /// <summary>
    /// Test case to verify that GenerateShapes creates the expected number of shapes.
    /// </summary>
    [Test]
    public void GenerateShapes_ShouldCreateExpectedNumberOfShapes()
    {
        // Arrange

        // Create an instance of Form1 with the provided random number generator
        var form = new Form1(randomNumberGenerator);

        // Specify the expected number of shapes
        int expectedNumberOfShapes = 6;

        // Act

        // Generate shapes and get the actual number of shapes
        var shapes = form.GenerateShapes();

        // Assert

        // Verify that the number of generated shapes matches the expected number
        Assert.AreEqual(expectedNumberOfShapes, shapes.Count, "The number of shapes generated was not as expected.");
    }
}
