using FluentAssertions;
using Moq;
using Parser.Logic;
using Xunit;

namespace Parser.Test
{
    public abstract class FileTest
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

        protected FileSettingsStubBase fileSettingsStub;

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void RowsCount_ReturnValueOfRowsAmount(int rowsAmount)
        {
            // arrange
            Row[] rows = BuildRowsWithoutColumns(rowsAmount);
            var xlsxFile = new File(
                fileSettingsStub.AlertProviderMock.Object,
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
            var rows = BuildRowsWithoutColumns(invalidRowsAmount);

            // act
            var xlsxFile = new File(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.RowValidator,
                rows);

            // assert
            fileSettingsStub.AlertProviderMock.Verify(a => a.Alert(It.IsAny<string>()), Times.Exactly(invalidRowsAmount));
        }

        [Fact]
        public void XlsxFile_WithValidRows_NotAlertIt()
        {
            // arrange

            // act
            var xlsxFile = new File(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.RowValidator,
                fileSettingsStub.ValidRows);

            // assert
            fileSettingsStub.AlertProviderMock.Verify(a => a.Alert(It.IsAny<string>()), Times.Never);
        }
    }
}