using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Email
{
    public class Message : IMessage<MessageType>
    {
        #region Properties
        public MessageType MessageType { get; private set; }
        public Guid? PhoneID { get; set; }
        public Guid PlatformID { get; set; }
        public Guid? CultureID { get; set; }
        public Guid InteractionID { get; set; }
        public string Body { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        public string TemplateUrl { get; set; } = string.Empty;
        public List<KeyValuePair<string, string>> Data { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool Simulation { get; set; } = false;        
        #endregion
    }
}