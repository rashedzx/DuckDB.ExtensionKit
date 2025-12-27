using System.Collections;

namespace DuckDB.ExtensionKit.TableFunctions;

public record TableFunction(IReadOnlyList<ColumnInfo> Columns, IEnumerable Data);