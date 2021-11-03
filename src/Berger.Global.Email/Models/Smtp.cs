using System;

namespace Berger.Global.Email.Models
{
    public class Smtp
    {
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