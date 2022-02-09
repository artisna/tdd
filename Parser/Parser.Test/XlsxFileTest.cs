using Xunit;
using FluentAssertions;
using Parser.Logic;

namespace Parser.Test
{
    public class XlsxFileTest
    {
        private static Row[] BuildRowsWithoutColumns(int rowsCount)
        {
            var rows = new Row[rowsCount];
            return rows;
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void RowsCount_ReturnValueOfRowsAmount(int rowsAmount)
        {
            // arrange
            Row[] rows = BuildRowsWithoutColumns(rowsAmount);
            var xlsxFile = new XlsxFile(rows);

            // act
            var rowsCount = xlsxFile.RowsCount();

            // assert
            rowsCount.Should().Be(rowsAmount);
        }
    }
}