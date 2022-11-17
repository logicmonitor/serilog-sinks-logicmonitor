# Serilog.Sinks.LogicMonitor

A Serilog sink that send events and logs straight away to LogicMonitor.
This Package Uses LogicMonitor.DataSDK to send logs.

Export the following environment variable.

 System property   |      Environment variable      |  Description |
|----------|-------------|:------|
| `Configration.company` |  `LM_COMPANY` |  Account name (Company Name) is your organization name |
| `Configration.AccessID` |  `LM_ACCESS_ID` |  Access id while using LMv1 authentication. (Not needed while using Bearer API )  |
| `Configration.AccessKey` |  `LM_ACCESS_KEY` |    Access key while using LMv1 authentication. (Not needed while using Bearer API ) |

```csharp
using (var log = new LoggerConfiguration()
    .WriteTo.LogicMonitor()
    .CreateLogger())
{    
    // An example
    log.Information("My Log to LogicMonitor");
}
```

or 

```csharp
//Note.: Object of 'LogicMonitor.DataSDK.Configuration' class and not 'Serilog.Configuration'
Configuration configuration = new Configuration(company: "YourCompanyName", accessID: "LM_ACCESS_ID", accessKey: "LM_ACCESS_ID");
using (var log = new LoggerConfiguration()
    .WriteTo.LogicMonitor(configuration)
    .CreateLogger())
{    
    // An example
    log.Information("My Log to LogicMonitor");
}
```

