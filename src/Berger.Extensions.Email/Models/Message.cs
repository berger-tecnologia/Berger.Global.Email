namespace Berger.Extensions.Email
{
    public class Message
    {
        #region Properties
        public string Body { get; set; }
        public string Subject { get; set; }
        public string Recipient { get; set; }
        public MessageType MessageType { get; set; }
        public string TemplateUrl { get; set; }
        public List<KeyValuePair<string, string>> Data { get; set; }
        #endregion
    }
}