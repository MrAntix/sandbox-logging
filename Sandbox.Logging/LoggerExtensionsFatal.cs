using System;

namespace Sandbox.Logging
{
    public static class LoggerExtensionsFatal
    {
        public static void Fatal(
            this ILogger logger,
            IFormatProvider formatProvider, Func<LogMessageDelegate, string> getMessage,
            Exception ex)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Fatal, formatProvider, getMessage, ex);
        }

        public static void Fatal(
            this ILogger logger,
            IFormatProvider formatProvider, Func<LogMessageDelegate, string> getMessage)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Fatal, formatProvider, getMessage, null);
        }

        public static void Fatal(
            this ILogger logger,
            Func<LogMessageDelegate, string> getMessage)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Fatal, null, getMessage, null);
        }

        public static void Fatal(
            this ILogger logger,
            Func<LogMessageDelegate, string> getMessage, Exception ex)
        {
            if (logger == null) return;

            logger.Log(LogLevel.Fatal, null, getMessage, ex);
        }
    }
}