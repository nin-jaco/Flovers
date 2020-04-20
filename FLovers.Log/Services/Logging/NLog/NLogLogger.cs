using System;
using NLog;
using ILogger = FLovers.Log.Services.Logging.Interfaces.ILogger;

namespace FLovers.Log.Services.Logging.NLog
{
    public class NLogLogger : ILogger
    {
        private Logger Logger { get; }

        public NLogLogger()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }

        public void Warn(string message)
        {
            Logger.Warn(message);
        }

        public void Debug(string message)
        {
            Logger.Debug(message);
        }

        public void Error(string message)
        {
            try
            {
                Logger.Error(message);
            }
            catch(Exception ex)
            { }
        }

        public void Error(Exception x)
        {
            Error(LogUtility.BuildExceptionMessage(x));
        }

        public void Error(string message, Exception x)
        {
            Logger.Error(x, message);
        }

        public void Fatal(string message)
        {
            Logger.Fatal(message);
        }

        public void Fatal(Exception x)
        {
            Fatal(LogUtility.BuildExceptionMessage(x));
        }
    }
}
