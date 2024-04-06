using NUnit.Framework;
using MultiOperationCalculator.Library;

namespace MultiOperationCalculator.Tests.ParsingTests
{
    [TestFixture]
    public class ParsingTests
    {
        [Test]
        public void ParseToArrayMathString_ValidInput_ReturnsExpectedArray()
        {
            // Arrange
            string mathString = "5.5   +   3.14 *2-10/2          ";
            string[] expectedArray = { "5,5", "+", "3,14", "*", "2", "-", "10", "/", "2" };

            // Act
            string[] actualArray = Parsing.ParseToArrayMathString(mathString);

            // Assert
            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void ParseToArrayMathString_InputWithLetters_ThrowsArgumentException()
        {
            // Arrange
            string mathString = "5.5+3a*2-10/2";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Parsing.ParseToArrayMathString(mathString));
        }

        [Test]
        public void ParseToArrayMathString_EmptyInput_ReturnsEmptyArray()
        {
            // Arrange
            string mathString = "";
            string[] expectedArray = Array.Empty<string>();

            // Act
            string[] actualArray = Parsing.ParseToArrayMathString(mathString);

            // Assert
            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void ParseToArrayMathString_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string mathString = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => Parsing.ParseToArrayMathString(mathString));
        }
    }
}
