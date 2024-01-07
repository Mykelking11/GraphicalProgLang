using NUnit.Framework;
using ASE_Programming_Language; // Replace with the actual namespace of the class containing CheckSyntax
using System.Security.Cryptography;

[TestFixture]
public class SyntaxCheckerTests
{
    private IRandomNumberGenerator randomNumberGenerator;

    [Test]
    public void CheckSyntax_ShouldDetectInvalidSetLoopCommand()
    {
        // Arrange
        var syntaxChecker = new Form1(randomNumberGenerator);
        string[] lines = { "set loop ten" }; // Invalid because "ten" is not an integer

        // Act
        var errors = syntaxChecker.CheckSyntax(lines);

        // Assert
        Assert.That(errors, Has.Some.Contains("Invalid 'set loop' command."));
    }

}
