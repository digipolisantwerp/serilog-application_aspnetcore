using System;

namespace Digipolis.Serilog.ApplicationEnrichment
{
    class ApplicationLoggingProperties
    {
        public const string ApplicationId = "ApplicationId";
        public const string ApplicationName = "ApplicationName";
        public const string ApplicationInstanceId = "ApplicationInstanceId";
        public const string ApplicationInstanceName = "ApplicationInstanceName";
        public const string ApplicationComponentId = "ApplicationComponentId";
        public const string ApplicationComponentName = "ApplicationComponentName";
        public const string ApplicationVersion = "ApplicationVersion";
        public const string ApplicationStackTrace = "ApplicationStacktrace";

        public const string ThreadId = "ApplicationThreadId";
        public const string ProcessId = "ApplicationProcessId";

        public const string MachineName = "EnvironmentMachineName";
        public const string EnvironmentUserName = "EnvironmentUserName";

        public const string NullValue = "null";
    }
}
