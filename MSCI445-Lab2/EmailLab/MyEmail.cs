using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailLab
{
    public class MyEmail
    {
        // declare variables
        string subject;
        string content;
        string username;
        string password;
        string recipient;
        public MyEmail(string subject, string content, string username, string password, string recipient)
        {
            // initialize variables
            this.subject = subject;
            this.content = content;
            this.username = username;
            this.password = password;
            this.recipient = recipient;
        }
        // password setter
        public void setPassword(string password)
        {
            this.password = password;
        }
        public bool send()
        {
            try
            {
                // set the credentials of the email server
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
                SmtpServer.EnableSsl = true;

                // set the to, from, subject, and content of the email
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(username);
                mail.To.Add(recipient);
                mail.Subject = subject;
                mail.Body = content;

                // send the email
                SmtpServer.Send(mail);
                return true;
            }
            // catch any exception and return false because email wasn't sent
            catch (Exception)
            {
                return false;
            }
        }
    }
}
