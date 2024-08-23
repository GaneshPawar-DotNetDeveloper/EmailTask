using System;
using System.Net;
using System.Net.Mail;

namespace EmailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter recipient email address:");
            string recipientEmail = Console.ReadLine();

            Console.WriteLine("Enter subject:");
            string subject = Console.ReadLine();

            Console.WriteLine("Enter email body:");
            string body = Console.ReadLine();

            SendEmail(recipientEmail, subject, body);

            Console.WriteLine("Email sent! Press any key to exit.");
            Console.ReadKey();
            Console.ReadLine();
        }

        static void SendEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // Use 465 for SSL or 587 for TLS
                    Credentials = new NetworkCredential("itsganeshpawar99@gmail.com", "ktus ufvq ycim iroc"),
                    EnableSsl = true, // Set to true if using SSL/TLS
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("itsganeshpawar99@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false,
                };

                mailMessage.To.Add(recipientEmail);

                client.Send(mailMessage);
                Console.WriteLine("Email successfully sent to " + recipientEmail);
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine("Failed to send email. SMTP Error: " + smtpEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email. General Error: " + ex.Message);
            }
        }
    }
}