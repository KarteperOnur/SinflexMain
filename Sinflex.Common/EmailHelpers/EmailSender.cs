using System.Net;
using System.Net.Mail;

namespace Sinflex.Common.EmailHelpers
{
    public class EmailSender
    {
        public static void SendEmail(string email, string subject, string body)
        {
            //MailMessage
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress("yzl3172@outlook.com", "Yzl3172");
            sender.Subject = subject;
            sender.Body = body;
            sender.To.Add(email);



            //SmtpClient
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential("yzl3172@outlook.com", "YzlKadikoy--");
            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            smtpClient.Send(sender);
        }
    }
}
