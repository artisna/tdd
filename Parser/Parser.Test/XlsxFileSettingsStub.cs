using Parser.Logic;

namespace Parser.Test
{
    public class XlsxFileSettingsStub : FileSettingsStubBase
    {
        public XlsxFileSettingsStub()
        {
            this.RowValidator = new XlsxRowValidator();

            this.ValidRows = new[] { new Row(new[] { new Column(), new Column(), new Column() }) };
            this.InvalidRows = new[] { new Row(new[] { new Column(), new Column(), new Column(), new Column() }) };
        }
    }
}
