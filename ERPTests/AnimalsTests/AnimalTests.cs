using System;
using AnimalsLibrary;
using Xunit;

namespace ERPTests.AnimalsTests
{
    public class AnimalTests
    {
        [Theory]
        [InlineData(5, 1, true)]
        [InlineData(10, 3, false)]
        public void Animal_Constructor_ValidatesInput(int food, int number, bool isHealthy)
        {
            // Поскольку конструктор Animal уже проверяет значения, не нужно вручную проверять эти исключения
            var animal = new MockAnimal(food, number, isHealthy);

            Assert.Equal(food, animal.Food);
            Assert.Equal(number, animal.Number);
            Assert.Equal(isHealthy, animal.IsHealthy);
        }

        [Theory]
        [InlineData(-1, 1, true)]
        [InlineData(5, -1, true)]
        public void Animal_Constructor_InvalidInput_ThrowsArgumentException(int food, int number, bool isHealthy)
        {
            // Проверяем, что исключение выбрасывается для некорректных входных данных
            Assert.Throws<ArgumentException>(() => new MockAnimal(food, number, isHealthy));
        }

        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
            var animal = new MockAnimal(5, 1, true);
            Assert.Equal("MockAnimal #1 | Еда: 5 кг/день | Здоров: Да", animal.ToString());
        }

        private class MockAnimal : Animal
        {
            public MockAnimal(int food, int number, bool isHealthy)
                : base(food, number, isHealthy) { }
        }
    }
}
