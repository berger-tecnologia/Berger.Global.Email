using System;
using berger.global.domain.Models;
using berger.global.email.infra.Interfaces;
using System.Collections.Generic;

namespace berger.global.email.infra.Services
{
    public class CredentialInfra : ICredentialInfra
    {
        public List<Credential> Get()
        {
            var credentials = new List<Credential>
            {
                new Credential
                {
                    ID = Guid.Parse("bc39af87-71be-4624-8f76-2d7c006fe8d6"),
                    TenantID = Guid.Parse("bc39af87-71be-4624-8f76-2d7c006fe8d6"),
                    User = "testeparaenvioporapi@gmail.com",
                    Password = "Teste1234",
                    Alias = "Gmail",
                    Server = "smtp.gmail.com",
                    Port = 587,
                    SSL = true
                },

                new Credential
                {
                    ID = Guid.Parse("bc39af00-71be-4624-8f76-2d7c006fe8d6"),
                    TenantID = Guid.Parse("bc39af87-71be-4624-8f76-2d7c006fe8d6"),
                    User = "LOREMIPSUM@gmail.com",
                    Password = "DfsalJH",
                    Alias = "Outlook",
                    Server = "smtp-mail.outlook.com",
                    Port = 587,
                    SSL = true
                }
            };

            return credentials;
        }
    }
}
