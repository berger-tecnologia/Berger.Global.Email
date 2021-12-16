using System.Net;
using System.Net.Mail;
using Berger.Extensions.Email.Models;

namespace Berger.Extensions.Email.Services
{
    public class Sender
    {
        #region Properties
        private SmtpClient _client;
        private MailMessage _message;
        #endregion

        #region Methods
        public void Send(Message message, Smtp smtp)
        {
            Prepare(message, smtp);

            _client.Send(_message);
        }
        public void Send(Message message, Smtp smtp, string alias)
        {
            Prepare(message, smtp, alias);

            _client.Send(_message);
        }
        private void Prepare(Message message, Smtp smtp, string alias = "")
        {
            var body = string.Empty;

            _message = new MailMessage();

            if (message.MessageType == MessageType.Html)
            {
                _message.IsBodyHtml = true;

                body = GetTemplate(message);
            }
            else
                body = message.Body;

            if (!string.IsNullOrEmpty(alias))
                _message.From = new MailAddress(smtp.User, alias);
            else
                _message.From = new MailAddress(smtp.User);

            _message.Body = body;
            _message.To.Add(message.Recipient);
            _message.Subject = message.Subject;

            _client = new SmtpClient(smtp.Host, smtp.Port);

            _client.UseDefaultCredentials = false;
            _client.EnableSsl = smtp.EnableSsl;
            _client.Credentials = new NetworkCredential(smtp.User, smtp.Password);
        }
        private string GetTemplate(Message message)
        {
            var html = string.Empty;

            using (WebClient client = new WebClient())
            {
                html = client.DownloadString(message.TemplateUrl);

                if (message.Data != null)
                {
                    foreach (KeyValuePair<string, string> dictionary in message.Data)
                    {
                        html = html.Replace(dictionary.Key, dictionary.Value);
                    }
                }
            }

            return html;
        }
        #endregion
    }
}