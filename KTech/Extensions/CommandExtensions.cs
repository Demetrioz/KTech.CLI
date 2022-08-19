using System.CommandLine;

namespace KTech.Extensions
{
    public static class CommandExtensions
    {
        public static Command AddOptions(this Command command, List<Option> options)
        {
            foreach (var option in options)
                command.AddOption(option);

            return command;
        }
    }
}
