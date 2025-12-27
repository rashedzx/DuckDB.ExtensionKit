using DuckDB.ExtensionKit.NativeObjects;

namespace DuckDB.ExtensionKit.NativeMethods;

public static partial class NativeMethods
{
    internal static unsafe class LogicalType
    {
        internal static DuckDBLogicalType DuckDBCreateLogicalType(DuckDBType type)
        {
            var logicalType = Api.duckdb_create_logical_type(type);

            return new DuckDBLogicalType(logicalType);
        }

        internal static DuckDBLogicalType DuckDBCreateDecimalType(byte width, byte scale)
        {
            var type = Api.duckdb_create_decimal_type(width, scale);

            return new DuckDBLogicalType(type);
        }

        internal static DuckDBType DuckDBGetTypeId(DuckDBLogicalType type) => Api.duckdb_get_type_id(type.DangerousGetHandle());

        internal static byte DuckDBDecimalWidth(DuckDBLogicalType type) => Api.duckdb_decimal_width(type.DangerousGetHandle());

        internal static byte DuckDBDecimalScale(DuckDBLogicalType type) => Api.duckdb_decimal_scale(type.DangerousGetHandle());

        internal static DuckDBType DuckDBDecimalInternalType(DuckDBLogicalType type) => Api.duckdb_decimal_internal_type(type.DangerousGetHandle());

        internal static DuckDBLogicalType DuckDBListTypeChildType(DuckDBLogicalType type)
        {
            var childType = Api.duckdb_list_type_child_type(type.DangerousGetHandle());

            return new DuckDBLogicalType(childType);
        }

        internal static DuckDBLogicalType DuckDBArrayTypeChildType(DuckDBLogicalType type)
        {
            var childType = Api.duckdb_array_type_child_type(type.DangerousGetHandle());

            return new DuckDBLogicalType(childType);
        }

        internal static ulong DuckDBArrayVectorGetSize(DuckDBLogicalType type) => Api.duckdb_array_type_array_size(type.DangerousGetHandle());

        internal static DuckDBLogicalType DuckDBMapTypeKeyType(DuckDBLogicalType type)
        {
            var keyType = Api.duckdb_map_type_key_type(type.DangerousGetHandle());

            return new DuckDBLogicalType(keyType);
        }

        internal static DuckDBLogicalType DuckDBMapTypeValueType(DuckDBLogicalType type)
        {
            var valueType = Api.duckdb_map_type_value_type(type.DangerousGetHandle());

            return new DuckDBLogicalType(valueType);
        }

        internal static DuckDBType DuckDBEnumInternalType(DuckDBLogicalType type) => Api.duckdb_enum_internal_type(type.DangerousGetHandle());

        internal static uint DuckDBEnumDictionarySize(DuckDBLogicalType type) => Api.duckdb_enum_dictionary_size(type.DangerousGetHandle());

        internal static byte* DuckDBEnumDictionaryValue(DuckDBLogicalType type, ulong index) => Api.duckdb_enum_dictionary_value(type.DangerousGetHandle(), index);

        internal static void DuckDBDestroyLogicalType(IntPtr type) => Api.duckdb_destroy_logical_type(&type);
    }
}