namespace Parser.Logic
{
    public class Row
    {
        private const int ValidXlsxRowColumnsAmount = 3;

        private readonly int validRowColumnsAmount;
        private readonly IEnumerable<Column> columns;

        public Row(IEnumerable<Column> columns, int validRowColumnsAmount = ValidXlsxRowColumnsAmount)
        {
            this.validRowColumnsAmount = validRowColumnsAmount;
            this.columns = columns;
        }

        public bool IsValid()
        {
            if (columns == null)
                return false;

            return columns.Count() == validRowColumnsAmount;
        }
    }
}