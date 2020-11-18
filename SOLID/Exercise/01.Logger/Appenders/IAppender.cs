using _01Logger.Enums;
using _01Logger.Layouts;

namespace _01Logger.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
