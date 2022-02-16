using Parser.Logic;

namespace Parser.Test
{
    public class CsvFileSettingsStub : FileSettingsStubBase
    {
        public CsvFileSettingsStub()
        {
            this.RowValidator = new CsvRowValidator();

            this.ValidRows = new[] { new Row(new[] { new Column(), new Column(), new Column(), new Column() }) };
            this.InvalidRows = new[] { new Row(new[] { new Column(), new Column(), new Column() }) };
        }
    }
}
