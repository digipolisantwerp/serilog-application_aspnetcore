using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;
using Xunit;

namespace Digipolis.Serilog.ApplicationServices.UnitTests.Enrichers
{
    public class AddApplicationServicesEnricherExtTests
    {
        [Fact]
        void ApplicationServicesEnricherIsAdded()
        {
            var options = new SerilogExtensionsOptions();
            options.AddApplicationServicesEnricher();
            Assert.Collection(options.EnricherTypes, item => Assert.Equal(typeof(ApplicationServicesEnricher), item));
        }

        [Fact]
        void ApplicationServicesEnricherIsAddedOnlyOnce()
        {
            var options = new SerilogExtensionsOptions();
            options.AddApplicationServicesEnricher();
            options.AddApplicationServicesEnricher();
            Assert.Collection(options.EnricherTypes, item => Assert.Equal(typeof(ApplicationServicesEnricher), item));
        }

        [Fact]
        void ApplicationServicesEnricherIsRegisteredAsSingleton()
        {
            var services = new ServiceCollection();
            services.AddSerilogExtensions(options => {
                options.MessageVersion = "1";
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
