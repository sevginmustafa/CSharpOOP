using SimpleSnake.GameObjects;
using SimpleSnake.Utilities;
using SimpleSnake.Core;

namespace SimpleSnake
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);

            Snake snake = new Snake(wall, 1, 1);

            Engine engine = new Engine(wall,snake);

            engine.Run();
        }
    }
}
