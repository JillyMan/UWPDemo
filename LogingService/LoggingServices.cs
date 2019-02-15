using System;
using MetroLog;
using MetroLog.Targets;

namespace LogingService
{
    public class LoggingServices : Interfaces.ILogingService
    {
        public static LoggingServices Instance { get; }
        public static int RetainDays { get; } = 3;
        public static bool Enabled { get; set; } = true;

        static LoggingServices()
        {
            Instance = Instance ?? new LoggingServices();

#if DEBUG
            LogManagerFactory.DefaultConfiguration.AddTarget(LogLevel.Trace, LogLevel.Fatal, new StreamingFileTarget { RetainDays = LoggingServices.RetainDays });
#else
            LogManagerFactory.DefaultConfiguration.AddTarget(LogLevel.Info, LogLevel.Fatal, new StreamingFileTarget { RetainDays = LoggingServices.RetainDays });
#endif
        }

        public void WriteLine<T>(string message, LogLevel logLevel = LogLevel.Trace, Exception exception = null)
        {
            if(Enabled)
            {
                var logger = LogManagerFactory.DefaultLogManager.GetLogger<T>();

                if(logLevel == LogLevel.Trace && logger.IsTraceEnabled)
                {
                    logger.Trace(message);
                }
                else if (logLevel == LogLevel.Debug && logger.IsDebugEnabled)
                {
                    logger.Debug(message);
                }
                else if (logLevel == LogLevel.Error && logger.IsErrorEnabled)
                {
                    logger.Error(message);
                }
                else if (logLevel == LogLevel.Fatal && logger.IsFatalEnabled)
                {
                    logger.Fatal(message);
                }
                else if (logLevel == LogLevel.Info && logger.IsInfoEnabled)
                {
                    logger.Info(message);
                }
                else if (logLevel == LogLevel.Warn && logger.IsWarnEnabled)
                {
                    logger.Warn(message);
                }
            }
        }
    }
}
