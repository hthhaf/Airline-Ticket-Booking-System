using B2C.Model;
using B2C.Data;
using B2C.Controller;
using MailKit.Net.Smtp;
using MailKit.Security;
using B2C.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;


namespace B2C.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
       

        public MailService(IOptions<MailSettings> mailSettingsOptions)
        {
            _mailSettings = mailSettingsOptions.Value;

        }



        public Task<bool> SendHTMLMail(HTMLMailData htmlMailData, string html)
        {
            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                    emailMessage.From.Add(emailFrom);

                    MailboxAddress emailTo = new MailboxAddress(htmlMailData.EmailToName, htmlMailData.EmailToId);
                    emailMessage.To.Add(emailTo);

                    emailMessage.Subject = "Airline Booking";

              
                    

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.HtmlBody = html;
                    emailBodyBuilder.TextBody = "Plain Text goes here to avoid marked as spam for some email servers.";

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();

                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        mailClient.Connect(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        mailClient.Authenticate(_mailSettings.SenderEmail, _mailSettings.Password);
                        mailClient.Send(emailMessage);
                        mailClient.Disconnect(true);
                    }
                }

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                // Exception Details
                return Task.FromResult(false);
            }
        }

    }
}