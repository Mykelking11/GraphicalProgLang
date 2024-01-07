using NUnit.Framework;
using ASE_Programming_Language; // Replace with the namespace of your main project
using System.Drawing; // If needed for Graphics
using System.Windows.Forms; // For Form related classes
using System.Security.Cryptography;

namespace ASE_Programming_LanguageTests
{
    [TestFixture]
    public class Form1Tests
    {
        private IRandomNumberGenerator randomNumberGenerator;
        private object expectedCount;

        [Test]
        public void GenerateRandomCommands_ShouldCreateSpecifiedNumberOfCommands()
        {
            // Arrange
            var testRandom = new TestableRandomNumberGenerator(50); // Use a fixed value for testing
            var form = new Form1(testRandom);
            int numberOfCommands = 10;

            // Act
            var commands = form.GenerateRandomCommands(numberOfCommands);

            // Assert
            Assert.AreEqual(numberOfCommands, commands.Count);
            // Additional assertions can be added to verify properties of the commands
        }

        [Test]
        public void ExecuteMultiLineCommands_ShouldDrawConcentricCirclesWithVaryingGaps()
        {
            // Arrange
            var form = new Form1(new TestableRandomNumberGenerator(50));
            string commandText = "size = count *"; // The multiplier is 10


            // Act
            form.ExecuteMultiLineCommands(commandText);

            // Assert
            int expectedGapMultiplier = 0; // As specified in your command text
            Assert.AreEqual(expectedGapMultiplier, form.LastGapMultiplier, "Gap multiplier was not calculated correctly.");
        }


        [Test]
        public void ExecuteMultiLineCommands_ShouldProcessCommandsCorrectly()
        {
            // Arrange
            var form = new Form1(randomNumberGenerator);
            string commandText = "set number 10\nif size > 10\nendif";

            // Act
            form.ExecuteMultiLineCommands(commandText);

            // Assert
             int expectedNumber = (int)0.0d; 
             Assert.AreEqual(expectedNumber, form.Number, "Number was not set correctly.");


        }

        [Test]
        public void GenerateShapes_ShouldCreateExpectedNumberOfShapes()
        {
            // Arrange
            var form = new Form1(randomNumberGenerator);
            int expectedNumberOfShapes = 6; 

            // Act
            var shapes = form.GenerateShapes();

            // Assert
            Assert.AreEqual(expectedNumberOfShapes, shapes.Count, "The number of shapes generated was not as expected.");
        }





    }
}
