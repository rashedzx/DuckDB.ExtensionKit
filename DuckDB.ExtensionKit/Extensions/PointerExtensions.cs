using System.Runtime.InteropServices;
using System.Text;

namespace DuckDB.ExtensionKit.Extensions;

internal static class PointerExtensions
{
    internal static unsafe string ToManagedString(byte* unmanagedString, bool freeWhenCopied = true, int? length = null)
    {
        var span = length.HasValue ? new ReadOnlySpan<byte>(unmanagedString, length.Value) : MemoryMarshal.CreateReadOnlySpanFromNullTerminated(unmanagedString);

        var result = Encoding.UTF8.GetString(span);

        if (freeWhenCopied)
        {
            NativeMethods.NativeMethods.Helpers.DuckDBFree(unmanagedString);
        }

        return result;
    }
}