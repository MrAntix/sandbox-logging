using System;
using System.Globalization;
using System.Linq;
using Moq;
using Sandbox.Logging.Log4Net;
using Xunit;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Repository.Hierarchy;

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

        [Fact]
        public void handles_curly_brackets_when_no_args_are_passed()
        {
            const string jsonString = "{'Content':'JSON'}";
            object message = null;
            var ilogMock = new Mock<ILog>();
            ilogMock
                .Setup(o => o.IsDebugEnabled)
                .Returns(true);
            ilogMock
                .Setup(o => o.Debug(It.IsAny<object>(), It.IsAny<Exception>()))
                .Callback((object m, Exception ex) => { message = m; });

            var logger = (ILogger) new Log4NetLogger(ilogMock.Object);

            logger.Debug(m => m(jsonString));

            Assert.Equal(jsonString, message);
        }

        [Fact]
        public void with_a_real_log4net_log()
        {
            var appender = new MemoryAppender {Threshold = Level.All};
            appender.ActivateOptions();
            BasicConfigurator.Configure(appender);

            var log = LogManager.GetLogger(GetType());

            var logger = (ILogger)new Log4NetLogger(log);

            logger.Debug(m => m("Hello {0}", "Bob"));

            Assert.Equal("Hello Bob", appender.GetEvents().Single().MessageObject);
        }
    }
}