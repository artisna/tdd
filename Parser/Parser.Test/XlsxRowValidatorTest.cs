using FluentAssertions;
using Parser.Logic;
using Xunit;

namespace Parser.Test
{
    public class XlsxRowValidatorTest
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
