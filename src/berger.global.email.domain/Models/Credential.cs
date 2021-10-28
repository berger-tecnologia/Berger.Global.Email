using System;

namespace berger.global.domain.Models
{
    public class Credential
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid TenantID { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Alias { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        #endregion
    }
}