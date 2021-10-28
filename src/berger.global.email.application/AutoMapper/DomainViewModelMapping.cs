using AutoMapper;
using berger.global.domain.Models;
using berger.global.application.ViewModels;

namespace berger.global.application.AutoMapper
{
    public class DomainViewModelMapping : Profile
    {
        public DomainViewModelMapping()
        {
            CreateMap<Email, EmailViewModel>();
        }
    }
}