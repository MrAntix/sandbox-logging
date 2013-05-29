using System;
using log4net;

namespace Sandbox.Logging.Log4Net
{
    public class Log4NetLogger : ILogger
    {
        readonly ILog _log;

        public Log4NetLogger(ILog log)
        {
            _log = log;
        }

        public void Log(
            LogLevel logLevel,
            IFormatProvider formatProvider, Func<LogMessageDelegate, string> formatMessage,
            Exception ex)
        {
            var getMessage = LoggerHelper.GetMessageFunc(formatProvider, formatMessage);

            switch (logLevel)
            {
                case LogLevel.Debug:

                    if (_log.IsDebugEnabled)
                        _log.Debug(getMessage(), ex);

                    break;
                case LogLevel.Information:

                    if (_log.IsInfoEnabled)
                        _log.Info(getMessage(), ex);

                    break;
                case LogLevel.Warning:

                    if (_log.IsInfoEnabled)
                        _log.Warn(getMessage(), ex);

                    break;
                case LogLevel.Error:

                    if (_log.IsErrorEnabled)
                        _log.Error(getMessage(), ex);

                    break;
                case LogLevel.Fatal:

                    if (_log.IsFatalEnabled)
                        _log.Fatal(getMessage(), ex);

                    break;
            }
        }
    }
}