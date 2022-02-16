namespace Parser.Logic
{
    public class CsvRowValidator : IRowValidator
    {
        private const int ValidXlsxRowColumnsAmount = 4;

        public bool IsValid(Row row)
        {
            return row.ColumnsCount == ValidXlsxRowColumnsAmount;
        }
    }
}
