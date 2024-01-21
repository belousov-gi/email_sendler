using email_sendler.DataLayer;
using email_sendler.Enums;
using email_sendler.Interfaces;
using email_sendler.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace email_sendler.Services;

public class SmtpService
{
    private IOptions<SmtpServiceConfiguration> _configuration;
    private IStorage _storage;
    public SmtpService(IOptions<SmtpServiceConfiguration> configuration, IStorage dbStorageManager)
    {
        _configuration = configuration;
        _storage = dbStorageManager;
    }
    public void SendEmail( string subject, string body, string recipientEmail)
    {
        try
        {
            using var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration.Value.FieldFromName,
                _configuration.Value.FieldFromAddress));
            emailMessage.To.Add(new MailboxAddress("", recipientEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect(_configuration.Value.SmtpProvider, _configuration.Value.Port,
                    _configuration.Value.UseSsl);
                client.Authenticate(_configuration.Value.UserName, _configuration.Value.Password); 
                client.Send(emailMessage);
                client.DisconnectAsync(true);
            }

            var result = ResultOfDispatch.OK.ToString();
            
            var mailLog = new MailLogModel()
            {
                Subject = subject,
                Body = body,
                Recipient = recipientEmail,
                DateTimeDispatch = DateTime.Now,
                Result = result,
            };
            _storage.SaveMailInfoAsync(mailLog);
        }

        catch (Exception e)
        {
            string errorMessage = e.Message;
            var result = ResultOfDispatch.Failed.ToString();
            
            var mailLog = new MailLogModel()
            {
                Subject = subject,
                Body = body,
                Recipient = recipientEmail,
                DateTimeDispatch = DateTime.Now,
                Result = result,
                FailedMessage = errorMessage
            };
            _storage.SaveMailInfoAsync(mailLog);
        }
      
    }
}


    