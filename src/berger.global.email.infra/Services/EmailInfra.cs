using System.Net;
using System.Net.Mail;
using berger.global.domain.Models;
using System.Collections.Generic;
using berger.global.email.infra.Interfaces;

namespace berger.global.email.infra.Services
{
    public class EmailInfra : IEmailInfra
    {
        private string _html;

        private SmtpClient _client;
        private MailMessage _email;

        public EmailInfra()
        {
        }
        public void Send(Email email, Credential credential)
        {
            Prepare(email, credential, string.Empty);

            _html = string.Empty;

            _client.Send(_email);
        }

        public void Send(Email email, Credential credential, string alias)
        {
            Prepare(email, credential, alias);

            _html = string.Empty;

            _client.Send(_email);
        }

        public void Prepare(Email email, Credential credential, string alias)
        {
            var message = string.Empty;

            _email = new MailMessage();

            var url = email.Template;
            var subject = email.Subject;
            var recipient = email.Recipient;

            /* Envio de e-mail com código em Html */
            if (!string.IsNullOrEmpty(url))
            {
                using (WebClient client = new WebClient())
                {
                    _html = client.DownloadString(url);

                    foreach (KeyValuePair<string, string> chave in email.Data)
                    {
                        _html = _html.Replace(chave.Key, chave.Value);
                    }
                }
            }

            /* Configurações gerais */
            message = string.IsNullOrEmpty(email.Message) ? _html : email.Message;

            if (!string.IsNullOrEmpty(alias))
                _email.From = new MailAddress(credential.User, alias);
            else
                _email.From = new MailAddress(credential.User);

            _email.To.Add(recipient);

            _email.Body = message;
            _email.Subject = subject;
            _email.IsBodyHtml = true;

            _client = new SmtpClient(credential.Server, credential.Port);

            _client.EnableSsl = credential.SSL;
            _client.Credentials = new NetworkCredential(credential.User, credential.Password);
        }
    }
}
