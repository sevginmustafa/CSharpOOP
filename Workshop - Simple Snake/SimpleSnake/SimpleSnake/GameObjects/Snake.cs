using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake : Point
    {
        private const char snakeSymbol = '\u25CF';
        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;
        private int foodIndex = new Random().Next(0, 3);

        public Snake(Wall wall, int leftX, int topY)
            : base(leftX, topY)
        {
            snakeElements = new Queue<Point>();
            this.wall = wall;
            foods = new Food[]
            {
                new FoodAsterisk(wall),
                new FoodDollar(wall),
                new FoodHash(wall)
            };
            CreateSnake();
            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        private void CreateSnake()
        {
            for (int i = 0; i < 6; i++)
            {
                snakeElements.Enqueue(new Point(LeftX + i, TopY));
                Draw(LeftX + i, TopY, snakeSymbol);
            }
        }

        public bool IsMoving(Point direction)
        {
            Point snakeCurrentHead = snakeElements.Last();

            GetNextPoint(direction, snakeCurrentHead);

            if (LeftX == 0 || TopY == 0 ||
               LeftX == wall.LeftX || TopY == wall.TopY)
            {
                return false;
            }

            if (snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY))
            {
                return false;
            }

            Point snakeNewHead = new Point(LeftX, TopY);

            snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                GetNextPoint(direction, snakeNewHead);
                snakeNewHead = new Point(LeftX, TopY);
                snakeElements.Enqueue(snakeNewHead);
                snakeNewHead.Draw(snakeSymbol);

                foodIndex = new Random().Next(0, 3);
                foods[foodIndex].SetRandomPosition(snakeElements);
            }

            Point tail = snakeElements.Dequeue();
            tail.Draw(' ');

            return true;
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            LeftX = direction.LeftX + snakeHead.LeftX;
            TopY = direction.TopY + snakeHead.TopY;
        }
    }
}
