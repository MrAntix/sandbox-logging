using System;

namespace Sandbox.Logging
{
    public static class LoggerExtensionsError
    {
        public static void Error(
            this ILogger logger,
            IFormatProvider formatProvider, Func<LogMessageDelegate, string> getMessage,
            Exception ex)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Error, formatProvider, getMessage, ex);
        }

        public static void Error(
            this ILogger logger,
            IFormatProvider formatProvider, Func<LogMessageDelegate, string> getMessage)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Error, formatProvider, getMessage, null);
        }

        public static void Error(
            this ILogger logger,
            Func<LogMessageDelegate, string> getMessage)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Error, null, getMessage, null);
        }

        public static void Error(
            this ILogger logger,
            Func<LogMessageDelegate, string> getMessage, Exception ex)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Error, null, getMessage, ex);
        }
    }
}