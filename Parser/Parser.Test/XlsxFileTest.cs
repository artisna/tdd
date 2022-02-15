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
            for (var i = 0; i < rowsCount; ++i)
            {
                rows[i] = new Row(null);
            }

            return rows;
        }

        private static Column[] BuildColumns(int columnsCount)
        {
            var rows = new Column[columnsCount];
            for (var i = 0; i < columnsCount; ++i)
            {
                rows[i] = new Column();
            }

            return rows;
        }

        private Mock<IAlertProvider> defaultAlertProviderMock = new Mock<IAlertProvider>();
        private Mock<IStorageProvider> defaultStorageProviderMock = new Mock<IStorageProvider>();


        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void RowsCount_ReturnValueOfRowsAmount(int rowsAmount)
        {
            // arrange
            defaultAlertProviderMock.Setup(m => m.Alert(It.IsAny<string>()));
            Row[] rows = BuildRowsWithoutColumns(rowsAmount);
            var xlsxFile = new XlsxFile(defaultAlertProviderMock.Object, defaultStorageProviderMock.Object, rows);

            // act
            var rowsCount = xlsxFile.RowsCount();

            // assert
            rowsCount.Should().Be(rowsAmount);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void XlsxFile_WithInvalidRows_AlertIt(int invalidRowsAmount)
        {
            // arrange
            defaultAlertProviderMock.Setup(m => m.Alert(It.IsAny<string>()));
            var rows = BuildRowsWithoutColumns(invalidRowsAmount);

            // act
            var xlsxFile = new XlsxFile(defaultAlertProviderMock.Object, defaultStorageProviderMock.Object, rows);

            // assert
            defaultAlertProviderMock.Verify(a => a.Alert(It.IsAny<string>()), Times.Exactly(invalidRowsAmount));
        }

        [Fact]
        public void XlsxFile_WithValidRows_NotAlertIt()
        {
            // arrange
            defaultAlertProviderMock.Setup(m => m.Alert(It.IsAny<string>()));
            var rows = new[] { new Row(BuildColumns(3)) };

            // act
            var xlsxFile = new XlsxFile(defaultAlertProviderMock.Object, defaultStorageProviderMock.Object, rows);

            // assert
            defaultAlertProviderMock.Verify(a => a.Alert(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void XlsxFile_WithParsedRows_ItIsLoadedToStorage()
        {
            // arrange
            defaultAlertProviderMock.Setup(m => m.Alert(It.IsAny<string>()));
            var rows = new[] { new Row(BuildColumns(3)) };

            // act
            var xlsxFile = new XlsxFile(defaultAlertProviderMock.Object, defaultStorageProviderMock.Object, rows);

            // assert
            defaultStorageProviderMock.Verify(a => a.Save(It.IsAny<XlsxFile>()), Times.Once);
        }

        [Fact]
        public void XlsxFile_WithNotParsedRows_NotLoadedToStorage()
        {
            // arrange
            defaultAlertProviderMock.Setup(m => m.Alert(It.IsAny<string>()));
            var rows = new[] { new Row(BuildColumns(2)) };

            // act
            var xlsxFile = new XlsxFile(defaultAlertProviderMock.Object, defaultStorageProviderMock.Object, rows);

            // assert
            defaultStorageProviderMock.Verify(a => a.Save(It.IsAny<XlsxFile>()), Times.Never);
        }
    }
}