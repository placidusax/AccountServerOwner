using Contracts;
using log4net;
using System.Reflection;

 namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);// using system reflection to get the fully-qualified name of the class
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInfo(string message) => logger.Info(message);
        public void LogWarn(string message) => logger.Warn(message);
    }
}