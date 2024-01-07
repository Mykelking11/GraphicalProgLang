using NUnit.Framework;
using ASE_Programming_Language; // Replace with the actual namespace of the class containing CheckSyntax
using System.Security.Cryptography;

/// <summary>
/// Test fixture for the SyntaxChecker class.
/// </summary>
[TestFixture]
public class SyntaxCheckerTests
{
    private IRandomNumberGenerator randomNumberGenerator;

    /// <summary>
    /// Test case to verify that CheckSyntax detects an invalid 'set loop' command.
    /// </summary>
    [Test]
    public void CheckSyntax_ShouldDetectInvalidSetLoopCommand()
    {
        // Arrange

        // Create an instance of Form1 (assuming SyntaxChecker is part of Form1)
        var syntaxChecker = new Form1(randomNumberGenerator);

        // Specify the lines containing the invalid 'set loop' command
        string[] lines = { "set loop ten" }; // Invalid because "ten" is not an integer

        // Act

        // Check the syntax and get the errors
        var errors = syntaxChecker.CheckSyntax(lines);

        // Assert

        // Verify that the errors collection has at least one item containing the expected error message
        Assert.That(errors, Has.Some.Contains("Invalid 'set loop' command."));
    }
}
