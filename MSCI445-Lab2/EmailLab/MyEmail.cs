using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailLab
{
    public class MyEmail
    {
        string subject;
        string content;
        string username;
        string password;
        string recipient;
        public MyEmail(string subject, string content, string username, string password, string recipient)
        {
            this.subject = subject;
            this.content = content;
            this.username = username;
            this.password = password;
            this.recipient = recipient;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        public void send()
        {
            Debug.WriteLine("here");
        }
    }
}
