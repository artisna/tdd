namespace Parser.Logic
{
    public class XlsxFile
    {
        private readonly IEnumerable<Row> rows;

        public XlsxFile(IEnumerable<Row> rows)
        {
            this.rows = rows;
        }

        public object RowsCount()
        {
            return rows.Count();
        }
    }
}