using MediatR;
using System.Threading;
using System.Threading.Tasks;
using berger.global.domain.Models;
using berger.global.domain.Requests;
using System.Collections.Generic;

namespace berger.global.domain.Queries
{
    public class CredentialQueryHandler : IRequestHandler<CredentialRequest.Query.Get, List<Credential>>,IRequestHandler<CredentialRequest.Query.GetByID, Credential>,IRequestHandler<CredentialRequest.Query.GetByTenantID, Credential>
    {
        public async Task<List<Credential>> Handle(CredentialRequest.Query.Get request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return request.Credentials;
            });
        }

        public async Task<Credential> Handle(CredentialRequest.Query.GetByID request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var credentials = request.Credentials;

                return credentials.Find(c => c.ID == request.ID);
            });
        }

        public async Task<Credential> Handle(CredentialRequest.Query.GetByTenantID request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var credentials = request.Credentials;

                return credentials.Find(c => c.TenantID == request.TenantID);
            });
        }
    }
}
