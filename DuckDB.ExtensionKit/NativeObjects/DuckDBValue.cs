using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.Win32.SafeHandles;

namespace DuckDB.ExtensionKit.NativeObjects;

public class DuckDBValue : SafeHandleZeroOrMinusOneIsInvalid, IDuckDBValueReader
{
    private DuckDBValue[] childValues = [];

    public DuckDBValue(IntPtr value) : base(true) => SetHandle(value);

    protected override bool ReleaseHandle()
    {
        foreach (var value in childValues)
        {
            value.Dispose();
        }

        NativeMethods.NativeMethods.Value.DuckDBDestroyValue(handle);
        return true;
    }

    internal void SetChildValues(DuckDBValue[] values)
    {
        childValues = values;
    }

    public bool IsNull() => NativeMethods.NativeMethods.Value.DuckDBIsNullValue(this);

    public T GetValue<T>()
    {
        var logicalType = NativeMethods.NativeMethods.Value.DuckDBGetValueType(this);

        //Logical type is part of the duckdb_value object and it shouldn't be released separately
        //It will get released when the duckdb_value object is destroyed below.
        var add = false;
        logicalType.DangerousAddRef(ref add);

        var duckDBType = NativeMethods.NativeMethods.LogicalType.DuckDBGetTypeId(logicalType);

        return duckDBType switch
        {
            DuckDBType.Boolean => Cast(NativeMethods.NativeMethods.Value.DuckDBGetBool(this)),

            DuckDBType.TinyInt => Cast(NativeMethods.NativeMethods.Value.DuckDBGetInt8(this)),
            DuckDBType.SmallInt => Cast(NativeMethods.NativeMethods.Value.DuckDBGetInt16(this)),
            DuckDBType.Integer => Cast(NativeMethods.NativeMethods.Value.DuckDBGetInt32(this)),
            DuckDBType.BigInt => Cast(NativeMethods.NativeMethods.Value.DuckDBGetInt64(this)),

            DuckDBType.UnsignedTinyInt => Cast(NativeMethods.NativeMethods.Value.DuckDBGetUInt8(this)),
            DuckDBType.UnsignedSmallInt => Cast(NativeMethods.NativeMethods.Value.DuckDBGetUInt16(this)),
            DuckDBType.UnsignedInteger => Cast(NativeMethods.NativeMethods.Value.DuckDBGetUInt32(this)),
            DuckDBType.UnsignedBigInt => Cast(NativeMethods.NativeMethods.Value.DuckDBGetUInt64(this)),

            DuckDBType.Float => Cast(NativeMethods.NativeMethods.Value.DuckDBGetFloat(this)),
            DuckDBType.Double => Cast(NativeMethods.NativeMethods.Value.DuckDBGetDouble(this)),

            DuckDBType.Decimal => Cast(decimal.Parse(NativeMethods.NativeMethods.Value.DuckDBGetVarchar(this), NumberStyles.Any, CultureInfo.InvariantCulture)),

            DuckDBType.Uuid => Cast(new Guid(NativeMethods.NativeMethods.Value.DuckDBGetVarchar(this))),

            DuckDBType.HugeInt => Cast(NativeMethods.NativeMethods.Value.DuckDBGetHugeInt(this).ToBigInteger()),
            DuckDBType.UnsignedHugeInt => Cast(NativeMethods.NativeMethods.Value.DuckDBGetUHugeInt(this).ToBigInteger()),

            DuckDBType.Varchar => Cast(NativeMethods.NativeMethods.Value.DuckDBGetVarchar(this)),

            //DuckDBType.Date => Cast((DateOnly)DuckDBDateOnly.FromDuckDBDate(NativeMethods.Value.DuckDBGetDate(this))),
            //DuckDBType.Time => Cast((TimeOnly)NativeMethods.DateTimeHelpers.DuckDBFromTime(NativeMethods.Value.DuckDBGetTime(this))),

            //DuckDBType.TimeTz => expr,
            //DuckDBType.Interval => Cast((TimeSpan)NativeMethods.Value.DuckDBGetInterval(this)),
            //DuckDBType.Timestamp => Cast(DuckDBTimestamp.FromDuckDBTimestampStruct(NativeMethods.Value.DuckDBGetTimestamp(this)).ToDateTime()),
            //DuckDBType.TimestampS => expr,
            //DuckDBType.TimestampMs => expr,
            //DuckDBType.TimestampNs => expr,
            //DuckDBType.TimestampTz => expr,
            _ => throw new NotImplementedException($"Cannot read value of type {typeof(T).FullName}")
        };

        T Cast<TSource>(TSource value) => Unsafe.As<TSource, T>(ref value);
    }
}