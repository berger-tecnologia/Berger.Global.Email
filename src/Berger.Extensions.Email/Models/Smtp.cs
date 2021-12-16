namespace Berger.Extensions.Email.Models
{
    public class Smtp
    {
        #region Constructors
        public Smtp()
        {
        }
        public Smtp(string user, string password, string host, int port, bool ssl = true)
        {
            User = user;
            Password = password;
            Host = host;
            Port = port;
            EnableSsl = ssl;
        }
        public Smtp(string user, string password, string alias, string host, int port, bool ssl = true)
        {
            User = user;
            Password = password;
            Alias = alias;
            Host = host;
            Port = port;
            EnableSsl = ssl;
        }
        #endregion

        #region Properties
        public string User { get; set; }
        public string Password { get; set; }
        public string Alias { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        #endregion
    }
}