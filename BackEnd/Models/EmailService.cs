using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class EmailService
    {

        public async void SendEmailAsync(string userkey,string email)
        {
            var emailMessage = new MimeMessage();

            string message = $"<a href='http://yourprojectname:8080/register/approve/{userkey}/{email}'>Подтвердите Регистрацию </a>";

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "smurf2003@mail.ua"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = "Подтверждение регистрации";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 25, false);
                await client.AuthenticateAsync("smurf2003@mail.ua", "vfvfvfif1");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);

            }
        }
    }
}
