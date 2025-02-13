using System;
using Xunit;
using AnimalsLibrary.PredatorAnimals;
using AnimalsLibrary;

namespace ERPTests.AnimalsTests
{
    public class PredatorTests
    {
        [Theory]
        [InlineData(5, 1, true)]
        [InlineData(10, 3, false)]
        public void Predator_Constructor_ValidatesInput(int food, int number, bool isHealthy)
        {
            if (food < 0)
            {
                Assert.Throws<ArgumentException>(() => new Tiger(food, number, isHealthy));
            }
            else
            {
                var animal = new Tiger(food, number, isHealthy);
                Assert.IsType<Tiger>(animal);
                Assert.IsAssignableFrom<Predator>(animal);
                Assert.Equal(food, animal.Food);
                Assert.Equal(number, animal.Number);
                Assert.Equal(isHealthy, animal.IsHealthy);
            }
        }

        [Fact]
        public void Predator_ToString_ReturnsCorrectFormat()
        {
            var tiger = new Tiger(8, 1, true);
            var result = tiger.ToString();
            Assert.Equal("Tiger #1 | Еда: 8 кг/день | Здоров: Да", result);
        }
    }
}

