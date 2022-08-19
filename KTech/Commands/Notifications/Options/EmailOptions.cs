using System.CommandLine;

namespace KTech.Commands.Notifications.Options
{
    public static class EmailOptions
    {
        public static Option<string[]> ToOption = new Option<string[]>(
            name: "--to",
            description: "Comma separated list of who the email will be sent to",
            parseArgument: result =>
            {
                List<string> emails = new();
                for (int i = 0; i < result.Tokens.Count; i++)
                    if (result.Tokens[i].Value.ToLower().Contains("@"))
                    {
                        emails.Add(result.Tokens[i].Value);
                    }
                    else
                    {
                        result.ErrorMessage = "--to must contain valid email addresses";
                    }

                return emails.Any()
                    ? emails.ToArray()
                    : new string[] { };
            }
        )
        {
            IsRequired = true,
            AllowMultipleArgumentsPerToken = true
        };

        public static Option<string> FromOption = new Option<string>("--from", "Who the email will be coming from") { IsRequired = true };
        public static Option<string[]> CcOption = new Option<string[]>("--cc", "Comma separated list of who the email will be cced to");
        public static Option<string[]> BccOption = new Option<string[]>("--bcc", "Comma separated list of who the email will be bcced to");
        public static Option<string> BodyOption = new Option<string>("--body", "The contents of the email body") { IsRequired = true };
        public static Option<string> SubjectOption = new Option<string>("--subject", "The subject of the email") { IsRequired = true };

        public static List<Option> GetOptions()
        {
            return new List<Option>()
            {
                FromOption,
                ToOption,
                CcOption,
                BccOption,
                SubjectOption,
                BodyOption
            };
        }
    }
}
