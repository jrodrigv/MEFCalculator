using Calculator.Core;
using NUnit.Framework;
using Operation.Multiply;

namespace Tests
{
    public class MultiplyUnitTest()
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(3,3,9)]
        public void MultiplyIntegerTest(int operatorA, int operatorB, int result)
        {
            IOperation multiply = new MultiplyOperation();

            var actualResult = multiply.Operate(operatorA, operatorB);

            Assert.AreEqual(result, actualResult, $"{operatorA} * {operatorB} is not equal to {result}");
        }
    }
}