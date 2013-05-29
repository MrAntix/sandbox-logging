using System;

namespace Sandbox.Logging
{
    public static class LoggerExtensionsWarning
    {
        public static void Warning(
            this ILogger logger,
            IFormatProvider formatProvider, Func<LogMessageDelegate, string> getMessage,
            Exception ex)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Warning, formatProvider, getMessage, ex);
        }

        public static void Warning(
            this ILogger logger,
            IFormatProvider formatProvider, Func<LogMessageDelegate, string> getMessage)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Warning, formatProvider, getMessage, null);
        }

        public static void Warning(
            this ILogger logger,
            Func<LogMessageDelegate, string> getMessage)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Warning, null, getMessage, null);
        }

        public static void Warning(
            this ILogger logger,
            Func<LogMessageDelegate, string> getMessage, Exception ex)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Warning, null, getMessage, ex);
        }
    }
}