using CommandLineArguments;

var parser = new Parser(
    new ICommandLineOption[] {
        new StringCommandLineOption("--targetDirectory"),
        new StringCommandLineOption("--scriptDirectory")
    });

if (!parser.TryParse(args, true))
{
    Console.WriteLine("Unfortunately there have been problems with the command line arguments.");
    Console.WriteLine("");
    return;
}

if (string.IsNullOrWhiteSpace(parser.TryGetOptionWithValue<string>("--targetDirectory")) || string.IsNullOrEmpty(parser.TryGetOptionWithValue<string>("--scriptDirectory"))) 
{
    Console.WriteLine("Unfortunately there have been problems with the command line arguments.");
    Console.WriteLine("");
    return;
}


{

}
;
Console.WriteLine(parser.TryGetOptionWithValue<string>("--targetDirectory"));
