using System;
using System.Collections.Generic;

namespace berger.global.application.ViewModels
{
    public class EmailViewModel
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid TenantID { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Template { get; set; }
        public string Recipient { get; set; }
        public List<KeyValuePair<string, string>> Data { get; set; }
        #endregion
    }
}
