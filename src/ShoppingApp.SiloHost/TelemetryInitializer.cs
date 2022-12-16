using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System.Reflection;
using ShoppingApp.Common;

namespace ShoppingApp.SiloHost;

internal class TelemetryInitializer : ITelemetryInitializer
{
    private readonly string _roleName;

    public TelemetryInitializer()
    {
        _roleName = "ShoppingApp.SiloHost";
    }

    public void Initialize(ITelemetry telemetry)
    {
        telemetry.Context.Cloud.RoleName = _roleName;
  
        var assembly = Assembly.GetExecutingAssembly();
        var version = AppInfo.RetrieveInformationalVersion(assembly);
        telemetry.Context.Component.Version = version;
        telemetry.Context.Cloud.RoleInstance = $"{_roleName} {version}";
    }
}