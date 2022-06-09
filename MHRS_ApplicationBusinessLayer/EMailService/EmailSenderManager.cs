using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationBusinessLayer.EMailService
{
    public class EmailSenderManager : IEmailSenderService
    {
        //dependency injection
        private readonly IConfiguration _configuration; //readonly dışardan müdahaleyi engeller sadece ctor calısır. application json dosyasına ulasmak icin

        public EmailSenderManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string SenderMail => _configuration.GetSection("EmailOptions:SenderMail").Value; 
        public string Password => _configuration.GetSection("EmailOptions:Password").Value;
        public string Smtp => _configuration.GetSection("EmailOptions:Smtp").Value;
        public int SmtpPort => int.Parse(_configuration.GetSection("EmailOptions:SmtpPort").Value);
        public string CC => _configuration.GetSection("ManagerEmails:EmailToCC").Value;
        public async Task SendAsync(EMailMessage message)
        {
            try
            {
                var mail = new MailMessage()
                {
                    From = new MailAddress(this.SenderMail)
                };
                //contacts
                foreach (var item in message.Contacts)
                {
                    mail.To.Add(new MailAddress(item));
                }
                //cc
                if(message.CC!=null)
                {
                    foreach (var item in message.CC)
                    {
                        mail.CC.Add(new MailAddress(item));
                    }
                }
                //cc appsett.json dosysından gelecek
                if (this.CC != null)
                {
                    foreach (var item in this.CC.Split(","))
                    {
                        mail.CC.Add(new MailAddress(item));
                    }
                }
                //bcc
                if(message.BCC!=null)
                {
                    foreach (var item in message.BCC)
                    {
                        mail.Bcc.Add(new MailAddress(item));
                    }
                }
                mail.Subject = message.Subject;
                mail.Body = message.Body;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.HeadersEncoding = Encoding.UTF8;
                var smtpClient = new SmtpClient(Smtp, SmtpPort)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(SenderMail, Password)
                };
                await smtpClient.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                //ex loglansın
            }
        }
    }
}
