using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Parser.Logic;

namespace Parser.Test
{
    public class RowTest
    {
        [Fact]
        public void Row_WithoutColumns_IsInvalid()
        {
            // arrange
            var row = new Row(null);

            // act
            var validationResult = row.IsValid();

            // assert
            validationResult.Should().BeFalse();
        }

        [Fact]
        public void Row_WithThreeColumns_IsValid()
        {
            // arrange
            var columns = new[] { new Column(), new Column(), new Column() };
            var row = new Row(columns);

            // act
            var validationResult = row.IsValid();

            // assert
            validationResult.Should().BeTrue();
        }

        [Fact]
        public void Row_WithFourColumns_IsValidCsvRow()
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
