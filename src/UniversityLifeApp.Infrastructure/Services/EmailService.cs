using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniversityLifeApp.Application.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string subject, string html)
        {
            try
            {
                // create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("elnur.h174@yandex.com"));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = html };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.yandex.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("elnur.h174@yandex.com", "20Coder02");
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"E-posta gönderme hatası: {ex.Message}");
            }
        }
    }
}
