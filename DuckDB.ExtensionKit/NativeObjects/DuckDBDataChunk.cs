using Microsoft.Win32.SafeHandles;

namespace DuckDB.ExtensionKit.NativeObjects;

public class DuckDBDataChunk : SafeHandleZeroOrMinusOneIsInvalid
{
    public DuckDBDataChunk() : base(true)
    {
    }

    public DuckDBDataChunk(IntPtr chunk) : base(false)
    {
        SetHandle(chunk);
    }

    protected override bool ReleaseHandle()
    {
        NativeMethods.NativeMethods.DataChunks.DuckDBDestroyDataChunk(handle);
        return true;
    }
}