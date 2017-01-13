using System;
using Digipolis.ApplicationServices;
using Digipolis.Serilog.ApplicationEnrichment;
using Serilog.Core;
using Serilog.Events;

namespace Digipolis.Serilog
{
    public class ApplicationContextEnricher : ILogEventEnricher
    {
        public ApplicationContextEnricher(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        private readonly IApplicationContext _applicationContext;

        private LogEventProperty _applicationId;
        private LogEventProperty _applicationName;
        private LogEventProperty _applicationInstanceId;
        private LogEventProperty _applicationInstanceName;
        private LogEventProperty _applicationVersion;

        private const string COMPONENTKEY = "SourceContext";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if ( _applicationId == null ) InitProperties(propertyFactory);

            logEvent.AddPropertyIfAbsent(_applicationId);
            logEvent.AddPropertyIfAbsent(_applicationName);
            logEvent.AddPropertyIfAbsent(_applicationInstanceId);
            logEvent.AddPropertyIfAbsent(_applicationInstanceName);
            logEvent.AddPropertyIfAbsent(_applicationVersion);

            if ( logEvent.Properties.ContainsKey(COMPONENTKEY) )
            {
                var sourceContext = logEvent.Properties[COMPONENTKEY];
                var idProp = new LogEventProperty(ApplicationLoggingProperties.ApplicationComponentId, sourceContext);
                var nameProp = new LogEventProperty(ApplicationLoggingProperties.ApplicationComponentName, sourceContext);
                logEvent.AddOrUpdateProperty(idProp);
                logEvent.AddOrUpdateProperty(nameProp);
            }

            // ToDo (SVB) : only when configured
            //logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("LoggingProperties.ApplicationStackTrace", Environment.StackTrace));
        }

        private void InitProperties(ILogEventPropertyFactory propertyFactory)
        {
            _applicationId = propertyFactory.CreateProperty(ApplicationLoggingProperties.ApplicationId, _applicationContext.ApplicationId ?? ApplicationLoggingProperties.NullValue);
            _applicationName = propertyFactory.CreateProperty(ApplicationLoggingProperties.ApplicationName, _applicationContext.ApplicationName ?? ApplicationLoggingProperties.NullValue);
            _applicationInstanceId = propertyFactory.CreateProperty(ApplicationLoggingProperties.ApplicationInstanceId, _applicationContext.InstanceId ?? ApplicationLoggingProperties.NullValue);
            _applicationInstanceName = propertyFactory.CreateProperty(ApplicationLoggingProperties.ApplicationInstanceName, _applicationContext.InstanceName ?? ApplicationLoggingProperties.NullValue);
            _applicationVersion = propertyFactory.CreateProperty(ApplicationLoggingProperties.ApplicationVersion, _applicationContext.ApplicationVersion ?? ApplicationLoggingProperties.NullValue);
        }
    }
}
