using SimpleSnake.Core;
using SimpleSnake.GameObjects;
using System.Collections.Generic;
using SimpleSnake.Utilities;

namespace SimpleSnake
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Wall wall = new Wall(60, 20);

            Snake snake = new Snake(wall,1,1);
            Engine engine = new Engine(snake);
            engine.Run();
        }
    }
}
