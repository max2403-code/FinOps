using TUnit.Core;
using System.Threading.Tasks;
using TUnit.Assertions.Extensions;

namespace FinOps.Modules.Inventory.Tests
{
    internal class CalculatorTests
    {
        private Calculator _calculator = new Calculator();

        // Простой тест
        [Test]
        public async Task Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Act
            var result = _calculator.Add(5, 3);

            // Assert
            await Assert.That(result).IsEqualTo(8);
        }

        // Параметризованный тест с разными данными
        [Test]
        [Arguments(10, 2, 5)]
        [Arguments(15, 3, 5)]
        [Arguments(100, 10, 10)]
        public async Task Divide_ValidNumbers_ReturnsCorrectResult(int a, int b, double expected)
        {
            // Act
            var result = _calculator.Divide(a, b);

            // Assert
            await Assert.That(result).IsEqualTo(expected);
        }

        // Тест на исключение
        [Test]
        public async Task Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Act & Assert
            await Assert.That(() => _calculator.Divide(10, 0))
                  .Throws<DivideByZeroException>();
        }

        // Тест с булевым утверждением
        [Test]
        public async Task IsEven_WithEvenNumber_ReturnsTrue()
        {
            // Act
            var result = _calculator.IsEven(4);

            // Assert
            await Assert.That(result).IsTrue();
        }

        // Асинхронный тест (если бы методы были асинхронными)
        [Test]
        public async Task AsyncTestExample()
        {
            // Для демонстрации асинхронности
            await Task.Delay(100);

            var result = _calculator.Add(2, 2);
            await Assert.That(result).IsEqualTo(4);
        }
    }
}
