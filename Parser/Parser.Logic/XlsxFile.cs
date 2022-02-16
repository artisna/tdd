namespace Parser.Logic
{
    public class XlsxFile
    {
        private readonly IEnumerable<Row> rows;
        private readonly IAlertProvider alertProvider;
        private readonly IStorageProvider storageProvider;
        private readonly IRowValidator rowValidator;

        public XlsxFile(IAlertProvider alertProvider, IStorageProvider storageProvider, XlsxRowValidator xlsxRowValidator, IEnumerable<Row> rows)
        {
            this.alertProvider = alertProvider;
            this.storageProvider = storageProvider;
            this.rowValidator = xlsxRowValidator;

            this.ValidateRows(rows);
            this.rows = rows;

            // TODO: investigate criterion of completed parsing
            this.IsParsed = this.rows.All(r => rowValidator.IsValid(r));
            if (this.IsParsed)
            {
                this.storageProvider.Save(this);
            }
        }

        public bool IsParsed { get; private set; }

        public int RowsCount()
        {
            return rows.Count();
        }

        private void ValidateRows(IEnumerable<Row> rows)
        {
            foreach (var row in rows)
            {
                if (!rowValidator.IsValid(row))
                {
                    this.alertProvider.Alert("Row is invalid");
                }
            }
        }
    }
}