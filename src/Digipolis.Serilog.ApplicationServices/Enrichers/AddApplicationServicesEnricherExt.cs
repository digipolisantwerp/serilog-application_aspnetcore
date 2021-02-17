using System;
using Digipolis.Serilog.Enrichers;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;

namespace Digipolis.Serilog
{
    public static class AddApplicationServicesEnricherExt
    {
        [Obsolete("This package is obsolete")]
        public static SerilogExtensionsOptions AddApplicationServicesEnricher(this SerilogExtensionsOptions options)
        {
            options.ApplicationServices.AddSingleton<ILogEventEnricher, ApplicationServicesEnricher>();
            return options;
        }
    }
}
