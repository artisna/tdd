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

        [Fact]
        public void RowsCount_ReturnValueTwo()
        {
            // arrange
            Row[] rows = BuildRowsWithoutColumns(2);
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
            var rows = BuildRowsWithoutColumns(3);
            var xlsxFile = new XlsxFile(rows);

            // act
            var rowsCount = xlsxFile.RowsCount();

            // assert
            rowsCount.Should().Be(3);
        }
    }
}