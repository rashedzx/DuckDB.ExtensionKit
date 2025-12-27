namespace DuckDB.ExtensionKit.Common;

internal static class DuckDBGlobalData
{
    public static ulong VectorSize { get; } = NativeMethods.NativeMethods.Helpers.DuckDBVectorSize();
}