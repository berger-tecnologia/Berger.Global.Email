﻿using System;
using System.Collections.Generic;
using Berger.Global.Email.Models;

namespace Berger.Global.Email.Models
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