using System;
using AnimalsLibrary;
using Moq;
using Places;
using ThingsLibrary;
using Xunit;

namespace ERPTests.PlacecTests
{
    public class ZooTests
    {
        [Fact]
        public void AddAnimal_HealthyAnimal_AddsToCollection()
        {
            var clinicMock = new Mock<IHealthChecker>();
            clinicMock.Setup(x => x.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(clinicMock.Object);
            var animal = new MockAnimal(5, 1, true);

            var result = zoo.AddAnimal(animal);

            Assert.True(result);
            Assert.Contains(animal, zoo.GetAllAnimals());
        }

        [Fact]
        public void AddAnimal_UnhealthyAnimal_Rejects()
        {
            var clinicMock = new Mock<IHealthChecker>();
            clinicMock.Setup(x => x.IsHealthy(It.IsAny<Animal>())).Returns(false);

            var zoo = new Zoo(clinicMock.Object);
            var animal = new MockAnimal(5, 1, true);

            var result = zoo.AddAnimal(animal);

            Assert.False(result);
            Assert.DoesNotContain(animal, zoo.GetAllAnimals());
        }

        [Fact]
        public void AddThing_UniqueNumber_AddsToCollection()
        {
            var zoo = new Zoo(Mock.Of<IHealthChecker>());
            var thing = new MockThing(1);

            zoo.AddThing(thing);

            Assert.Contains(thing, zoo.GetAllThings());
        }

        [Fact]
        public void AddThing_DuplicateNumber_ThrowsException()
        {
            var zoo = new Zoo(Mock.Of<IHealthChecker>());
            var thing1 = new MockThing(1);
            var thing2 = new MockThing(1);

            zoo.AddThing(thing1);
            Assert.Throws<ArgumentException>(() => zoo.AddThing(thing2));
        }

        [Fact]
        public void CalculateTotalFood_ReturnsCorrectSum()
        {
            var clinicMock = new Mock<IHealthChecker>();
            clinicMock.Setup(x => x.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(clinicMock.Object);
            zoo.AddAnimal(new MockAnimal(5, 1, true));
            zoo.AddAnimal(new MockAnimal(3, 2, true));

            var totalFood = zoo.CalculateTotalFood();

            Assert.Equal(8, totalFood);
        }

        [Fact]
        public void GetContactAnimals_ReturnsOnlyHerboWithKindnessAbove5()
        {
            var clinicMock = new Mock<IHealthChecker>();
            clinicMock.Setup(x => x.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(clinicMock.Object);
            zoo.AddAnimal(new MockHerbo(2, 1, true, 6));
            zoo.AddAnimal(new MockHerbo(1, 2, true, 4));

            var contactAnimals = zoo.GetContactAnimals();

            Assert.Single(contactAnimals);
            Assert.Equal(1, contactAnimals.First().Number);
        }

        [Fact]
        public void GetAllInventory_ReturnsAnimalsAndThings()
        {
            var clinicMock = new Mock<IHealthChecker>();
            clinicMock.Setup(x => x.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(clinicMock.Object);
            zoo.AddAnimal(new MockAnimal(5, 1, true));
            zoo.AddThing(new MockThing(2));

            var inventory = zoo.GetAllInventory();

            Assert.Equal(2, inventory.Count());
        }

        private class MockAnimal : Animal
        {
            public MockAnimal(int food, int number, bool isHealthy)
                : base(food, number, isHealthy) { }
        }

        private class MockHerbo : Herbo
        {
            public MockHerbo(int food, int number, bool isHealthy, int kindness)
                : base(food, number, isHealthy, kindness) { }
        }

        private class MockThing : Thing
        {
            public MockThing(int number) : base(number) { }
        }
    }
}

