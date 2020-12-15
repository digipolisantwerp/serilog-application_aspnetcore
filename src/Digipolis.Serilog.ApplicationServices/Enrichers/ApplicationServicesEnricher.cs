using System;
using Digipolis.ApplicationServices;
using Digipolis.Serilog.ApplicationServices;
using Serilog.Core;
using Serilog.Events;

namespace Digipolis.Serilog.Enrichers
{
    public class ApplicationServicesEnricher : ILogEventEnricher
    {
        public ApplicationServicesEnricher(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        private readonly IApplicationContext _applicationContext;

        private LogEventProperty _applicationId;
        private LogEventProperty _applicationName;
        private LogEventProperty _applicationInstanceId;
        private LogEventProperty _applicationInstanceName;
        private LogEventProperty _applicationVersion;
        private LogEventProperty _machineName;


        private const string COMPONENTKEY = "SourceContext";

        [Obsolete("This package is obsolete")]
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if ( _applicationId == null ) InitProperties(propertyFactory);

            logEvent.AddPropertyIfAbsent(_applicationId);
            logEvent.AddPropertyIfAbsent(_applicationName);
            logEvent.AddPropertyIfAbsent(_applicationInstanceId);
            logEvent.AddPropertyIfAbsent(_applicationInstanceName);
            logEvent.AddPropertyIfAbsent(_applicationVersion);
            logEvent.AddPropertyIfAbsent(_machineName);

            if ( logEvent.Properties.ContainsKey(COMPONENTKEY) )
            {
                var sourceContext = logEvent.Properties[COMPONENTKEY];
                var idProp = new LogEventProperty(ApplicationLoggingProperties.ApplicationComponentId, sourceContext);
                var nameProp = new LogEventProperty(ApplicationLoggingProperties.ApplicationComponentName, sourceContext);
                logEvent.AddOrUpdateProperty(idProp);
                logEvent.AddOrUpdateProperty(nameProp);
            }

            var processIdProp = new LogEventProperty(ApplicationLoggingProperties.ProcessId, new ScalarValue(System.Diagnostics.Process.GetCurrentProcess().Id));
            var threadIdProp = new LogEventProperty(ApplicationLoggingProperties.ThreadId, new ScalarValue(System.Environment.CurrentManagedThreadId));
            logEvent.AddOrUpdateProperty(processIdProp);
            logEvent.AddOrUpdateProperty(threadIdProp);
        }

        private void InitProperties(ILogEventPropertyFactory propertyFactory)
        {
            _applicationId = new LogEventProperty(ApplicationLoggingProperties.ApplicationId, new ScalarValue(_applicationContext.ApplicationId ?? ApplicationLoggingProperties.NullValue));
            _applicationName = new LogEventProperty(ApplicationLoggingProperties.ApplicationName, new ScalarValue(_applicationContext.ApplicationName ?? ApplicationLoggingProperties.NullValue));
            _applicationInstanceId = new LogEventProperty(ApplicationLoggingProperties.ApplicationInstanceId, new ScalarValue(_applicationContext.InstanceId ?? ApplicationLoggingProperties.NullValue));
            _applicationInstanceName = new LogEventProperty(ApplicationLoggingProperties.ApplicationInstanceName, new ScalarValue(_applicationContext.InstanceName ?? ApplicationLoggingProperties.NullValue));
            _applicationVersion = new LogEventProperty(ApplicationLoggingProperties.ApplicationVersion, new ScalarValue(_applicationContext.ApplicationVersion ?? ApplicationLoggingProperties.NullValue));
            _machineName = new LogEventProperty(ApplicationLoggingProperties.MachineName, new ScalarValue(System.Environment.MachineName ?? ApplicationLoggingProperties.NullValue));
        }
    }
}
