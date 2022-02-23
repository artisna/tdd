namespace Parser.Logic
{
    public class File
    {
        private readonly IEnumerable<Row> rows;
        private readonly IAlertProvider alertProvider;
        private readonly IRowValidator rowValidator;

        public File(IAlertProvider alertProvider, IRowValidator rowValidator, IEnumerable<Row> rows)
        {
            this.alertProvider = alertProvider;
            this.rowValidator = rowValidator;

            this.ValidateRows(rows);
            this.rows = rows;
        }

        public bool IsAllRowsValid() => this.rows.All(r => rowValidator.IsValid(r));

        public bool IsParsed { get; private set; }

        public void ToggleParsed(bool toggleValue)
        {
            this.IsParsed = toggleValue;
        }

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