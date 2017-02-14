using System;
using System.Linq;
using Digipolis.Serilog.Enrichers;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;
using Xunit;

namespace Digipolis.Serilog.ApplicationServices.UnitTests.Enrichers
{
    public class AddApplicationServicesEnricherExtTests
    {
        [Fact]
        void ApplicationServicesEnricherIsRegisteredAsSingleton()
        {
            var services = new ServiceCollection();
            services.AddSerilogExtensions(options => {
                options.AddApplicationServicesEnricher();
            });

            var registrations = services.Where(sd => sd.ServiceType == typeof(ILogEventEnricher) &&
                                                     sd.ImplementationType == typeof(ApplicationServicesEnricher))
                                                     .ToArray();

            Assert.Equal(1, registrations.Count());
            Assert.Equal(ServiceLifetime.Singleton, registrations[0].Lifetime);
        }
    }
}
