using System;
using System.Configuration;
using FLovers.Log.Services.Logging.Interfaces;

namespace FLovers.Log.Services.Logging.NLog
{
    public static class LogFactory
    {
        /// <summary>
        /// This static class returns the logger that is configured through the appSettings section of the web.config file
        /// The default logger is NLog
        /// </summary>
        /// <returns>A concrete logger, NLogLogger</returns>
        public static ILogger Logger()
        {
            var defaultLoggerTypeName = "FLovers.Log.Services.Logging.NLog.NLogLogger";
            var loggerTypeName = ConfigurationManager.AppSettings["loggerTypeName"];
            loggerTypeName = loggerTypeName ?? defaultLoggerTypeName;

            Type loggerType = Type.GetType(loggerTypeName);
            ILogger logger = Activator.CreateInstance(loggerType) as ILogger;

            return logger;
        }
    }
}
