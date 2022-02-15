namespace Parser.Logic
{
    public class XlsxFile
    {
        private readonly IEnumerable<Row> rows;
        private readonly IAlertProvider alertProvider;
        private readonly IStorageProvider storageProvider;

        public XlsxFile(IAlertProvider alertProvider, IStorageProvider storageProvider, IEnumerable<Row> rows)
        {
            this.alertProvider = alertProvider;
            this.storageProvider = storageProvider;

            this.ValidateRows(rows);
            this.rows = rows;

            // TODO: investigate criterion of completed parsing
            var isParsed = this.rows.All(r => r.IsValid());
            if (isParsed)
            {
                this.storageProvider.Save(this);
            }
        }

        public bool IsParsed { get => true; }

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