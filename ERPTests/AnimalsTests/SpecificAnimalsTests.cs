using System;
using AnimalsLibrary.HerboAnimals;
using AnimalsLibrary.PredatorAnimals;
using Xunit;

namespace ERPTests.AnimalsTests
{
    public class SpecificAnimalsTests
    {
        [Fact]
        public void Tiger_Constructor_SetsProperties()
        {
            var tiger = new Tiger(8, 1, true);
            Assert.Equal(8, tiger.Food);
            Assert.Equal(1, tiger.Number);
            Assert.True(tiger.IsHealthy);
        }

        [Fact]
        public void Wolf_Constructor_SetsProperties()
        {
            var wolf = new Wolf(5, 2, false);
            Assert.Equal(5, wolf.Food);
            Assert.Equal(2, wolf.Number);
            Assert.False(wolf.IsHealthy);
        }

        [Fact]
        public void Rabbit_Constructor_SetsProperties()
        {
            var rabbit = new Rabbit(2, 1, true, 7);
            Assert.Equal(2, rabbit.Food);
            Assert.Equal(1, rabbit.Number);
            Assert.True(rabbit.IsHealthy);
            Assert.Equal(7, rabbit.Kindness);
            Assert.True(rabbit.CanBeInContactZoo); // kindness > 5
        }

        [Fact]
        public void Monkey_Constructor_SetsProperties()
        {
            var monkey1 = new Monkey(2, 1, true, 6);
            Assert.Equal(2, monkey1.Food);
            Assert.Equal(1, monkey1.Number);
            Assert.True(monkey1.IsHealthy);
            Assert.Equal(6, monkey1.Kindness);
            Assert.True(monkey1.CanBeInContactZoo); // kindness > 5

            var monkey2 = new Monkey(2, 2, true, 4);
            Assert.Equal(2, monkey2.Food);
            Assert.Equal(2, monkey2.Number);
            Assert.True(monkey2.IsHealthy);
            Assert.Equal(4, monkey2.Kindness);
            Assert.False(monkey2.CanBeInContactZoo); // kindness <= 5
        }

        [Fact]
        public void Monkey_ToString_IncludesKindness()
        {
            var monkey = new Monkey(5, 1, true, 7);
            var result = monkey.ToString();
            Assert.Contains("Доброта: 7/10", result);
        }
    }
}

