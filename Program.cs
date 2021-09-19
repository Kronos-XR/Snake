using System;

namespace snake
{
    class Program
    {
        static readonly int x = 80;
        static readonly int y = 26;
        static int headX = x / 2;
        static int headY = y / 2;
        static string directionOfMovement;
        static int score = 0;

        static int fruitX;
        static int fruitY;
        static int lengthBody = 5;
        static int[,] snakeBody = {{ headX, headY }, {0, 0}, {0, 0} };
        static void Main(string[] args)
        {
            Console.SetWindowSize(x + 1, y + 3);
            Console.SetBufferSize(x + 1, y + 3);
            Console.CursorVisible = false;
            Body(snakeBody, lengthBody);

            Fruit();
            while (true)
            {
                Input();
                HeadMove();

                if (headX == fruitX && headY == fruitY)
                {
                    Fruit();
                    score += 100;
                    lengthBody += 1;
                }
                System.Threading.Thread.Sleep(200);
                snakeBody = Body(snakeBody, lengthBody);
                Draw();
                if (CheckGameOver())
                {
                    break;
                }
            }
            Draw();
            EndGameScript();
        }
        static void Draw()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < x + 1; i++)
            {
                Console.Write("#");
            }
            for (int i = 0; i < y - 1; i++)
            {
                Console.WriteLine("#" + "".PadRight(x - 1, ' ') + "#");
            }
            for (int i = 0; i < x + 1; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine("Score " + score);
            Console.SetCursorPosition(fruitX, fruitY);
            Console.Write("@");
            for (int i = 0; i < lengthBody; i++)
            {
                if (snakeBody[i, 0] == 0 && snakeBody[i, 1] == 0)
                    break;
                if (i == 0)
                {
                    Console.SetCursorPosition(snakeBody[0, 0], snakeBody[0, 1]);
                    Console.Write("0");
                }
                else
                {
                    Console.SetCursorPosition(snakeBody[i, 0], snakeBody[i, 1]);
                    Console.Write("O");
                }
            }
        }

        static int[,] Body(int[,] oldBody, int lengthBody = 1)
        {

            int[,] snakeBody = new int[lengthBody, 2];
            snakeBody[0, 0] = headX;
            snakeBody[0, 1] = headY;
            if (snakeBody[0, 0] == oldBody[0, 0] && snakeBody[0, 1] == oldBody[0, 1])
            {
                return snakeBody;
            }
            for (int i = 0; i < snakeBody.GetLength(0) - 1; i++)
            {
                snakeBody[i + 1, 0] = oldBody[i, 0];
                snakeBody[i + 1, 1] = oldBody[i, 1];
            }
            return snakeBody;
        }

        static void Input()
        {
            if (Console.KeyAvailable)
            {
                var checkKey = Console.ReadKey(true);
                switch (checkKey.KeyChar)
                {
                    case 'w':
                        {
                            if (directionOfMovement != "DOWN")
                                directionOfMovement = "UP";
                            break;
                        }
                    case 'a':
                        {
                            if (directionOfMovement != "RIGHT")
                                directionOfMovement = "LEFT";
                            break;
                        }
                    case 's':
                        {
                            if (directionOfMovement != "UP")
                                directionOfMovement = "DOWN";
                            break;
                        }
                    case 'd':
                        {
                            if (directionOfMovement != "LEFT")
                                directionOfMovement = "RIGHT";
                            break;
                        }
                }
            }
        }

        static void HeadMove()
        {
            switch (directionOfMovement)
            {
                case "UP":
                    headY -= 1;
                    break;
                case "LEFT":
                    headX -= 1;
                    break;
                case "DOWN":
                    headY += +1;
                    break;
                case "RIGHT":
                    headX += 1;
                    break;
            }
        }
        static bool CheckGameOver()
        {
            if (headX == x || headX == 0 || headY == y || headY == 0)
            {
                return true;
            }
            for (int i = 1; i < lengthBody; i++)
            {
                if (headX == snakeBody[i, 0] && headY == snakeBody[i, 1])
                {
                    return true;
                }
            }
            return false;
        }
        static void EndGameScript()
        {
            Console.SetCursorPosition(headX, headY);
            Console.Write("!");
            Console.SetCursorPosition(x / 2, y / 2);
            Console.Write("Game over ");
            Console.SetCursorPosition(x / 2, y / 2 + 1);
            Console.Write("Score " + score);
            Console.ReadKey(true);
        }
        static void Fruit()
        {
            Random rnd = new Random();
            fruitX = rnd.Next(1, x);
            fruitY = rnd.Next(1, y);
        }
    }
}

