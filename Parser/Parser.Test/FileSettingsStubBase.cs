using Moq;
using Parser.Logic;

namespace Parser.Test
{
    public class FileSettingsStubBase
    {
        public FileSettingsStubBase()
        {
            this.AlertProviderMock = new Mock<IAlertProvider>();
            this.AlertProviderMock.Setup(m => m.Alert(It.IsAny<string>()));

            this.StorageProviderMock = new Mock<IStorageProvider>();
        }

        public Mock<IAlertProvider> AlertProviderMock { get; protected set; }
        public Mock<IStorageProvider> StorageProviderMock { get; protected set; }
        public IRowValidator RowValidator { get; protected set; }
        public Row[] ValidRows { get; protected set; }
        public Row[] InvalidRows { get; protected set; }
    }
}