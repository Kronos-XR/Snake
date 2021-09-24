using System;

namespace snake
{
    class Program
    {
        static readonly int screenWidth = 80;
        static readonly int screenHeight = 26;
        static int headX = screenWidth / 2;
        static int headY = screenHeight / 2;

        static int lengthBody = 5;
        static void Main(string[] args)
        {
            int score = 0;
            int speed = 50;
            int fruitX = 0;
            int fruitY = 0;
            string directionOfMovement = null;
            int[,] snakeBody = { { headX, headY }, { 0, 0 }, { 0, 0 } };
            Console.SetWindowSize(screenWidth + 1, screenHeight + 3);
            Console.SetBufferSize(screenWidth + 1, screenHeight + 3);
            Console.CursorVisible = false;
            Body(snakeBody, lengthBody);
            Fruit(ref fruitX, ref fruitY);
            while (true)
            {
                Input(ref directionOfMovement);
                HeadMove(ref directionOfMovement);

                if (headX == fruitX && headY == fruitY)
                {
                    Fruit(ref fruitX, ref fruitY);
                    score += 100;
                    lengthBody += 1;
                }
                System.Threading.Thread.Sleep(speed);
                snakeBody = Body(snakeBody, lengthBody);
                Draw(ref snakeBody, fruitX, fruitY, score);
                if (CheckGameOver(ref snakeBody))
                {
                    break;
                }
            }
            Draw(ref snakeBody, fruitX, fruitY, score);
            EndGameScript(score);
        }
        static void Draw(ref int[,] snakeBody, int fruitX,int fruitY, int score)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < screenWidth + 1; i++)
            {
                Console.Write("#");
            }
            for (int i = 0; i < screenHeight - 1; i++)
            {
                Console.WriteLine("#" + "".PadRight(screenWidth - 1, ' ') + "#");
            }
            for (int i = 0; i < screenWidth + 1; i++)
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

        static void Input(ref string directionOfMovement)
        {
            if (Console.KeyAvailable)
            {
                var checkKey = Console.ReadKey(true);
                switch (checkKey.KeyChar)
                {
                    case 'ц':
                    case 'w':
                        {
                            if (directionOfMovement != "DOWN")
                                directionOfMovement = "UP";
                            break;
                        }
                    case 'ф':
                    case 'a':
                        {
                            if (directionOfMovement != "RIGHT")
                                directionOfMovement = "LEFT";
                            break;
                        }
                    case 'ы':
                    case 's':
                        {
                            if (directionOfMovement != "UP")
                                directionOfMovement = "DOWN";
                            break;
                        }
                    case 'в':
                    case 'd':
                        {
                            if (directionOfMovement != "LEFT")
                                directionOfMovement = "RIGHT";
                            break;
                        }
                }
            }
        }

        static void HeadMove(ref string directionOfMovement)
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
        static bool CheckGameOver(ref int[,]snakeBody)
        {
            if (headX == screenWidth || headX == 0 || headY == screenHeight || headY == 0)
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
        static void EndGameScript(int score)
        {
            Console.SetCursorPosition(headX, headY);
            Console.Write("!");
            Console.SetCursorPosition(screenWidth / 2, screenHeight / 2);
            Console.Write("Game over ");
            Console.SetCursorPosition(screenWidth / 2, screenHeight / 2 + 1);
            Console.Write("Score " + score);
            Console.ReadKey(true);
        }
        static void Fruit(ref int fruitX, ref int fruitY)
        {
            Random rnd = new Random();
            fruitX = rnd.Next(1, screenWidth);
            fruitY = rnd.Next(1, screenHeight);
        }
    }
}

