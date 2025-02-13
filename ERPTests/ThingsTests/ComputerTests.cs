using System;
using ThingsLibrary.SomeThings;
using Xunit;

namespace ERPTests.ThingsTests
{
    public class ComputerTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        public void Computer_Constructor_ValidatesNumber(int number)
        {
            if (number < 0)
            {
                Assert.Throws<ArgumentException>(() => new Computer(number));
            }
            else
            {
                var computer = new Computer(number);
                Assert.Equal(number, computer.Number);
            }
        }

        [Fact]
        public void Computer_ToString_ReturnsCorrectFormat()
        {
            var computer = new Computer(5);
            Assert.Equal("Computer #5", computer.ToString());
        }
    }
}

