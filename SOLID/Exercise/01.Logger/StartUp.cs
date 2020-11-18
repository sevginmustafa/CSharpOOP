using _01Logger.Appenders;
using _01Logger.Layouts;
using _01Logger.Loggers;

namespace _01Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);

            var file = new LogFile();
            var fileAppender = new FileAppender(simpleLayout, file);

            var logger = new Logger(consoleAppender, fileAppender);


            logger.Error("3/31/2015 5:33:07 PM", "ERROR parsing request");

            System.Console.WriteLine(fileAppender.LogFile.Size);
        }
    }
}
