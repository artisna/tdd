namespace Parser.Logic
{
    public class XlsxRowValidator : IRowValidator
    {
        private const int ValidXlsxRowColumnsAmount = 3;

        public bool IsValid(Row row)
        {
            return row.ColumnsCount == ValidXlsxRowColumnsAmount;
        }
    }
}
