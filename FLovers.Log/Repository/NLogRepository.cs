using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FLovers.Log.Models;
using FLovers.Log.Repository.Entities;
using FLovers.Log.Repository.Interfaces;

namespace FLovers.Log.Repository
{
    /// <summary>
    /// This class extracts information that NLog stores so that we can report on it
    /// </summary>
    public class NLogRepository : ILogReportingRepository
    {
        private FLoversErrorEntities Context { get; } = null;

        /// <summary>
        /// Default Constructor uses the default Entity Container
        /// </summary>
        public NLogRepository()
        {
            Context = new FLoversErrorEntities();
        }

        /// <summary>
        /// Overloaded constructor that can take an EntityContainer as a parameter so that it can be mocked out by our tests
        /// </summary>
        /// <param name="context">The Entity context</param>
        public NLogRepository(FLoversErrorEntities context)
        {
            Context = context;
        }

        /// <summary>
        /// Gets a filtered list of log events
        /// </summary>
        /// <param name="pageIndex">0 based page index</param>
        /// <param name="pageSize">max number of records to return</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="logLevel">The level of the log messages</param>
        /// <returns>A filtered list of log events</returns>
        public IQueryable<LogEvent> GetByDateRangeAndType(DateTime start, DateTime end, string logLevel)
        {
            IQueryable<LogEvent> list = (from b in Context.NLog_Error
                                         where b.time_stamp >= start && b.time_stamp <= end
                                                                     && (b.level == logLevel || logLevel == "All")
                                         select new LogEvent
                                         {
                                             IdType = "number",
                                             Id = "",
                                             IdAsInteger = b.Id,
                                             IdAsGuid = Guid.NewGuid(),
                                             LoggerProviderName = "NLog",
                                             LogDate = b.time_stamp,
                                             MachineName = b.host,
                                             Message = b.message,
                                             Type = b.type,
                                             Level = b.level,
                                             Source = b.source,
                                             StackTrace = b.stacktrace
                                         });

            return list;
        }

        /// <summary>
        /// Returns a single Log event
        /// </summary>
        /// <param name="id">Id of the log event as a string</param>
        /// <returns>A single Log event</returns>
        public LogEvent GetById(string id)
        {
            int logEventId = Convert.ToInt32(id);

            LogEvent logEvent = (from b in Context.NLog_Error
                                 where b.Id == logEventId
                                 select new LogEvent
                                 {
                                     IdType = "number",
                                     IdAsInteger = b.Id,
                                     LoggerProviderName = "NLog",
                                     LogDate = b.time_stamp,
                                     MachineName = b.host,
                                     Message = b.message,
                                     Type = b.type,
                                     Level = b.level,
                                     Source = b.source,
                                     StackTrace = b.stacktrace,
                                     AllXml = b.allxml
                                 })
                .SingleOrDefault();

            return logEvent;

        }

        /// <summary>
        /// Clears log messages between a date range and for specified log levels
        /// </summary>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="logLevels">string array of log levels</param>
        public void ClearLog(DateTime start, DateTime end, string[] logLevels)
        {
            string logLevelList = "";
            foreach (string logLevel in logLevels)
            {
                logLevelList += ",'" + logLevel + "'";
            }
            if (logLevelList.Length > 0)
            {
                logLevelList = logLevelList.Substring(1);
            }

            string commandText = "delete from NLog_Error WHERE time_stamp >= @p0 and time_stamp <= @p1 and level in (@p2)";

            SqlParameter paramStartDate = new SqlParameter { ParameterName = "p0", Value = start.ToUniversalTime(), DbType = System.Data.DbType.DateTime };
            SqlParameter paramEndDate = new SqlParameter { ParameterName = "p1", Value = end.ToUniversalTime(), DbType = System.Data.DbType.DateTime };
            SqlParameter paramLogLevelList = new SqlParameter { ParameterName = "p2", Value = logLevelList };

            Context.Database.ExecuteSqlCommand(commandText, paramStartDate, paramEndDate, paramLogLevelList);
        }

        public IQueryable<LogEvent> GetByDateRangeAndTypePaged(int pageIndex, int pageSize, DateTime start, DateTime end, string logLevel)
        {
            throw new NotImplementedException();
        }
    }
}
