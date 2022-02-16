using FluentAssertions;
using Moq;
using Parser.Logic;
using Xunit;

namespace Parser.Test
{
    public class ParsedFileTest
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

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void RowsCount_ReturnValueOfRowsAmount(int rowsAmount)
        {
            // arrange
            var fileSettingsStub = new XlsxFileSettingsStub();
            Row[] rows = BuildRowsWithoutColumns(rowsAmount);
            var xlsxFile = new ParsedFile(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.StorageProviderMock.Object,
                fileSettingsStub.RowValidator,
                rows);

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
            var fileSettingsStub = new XlsxFileSettingsStub();
            var rows = BuildRowsWithoutColumns(invalidRowsAmount);

            // act
            var xlsxFile = new ParsedFile(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.StorageProviderMock.Object,
                fileSettingsStub.RowValidator,
                rows);

            // assert
            fileSettingsStub.AlertProviderMock.Verify(a => a.Alert(It.IsAny<string>()), Times.Exactly(invalidRowsAmount));
        }

        [Fact]
        public void XlsxFile_WithValidRows_NotAlertIt()
        {
            // arrange
            var fileSettingsStub = new XlsxFileSettingsStub();

            // act
            var xlsxFile = new ParsedFile(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.StorageProviderMock.Object,
                fileSettingsStub.RowValidator,
                fileSettingsStub.ValidRows);

            // assert
            fileSettingsStub.AlertProviderMock.Verify(a => a.Alert(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void XlsxFile_WithParsedRows_ItIsLoadedToStorage()
        {
            // arrange
            var fileSettingsStub = new XlsxFileSettingsStub();

            // act
            var xlsxFile = new ParsedFile(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.StorageProviderMock.Object,
                fileSettingsStub.RowValidator,
                fileSettingsStub.ValidRows);

            // assert
            fileSettingsStub.StorageProviderMock.Verify(a => a.Save(It.IsAny<ParsedFile>()), Times.Once);
        }

        [Fact]
        public void XlsxFile_WithNotParsedRows_NotLoadedToStorage()
        {
            // arrange
            var fileSettingsStub = new XlsxFileSettingsStub();

            // act
            var xlsxFile = new ParsedFile(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.StorageProviderMock.Object,
                fileSettingsStub.RowValidator,
                fileSettingsStub.InvalidRows);

            // assert
            fileSettingsStub.StorageProviderMock.Verify(a => a.Save(It.IsAny<ParsedFile>()), Times.Never);
        }

        [Fact]
        public void XlsxFile_WithParsedRows_MarkedAsParsed()
        {
            // arrange
            var fileSettingsStub = new XlsxFileSettingsStub();

            // act
            var xlsxFile = new ParsedFile(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.StorageProviderMock.Object,
                fileSettingsStub.RowValidator,
                fileSettingsStub.ValidRows);

            // assert
            xlsxFile.IsParsed.Should().BeTrue();
        }

        [Fact]
        public void XlsxFile_WithNotParsedRows_MarkedAsNotParsed()
        {
            // arrange
            var fileSettingsStub = new XlsxFileSettingsStub();

            // act
            var xlsxFile = new ParsedFile(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.StorageProviderMock.Object,
                fileSettingsStub.RowValidator,
                fileSettingsStub.InvalidRows);

            // assert
            xlsxFile.IsParsed.Should().BeFalse();
        }
    }
}