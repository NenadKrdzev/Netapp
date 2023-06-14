using System;
using System.Collections.Generic;
using System.Text;

namespace eCinema.Domain
{
    public class EmailSettings
    {
        public string SMTPServer { get; set; }
        public string SMTPUsername { get; set; }
        public string SMTPPassword { get; set; }
        public int SMTPServerPort { get; set; }
        public bool EnableSsl { get; set; }
        public string EmailDisplayName { get; set; }
        public string SenderName { get; set; }

        public EmailSettings() { }
        public EmailSettings(string smtpServer,string smtpUsername, string smtpPassword, int smtpServerPort)
        {
            this.SMTPServer = smtpServer;
            this.SMTPUsername = smtpUsername;
            this.SMTPPassword = smtpPassword;
            this.SMTPServerPort = smtpServerPort;

        }
    }
}
