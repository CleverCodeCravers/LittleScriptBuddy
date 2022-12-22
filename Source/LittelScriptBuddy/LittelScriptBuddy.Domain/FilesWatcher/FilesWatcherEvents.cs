using LittelScriptBuddy.Domain.ScriptExecution;

namespace LittelScriptBuddy.Domain.FilesWatcher
{
    public  class FilesWatcherEvents
    {
        private string _scriptsPath = "";

        public FilesWatcherEvents(string scriptsPath)
        {
            this._scriptsPath = scriptsPath;
        }
        public void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Changed");
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            var commentLine = FilesProcessor.GetFirstLine(e.FullPath);

            if (string.IsNullOrEmpty(commentLine))
            {
                return;
            }

            var command = FilesProcessor.ParseString(commentLine);
            var scriptName = FilesProcessor.GetToken(ref command);

            var scriptPath = Path.Combine(this._scriptsPath, scriptName);
            
            if (!FilesProcessor.CheckIfScriptExists(scriptPath))
            {
                return;
            }

            var executeScript = new ScriptExecutor().ExecuteCommand(scriptPath, command);

            Console.WriteLine(executeScript);
        }


    }
}
