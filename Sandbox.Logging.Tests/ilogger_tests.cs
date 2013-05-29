using System;
using Moq;
using Xunit;

namespace Sandbox.Logging.Tests
{
    public class ilogger_tests
    {
        [Fact]
        public void log_a_debug_message()
        {
            var loggerMock = new Mock<ILogger>();

            loggerMock
                .Setup(o => o.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<IFormatProvider>(),
                    It.IsAny<Func<LogMessageDelegate, string>>(),
                    It.IsAny<Exception>()))
                .Verifiable();

            loggerMock.Object.Debug(m => m("Hello {0}", "Bob"));

            loggerMock.Verify();
        }

        [Fact]
        public void no_error_calling_null_log()
        {
            Assert.DoesNotThrow(
                () => default(ILogger).Debug(m => m("Hello {0}", "Bob")));
        }
    }
}