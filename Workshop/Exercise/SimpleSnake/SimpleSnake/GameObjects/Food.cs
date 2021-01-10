using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int foodPoints)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            FoodPoints = foodPoints;
            this.foodSymbol = foodSymbol;
            random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snake.Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isPointOfSnake)
            {
                LeftX = random.Next(1, wall.LeftX - 1);
                TopY = random.Next(1, wall.TopY - 1);

                isPointOfSnake = snake.Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return TopY == snake.TopY && LeftX == snake.LeftX;
        }
    }
}
