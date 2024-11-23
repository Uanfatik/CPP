using System.Collections.Frozen;
using System.Text;
using CommandLine;
using CommandLine.Text;
using Lab4.Application;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

var result = new Parser().ParseArguments<RunOptions, SetPathOptions>(args);
var message = result.MapResult<RunOptions, SetPathOptions, string>(
    OptionsMapper.MapRunOptions,
    OptionsMapper.MapSetPathOptions,
    errors => OptionsMapper.MapErrors(result, errors)
);
Console.WriteLine(message);

file static class OptionsMapper
{
    private static readonly Version? Version;
    private static readonly FrozenDictionary<string, Func<IEnumerator<string>, string>> RunMethods;


    static OptionsMapper()
    {
        Version = typeof(OptionsMapper).Assembly.GetName().Version;
        RunMethods = new Dictionary<string, Func<IEnumerator<string>, string>>
            {
                ["lab1"] = Lab1Runner.Run,
                ["lab2"] = Lab2Runner.Run,
                ["lab3"] = Lab3Runner.Run
            }
            .ToFrozenDictionary();
    }


    public static string MapErrors<T>(ParserResult<T> result, IEnumerable<Error> errors)
    {
        return errors.IsVersion()
            ? $"""
               Author: Viktor Semenchenko
               Version: {Version}
               """
            : HelpText.AutoBuild(result);
    }


    public static string MapRunOptions(RunOptions options)
    {
        if (!RunMethods.TryGetValue(options.LaboratoryWorkName, out var run))
        {
            return "Invalid lab name.";
        }

        var directoryPath =
            Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User)
            ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        var inputPath = options.InputPath ?? Path.Join(directoryPath, "INPUT.TXT");
        var outputPath = options.OutputPath ?? Path.Join(directoryPath, "OUTPUT.TXT");

        string[] linesArray;
        try
        {
            linesArray = File.ReadAllLines(inputPath);
        }
        catch (Exception exception)
        {
            return $"An error occurred while reading the file. {exception.Message}";
        }

        string output;
        using (var lines = linesArray.AsEnumerable().GetEnumerator())
        {
            try
            {
                output = run(lines);
            }
            catch (InputException exception)
            {
                output = exception.Message;
            }
        }

        try
        {
            File.WriteAllLines(outputPath, [output]);
        }
        catch (Exception exception)
        {
            return $"An error occurred while writing the file. {exception.Message}";
        }

        return "Execution completed!";
    }


    public static string MapSetPathOptions(SetPathOptions options)
    {
        Environment.SetEnvironmentVariable(
            "LAB_PATH",
            options.FilesDirectoryPath,
            EnvironmentVariableTarget.User
        );
        return "Environment variable set!";
    }
}


[Verb("run", HelpText = "Run laboratory work.")]
file class RunOptions
{
    [Value(0, HelpText = "Laboratory work name ('lab1', 'lab2' or 'lab3').", Required = true)]
    public required string LaboratoryWorkName { get; init; }

    [Option('i', "input", HelpText = "The path to the input file.")]
    public string? InputPath { get; init; }

    [Option('o', "output", HelpText = "The path to the output file.")]
    public string? OutputPath { get; init; }
}


[Verb("set-path", HelpText = "Set the path to the directory with the input/output files as an environment variable.")]
file class SetPathOptions
{
    [Option('p', "path", HelpText = "The path to the directory with the input/output files.", Required = true)]
    public required string FilesDirectoryPath { get; init; }
}
