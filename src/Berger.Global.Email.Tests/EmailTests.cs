using NUnit.Framework;
using Berger.Global.Email.Models;
using Berger.Global.Body.Services;

namespace Berger.Global.Email.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldSendSimpleMail()
        {
            var sender = new Sender();

            var message = CreateTextMessage("recipient@email.com");

            var smtp = CreateSmtp("sender@email.com", "secret", "smtp.server");

            sender.Send(message, smtp, "test@email.com");

            Assert.Pass();
        }

        private Smtp CreateSmtp(string userEmail, string password, string host)
        {
            return new Smtp
            {
                User = userEmail,
                Password = password,
                Host = host,
                Port = 587,
                EnableSsl = true
            };
        }
        private Message CreateTextMessage(string recipient, string subject = "", string body = "")
        {
            return new Message
            {
                Recipient = recipient,
                Subject = subject,
                Body = body,
                MessageType = MessageType.Text
            };
        }
    }
}