using System;
using Serilog.Events;
using LogicMonitor.DataSDK.Api;
using LogicMonitor.DataSDK.Model;
using LogicMonitor.DataSDK;
using conf = LogicMonitor.DataSDK.Configuration;
using Serilog.Core;

namespace Serilog.Sinks.LogicMonitor
{
    public class LogicmonitorSink : ILogEventSink
    {
        Logs Logs;
        conf Configuration;
        Resource Resource;

        public LogicmonitorSink(conf conf = null, Resource resource = null, bool batch = true, int interval = 10)
        {
            Configuration = conf ??= new conf();
            ApiClient apiClient = new ApiClient(Configuration);
            Resource = resource ??= new Resource();
            Logs = new Logs(batch: batch, interval: interval, apiClient: apiClient);

        }

        /// <summary>
        /// Emit a batch of log events to LogicMonitor platform.
        /// </summary>
        /// <param name="events">The events to emit.</param>
        public void Emit(LogEvent logEvent)
        {
            var response = Logs.SendLogs(message: logEvent.MessageTemplate.Text, resource: Resource);
        }

        

    }
}
