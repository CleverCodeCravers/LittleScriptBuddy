
using CommandLineArguments;

namespace LittelScriptBuddy.Domain
{
    public class ConsoleCommandLineParser
    {
        public Result<ConsoleCommandLineParameters> Parse(string[] args)
        {
            var parser = new Parser(
                new ICommandLineOption[] {
                new StringCommandLineOption("--targetDirectory"),
                new StringCommandLineOption("--scriptsDirectory"),
                });

            if (!parser.TryParse(args, true) || args.Length == 0)
            {
                return Result<ConsoleCommandLineParameters>.Failure("Invalid command line arguments");
            }

            return Result<ConsoleCommandLineParameters>.Success(
                new ConsoleCommandLineParameters(
                    parser.GetOptionWithValue<string>("--targetDirectory") ?? "",
                    parser.GetOptionWithValue<string>("--scriptsDirectory") ?? ""
                ));
        }
    }
}
