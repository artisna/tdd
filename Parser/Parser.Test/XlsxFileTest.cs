using Xunit;
using FluentAssertions;
using Parser.Logic;
using System;
using Moq;

namespace Parser.Test
{
    public class XlsxFileTest
    {
        private static Row[] BuildRowsWithoutColumns(int rowsCount)
        {
            var rows = new Row[rowsCount];
            return rows;
        }

        private Mock<IAlertProvider> defaultAlertProviderMock = new Mock<IAlertProvider>();

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void RowsCount_ReturnValueOfRowsAmount(int rowsAmount)
        {
            // arrange
            Row[] rows = BuildRowsWithoutColumns(rowsAmount);
            var xlsxFile = new XlsxFile(defaultAlertProviderMock.Object, rows);

            // act
            var rowsCount = xlsxFile.RowsCount();

            // assert
            rowsCount.Should().Be(rowsAmount);
        }

        [Fact]
        public void XlsxFile_WithOneInvalidRows_AlertIt()
        {
            // arrange
            defaultAlertProviderMock.Setup(m => m.Alert(It.IsAny<string>()));
            var rows = BuildRowsWithoutColumns(1);

            // act
            var xlsxFile = new XlsxFile(defaultAlertProviderMock.Object, rows);

            // assert
            defaultAlertProviderMock.Verify(a => a.Alert(It.IsAny<string>()), Times.Exactly(1));
        }
    }
}