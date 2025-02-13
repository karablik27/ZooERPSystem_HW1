using System;
using AnimalsLibrary;
using Places;
using Xunit;

namespace ERPTests.PlacecTests
{
    public class VeterinaryClinicTests
    {
        [Fact]
        public void IsHealthy_ReturnsTrueForHealthyAnimal()
        {
            var clinic = new VeterinaryClinic();
            var healthyAnimal = new MockAnimal(5, 1, true);

            var result = clinic.IsHealthy(healthyAnimal);

            Assert.True(result);
        }

        [Fact]
        public void IsHealthy_ReturnsFalseForUnhealthyAnimal()
        {
            var clinic = new VeterinaryClinic();
            var unhealthyAnimal = new MockAnimal(5, 1, false);

            var result = clinic.IsHealthy(unhealthyAnimal);

            Assert.False(result);
        }

        private class MockAnimal : Animal
        {
            public MockAnimal(int food, int number, bool isHealthy)
                : base(food, number, isHealthy) { }
        }
    }
}

