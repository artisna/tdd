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
            var columns = new[] { new Column(), new Column(), new Column(), new Column() };
            var row = new Row(columns, validRowColumnsAmount: 4);

            // act
            var validationResult = row.IsValid();

            // assert
            validationResult.Should().BeTrue();
        }
    }
}
