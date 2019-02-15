using System;

namespace LogingService.Interfaces
{
    public interface ILogingService
    {
        void WriteLine<T>(string message, MetroLog.LogLevel logLevel = MetroLog.LogLevel.Trace, Exception exception = null);
    }
}
