namespace Parser.Test
{
    public class CsvFileTest : ParsedFileTest
    {
        public CsvFileTest()
        {
            this.fileSettingsStub = new CsvFileSettingsStub();
        }
    }
}