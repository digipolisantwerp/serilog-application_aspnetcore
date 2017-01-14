using System;

namespace Digipolis.Serilog
{
    public static class AddApplicationContextEnricherExt
    {
        public static SerilogExtensionsOptions AddApplicationContextEnricher(this SerilogExtensionsOptions options)
        {
            options.AddEnricher<ApplicationContextEnricher>();
            return options;
        }
    }
}
