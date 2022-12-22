using LittelScriptBuddy.Domain;
using LittelScriptBuddy.Domain.FilesWatcher;

var parser = new ConsoleCommandLineParser();

var commandLineParametersResult = parser.Parse(args);

if (!commandLineParametersResult.IsSuccess)
{
    Console.WriteLine("Unfortunately there have been problems with the command line arguments.");
    return;
}

var parameters = commandLineParametersResult.Value;

var watcher = new FilesWatcher(parameters.TargetDirectory, parameters.ScriptsDirectory);

Console.WriteLine("Press 'q' to quit the program.");
while (Console.Read() != 'q') ;
