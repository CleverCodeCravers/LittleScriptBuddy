namespace LittelScriptBuddy.Domain.FilesWatcher
{
    public class FilesWatcher
    {
        private FileSystemWatcher _watcher = new();

        public FilesWatcher(string targetDirectory, string scriptDirectory)
        {
            _watcher.Path = targetDirectory;
            _watcher.Filter = "*.*";
            _watcher.IncludeSubdirectories= true;
            _watcher.EnableRaisingEvents = true;
            _watcher.Changed += new FilesWatcherEvents(scriptDirectory).OnChanged;
        }

    }
}
