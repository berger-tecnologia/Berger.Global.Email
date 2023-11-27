using System.Net;
using System.Net.Mail;
using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Email
{
    public class SmtpClientFactory : ISmtpClientFactory
    {
        public SmtpClient Create(ISmtpConfiguration smtpConfig)
        {
            return new SmtpClient(smtpConfig.Host, smtpConfig.Port)
            {
                UseDefaultCredentials = false,
                EnableSsl = smtpConfig.EnableSsl,
                Credentials = new NetworkCredential(smtpConfig.User, smtpConfig.Password)
            };
        }
    }
}