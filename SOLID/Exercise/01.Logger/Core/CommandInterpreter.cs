using _01Logger.Appenders;
using _01Logger.Enums;
using _01Logger.Layouts;
using _01Logger.Loggers;
using System;
using System.Collections.Generic;

namespace _01Logger.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public void Read(int n)
        {
            List<IAppender> appenders = new List<IAppender>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();

                string appenderType = info[0];
                string layoutType = info[1];

                ILayout layout = null;

                if (layoutType == "SimpleLayout")
                {
                    layout = new SimpleLayout();
                }
                else if (layoutType == "XmlLayout")
                {
                    layout = new XmlLayout();
                }

                IAppender appender = null;

                if (appenderType == "ConsoleAppender")
                {
                    appender = new ConsoleAppender(layout);
                }
                else if (appenderType == "FileAppender")
                {
                    ILogFile logFile = new LogFile();

                    appender = new FileAppender(layout, logFile);
                }

                appender.ReportLevel = ReportLevel.INFO;

                if (info.Length > 2)
                {
                    string reportLevel = info[2].ToUpper();

                    appender.ReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);
                }

                appenders.Add(appender);
            }

            string input2 = string.Empty;

            List<string> messages = new List<string>();

            while ((input2 = Console.ReadLine()) != "END")
            {
                messages.Add(input2);
            }

            foreach (var appender in appenders)
            {
                foreach (var message in messages)
                {
                    string[] info = message.Split('|');

                    string reportLevel = info[0].ToUpper();
                    string dateTime = info[1];
                    string messageData = info[2];

                    ILogger logger = new Logger(appender);

                    if (reportLevel == "INFO")
                    {
                        logger.Info(dateTime, messageData);
                    }
                    else if (reportLevel == "WARNING")
                    {
                        logger.Warning(dateTime, messageData);
                    }
                    else if (reportLevel == "ERROR")
                    {
                        logger.Error(dateTime, messageData);
                    }
                    else if (reportLevel == "CRITICAL")
                    {
                        logger.Critical(dateTime, messageData);
                    }
                    else if (reportLevel == "FATAL")
                    {
                        logger.Fatal(dateTime, messageData);
                    }
                }
            }

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
