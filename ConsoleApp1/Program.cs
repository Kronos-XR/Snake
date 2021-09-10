// консольная змейка

// убери стакание кнопок движения
// как добавить тело змейки?
//варианты
//сделать массив двумерный (2 на много)элементов с координатами змейки и каждый шаг его перезаписывать смещать, если сьедается фрукт то делать его больше
//



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

        static void Main(string[] args)
        {
            Console.SetWindowSize(x + 1, y + 2);
            Console.SetBufferSize(x + 1, y + 2);
            Console.CursorVisible = false;
            while (true)
            {

                Draw();
                Input();
                HeadMove();
                if (CheckGameOver())
                {
                    break;
                }
                System.Threading.Thread.Sleep(200);
            }
            Draw();
            EndGameScript();
        }
        static void EndGameScript()
        {
            Console.SetCursorPosition(headX, headY);
            Console.Write("!");
            Console.SetCursorPosition(x / 2, y / 2);
            Console.Write("Game over ");
            Console.ReadKey(true);
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
            Console.SetCursorPosition(headX, headY);
            Console.WriteLine('0');

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
                            {
                                directionOfMovement = "UP";
                            }
                            break;
                        }
                    case 'a':
                        {
                            if (directionOfMovement != "RIGHT")
                            {
                                directionOfMovement = "LEFT";
                            }
                            break;
                        }
                
                    case 's':
                        {
                            if (directionOfMovement != "UP")
                            {
                                directionOfMovement = "DOWN";
                            }
                            break;
                        }

            
                    case 'd':
                        {
                            if (directionOfMovement != "LEFT")
                            {
                                directionOfMovement = "RIGHT";
                            }
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

        static void Body()
        {
            int[,] snakeBody;
            //++++++++++++++++++++++++++++++++++++++++++++++++++
        }
            static bool CheckGameOver()
            {
                if (headX == x || headX == 0 || headY == y || headY == 0)
                {
                    return true;
                }
                return false;
            }
        }
    }

