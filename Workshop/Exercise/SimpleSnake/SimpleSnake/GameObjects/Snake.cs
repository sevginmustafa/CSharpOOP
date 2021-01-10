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
            this.wall = wall;
            snakeElements = new Queue<Point>();
            foods = new Food[]
            {
               new FoodAsterisk(this.wall),
               new FoodDollar(this.wall),
               new FoodHash(this.wall)
            };
            CreateSnake();
            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        private void CreateSnake()
        {
            for (int i = 0; i < 6; i++)
            {
                Point point = new Point(LeftX + i, TopY);
                point.Draw(snakeSymbol);
                snakeElements.Enqueue(point);
            }
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);

            if (LeftX == 0 || TopY == 0 ||
                LeftX == wall.LeftX || TopY == wall.TopY)
            {
                return false;
            }

            if (snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY))
            {
                return false;
            }

            Point newHead = new Point(LeftX, TopY);
            newHead.Draw(snakeSymbol);
            snakeElements.Enqueue(newHead);

            if (foods[foodIndex].IsFoodPoint(newHead))
            {
                GetNextPoint(direction, newHead);
                newHead = new Point(LeftX, TopY);
                newHead.Draw(snakeSymbol);
                snakeElements.Enqueue(newHead);

                foodIndex = new Random().Next(0, 3);
                foods[foodIndex].SetRandomPosition(snakeElements);
            }

            Point tail = snakeElements.Dequeue();
            tail.Draw(' ');

            return true;
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            LeftX = snakeHead.LeftX + direction.LeftX;
            TopY = snakeHead.TopY + direction.TopY;
        }
    }
}
