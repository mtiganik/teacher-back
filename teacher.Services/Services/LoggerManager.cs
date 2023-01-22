using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teacher.Services.Interfaces;

namespace teacher.Services.Services
{
    public class LoggerManager : ILoggerManager
    {
        private static ILoggerManager logger = (ILoggerManager)LogManager.GetCurrentClassLogger();
        public LoggerManager() { }

        public void LogDebug(string message)
        {
            logger.LogDebug(message);
        }

        public void LogError(string message)
        {
            logger.LogError(message);
        }

        public void LogInfo(string message)
        {
            logger.LogInfo(message);
        }

        public void LogWarning(string message)
        {
            logger.LogWarning(message);
        }
    }
}
