using FluentAssertions;
using Parser.Logic;
using Xunit;

namespace Parser.Test
{
    public class CsvRowValidatorTest
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
