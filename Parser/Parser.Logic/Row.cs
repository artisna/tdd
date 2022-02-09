namespace Parser.Logic
{
    public class Row
    {
        private readonly IEnumerable<Column> columns;

        public Row(IEnumerable<Column> columns)
        {
            this.columns = columns;
        }

        public bool IsValid()
        {
            return columns.Count() == 3;
        }
    }
}