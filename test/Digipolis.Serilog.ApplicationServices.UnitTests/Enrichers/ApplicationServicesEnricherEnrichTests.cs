using System;
using System.Collections.Generic;
using Digipolis.ApplicationServices;
using Digipolis.Serilog.Enrichers;
using Serilog.Events;
using Serilog.Parsing;
using Xunit;

namespace Digipolis.Serilog.ApplicationServices.UnitTests.Enrichers
{
    public class ApplicationServicesEnricherEnrichTests
    {
        [Fact]
        void ApplicationIdIsAddedToLogEvent()
        {
            var appContext = new ApplicationContext("appId", "appName");
            var enricher = new ApplicationServicesEnricher(appContext);
            var logEvent = CreateLogEvent();
            
            enricher.Enrich(logEvent, null);

            Assert.Contains(ApplicationLoggingProperties.ApplicationId, logEvent.Properties.Keys);
        }

        [Fact]
        void ApplicationNameIsAddedToLogEvent()
        {
            var appContext = new ApplicationContext("appId", "appName");
            var enricher = new ApplicationServicesEnricher(appContext);
            var logEvent = CreateLogEvent();

            enricher.Enrich(logEvent, null);

            Assert.Contains(ApplicationLoggingProperties.ApplicationName, logEvent.Properties.Keys);
        }

        [Fact]
        void ApplicationInstanceIdIsAddedToLogEvent()
        {
            var appContext = new ApplicationContext("appId", "appName");
            var enricher = new ApplicationServicesEnricher(appContext);
            var logEvent = CreateLogEvent();

            enricher.Enrich(logEvent, null);

            Assert.Contains(ApplicationLoggingProperties.ApplicationInstanceId, logEvent.Properties.Keys);
        }

        [Fact]
        void ApplicationInstanceNameIsAddedToLogEvent()
        {
            var appContext = new ApplicationContext("appId", "appName");
            var enricher = new ApplicationServicesEnricher(appContext);
            var logEvent = CreateLogEvent();

            enricher.Enrich(logEvent, null);

            Assert.Contains(ApplicationLoggingProperties.ApplicationInstanceName, logEvent.Properties.Keys);
        }

        [Fact]
        void ProcessIdIsAddedToLogEvent()
        {
            var appContext = new ApplicationContext("appId", "appName");
            var enricher = new ApplicationServicesEnricher(appContext);
            var logEvent = CreateLogEvent();

            enricher.Enrich(logEvent, null);

            Assert.Contains(ApplicationLoggingProperties.ProcessId, logEvent.Properties.Keys);
        }

        [Fact]
        void ThreadIdIsAddedToLogEvent()
        {
            var appContext = new ApplicationContext("appId", "appName");
            var enricher = new ApplicationServicesEnricher(appContext);
            var logEvent = CreateLogEvent();

            enricher.Enrich(logEvent, null);

            Assert.Contains(ApplicationLoggingProperties.ThreadId, logEvent.Properties.Keys);
        }

        [Fact]
        void MachineNameIsAddedToLogEvent()
        {
            var appContext = new ApplicationContext("appId", "appName");
            var enricher = new ApplicationServicesEnricher(appContext);
            var logEvent = CreateLogEvent();

            enricher.Enrich(logEvent, null);

            Assert.Contains(ApplicationLoggingProperties.MachineName, logEvent.Properties.Keys);
        }

        [Fact]
        void ApplicationVersionIsAddedToLogEvent()
        {
            var appContext = new ApplicationContext("appId", "appName");
            var enricher = new ApplicationServicesEnricher(appContext);
            var logEvent = CreateLogEvent();

            enricher.Enrich(logEvent, null);

            Assert.Contains(ApplicationLoggingProperties.ApplicationVersion, logEvent.Properties.Keys);
        }

        private LogEvent CreateLogEvent()
        {
            var tokens = new List<MessageTemplateToken>();
            var properties = new List<LogEventProperty>();
            var logEvent = new LogEvent(DateTime.Now, LogEventLevel.Information, null, new MessageTemplate(tokens), properties);
            return logEvent;
        }
    }
}
