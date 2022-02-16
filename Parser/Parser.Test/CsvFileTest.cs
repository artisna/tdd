using FluentAssertions;
using Parser.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Parser.Test
{
    public class CsvFileTest
    {
        [Fact]
        public void CsvFileRow_WithFourColumns_IsValidCsvRow()
        {
            // arrange
            var csvRowValidator = new CsvRowValidator();
            var columns = new[] { new Column(), new Column(), new Column(), new Column() };
            var row = new Row(columns, validRowColumnsAmount: 4);

            // act
            var validationResult = csvRowValidator.IsValid(row);

            // assert
            validationResult.Should().BeTrue();
        }
    }
}
