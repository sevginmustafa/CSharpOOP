using _01Logger.Enums;
using _01Logger.Layouts;
using _01Logger.Loggers;

namespace _01Logger.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile logFile)
        {
            Layout = layout;
            LogFile = logFile;
        }

        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }
        public ILogFile LogFile { get; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                LogFile.Write(string.Format(Layout.Format, dateTime, reportLevel, message));
            }
        }
    }
}
