using System.Reflection.Metadata.Ecma335;

namespace LittelScriptBuddy.Domain.FilesWatcher
{
    public class FileChangeWatcher 
    {
        private readonly string targetDirectory;
        private readonly string fileEnding;
        private readonly Action<string> onFileChanged;

        private FileSystemWatcher _watcher = new();

        public FileChangeWatcher(
            string targetDirectory,
            string fileEnding, 
            Action<string> onFileChanged
            )
        {
            this.targetDirectory = targetDirectory;
            this.fileEnding = fileEnding;
            this.onFileChanged = onFileChanged;

        }

        public void Run() 
        {
            _watcher.Path = targetDirectory;
            _watcher.Filter = "*.*";
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
            _watcher.Changed += OnFileChanged;
            _watcher.Renamed += OnFileRenamed;
        }

        private bool BelongsToTheFilesWeWant(string filenameWithFullPath)
        {
            var filename = filenameWithFullPath;

            if (filenameWithFullPath.Contains("/.git/"))
                return false;

            if (filenameWithFullPath.Contains("/.vs/"))
                return false;

            return filename.EndsWith(fileEnding);
        }


        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (!BelongsToTheFilesWeWant(e.FullPath))
                return;

            if (onFileChanged != null)
                onFileChanged(e.FullPath);
        }

        private void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            if (!BelongsToTheFilesWeWant(e.FullPath))
                return;

            if (onFileChanged != null)
                onFileChanged(e.FullPath);
        }
    }
}
