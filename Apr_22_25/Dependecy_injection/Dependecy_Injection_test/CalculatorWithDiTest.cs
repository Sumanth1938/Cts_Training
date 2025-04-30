using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependecy_injection.Controllers;
using Dependecy_injection.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Dependecy_Injection_test
{
    [TestFixture]
    public class CalculatorWithDiTest
    {

        private Mock<ICalculator> _mockCalculator;
        private CalculatorWithDiController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockCalculator = new Mock<ICalculator>();
            _controller = new CalculatorWithDiController(_mockCalculator.Object);
        }

        [Test]
        public void Add_ReturnsOkResult_WithSum()
        {
            // Arrange
            int a = 5;
            int b = 3;
            int expectedSum = 8;
            _mockCalculator.Setup(c => c.Add(a, b)).Returns(expectedSum);

            // Act
            var result = _controller.Add(a, b) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedSum, result.Value);
        }

        [Test]
        public void Multiply_ReturnsOkResult_WithProduct()
        {
            // Arrange
            int a = 5;
            int b = 3;
            int expectedProduct = 15;
            _mockCalculator.Setup(c => c.Multiply(a, b)).Returns(expectedProduct);

            // Act
            var result = _controller.Multiply(a, b) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedProduct, result.Value);
        }


        [Test]
        public void GetCalc_ReturnsOkResult_WithListOfResults()
        {
            // Arrange
            int a = 5;
            int b = 3;
            int expectedSum = 8;
            int expectedProduct = 15;
            var expectedList = new List<int> { expectedSum, expectedProduct };
            _mockCalculator.Setup(c => c.Add(a, b)).Returns(expectedSum);
            _mockCalculator.Setup(c => c.Multiply(a, b)).Returns(expectedProduct);

            // Act
            var result = _controller.GetCalc(a, b) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedList, result.Value);
        }

    }
}
