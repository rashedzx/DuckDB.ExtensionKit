using DuckDB.ExtensionKit.Extensions;
using DuckDB.ExtensionKit.Native;

namespace DuckDB.ExtensionKit.DataChunk.Writer;

internal sealed unsafe class GuidVectorDataWriter(IntPtr vector, void* vectorData, DuckDBType columnType) : VectorDataWriterBase(vector, vectorData, columnType)
{
    internal override bool AppendGuid(Guid value, ulong rowIndex) => AppendValueInternal(value.ToHugeInt(), rowIndex);
}