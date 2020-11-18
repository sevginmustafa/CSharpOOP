using _01Logger.Appenders;
using _01Logger.Enums;
using System;

namespace _01Logger.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }

        public IAppender[] Appenders
        {
            get
            {
                return appenders;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(appenders), "value cannot be null");
                }

                appenders = value;
            }
        }

        public void Info(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Warning, message);
        }

        public void Error(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Error, message);
        }

        public void Critical(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Critical, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Fatal, message);
        }

        private void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }
    }
}
