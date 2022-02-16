using FluentAssertions;
using Parser.Logic;
using Xunit;

namespace Parser.Test
{
    public class XlsxRowValidatorTest
    {
        [Fact]
        public void XlsxRow_WithoutColumns_IsInvalid()
        {
            // arrange
            var xlsxRowValidator = new XlsxRowValidator();
            var row = new Row(null);

            // act
            var validationResult = xlsxRowValidator.IsValid(row);

            // assert
            validationResult.Should().BeFalse();
        }

        [Fact]
        public void XlsxRow_WithThreeColumns_IsValidXlsxRow()
        {
            // arrange
            var xlsxRowValidator = new XlsxRowValidator();
            var columns = new[] { new Column(), new Column(), new Column() };
            var row = new Row(columns);

            // act
            var validationResult = xlsxRowValidator.IsValid(row);

            // assert
            validationResult.Should().BeTrue();
        }
    }
}
