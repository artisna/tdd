﻿using FluentAssertions;
using Moq;
using Parser.Logic;
using Xunit;

namespace Parser.Test
{
    public class FileParserTest
    {
        private FileSettingsStubBase fileSettingsStub;

        public FileParserTest()
        {
            this.fileSettingsStub = new XlsxFileSettingsStub();
        }

        [Fact]
        public void Parse_XlsxFileWithNotParsedRows_MarkedAsNotParsed()
        {
            // arrange
            var xlsxFile = new File(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.RowValidator,
                fileSettingsStub.InvalidRows);
            var parser = new FileParser(fileSettingsStub.StorageProviderMock.Object);

            // act
            parser.Parse(xlsxFile);

            // assert
            xlsxFile.IsParsed.Should().BeFalse();
        }

        [Fact]
        public void Parse_XlsxFileWithParsedRows_MarkedAsParsed()
        {
            // arrange
            var xlsxFile = new File(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.RowValidator,
                fileSettingsStub.ValidRows);
            var parser = new FileParser(fileSettingsStub.StorageProviderMock.Object);

            // act
            parser.Parse(xlsxFile);

            // assert
            xlsxFile.IsParsed.Should().BeTrue();
        }

        [Fact]
        public void Parse_XlsxFileWithParsedRows_LoadedToStorage()
        {
            // arrange
            var xlsxFile = new File(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.RowValidator,
                fileSettingsStub.ValidRows);
            var parser = new FileParser(fileSettingsStub.StorageProviderMock.Object);

            // act
            parser.Parse(xlsxFile);

            // assert
            fileSettingsStub.StorageProviderMock.Verify(a => a.Save(It.IsAny<File>()), Times.Once);
        }

        [Fact]
        public void Parse_XlsxFileWithNotParsedRows_NotLoadedToStorage()
        {
            // arrange
            var xlsxFile = new File(
                fileSettingsStub.AlertProviderMock.Object,
                fileSettingsStub.RowValidator,
                fileSettingsStub.InvalidRows);
            var parser = new FileParser(fileSettingsStub.StorageProviderMock.Object);

            // act
            parser.Parse(xlsxFile);

            // assert
            fileSettingsStub.StorageProviderMock.Verify(a => a.Save(It.IsAny<File>()), Times.Never);
        }
    }
}
