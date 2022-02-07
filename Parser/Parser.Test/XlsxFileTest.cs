using Xunit;
using FluentAssertions;
using Parser.Logic;

namespace Parser.Test
{
    public class XlsxFileTest
    {
        [Fact]
        public void RowsCount_ReturnValueTwo()
        {
            // arrange
            var xlsxFile = new XlsxFile();

            // act
            var rowsCount = xlsxFile.RowsCount();

            // assert
            rowsCount.Should().Be(2);
        }
    }
}