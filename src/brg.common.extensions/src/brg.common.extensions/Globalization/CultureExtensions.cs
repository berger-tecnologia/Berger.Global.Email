using System;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;

namespace brg.common.extensions.Globalization
{
    public static class CultureExtensions
    {
        public static void ConfigureCulture(this IServiceCollection services, string name)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var culture = new CultureInfo(name);

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}