using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using Berger.Global.Email.Models;

namespace Berger.Global.Body.Services
{
    public class Sender
    {
        private SmtpClient _client;
        private MailMessage _message;

        public void Send(Message message, Smtp credential)
        {
            Prepare(message, credential);

            _client.Send(_message);
        }

        public void Send(Message message, Smtp credential, string alias)
        {
            Prepare(message, credential, alias);

            _client.Send(_message);
        }

        private void Prepare(Message message, Smtp credential, string alias = "")
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
                _message.From = new MailAddress(credential.User, alias);
            else
                _message.From = new MailAddress(credential.User);

            _message.Body = body;
            _message.To.Add(message.Recipient);
            _message.Subject = message.Subject;

            _client = new SmtpClient(credential.Host, credential.Port);

            _client.UseDefaultCredentials = false;
            _client.EnableSsl = credential.EnableSsl;
            _client.Credentials = new NetworkCredential(credential.User, credential.Password);
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
    }
}