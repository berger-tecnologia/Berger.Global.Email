using berger.global.domain.Models;

namespace berger.global.email.infra.Interfaces
{
    public interface IEmailInfra
    {
        void Send(Email email, Credential credential);
        void Send(Email email, Credential credential, string alias);
    }
}