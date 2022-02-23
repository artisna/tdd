namespace Parser.Logic
{
    public class FileParser : IFileParser
    {
        private readonly IStorageProvider storageProvider;

        public FileParser(IStorageProvider storageProvider)
        {
            this.storageProvider = storageProvider;
        }

        public void Parse(File parsedFile)
        {
            var isFileParsed = parsedFile.IsAllRowsValid();
            parsedFile.ToggleParsed(isFileParsed);

            if (isFileParsed)
            {
                this.storageProvider.Save(parsedFile);
            }
        }
    }
}
