using System;
using ThingsLibrary;
using Xunit;

namespace ERPTests.ThingsTests
{
    public class ThingTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        public void Thing_Constructor_ValidatesNumber(int number)
        {
            if (number < 0)
            {
                Assert.Throws<ArgumentException>(() => new MockThing(number));
            }
            else
            {
                var thing = new MockThing(number);
                Assert.Equal(number, thing.Number);
            }
        }

        [Fact]
        public void Thing_ToString_ReturnsCorrectFormat()
        {
            var thing = new MockThing(5);
            Assert.Equal("MockThing #5", thing.ToString());
        }

        private class MockThing : Thing
        {
            public MockThing(int number) : base(number) { }
        }
    }
}

