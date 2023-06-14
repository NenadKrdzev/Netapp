//using eCinema.Domain;
//using eCinema.Domain.DomainModels;
//using eCinema.Services.Interface;
//using MailKit.Security;
//using MimeKit;
//using System;
//using System.Collections.Generic;
//using System.Net.Mail;
//using System.Text;
//using System.Threading.Tasks;

//namespace eCinema.Services.Implementation
//{
//    public class EmailService : IEmailService
//    {
//        private readonly EmailSettings _settings;

//        public EmailService(EmailSettings settings)
//        {
//            _settings = settings;
//        }
//        public async Task SendEmailASync(List<EmailMessage> allMails)
//        {
//            List<MimeMessage> messages = new List<MimeMessage>();

//            foreach (var item in allMails)
//            {
//                var emailMessage = new MimeMessage
//                {
//                    Sender = new MailboxAddress(_settings.SenderName, _settings.SMTPUsername),
//                    Subject = item.Subject
//                };

//                emailMessage.From.Add(new MailboxAddress(_settings.EmailDisplayName, _settings.SMTPUsername));

//                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = item.Content };

//                emailMessage.To.Add(new MailboxAddress(item.MailTo, item.MailTo));

//                messages.Add(emailMessage);
//            }

//            try
//            {
//                using(var smtp=new MailKit.Net.Smtp.SmtpClient())
//                {
//                    var socketOption = _settings.EnableSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto;

//                    await smtp.ConnectAsync(_settings.SMTPServer, _settings.SMTPServerPort, socketOption);

//                    if (string.IsNullOrEmpty(_settings.SMTPUsername))
//                    {
//                        await smtp.AuthenticateAsync(_settings.SMTPUsername, _settings.SMTPPassword);
//                    }

//                    foreach (var item in messages)
//                    {
//                        await smtp.SendAsync(item);
//                    }

//                    await smtp.DisconnectAsync(true);
//                }
//            }
//            catch (SmtpException ex)
//            {

//                throw ex;
//            }
//        }
//    }
//}
