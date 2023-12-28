using MailKit.Net.Smtp;
using MimeKit;
using System;

namespace Shafa_Al_Firdaus_API.Models
{
    public class EmailService
    {
        public EmailService()
        {

        }
        public void SendEmail(string to, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Iskandar Maulana", "mynameiskandar410@gmail.com"));
                message.To.Add(new MailboxAddress("DKM Asy-Syabab",to));
                message.Subject = subject;

                var textPart = new TextPart("plain")
                {
                    Text = body
                };

                var multipart = new Multipart("mixed");
                multipart.Add(textPart);

                message.Body = multipart;

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("mynameiskandar410@gmail.com", "iskandar2468");

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email. Error: {ex.Message}");
            }
        }
    }
}
