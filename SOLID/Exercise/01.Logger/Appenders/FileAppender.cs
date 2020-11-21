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
        public int Count { get ; set ; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                Count++;
                LogFile.Write(string.Format(Layout.Format, dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return  $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {Count}, File Size: {LogFile.Size}";
        }
    }
}
