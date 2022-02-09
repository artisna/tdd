namespace Parser.Logic
{
    public class Row
    {
        private const int ValidRowColumnsAmount = 3;
        private readonly IEnumerable<Column> columns;

        public Row(IEnumerable<Column> columns)
        {
            this.columns = columns;
        }

        public bool IsValid()
        {
            if (columns == null)
                return false;

            return columns.Count() == ValidRowColumnsAmount;
        }
    }
}