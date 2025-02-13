using System;
using ThingsLibrary.SomeThings;
using Xunit;

namespace ERPTests.ThingsTests
{
    public class TableTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        public void Table_Constructor_ValidatesNumber(int number)
        {
            if (number < 0)
            {
                Assert.Throws<ArgumentException>(() => new Table(number));
            }
            else
            {
                var table = new Table(number);
                Assert.Equal(number, table.Number);
            }
        }

        [Fact]
        public void Table_ToString_ReturnsCorrectFormat()
        {
            var table = new Table(5);
            Assert.Equal("Table #5", table.ToString());
        }
    }
}

