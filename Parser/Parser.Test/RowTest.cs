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
            var xlsxRowValidator = new XlsxRowValidator();
            var row = new Row(null);

            // act
            var validationResult = xlsxRowValidator.IsValid(row);

            // assert
            validationResult.Should().BeFalse();
        }
    }
}
