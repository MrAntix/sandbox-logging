using System;

namespace Sandbox.Logging
{
    public static class LoggerExtensionsDebug
    {
        public static void Debug(
            this ILogger logger,
            IFormatProvider formatProvider, Func<LogMessageDelegate, string> getMessage,
            Exception ex)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Debug, formatProvider, getMessage, ex);
        }

        public static void Debug(
            this ILogger logger,
            IFormatProvider formatProvider, Func<LogMessageDelegate, string> getMessage)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Debug, formatProvider, getMessage, null);
        }

        public static void Debug(
            this ILogger logger,
            Func<LogMessageDelegate, string> getMessage)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Debug, null, getMessage, null);
        }

        public static void Debug(
            this ILogger logger,
            Func<LogMessageDelegate, string> getMessage, Exception ex)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Debug, null, getMessage, ex);
        }
    }
}