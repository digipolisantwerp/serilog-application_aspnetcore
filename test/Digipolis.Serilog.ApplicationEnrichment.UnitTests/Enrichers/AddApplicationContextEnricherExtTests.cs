using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;
using Xunit;

namespace Digipolis.Serilog.ApplicationEnrichment.UnitTests.Enrichers
{
    public class AddApplicationContextEnricherExtTests
    {
        [Fact]
        void ApplicationContextEnricherIsAdded()
        {
            var options = new SerilogExtensionsOptions();
            options.AddApplicationContextEnricher();
            Assert.Collection(options.EnricherTypes, item => Assert.Equal(typeof(ApplicationContextEnricher), item));
        }

        [Fact]
        void ApplicationContextEnricherIsRegisteredAsSingleton()
        {
            var services = new ServiceCollection();
            services.AddSerilogExtensions(options => {
                options.MessageVersion = "1";
                options.AddApplicationContextEnricher();
            });

            var registrations = services.Where(sd => sd.ServiceType == typeof(ILogEventEnricher) &&
                                                     sd.ImplementationType == typeof(ApplicationContextEnricher))
                                                     .ToArray();

            Assert.Equal(1, registrations.Count());
            Assert.Equal(ServiceLifetime.Singleton, registrations[0].Lifetime);
        }
    }
}
