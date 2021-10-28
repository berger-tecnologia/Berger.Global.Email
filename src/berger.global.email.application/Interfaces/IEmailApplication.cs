using System.Threading.Tasks;
using berger.global.application.ViewModels;

namespace berger.global.application.Interfaces
{
    public interface IEmailApplication
    {
        Task<dynamic> Send(EmailViewModel email);
    }
}