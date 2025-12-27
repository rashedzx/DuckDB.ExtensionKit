namespace DuckDB.ExtensionKit.Native;

public class DuckDBConnection(IntPtr connection)
{
    public IntPtr Connection { get; } = connection;
}