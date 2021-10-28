using System;
using AutoMapper;
using berger.global.domain.Models;
using berger.global.email.infra.Interfaces;
using berger.global.application.ViewModels;
using berger.global.application.Interfaces;
using MediatR;
using berger.global.domain.Requests;
using System.Threading.Tasks;

namespace berger.global.application.Services
{
    public class EmailApplication : IEmailApplication
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IEmailInfra _infra;
        private readonly IMediator _mediator;
        private readonly ICredentialInfra _credentials;
        #endregion

        #region Constructors
        public EmailApplication(IEmailInfra infra, IMapper mapper, IMediator mediator, ICredentialInfra credentials)
        {
            _infra = infra;
            _mapper = mapper;
            _mediator = mediator;
            _credentials = credentials;
        }
        #endregion

        #region Methods
        public async Task<dynamic> Send(EmailViewModel model)
        {
            try
            {
                var credentials = _credentials.Get();

                var credential = await _mediator.Send(new CredentialRequest.Query.GetByTenantID(credentials, model.TenantID));

                var email = _mapper.Map(model, new Email());

                _infra.Send(email, credential, "Website");

                return new { Success = $"Your email was successfully sent to {email.Recipient}" };
            }
            catch (Exception e)
            {
                dynamic error = new { Error = e.Message };

                return error;
            }
        }
        #endregion
    }
}