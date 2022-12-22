

using System.Diagnostics;

namespace LittelScriptBuddy.Domain.ScriptExecution
{
    public class ScriptExecutor : IScriptExecutor
    {
        public string ExecuteCommand(string scriptPath, string parameters)
        {

            if (parameters.Contains(';'))
            {
                parameters = parameters.Replace(";", "");
            }

            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = string.Format("-NoProfile -ExecutionPolicy ByPass -File {0} {1}", scriptPath, parameters),
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };

            var process = Process.Start(startInfo);

            var outputMessage = process!.StandardOutput.ReadToEnd();

            process.WaitForExit();

            return outputMessage.Trim();
        }
    }
}
