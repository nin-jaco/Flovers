using System;
using FLovers.Log.Services.Logging.NLog;

namespace FLovers.Log.Services.Logging
{
    public static class ErrorHandler
    {
        /// <summary>
        /// Global Error Logger extension with NLog
        /// </summary>
        /// <param name="exception"></param>
        public static void LogException(Exception exception)
        {
            LogFactory.Logger().Error(exception);
        }

        public static void LogMessage(string message)
        {
            LogFactory.Logger().Info(message);
        }
    }
}
