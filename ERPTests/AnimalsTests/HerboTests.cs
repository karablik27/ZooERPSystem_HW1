using System;
using AnimalsLibrary;
using AnimalsLibrary.HerboAnimals;
using Xunit;

namespace ERPTests.AnimalsTests
{
    public class HerboTests
    {
        [Theory]
        [InlineData(5, 1, true, 7)]  // корректные значения доброты
        [InlineData(5, 1, true, 3)]  // корректные значения доброты
        public void HerboConstructor_ValidValues_ShouldCreateHerbo(int food, int number, bool isHealthy, int kindness)
        {
            // Arrange
            var expectedCanBeInContactZoo = kindness > 5;

            // Act
            var herbo = new Monkey(food, number, isHealthy, kindness);

            // Assert
            Assert.Equal(kindness, herbo.Kindness);
            Assert.Equal(expectedCanBeInContactZoo, herbo.CanBeInContactZoo);
        }

        [Theory]
        [InlineData(-1)]  // некорректный уровень доброты
        [InlineData(11)]  // некорректный уровень доброты
        public void HerboConstructor_InvalidKindnessLevel_ShouldThrowArgumentException(int invalidKindness)
        {
            // Arrange
            string name = "Овечка";
            int food = 5;
            int number = 2;
            bool isHealthy = true;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                new Monkey(food, number, isHealthy, invalidKindness));
        }

        [Fact]
        public void Herbo_ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var monkey = new Monkey(5, 1, true, 7);

            // Act
            var result = monkey.ToString();

            // Assert
            Assert.Equal("Monkey #1 | Еда: 5 кг/день | Здоров: Да | Доброта: 7/10", result);
        }
    }
}
