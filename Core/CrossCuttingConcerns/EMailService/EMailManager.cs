using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Core.CrossCuttingConcerns.EMailService
{
    public class EMailManager : IEMailManager
    {
        public void SendEMail(EMailConfig eMailConfig, EMailContent eMailContent)
        {
            SmtpClient client = new SmtpClient(eMailConfig.SmtpServer)
            {
                Port = eMailConfig.Port,
                Credentials = new NetworkCredential(eMailConfig.From, eMailConfig.Password),
                EnableSsl = eMailConfig.EnableSsl,
                Timeout = Int32.MaxValue
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(eMailConfig.From),
                Subject = eMailContent.Subject,
                Body = eMailContent.Body,
                IsBodyHtml = eMailContent.IsBodyHtml
            };

            foreach (var to in eMailConfig.To)
            {
                mailMessage.To.Add(to);
            }

            client.Send(mailMessage);
            mailMessage.Dispose();

        }
    }
}
