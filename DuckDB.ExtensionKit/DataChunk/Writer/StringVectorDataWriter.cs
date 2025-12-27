namespace DuckDB.ExtensionKit.DataChunk.Writer;

internal sealed unsafe class StringVectorDataWriter(IntPtr vector, void* vectorData, DuckDBType columnType) : VectorDataWriterBase(vector, vectorData, columnType)
{
    internal override bool AppendString(string value, ulong rowIndex)
    {
        fixed (byte* valuePtr = System.Text.Encoding.UTF8.GetBytes(value + "\0"))
        {
            NativeMethods.NativeMethods.Vectors.DuckDBVectorAssignStringElement(Vector, rowIndex, valuePtr);
        }
        return true;
    }

    internal override bool AppendBlob(byte* value, int length, ulong rowIndex)
    {
        NativeMethods.NativeMethods.Vectors.DuckDBVectorAssignStringElementLength(Vector, rowIndex, value, (ulong)length);
        return true;
    }
}
