using System;
using MediatR;
using berger.global.domain.Models;
using System.Collections.Generic;

namespace berger.global.domain.Requests
{
    public class CredentialRequest
    {
        public class Query
        {
            public record Get(List<Credential> Credentials): IRequest<List<Credential>>;
            public record GetByID(List<Credential> Credentials, Guid ID): IRequest<Credential>;
            public record GetByTenantID(List<Credential> Credentials, Guid TenantID): IRequest<Credential>;
        }
    }
}
