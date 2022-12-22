namespace LittelScriptBuddy.Domain.ScriptExecution
{
    public interface IScriptExecutor
    {
     string ExecuteCommand(string script, string parameters);

    }
}
