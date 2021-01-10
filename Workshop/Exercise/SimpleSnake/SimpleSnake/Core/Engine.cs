using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Direction direction;
        private Snake snake;
        private int sleepTime = 100;
        private Point[] directionPoints;

        public Engine(Snake snake)
        {
            direction = new Direction();
            this.snake = snake;
            directionPoints = new Point[]
            {
                new Point(1,0),
                new Point(-1,0),
                new Point(0,1),
                new Point(0,-1)
            };
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(directionPoints[(int)direction]);

                if (!isMoving)
                {
                    Environment.Exit(0);
                }

                Thread.Sleep(sleepTime);
            }
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
        }
    }
}
