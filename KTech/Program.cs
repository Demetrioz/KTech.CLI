using KTech.Commands.Notifications.Bindings;
using KTech.Commands.Notifications.Handlers;
using KTech.Commands.Notifications.Options;
using KTech.Extensions;
using System.CommandLine;

// Documentation at https://docs.microsoft.com/en-us/dotnet/standard/commandline/

namespace Ktech
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            // Root
            RootCommand root = new RootCommand("Command Line Interface to interact with KTech Systems");

            // Notifications
            Command notification = new Command("notification", "Interact with KTech.Commands.Notifications");
            Command email = new Command("email", "Send an email via KTech.Commands.Notifications")
                .AddOptions(EmailOptions.GetOptions());


            root.AddCommand(notification);
            notification.AddCommand(email);
            email.SetHandler((email) => EmailHandlers.SendEmail(email), new EmailBinder());

            return await root.InvokeAsync(args);
        }
    }
}
