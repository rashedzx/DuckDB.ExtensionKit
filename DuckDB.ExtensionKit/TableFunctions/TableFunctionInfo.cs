using DuckDB.ExtensionKit.DataChunk.Writer;
using DuckDB.ExtensionKit.Native;

namespace DuckDB.ExtensionKit.TableFunctions;

class TableFunctionInfo(Func<IReadOnlyList<IDuckDBValueReader>, TableFunction> bind, Action<object?, VectorDataWriterBase[], ulong> mapper)
{
    public Func<IReadOnlyList<IDuckDBValueReader>, TableFunction> Bind { get; } = bind;
    public Action<object?, VectorDataWriterBase[], ulong> Mapper { get; } = mapper;
}