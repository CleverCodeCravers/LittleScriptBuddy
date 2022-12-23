using LittelScriptBuddy.Domain.ScriptExecution;
using System.Threading;

namespace LittelScriptBuddy.Domain.FilesWatcher
{
    public class FilesWatcherEvents
    {
        private string _scriptsPath = "";
        private bool IsExecuting { get; set; }

        public FilesWatcherEvents(string scriptsPath)
        {
            this._scriptsPath = scriptsPath;
        }
        public void OnChanged(object sender, FileSystemEventArgs e)
        {

            if (!IsExecuting)
            {
                IsExecuting = true;

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

                var scriptPath = Path.Combine(this._scriptsPath, scriptName + ".ps1");

                if (!FilesProcessor.CheckIfScriptExists(scriptPath))
                {
                    return;
                }

                var executeScript = new ScriptExecutor().ExecuteCommand(scriptPath, command);

                Console.WriteLine(executeScript);
                IsExecuting = false;
            }
        }

    }
}
