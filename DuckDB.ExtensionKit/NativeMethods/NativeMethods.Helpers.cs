namespace DuckDB.ExtensionKit.NativeMethods;

public static partial class NativeMethods
{
    internal static unsafe class Helpers
    {
        internal static void DuckDBFree(byte* ptr) => Api.duckdb_free(ptr);

        internal static ulong DuckDBVectorSize() => Api.duckdb_vector_size();
    }
}
