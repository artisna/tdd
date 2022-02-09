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
            var rows = new[] { new Row(null), new Row(null) };
            var xlsxFile = new XlsxFile(rows);

            // act
            var rowsCount = xlsxFile.RowsCount();

            // assert
            rowsCount.Should().Be(2);
        }

        [Fact]
        public void RowsCount_ReturnValueThree()
        {
            // arrange
            var rows = new[] { new Row(null), new Row(null), new Row(null) };
            var xlsxFile = new XlsxFile(rows);

            // act
            var rowsCount = xlsxFile.RowsCount();

            // assert
            rowsCount.Should().Be(3);
        }

    }
}