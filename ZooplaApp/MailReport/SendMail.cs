using System;
using System.Net;
using System.Net.Mail;
using ZooplaApp.Credencials;
using ZooplaApp.CustomException;

namespace ZooplaApp.MailReport
{
    /// <summary>
    /// To send extent report of test cases as a mail
    /// </summary>
    public class SendMail
    {
        public static void SendEmailMethod()
        {
            try
            {
                MailMessage mail = new MailMessage();
                string fromEmail = JsonData.data.EmailForReport;
                string password = JsonData.data.EmailForReportPassword;
                string ToEmail = JsonData.data.UserEmail;
                mail.From = new MailAddress(fromEmail);
                mail.Subject = "Zoopla App Test Report";
                mail.To.Add(ToEmail);
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(@"C:\Users\Admin\source\repos\ZooplaApp\ZooplaApp\ExtentReports\index.html"));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch(Exception)
            {
                throw new CustomExceptions("Error while sending mail",CustomException.ExceptionType.COULD_NOT_SEND_EMAIL);
            }
        }
    }
}
