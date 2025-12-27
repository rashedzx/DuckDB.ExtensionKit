namespace DuckDB.ExtensionKit.Native;

public interface IDuckDBValueReader
{
    bool IsNull();
    T GetValue<T>();
}