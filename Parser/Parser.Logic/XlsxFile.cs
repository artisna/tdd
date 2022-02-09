namespace Parser.Logic
{
    public class XlsxFile
    {
        private readonly IEnumerable<Row> rows;
        private readonly IAlertProvider alertProvider;

        public XlsxFile(IAlertProvider alertProvider, IEnumerable<Row> rows)
        {
            this.alertProvider = alertProvider;

            this.ValidateRows(rows);
            this.rows = rows;
        }

        public object RowsCount()
        {
            return rows.Count();
        }

        private void ValidateRows(IEnumerable<Row> rows)
        {
            foreach (var row in rows)
            {
                if (!row.IsValid())
                {
                    this.alertProvider.Alert("Row is invalid");
                }
            }
        }
    }
}