using EntityFramework_Slider.Services.Interface;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using EntityFramework_Slider.Helpers;

namespace EntityFramework_Slider.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public void Send(string to, string subject, string html, string from = null)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _emailSettings.FromAddress));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect( _emailSettings.Server, _emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettings.UserName, _emailSettings.Password);
            smtp.Send(email);
            smtp.Disconnect(true);


            //// create email message
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("faridrab@code.edu.az"));
            //email.To.Add(MailboxAddress.Parse(newUser.Email));
            //email.Subject = "Register confirmation";
            //email.Body = new TextPart(TextFormat.Html) { Text =  };

            //// send email
            //using var smtp = new SmtpClient();
            //smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate("faridrab@code.edu.az", "zlccxxaltpptpeyw");
            //smtp.Send(email);
            //smtp.Disconnect(true);


        }
    }
}
