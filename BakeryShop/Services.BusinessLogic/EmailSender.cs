using Domain.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Services.BusinessLogic
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailConfig = _configuration.GetSection("EmailSender");
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Bakery Shop", emailConfig["Email"]));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(emailConfig["Host"], int.Parse(emailConfig["Port"]), bool.Parse(emailConfig["UseSSL"]));
                await client.AuthenticateAsync(emailConfig["Email"], emailConfig["Password"]);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
