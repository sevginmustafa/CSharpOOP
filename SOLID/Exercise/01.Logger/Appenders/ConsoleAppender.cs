using _01Logger.Enums;
using _01Logger.Layouts;

namespace _01Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                System.Console.WriteLine(Layout.Format, dateTime, reportLevel, message);
            }
        }
    }
}
