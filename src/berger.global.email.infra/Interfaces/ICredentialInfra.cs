using berger.global.domain.Models;
using System.Collections.Generic;

namespace berger.global.email.infra.Interfaces
{
    public interface ICredentialInfra
    {
        public List<Credential> Get();
    }
}
