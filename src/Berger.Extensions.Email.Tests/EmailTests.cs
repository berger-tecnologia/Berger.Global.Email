using NUnit.Framework;

namespace Berger.Extensions.Email.Tests
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
            return new Smtp(userEmail, password, host, 587, true);
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