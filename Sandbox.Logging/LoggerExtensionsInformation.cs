using System;

namespace Sandbox.Logging
{
    public static class LoggerExtensionsInformation
    {
        public static void Information(
            this ILogger logger,
            IFormatProvider formatProvider, Func<LogMessageDelegate, string> getMessage,
            Exception ex)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Information, formatProvider, getMessage, ex);
        }

        public static void Information(
            this ILogger logger,
            IFormatProvider formatProvider, Func<LogMessageDelegate, string> getMessage)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Information, formatProvider, getMessage, null);
        }

        public static void Information(
            this ILogger logger,
            Func<LogMessageDelegate, string> getMessage)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Information, null, getMessage, null);
        }

        public static void Information(
            this ILogger logger,
            Func<LogMessageDelegate, string> getMessage, Exception ex)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Information, null, getMessage, ex);
        }
    }
}