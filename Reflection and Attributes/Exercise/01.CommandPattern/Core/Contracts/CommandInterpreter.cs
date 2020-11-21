using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] splitted = args.Split();

            string commandType = splitted[0];
            string[] commandArguments = splitted.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandType + "Command");

            ICommand command = (ICommand)Activator.CreateInstance(type);

            return command.Execute(commandArguments);
        }
    }
}
