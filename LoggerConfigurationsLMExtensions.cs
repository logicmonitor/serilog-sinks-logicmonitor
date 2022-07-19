using Serilog.Configuration;
using Serilog.Events;
using configuration = LogicMonitor.DataSDK.Configuration;
using LogicMonitor.DataSDK.Model;
using Serilog.Sinks.LogicMonitor;

namespace Serilog
{
    public static class LoggerConfigurationLMExtensions
    {
        public static LoggerConfiguration LogicMonitor(
            this LoggerSinkConfiguration loggerSinkConfiguration,
            configuration configuration = null,
            Resource resource = null,
            bool batch = true,
            int interval = 10,
            LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum
            )
        {
            var lmSink = new LogicmonitorSink(configuration, resource, batch, interval);
            return loggerSinkConfiguration.Sink(lmSink, restrictedToMinimumLevel);
        }
    }
}