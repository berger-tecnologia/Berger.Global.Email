using AutoMapper;
using berger.global.domain.Models;
using berger.global.application.ViewModels;

namespace berger.global.application.AutoMapper
{
    public class ViewModelDomainMapping : Profile
    {
        public ViewModelDomainMapping()
        {
            CreateMap<EmailViewModel, Email>();
        }
    }
}