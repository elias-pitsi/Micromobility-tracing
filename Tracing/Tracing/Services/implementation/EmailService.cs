using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Tracing.DataAccess.Dtos;
using Tracing.Services.interfaces;

namespace Tracing.Services.implementation
{
   
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = request.Body
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.google.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
