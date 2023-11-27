using System.Net.Mail;
using Berger.Extensions.Abstractions;
using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Email
{
    public class EmailService<T> : IEmailService<T> where T : Enum
    {
        #region Fields
        private readonly IConfiguration _config;
        private readonly ITemplateService _template;
        private readonly ISmtpClientFactory _smtpClientFactory;
        #endregion

        #region Constructor
        public EmailService(ITemplateService template, ISmtpClientFactory smtpClientFactory, IConfiguration config)
        {
            _config = config;
            _template = template;
            _smtpClientFactory = smtpClientFactory;
        }
        #endregion

        #region Methods
        public void Send(IMessage<T> message, ISmtpConfiguration smtpConfig, string alias = "")
        {
            using var mailMessage = CreateEmail(message, smtpConfig, alias);

            using var smtpClient = _smtpClientFactory.Create(smtpConfig);

            smtpClient.Send(mailMessage);
        }
        private MailMessage CreateEmail(IMessage<T> message, ISmtpConfiguration smtpConfig, string alias = "")
        {
            var body = _template.Process(message.Body, message.Data);

            var email = new MailMessage
            {
                From = new MailAddress(smtpConfig.User, string.IsNullOrEmpty(alias) ? smtpConfig.User : alias),
                Body = body,
                IsBodyHtml = true,
                Subject = message.Subject
            };

            email.To.Add(message.Recipient);

            return email;
        }
        #endregion
    }
}