using System;
using System.ComponentModel;

namespace Sandbox.Logging
{
    public interface ILogger
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        void Log(LogLevel logLevel,
                 IFormatProvider formatProvider, Func<LogMessageDelegate, string> getMessage,
                 Exception ex);
    }
}