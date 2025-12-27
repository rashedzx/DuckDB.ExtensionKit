using DuckDB.ExtensionKit.Native;
using System.Data.Common;

namespace DuckDB.ExtensionKit;

public class DuckDBException : DbException
{
    public DuckDBErrorType ErrorType { get; }

    internal DuckDBException()
    {
    }

    internal DuckDBException(string message) : base(message)
    {
    }

    internal DuckDBException(string message, DuckDBErrorType errorType) : base(message, (int)errorType)
    {
        ErrorType = errorType;
    }
}