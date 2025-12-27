using DuckDB.ExtensionKit.Native;
using System.Numerics;

namespace DuckDB.ExtensionKit.DataChunk.Writer;

internal sealed unsafe class NumericVectorDataWriter(IntPtr vector, void* vectorData, DuckDBType columnType) : VectorDataWriterBase(vector, vectorData, columnType)
{
    internal override bool AppendNumeric<T>(T value, ulong rowIndex) => AppendValueInternal(value, rowIndex);

    internal override bool AppendBigInteger(BigInteger value, ulong rowIndex) => AppendValueInternal(new DuckDBHugeInt(value), rowIndex);
}
