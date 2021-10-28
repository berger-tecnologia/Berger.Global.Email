using MediatR;
using berger.global.domain.Models;
using berger.global.email.infra.Services;
using berger.global.domain.Queries;
using berger.global.domain.Requests;
using berger.global.email.infra.Interfaces;
using System.Collections.Generic;
using berger.global.application.Services;
using berger.global.application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace berger.global.email.infra.ioc
{
    public static class Bootstrap
    {
        public static void Register(this IServiceCollection services)
        {
            // Application Services
            services.AddScoped<IEmailApplication, EmailApplication>();

            // Infrastructure Services
            services.AddScoped<IEmailInfra, EmailInfra>();
            services.AddScoped<ICredentialInfra, CredentialInfra>();

            // Mediators
            services.AddScoped<IRequestHandler<CredentialRequest.Query.GetByID, Credential>, CredentialQueryHandler>();
            services.AddScoped<IRequestHandler<CredentialRequest.Query.Get, List<Credential>>, CredentialQueryHandler>();
            services.AddScoped<IRequestHandler<CredentialRequest.Query.GetByTenantID, Credential>, CredentialQueryHandler>();
        }
    }
}