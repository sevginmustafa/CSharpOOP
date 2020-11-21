using _01Logger.Appenders;
using _01Logger.Core;
using _01Logger.Layouts;
using _01Logger.Loggers;

namespace _01Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();

            IEngine engine = new Engine(commandInterpreter);

            engine.Run();
        }
    }
}
