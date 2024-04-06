using MultiOperationCalculator.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiOperationCalculator.Tests.ArrayMathStringTests
{
    public class ArrayMathStringTests
    {
        [Test]
        public void CreateNewArrayWithResultAndRemoveTwoElements_ValidInput_ReturnsExpectedArray()
        {
            string[] oldArray = { "5", "+", "5", "+", "5" };
            string newItem = "10";
            int indexNewItem = 0;
            string[] expectedArray = { "10", "+", "5" };

            ArrayMathString.CreateNewArrayWithResultAndRemoveTwoElements(ref oldArray, newItem, indexNewItem);

            Assert.AreEqual(expectedArray, oldArray);
        }

        [Test]
        public void CreateNewArrayWithResultAndRemoveTwoElements_IndexBeyondNewArray_ThrowsArgumentOutOfRangeException()
        {
            string[] oldArray = { "5", "+", "5", "+", "5" };
            string newItem = "10";
            int indexNewItem = 3;

            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayMathString.CreateNewArrayWithResultAndRemoveTwoElements(ref oldArray, newItem, indexNewItem));
        }

        [Test]
        public void CreateNewArrayWithResultAndRemoveTwoElements_NegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            string[] oldArray = { "5", "+", "5", "+", "5" };
            string newItem = "10";
            int indexNewItem = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayMathString.CreateNewArrayWithResultAndRemoveTwoElements(ref oldArray, newItem, indexNewItem));
        }
    }
}

