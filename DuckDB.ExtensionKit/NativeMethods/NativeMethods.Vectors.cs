using DuckDB.ExtensionKit.NativeObjects;

namespace DuckDB.ExtensionKit.NativeMethods;

public static partial class NativeMethods
{
    internal static unsafe class Vectors
    {
        internal static DuckDBLogicalType DuckDBVectorGetColumnType(IntPtr vector) => new(Api.duckdb_vector_get_column_type(vector));

        internal static void* DuckDBVectorGetData(IntPtr vector) => Api.duckdb_vector_get_data(vector);

        internal static ulong* DuckDBVectorGetValidity(IntPtr vector) => Api.duckdb_vector_get_validity(vector);

        internal static void DuckDBVectorEnsureValidityWritable(IntPtr vector) => Api.duckdb_vector_ensure_validity_writable(vector);

        internal static void DuckDBVectorAssignStringElement(IntPtr vector, ulong index, byte* value) => Api.duckdb_vector_assign_string_element(vector, index, value);

        internal static void DuckDBVectorAssignStringElementLength(IntPtr vector, ulong index, byte* value, ulong length) => Api.duckdb_vector_assign_string_element_len(vector, index, value, length);

        internal static IntPtr DuckDBListVectorGetChild(IntPtr vector) => Api.duckdb_list_vector_get_child(vector);

        internal static ulong DuckDBListVectorGetSize(IntPtr vector) => Api.duckdb_list_vector_get_size(vector);

        internal static DuckDBState DuckDBListVectorSetSize(IntPtr vector, ulong size) => Api.duckdb_list_vector_set_size(vector, size);

        internal static DuckDBState DuckDBListVectorReserve(IntPtr vector, ulong capacity) => Api.duckdb_list_vector_reserve(vector, capacity);

        internal static IntPtr DuckDBArrayVectorGetChild(IntPtr vector) => Api.duckdb_array_vector_get_child(vector);

        internal static IntPtr DuckDBStructVectorGetChild(IntPtr vector, ulong index) => Api.duckdb_struct_vector_get_child(vector, index);
    }
}
