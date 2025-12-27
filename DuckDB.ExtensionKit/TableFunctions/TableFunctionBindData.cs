using System.Collections;

namespace DuckDB.ExtensionKit.TableFunctions;

class TableFunctionBindData(IReadOnlyList<ColumnInfo> columns, IEnumerator dataEnumerator) : IDisposable
{
    public IReadOnlyList<ColumnInfo> Columns { get; } = columns;
    public IEnumerator DataEnumerator { get; } = dataEnumerator;

    public void Dispose()
    {
        (DataEnumerator as IDisposable)?.Dispose();
    }
}