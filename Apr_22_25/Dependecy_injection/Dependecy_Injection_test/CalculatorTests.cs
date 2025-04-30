using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependecy_injection.Repositories.Interfaces;
using Moq;

namespace Dependecy_Injection_test
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_ShouldReturnSumOfTwoNumbers()
        {
            // Arrange
            var mockCalculator = new Mock<ICalculator>();
            int a = 5;
            int b = 10;
            int expectedSum = a + b;

            // Setup the mock to return the expected sum when Add is called
            mockCalculator.Setup(calc => calc.Add(a, b)).Returns(expectedSum);

            // Act
            int actualSum = mockCalculator.Object.Add(a, b);

            // Assert
            Assert.AreEqual(expectedSum, actualSum);
            // Ensure the Add method on the mock was called exactly once with the specified arguments
            mockCalculator.Verify(calc => calc.Add(a, b), Times.Once);
        }

        [Test]
        public void Multiply_ShouldReturnProductOfTwoNumbers()
        {
            // Arrange
            var mockCalculator = new Mock<ICalculator>();
            int a = 7;
            int b = 3;
            int expectedProduct = a * b;

            // Setup the mock to return the expected product when Multiply is called
            mockCalculator.Setup(calc => calc.Multiply(a, b)).Returns(expectedProduct);

            // Act
            int actualProduct = mockCalculator.Object.Multiply(a, b);

            // Assert
            Assert.AreEqual(expectedProduct, actualProduct);
            // Ensure the Multiply method on the mock was called exactly once with the specified arguments
            mockCalculator.Verify(calc => calc.Multiply(a, b), Times.Once);
        }
    }
}
