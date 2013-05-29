using System;
using System.Globalization;
using Moq;
using Sandbox.Logging.Log4Net;
using Xunit;
using log4net;

namespace Sandbox.Logging.Tests
{
    public class log4netlogger_tests
    {
        [Fact]
        public void calls_underlying_ilog_with_formatted_debug_message()
        {
            object message = null;
            var ilogMock = new Mock<ILog>();
            ilogMock
                .Setup(o => o.IsDebugEnabled)
                .Returns(true);
            ilogMock
                .Setup(o => o.Debug(It.IsAny<object>(), It.IsAny<Exception>()))
                .Callback((object m, Exception ex) => { message = m; });

            var logger = (ILogger) new Log4NetLogger(ilogMock.Object);

            logger.Debug(m => m("Hello {0}", "Bob"));

            Assert.Equal("Hello Bob", message);
        }

        [Fact]
        public void uses_passed_format_provider()
        {
            object message = null;
            var ilogMock = new Mock<ILog>();
            ilogMock
                .Setup(o => o.IsDebugEnabled)
                .Returns(true);
            ilogMock
                .Setup(o => o.Debug(It.IsAny<object>(), It.IsAny<Exception>()))
                .Callback((object m, Exception ex) => { message = m; });

            var logger = (ILogger) new Log4NetLogger(ilogMock.Object);

            var formatProvider = new CultureInfo("FR-fr");
            logger.Debug(formatProvider, m => m("Money {0:C}", 1.02M));

            Assert.Equal("Money 1,02 €", message);
        }
    }
}