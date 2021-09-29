using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public static class EmailService
    {

        public async static void SendVerifyEmailAsync(string userkey,string email,string subject)
        {
            var emailMessage = new MimeMessage();

          string  message = $"<a href='http://yourprojectname:8080/register/approve/{userkey}/{email}'>Подтвердите Регистрацию </a>";

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "kirill.cherkez@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 25, false);
                await client.AuthenticateAsync("kirill.cherkez@mail.ru", "Mpnetvi100");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);

            }
        }

        public async static void SendChangesInfoEmailAsync( string email, string message,string subject)
        {
            var emailMessage = new MimeMessage();

          

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "kirill.cherkez@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject =subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 25, false);
                await client.AuthenticateAsync("kirill.cherkez@mail.ru", "Mpnetvi100");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);

            }
        }
    }
}
