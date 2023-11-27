using System.Net.Mail;
using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Email
{
    public interface ISmtpClientFactory
    {
        SmtpClient Create(ISmtpConfiguration smtpConfig);
    }
}