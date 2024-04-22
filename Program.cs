using System;
using System.Net;
using System.Net.Mail;

namespace SmtpClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "your_smtp_server_address"; // for  example: "smtp.gmail.com"
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("username", "password"); //SMTP servers often require authentication to ensure that only authorized users can send emails.

                MailMessage message = new MailMessage();
                message.From = new MailAddress("sender@example.com");
                message.To.Add("recipient@example.com");
                message.Subject = "Subject of the email";
                message.Body = "Body of the email";

                // Optional: Attach a file
                Attachment attachment = new Attachment("path_to_attachment_file"); //test
                message.Attachments.Add(attachment);

                client.Send(message);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
