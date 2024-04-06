using NUnit.Framework;
using MultiOperationCalculator.Library;

namespace MultiOperationCalculator.Tests.CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {

        [Test]
        public void Solve_ValidMathString_ReturnsExpectedResult()
        {
            string mathString = "2+2";
            string expectedResult = "4";

            string actualResult = Calculator.Solve(mathString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Solve_MathStringWithMultipleOperations_ReturnsExpectedResult()
        {
            string mathString = "2+2*2";
            string expectedResult = "6";

            string actualResult = Calculator.Solve(mathString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Solve_MathStringWithDivision_ReturnsExpectedResult()
        {
            string mathString = "10 / 2";
            string expectedResult = "5";

            string actualResult = Calculator.Solve(mathString);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Solve_MathStringWithSubtraction_ReturnsExpectedResult()
        {
            string mathString = "10-5";
            string expectedResult = "5";

            string actualResult = Calculator.Solve(mathString);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Solve_MathStringWithMuchOperation_ReturnsExpectedResult()
        {
            string mathString = "12597/435.35*23.099-0.145495*434356.6532";
            string expectedResult = "-62528,343852946725393361663030";

            string actualResult = Calculator.Solve(mathString);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Solve_MathStringWithMuchOperation2_ReturnsExpectedResult()
        {
            string mathString = "987654321,123456789 / 123456789,12345678987654321123456789 - 7654321123456789 / 987654321,1234567896543210123456789";
            string expectedResult = "-7749992,1364343079474209827774";

            string actualResult = Calculator.Solve(mathString);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Solve_MathStringWithBigNumber_ReturnsExpectedResult()
        {
            string mathString = "999999999999999999999999999999999999999999999999999999" +
                "99999999999999999999999999999999999999999999999999999999999999999999999" +
                "999999999999999999999999999999999999999999999999999999999999999999999999" +
                "99999999999999999999999999999999999999999999999999999999999999999999999999" +
                "99999999999999999999999999999999999999999999999999999999999999999999999999" +
                "999999999999999999999999999999999999999999999999999999999999999999999999999" +
                "999999999999999999999999999999999999999999999999999999999999999999999999999" +
                "99999.1 + 1";

            string expectedResult = "10000000000000000000000000000000000000000000000000000000" +
                "0000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "0000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "0000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "0000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "0000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "00000000000000000000000000000000000000000000000000000000000000000,1";

            string actualResult = Calculator.Solve(mathString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Solve_NullMathString_ThrowsArgumentException()
        {
            string mathString = null;

            Assert.Throws<ArgumentException>(() => Calculator.Solve(mathString));
        }

        [Test]
        public void Solve_EmptyMathString_ThrowsArgumentException()
        {
            string mathString = "";

            Assert.Throws<ArgumentException>(() => Calculator.Solve(mathString));
        }

        [Test]
        public void Solve_IncorrectMathString_ThrowsArgumentException()
        {
            string mathString = "2++2";

            Assert.Throws<ArgumentException>(() => Calculator.Solve(mathString));
        }
    }
}
