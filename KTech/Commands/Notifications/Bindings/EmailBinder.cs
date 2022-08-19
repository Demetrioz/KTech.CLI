using KTech.Commands.Notifications.Options;
using System.CommandLine;
using System.CommandLine.Binding;

namespace KTech.Commands.Notifications.Bindings
{
    public class Email
    {
        public string? From { get; set; }
        public string[]? To { get; set; }
        public string[]? Cc { get; set; }
        public string[]? Bcc { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }


    public class EmailBinder : BinderBase<Email>
    {
        private readonly Option<string> _fromOption;
        private readonly Option<string[]> _toOption;
        private readonly Option<string[]> _ccOption;
        private readonly Option<string[]> _bccOption;
        private readonly Option<string> _subjectOption;
        private readonly Option<string> _bodyOption;

        public EmailBinder()
        {
            _fromOption = EmailOptions.FromOption;
            _toOption = EmailOptions.ToOption;
            _ccOption = EmailOptions.CcOption;
            _bccOption = EmailOptions.BccOption;
            _subjectOption = EmailOptions.SubjectOption;
            _bodyOption = EmailOptions.BodyOption;
        }

        protected override Email GetBoundValue(BindingContext bindingContext)
        {
            return new Email
            {
                From = bindingContext.ParseResult.GetValueForOption(_fromOption),
                To = bindingContext.ParseResult.GetValueForOption(_toOption),
                Cc = bindingContext.ParseResult.GetValueForOption(_ccOption),
                Bcc = bindingContext.ParseResult.GetValueForOption(_bccOption),
                Subject = bindingContext.ParseResult.GetValueForOption(_subjectOption),
                Body = bindingContext.ParseResult.GetValueForOption(_bodyOption)
            };
        }
    }
}
