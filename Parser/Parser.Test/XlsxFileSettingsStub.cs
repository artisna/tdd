using Moq;
using Parser.Logic;

namespace Parser.Test
{
    public class XlsxFileSettingsStub
    {
        public XlsxFileSettingsStub()
        {
            this.AlertProviderMock = new Mock<IAlertProvider>();
            this.AlertProviderMock.Setup(m => m.Alert(It.IsAny<string>()));

            this.StorageProviderMock = new Mock<IStorageProvider>();
            this.RowValidator = new XlsxRowValidator();
        }

        public Mock<IAlertProvider> AlertProviderMock { get; private set; }
        public Mock<IStorageProvider> StorageProviderMock { get; private set; }
        public IRowValidator RowValidator { get; private set; }
        public Row[] ValidRows => new[] { new Row(new[] { new Column(), new Column(), new Column() }) };
        public Row[] InvalidRows => new[] { new Row(new[] { new Column(), new Column(), new Column(), new Column() }) };
    }
}
