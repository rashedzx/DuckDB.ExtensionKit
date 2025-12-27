namespace DuckDB.ExtensionKit.NativeObjects;

public class DuckDBConnection(IntPtr connection)
{
    public IntPtr Connection { get; } = connection;
}