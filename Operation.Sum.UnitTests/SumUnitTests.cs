using Calculator.Core;
using NUnit.Framework;

namespace Operation.Sum.UnitTests
{
    public class SumUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2, 3, 5)]
        [TestCase(-1, 1, 0)]
        public void SumIntegersTest(int operatorA, int operatorB, int result)
        {
            IOperation sum = new Add();

            var actualResult = sum.Operate(operatorA, operatorB);

            Assert.AreEqual(result,actualResult, $"{operatorA} + {operatorB} is not equal to {result}");
        }
    }
}