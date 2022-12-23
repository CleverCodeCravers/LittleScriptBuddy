using LittelScriptBuddy.Domain;
using LittelScriptBuddy.Domain.FilesWatcher;
using LittelScriptBuddy.Domain.ScriptExecution;

var parser = new ConsoleCommandLineParser();

var commandLineParametersResult = parser.Parse(args);

if (!commandLineParametersResult.IsSuccess)
{
    Console.WriteLine("Unfortunately there have been problems with the command line arguments.");
    return;
}

var parameters = commandLineParametersResult.Value;

var watcher = new FileChangeWatcher(
    parameters.TargetDirectory, 
    ".cs",
    (file) =>
    {
        var fileContent = TolerantFileReader.ReadFile(file);
        var commentWithCommand = CommentWithCommandRetriever.Get(fileContent);
        if (commentWithCommand.RowIndex == -1)
            return;

        var command = CommentWithCommandRetriever.ExtractCommandOnly(commentWithCommand.Comment);
        var rest = command; 

        var scriptName = FilesProcessor.GetToken(ref rest);
        var scriptPath = Path.Combine(parameters.ScriptsDirectory, scriptName);
        var output = new ScriptExecutor().ExecuteCommand(scriptPath, rest);

        var newFileContent = FilesProcessor.ReplaceLineWithContent(fileContent, commentWithCommand.RowIndex, output);

        File.WriteAllLines(file, newFileContent);

        var zeitstempel = DateTime.Now;
        var targetFilename = Path.GetFileName(file);
        Console.WriteLine($" - [{zeitstempel:yyyy-MM-dd}] exec {command} >> {targetFilename}");
    });
watcher.Run();

Console.WriteLine("Press 'q' to quit the program.");
while (Console.Read() != 'q') ;
