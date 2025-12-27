using DuckDB.ExtensionKit.DataChunk.Reader;
using DuckDB.ExtensionKit.DataChunk.Writer;
using DuckDB.ExtensionKit.NativeObjects;

namespace DuckDB.ExtensionKit;

class ScalarFunctionInfo(DuckDBLogicalType returnType, Action<VectorDataReaderBase[], VectorDataWriterBase, ulong> action) : IDisposable
{
    public DuckDBLogicalType ReturnType { get; } = returnType;
    public Action<VectorDataReaderBase[], VectorDataWriterBase, ulong> Action { get; private set; } = action;

    public void Dispose()
    {
        ReturnType.Dispose();
    }
}
