﻿using System;
using System.Linq;

namespace Digipolis.Serilog
{
    public static class AddApplicationServicesEnricherExt
    {
        public static SerilogExtensionsOptions AddApplicationServicesEnricher(this SerilogExtensionsOptions options)
        {
            if ( !options.EnricherTypes.Contains(typeof(ApplicationServicesEnricher)) )
                options.AddEnricher<ApplicationServicesEnricher>();
            return options;
        }
    }
}