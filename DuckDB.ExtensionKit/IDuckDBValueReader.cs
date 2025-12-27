namespace DuckDB.ExtensionKit;

public interface IDuckDBValueReader
{
    bool IsNull();
    T GetValue<T>();
}