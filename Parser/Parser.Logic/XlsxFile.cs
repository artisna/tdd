namespace Parser.Logic
{
    public class XlsxFile
    {
        private readonly IEnumerable<Row> rows;
        private readonly IAlertProvider alertProvider;

        public XlsxFile(IAlertProvider alertProvider, IEnumerable<Row> rows)
        {
            this.alertProvider = alertProvider;
            this.rows = rows;
        }

        public object RowsCount()
        {
            return rows.Count();
        }
    }
}