﻿using FluentAssertions;
using Parser.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                fileSettingsStub.StorageProviderMock.Object,
                fileSettingsStub.RowValidator,
                fileSettingsStub.InvalidRows);
            var parser = new FileParser();

            // act
            parser.Parse(xlsxFile);

            // assert
            xlsxFile.IsParsed.Should().BeFalse();
        }
    }
}