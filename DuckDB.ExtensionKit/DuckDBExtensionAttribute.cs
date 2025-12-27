namespace DuckDB.ExtensionKit;

/// <summary>
/// Marks a partial class as a DuckDB extension entry point.
/// The class must contain a static method: <c>static void RegisterFunctions(DuckDBConnection connection)</c>
/// </summary>
/// <remarks>
/// The extension name and DuckDB version are configured via MSBuild properties in the project file:
/// <list type="bullet">
/// <item><c>ExtensionName</c> - The prefix for the native entry point (e.g., "myextension" becomes "myextension_init_c_api")</item>
/// <item><c>DuckDBVersion</c> - The DuckDB API version to target (e.g., "v1.2.0")</item>
/// </list>
/// </remarks>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class DuckDBExtensionAttribute : Attribute;
