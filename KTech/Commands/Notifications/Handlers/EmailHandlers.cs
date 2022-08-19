using KTech.Commands.Notifications.Bindings;

namespace KTech.Commands.Notifications.Handlers
{
    public static class EmailHandlers
    {
        public static void SendEmail(Email email)
        {
            Console.WriteLine("Would be sending an email:");
            Console.WriteLine($"To: {string.Join(", ", email?.To ?? new[] {""} )}");
            Console.WriteLine($"From: {email?.From}");
            Console.WriteLine($"CC: {string.Join(", ", email?.Cc ?? new[] { "" })}");
            Console.WriteLine($"BCC: {string.Join(", ", email?.Bcc ?? new[] { "" })}");
            Console.WriteLine($"Body: {email?.Body}");
            Console.WriteLine($"Subject: {email?.Subject}");
        }
    }
}
